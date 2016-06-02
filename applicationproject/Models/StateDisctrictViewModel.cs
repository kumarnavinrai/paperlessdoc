using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace applicationproject.Models
{
    public class StateDisctrictViewModel
    {
        public States States { get; set; }
        public Districts Districts { get; set; }
    }
}