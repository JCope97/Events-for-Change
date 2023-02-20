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
        public int Id { get; set; }

        //public string AspnetIdentityId { get; set; }  
        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        [InverseProperty("MapAppUser")]
        public virtual ICollection<UserEventList> UserEventLists { get; } = new List<UserEventList>();
    }
}