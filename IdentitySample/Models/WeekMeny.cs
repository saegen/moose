using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentitySample.Models
{
    public class Day
    {
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool Closed { get; set; }

        public string Food { get; set;}
    }


    public class WeekMeny
    {
        private string _closed = "Stängt";

        [Required]
        [Display(Name = "Vecka")]
        public int Week { get; set; }
        
        public IEnumerable<Day> WeekDay { get; set; }

        [Display(Name = "Stängt hela Veckan?")]
        public bool CloseWeek { get; set; }
    }
}