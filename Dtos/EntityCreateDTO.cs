using System.ComponentModel.DataAnnotations;

namespace downstreem.Dtos
{
    public class EntityCreateDTO
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Entity Name")]
        public string Name { get; set; }

        
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [Display(Name = "Company")]
        public string Company { get; set; }

        [Required]
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Social Media")]
        [StringLength (200)]
        public string SocialMedia { get; set; }

        [Required]
        [Display(Name = "Occurrences")]
        public int Occurrences { get; set; }
    }
}
