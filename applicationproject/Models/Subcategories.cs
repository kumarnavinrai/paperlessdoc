using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace applicationproject.Models
{
 
    public class SubcategoriesContext : DbContext
    {
        public SubcategoriesContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Subcategories> Subcategories { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }

    [Table("Subcategories")]
    public class Subcategories
    {
        [Key]
        public int subcategoryId { get; set; }
        [Display(Name = "Subcategory")]
        public string name { get; set; }
        [Display(Name = "Configuration")]
        public string config { get; set; }
        [Display(Name = "Category")]
        public int categoryId { get; set; }

    }
}