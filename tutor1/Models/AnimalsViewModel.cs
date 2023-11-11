using System.ComponentModel.DataAnnotations;

namespace tutor1.Models
{
    public class AnimalsViewModel
    {
        [Required]
        [Display(Name = "Animal Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Animal Color")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Color { get; set; }

        [Display(Name = "Years Alive")]
        [Range(0, int.MaxValue, ErrorMessage = "Value Cannot be Less than 0")]
        public int Age { get; set; }
        public bool Extinct { get; set; }
        public List<AnimalModel> Animals { get; set; }  = new List<AnimalModel>();

    }
}
