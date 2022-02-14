using System.ComponentModel.DataAnnotations;

namespace downstreem.Dtos
{
    public class EntityEditDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Entity Name")]
        public string Name { get; set; }

        [Display(Name = "Update Image")]
        public IFormFile? UpdateImage { get; set; }

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
        [StringLength(200)]
        public string SocialMedia { get; set; }

        [Required]
        [Display(Name = "Occurrences")]
        public int Occurrences { get; set; }

        [Required]
        [Display(Name = "DateFirst")]
        public string DateFirst { get; set; }

        public string? Image { get; set; }
    }
}
