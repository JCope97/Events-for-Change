using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtterProductions_CapstoneProject.Models;

[Table("Organzation")]
public partial class Organzation
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OrganzationLoginID")]
    public int OrganzationLoginId { get; set; }

    [StringLength(255)]
    public string OrganzationDescription { get; set; } = null!;

    [StringLength(255)]
    public string OrganzationLocation { get; set; } = null!;

    public byte[]? OrganzationPicture { get; set; }

    [InverseProperty("Organzation")]
    public virtual ICollection<Event> Events { get; } = new List<Event>();
}
