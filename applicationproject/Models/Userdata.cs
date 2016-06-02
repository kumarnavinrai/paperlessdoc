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
    public class UserdataContext : DbContext
    {
        public UserdataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Userdata> Userdata { get; set; }
    }

    [Table("Userdata")]
    public class Userdata
    {
        [Key]
        public int userdataId { get; set; }
        [Display(Name = "User")]
        public int userId { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "Country")]
        public string country { get; set; }
        [Display(Name = "Pin")]
        public string pinorzip { get; set; }
        [Display(Name = "Phone")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        
    }
}