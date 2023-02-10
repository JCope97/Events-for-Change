using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtterProductions_CapstoneProject.Models;

public partial class Event
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OrganzationID")]
    public int OrganzationId { get; set; }

    [StringLength(255)]
    public string EventName { get; set; } = null!;

    [StringLength(255)]
    public string EventLocation { get; set; } = null!;

    [Column("EventTypesID")]
    public int EventTypesId { get; set; }

    [StringLength(255)]
    public string EventDiscreption { get; set; } = null!;

    [ForeignKey("OrganzationId")]
    [InverseProperty("Events")]
    public virtual Organzation Organzation { get; set; } = null!;
}
