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

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name {0} must be between {2} and {1} character(s) in length.")]
    public string OrganizationName { get; set; } = null!;

    [StringLength(50, MinimumLength = 2, ErrorMessage = "Description {0} must be between {2} and {1} character(s) in length.")]
    public string OrganizationDescription { get; set; } = null!;

    [StringLength(50, MinimumLength = 2, ErrorMessage = "Location {0} must be between {2} and {1} character(s) in length.")]
    public string OrganizationLocation { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public int? OrganizationLoginId { get; set; }

    [InverseProperty("OrganizationNavigation")]
    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
