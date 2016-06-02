using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace applicationproject.Models
{
    public class StateViewModel
    {

        public States States { get; set; }
        public Country Country { get; set; }
    }
}