using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtterProductions_CapstoneProject.Models;

[Table("MapAppUser")]
public partial class MapAppUser
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [InverseProperty("MapAppUser")]
    public virtual ICollection<UserEventList> UserEventLists { get; } = new List<UserEventList>();
}
