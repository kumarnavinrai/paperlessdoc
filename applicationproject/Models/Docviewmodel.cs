using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace applicationproject.Models
{
    public class Docviewmodel
    {
        
        public int documentId { get; set; }
        [Display(Name = "Document")]
        public string name { get; set; }
        [Display(Name = "Configuration")]
        public string config { get; set; }
        [Display(Name = "Comments")]
        public string comments { get; set; }
        [Display(Name = "File")]
        public HttpPostedFileBase file { get; set; }
        [Display(Name = "Country")]
        public int countryId { get; set; }
        [Display(Name = "States")]
        public int stateId { get; set; }
        [Display(Name = "Districts")]
        public int districtId { get; set; }
        [Display(Name = "Departments")]
        public int departmentId { get; set; }
        [Display(Name = "Category")]
        public int categoryId { get; set; }
        [Display(Name = "Subcategory")]
        public int subcategoryId { get; set; }
        [Display(Name = "Language")]
        public int languageId { get; set; }
        [Display(Name = "Page Content")]
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string pageContent { get; set; }
        
        
    }
}