using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_SemesterAssignment_VMS.Models
{
    public class Interest
    {
        public Interest()
        {
            this.Volunteers = new HashSet<Volunteer>();
        }

        [Display(Name = "Interest ID")]
        public int InterestId { get; set; }

        [Display(Name = "Interest Name")]
        public string Name { get; set; }

        // Navigation properties
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}