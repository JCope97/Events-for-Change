using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtterProductions_CapstoneProject.Models;

[Table("Organzation")]
public class Organization
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string? AspnetIdentityId { get; set; }

    [InverseProperty("OrganizationNavigation")]
    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
