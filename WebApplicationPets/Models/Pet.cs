using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using static System.Net.WebRequestMethods;

namespace WebApplicationPets.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Age must be 0 or greater")]
        public int Age { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "Weight must be greater than 0")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Photo URL is required")]
        [RegularExpression(@"https?:.*\.(jpg|jpeg|png|gif)", ErrorMessage = "Invalid Photo URL")]
                              
        public string PhotoUrl { get; set; }

       
        public int CategoryId { get; set; }

        
        public virtual Category ReferencedCategory { get; set; }
    }
}
