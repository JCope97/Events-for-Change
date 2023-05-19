using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace OtterProductions_CapstoneProject.Models;

[Table("MapAppUser")]
public partial class MapAppUser
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string AspnetIdentityId { get; set; }

    [StringLength(50)]
    [RegularExpression("[a-zA-Z]{2,}$", ErrorMessage = "First name must be a minimum of 2 letter characters")]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [RegularExpression("[a-zA-Z]{2,}$", ErrorMessage = "Last name must be a minimum of 2 letter characters")]
    public string? LastName { get; set; }
    

    [StringLength(50)]
    [RegularExpression("[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,}$", ErrorMessage = "Email must be in a valid format: example@email.com")]
    public string? Email { get; set; }

    [StringLength(10)]
    [RegularExpression("[0-9]{10}$", ErrorMessage = "Must be 10 integers between 0-9")]
    public string? PhoneNumber { get; set; }

    [InverseProperty("MapAppUser")]
    public virtual ICollection<UserEventList> UserEventLists { get; } = new List<UserEventList>();
}
