using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


//Model with MapAppUser info
namespace OtterProductions_CapstoneProject.Models
{

    [Table("MapAppUser")]
    public partial class MapAppUser
    {
        [Key]
        [Column("ID")]
        [Required]
        public int Id { get; set; }

        
        [StringLength(50)]
        public string AspnetIdentityId { get; set; }

        
        [StringLength(50)]
        public string FirstName { get; set; }

        
        [StringLength(50)]
        public string LastName { get; set; }

        [InverseProperty("MapAppUser")]
        public virtual ICollection<UserEventList> UserEventLists { get; } = new List<UserEventList>();
    }
}