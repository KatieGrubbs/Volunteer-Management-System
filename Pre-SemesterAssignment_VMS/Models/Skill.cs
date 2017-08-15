using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_SemesterAssignment_VMS.Models
{
    public class Skill
    {
        public Skill()
        {
            this.Volunteers = new HashSet<Volunteer>();
        }

        [Display(Name = "Skill ID")]
        public int SkillId { get; set; }

        [Display(Name = "Skill Name")]
        public string Name { get; set; }

        // Navigation properties
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}