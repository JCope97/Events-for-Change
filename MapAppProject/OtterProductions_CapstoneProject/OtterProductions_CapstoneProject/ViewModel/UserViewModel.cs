using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OtterProductions_CapstoneProject.ViewModel
{
    public class UserViewModel
    {


        public int Id { get; set; }

        [StringLength(50)]
        public string? AspnetIdentityId { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(50)]
        public string? Username { get; set; }

        public string? PhoneNumber { get; set; }
        public string? OldEmail { get; set; }

    }
}