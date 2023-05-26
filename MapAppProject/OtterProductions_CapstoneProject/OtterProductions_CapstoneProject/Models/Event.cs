using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtterProductions_CapstoneProject.Models;

[Table("Event")]
[Index("OrganizationId", Name = "IX_Event_OrganizationID")]
public partial class Event
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OrganizationID")]
    public int OrganizationId { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "Event Name")]


    [StringLength(50)]
    public string EventName { get; set; } = null!;

    [DataType(DataType.Text)]
    [Display(Name = "Event Location")]


    [StringLength(50)]
    public string EventLocation { get; set; } = null!;

    [Column("EventTypeID")]
    public int EventTypeId { get; set; }


    [DataType(DataType.Text)]
    [Display(Name = "Event Description")]


    [StringLength(50)]
    public string EventDescription { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime EventDate { get; set; }

    [ForeignKey("OrganizationId")]
    [InverseProperty("Events")]
    public virtual EventType Organization { get; set; } = null!;

    [ForeignKey("OrganizationId")]
    [InverseProperty("Events")]
    public virtual Organization OrganizationNavigation { get; set; } = null!;

    [InverseProperty("Event")]
    public virtual ICollection<UserEventList> UserEventLists { get; } = new List<UserEventList>();
}
