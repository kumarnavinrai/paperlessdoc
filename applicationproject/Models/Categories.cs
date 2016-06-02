using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace applicationproject.Models
{
   
    public class CategoriesContext : DbContext
    {
        public CategoriesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Categories> Categories { get; set; }
    }

    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int categoryId { get; set; }
        [Display(Name = "Category")]
        public string name { get; set; }
        [Display(Name = "Configuration")]
        public string config { get; set; }
       
    }
}