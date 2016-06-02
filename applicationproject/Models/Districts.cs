using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace applicationproject.Models
{
    public class DistrictsContext : DbContext
    {

        public DistrictsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<States> States { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Districts> Districts { get; set; }
    }
    public class Districts
    {
        [Key]
        public int districtId { get; set; }
        [Display(Name = "Distric")]
        public string name { get; set; }
        [Display(Name = "Configuration")]
        public string config { get; set; }
        [Display(Name = "Updated")]
        public DateTime updated { get; set; }
        [Display(Name = "State")]
        public int stateId { get; set; }

    }
}