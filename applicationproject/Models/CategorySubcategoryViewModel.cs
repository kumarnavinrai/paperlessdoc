using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace applicationproject.Models
{
    public class CategorySubcategoryViewModel
    {
        public Subcategories Subcategories { get; set; }
        public Categories Categories { get; set; }
    }
}