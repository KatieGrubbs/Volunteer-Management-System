using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_SemesterAssignment_VMS.Models
{
    public class Opportunity
    {
        [Display(Name = "Opportunity ID")]
        public int OpportunityId { get; set; }

        [Display(Name = "Opportunity Name")]
        public string Name { get; set; }

        [Display(Name = "Opportunity Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        // Navigation properties
        public virtual Center Center { get; set; }
        // Foreign key
        public int CenterId { get; set; }
    }
}