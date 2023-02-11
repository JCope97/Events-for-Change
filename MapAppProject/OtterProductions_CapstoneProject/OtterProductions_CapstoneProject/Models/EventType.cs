using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtterProductions_CapstoneProject.Models;

[Table("EventType")]
public partial class EventType
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("EventType")]
    [StringLength(255)]
    public string? EventType1 { get; set; }

    [InverseProperty("Organzation")]
    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
