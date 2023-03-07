using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtterProductions_CapstoneProject.Areas.Identity.Data
{
    public class IdentityOrganization
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string OrganizationName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string OrganizationDescription { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string OrganizationLocation { get; set; }
    }
}
