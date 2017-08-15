using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_SemesterAssignment_VMS.Models
{
    public class Center
    {
        public Center()
        {
            this.Address = new Address();
            this.Volunteers = new HashSet<Volunteer>();
        }

        [Display(Name = "Center ID")]
        public int CenterId { get; set; }

        [Display(Name = "Center Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public Address Address { get; set; }

        [Display(Name = "Primary Contact")]
        public Contact PrimaryContact { get; set; }

        // Navigation properties
        public virtual ICollection<Volunteer> Volunteers { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}