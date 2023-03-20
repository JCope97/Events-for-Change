using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtterProductions_CapstoneProject.Models;

[Table("Organization")]
public partial class Organization
{
    [Key]
    [Column("ID")]
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

    public int? OrganizationLoginId { get; set; }

    public string OrganizationPicture { get; set; }
   

    [InverseProperty("OrganizationNavigation")]
    public virtual ICollection<Event> Events { get; } = new List<Event>();

}
