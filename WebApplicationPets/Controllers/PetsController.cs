using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationPets.Context;
using WebApplicationPets.Models;

namespace WebApplicationPets.Controllers
{
    public class PetsController : Controller
    {
        private readonly EFContext _context;

        public PetsController(EFContext context)
        {
            _context = context;
        }

        // GET: Pets
        public async Task<IActionResult> Index()
        {
            var eFContext = _context.Pets.Include(p => p.ReferencedCategory);
            return View(await eFContext.ToListAsync());
        }

        // GET: Pets/Details/5
        public IActionResult Details(int id)
        {
            var pet = _context.Pets
                .Include(p => p.ReferencedCategory) 
                .FirstOrDefault(m => m.Id == id);

            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Age,Weight,PhotoUrl,CategoryId")] Pet pet)
        {
            
            ModelState.Remove("ReferencedCategory");

            if (ModelState.IsValid)
            {
                
                pet.ReferencedCategory = await _context.Categories.FindAsync(pet.CategoryId);

                
                _context.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", pet.CategoryId);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

           
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", pet.CategoryId);
            return View(pet);
        }

        // POST: Pets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Age,Weight,PhotoUrl,CategoryId")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            
            ModelState.Remove("ReferencedCategory");

            if (ModelState.IsValid)
            {
                try
                {
                    
                    pet.ReferencedCategory = await _context.Categories.FindAsync(pet.CategoryId);

                   
                    _context.Update(pet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

           
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", pet.CategoryId);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = await _context.Pets
                .Include(p => p.ReferencedCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}
