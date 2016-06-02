using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace applicationproject.Models
{
    public class DocsandrelContext : DbContext
    {
        public DocsandrelContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Docs> Documents { get; set; }
        public DbSet<Documentrels> Documentrels { get; set; }
    }
    public class Docsandrel
    {
        public Docs Docs { get; set; }
        public Documentrels Documentrels { get; set; }
        public Languages Languages { get; set; }
        public Categories Categories { get; set; }
        public Subcategories Subcategories { get; set; }
        public Country Country { get; set; }
        public States States { get; set; }
        public Districts Districts { get; set; }
        public Departments Departments { get; set; }
    }
}