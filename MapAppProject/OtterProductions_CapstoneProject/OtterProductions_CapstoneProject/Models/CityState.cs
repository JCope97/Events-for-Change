using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace OtterProductions_CapstoneProject.Models
{
    public class CityState
    {
        //[Required]
        //public string address { get; set; }

        [Required]
        public string city { get; set; }

        [Required]
        public string state { get; set; }
        //[Required]
        //public string zip { get; set; }
    }
}
