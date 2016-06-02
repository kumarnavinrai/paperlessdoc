using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace applicationproject.Models
{
   
        public class DepartmentsContext : DbContext
        {

            public DepartmentsContext()
                : base("DefaultConnection")
            {
            }

            public DbSet<Departments> Departments { get; set; }
            public DbSet<Districts> Districts { get; set; }
        }
        public class Departments
        {
            [Key]
            public int departmentId { get; set; }
            [Display(Name = "Department")]
            public string name { get; set; }
            [Display(Name = "Configuration")]
            public string config { get; set; }
            [Display(Name = "Updated")]
            public DateTime updated { get; set; }
            [Display(Name = "District")]
            public int districtId { get; set; }

        }
   
}