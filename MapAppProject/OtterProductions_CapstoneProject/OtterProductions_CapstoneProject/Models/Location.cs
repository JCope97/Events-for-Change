using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace OtterProductions_CapstoneProject.Models
{
    public class Location
    {
        [Required]
        public string location { get; set; }

    }
}
