using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtterProductions_CapstoneProject.Models;

[Table("UserEventList")]
[Index("EventId", Name = "IX_UserEventList_EventID")]
[Index("MapAppUserId", Name = "IX_UserEventList_MapAppUserID")]
public partial class UserEventList
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("MapAppUserID")]
    public int MapAppUserId { get; set; }

    [Column("EventID")]
    public int EventId { get; set; }

    [ForeignKey("EventId")]
    [InverseProperty("UserEventLists")]
    public virtual Event Event { get; set; } = null!;

    [ForeignKey("MapAppUserId")]
    [InverseProperty("UserEventLists")]
    public virtual MapAppUser MapAppUser { get; set; } = null!;
}
