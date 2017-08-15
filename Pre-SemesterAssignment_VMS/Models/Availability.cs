using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_SemesterAssignment_VMS.Models
{
    public class Availability
    {
        public int AvailabilityId { get; set; }

        [Display(Name = "Day of Week")]
        public string DayOfWeek { get; set; }

        // Navigation properties
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}