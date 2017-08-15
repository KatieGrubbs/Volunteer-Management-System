using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_SemesterAssignment_VMS.Models
{
    public class Education
    {
        public int EducationId { get; set; }

        [Display(Name = "Education Level")]
        public string EducationLevel { get; set; }

        // Navigation properties
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}