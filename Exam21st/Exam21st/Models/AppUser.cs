using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exam21st.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        [NotMapped]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        [NotMapped]

        public override bool PhoneNumberConfirmed { get => base.PhoneNumberConfirmed; set => base.PhoneNumberConfirmed = value; }
    }
}
