using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pre_SemesterAssignment_VMS.Models;

namespace Pre_SemesterAssignment_VMS.ViewModels
{
    public class VolunteerViewModel
    {
        public Volunteer Volunteer { get; set; }
        public IEnumerable<Education> EducationLevels { get; set; }
    }
}