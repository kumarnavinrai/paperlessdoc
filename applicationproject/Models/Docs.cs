using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace applicationproject.Models
{
 

    public class DocsContext : DbContext
    {
        public DocsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Docs> Documents { get; set; }
        public DbSet<Documentrels> Documentrels { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Districts> Districts { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Subcategories> Subcategories { get; set; }
        public DbSet<Languages> Languages { get; set; }
       
    }

    
    [Table("Documents")]
    public class Docs
    {

        [Key]
        public int documentId { get; set; }
        [Display(Name = "Document")]
        public string name { get; set; }
        [Display(Name = "Configuration")]
        public string config { get; set; }
        [Display(Name = "Comments")]
        public string comments { get; set; }
        [Display(Name = "Filename")]
        public string filepath { get; set; }
        

    }
}