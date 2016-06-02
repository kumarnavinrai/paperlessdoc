using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace applicationproject.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Country> Country { get; set; }
    }

    [Table("Country")]
    public class Country
    {
        [Key]
        public int countryId { get; set; }
        [Display(Name = "Country")]
        public string name { get; set; }
        [Display(Name = "Configuration")]
        public string config { get; set; }
        [Display(Name = "Updated")]
        public DateTime updated { get; set; }
    }
    
}