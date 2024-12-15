using System.ComponentModel.DataAnnotations;

namespace WebApplicationPets.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public List<Pet> Pets { get; set; }
        public Category()
        {
            Pets = new List<Pet>();
        }
    }

}
