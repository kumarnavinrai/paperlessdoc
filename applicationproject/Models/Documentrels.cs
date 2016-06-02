using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace applicationproject.Models
{
    public class DocumentrelsContext : DbContext
    {
        public DocumentrelsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Documentrels> Documentrels { get; set; }
    }

    [Table("Documentrels")]
    public class Documentrels
    {
        [Key]
        public int documentrelId { get; set; }
        [Display(Name = "Document")]
        public int documentId { get; set; }
        [Display(Name = "Country")]
        public int countryId { get; set; }
        [Display(Name = "State")]
        public int stateId { get; set; }
        [Display(Name = "District")]
        public int districtId { get; set; }
        [Display(Name = "Department")]
        public int departmentId { get; set; }
        [Display(Name = "User")]
        public int userId { get; set; }
        [Display(Name = "Subcategory")]
        public int subcategoryId { get; set; }
        [Display(Name = "Language")]
        public int languageId { get; set; }
        [Display(Name = "File")]
        public int fileId { get; set; }
        [Display(Name = "Filename")]
        public string filename { get; set; }
        [Display(Name = "Category")]
        public int categoryId { get; set; }
       
    }
}