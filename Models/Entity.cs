using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace downstreem.Models
{
    public class Entity : BaseEntity
    {

        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        public string? Image { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string JobTitle { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Company { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string Notes { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string SocialMedia { get; set; }

        public int Occurrences { get; set; }

        public string? DateFirst { get; set; }

        public string? DateLast { get; set; }
    }
}
