using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace applicationproject.Models
{

    public class StatesContext : DbContext
    {
        
        public StatesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<States> States { get; set; }
        public DbSet<Country> Country { get; set; }
    }

    [Table("States")]
    public class States
    {
        [Key]
        public int stateId { get; set; }
        [Display(Name = "State")]
        public string name { get; set; }
        [Display(Name = "Configuration")]
        public string config { get; set; }
        [Display(Name = "Updated")]
        public DateTime updated { get; set; }
        [Display(Name = "Country")] 
        public int countryId { get; set; }
    }

  
      
}