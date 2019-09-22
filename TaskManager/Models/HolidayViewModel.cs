using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class HolidayViewModel
    {
        public IEnumerable<DateTime> Dates { get; set; }
    }
}