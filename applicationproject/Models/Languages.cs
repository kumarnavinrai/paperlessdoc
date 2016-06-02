using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace applicationproject.Models
{
   
    public class LanguagesContext : DbContext
    {
        public LanguagesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Languages> Languages { get; set; }
    }

    [Table("Languages")]
    public class Languages
    {
        [Key]
        public int languageId { get; set; }
        [Display(Name = "Language")]
        public string name { get; set; }
        [Display(Name = "Configuration")]
        public string config { get; set; }
      
    }
}