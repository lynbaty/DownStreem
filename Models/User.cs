using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace downstreem.Models
{
    public class User : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }
    }
}
