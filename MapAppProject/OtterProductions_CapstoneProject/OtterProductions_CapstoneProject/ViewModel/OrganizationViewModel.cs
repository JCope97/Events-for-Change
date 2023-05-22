using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OtterProductions_CapstoneProject.ViewModel
{
    public class OrganizationViewModel
    {

        
        public int Id { get; set; }

        [StringLength(50)]
        public string? AspnetIdentityId { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? OrganizationName { get; set; }

        [StringLength(50)]
        public string? OrganizationDescription { get; set; }

        [StringLength(50)]
        public string? OrganizationLocation { get; set; }

        public string? Address { get; set; }
        public string ImageUrl { get; set; }

        public string? PhoneNumber { get; set; }

        public string OrganizationPicture { get; set; }
        public string? OldEmail { get; set; }

    }
}
