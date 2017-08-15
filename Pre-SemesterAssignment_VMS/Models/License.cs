using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_SemesterAssignment_VMS.Models
{
    public class License
    {
        public License()
        {
            this.Volunteers = new HashSet<Volunteer>();
        }

        [Display(Name = "License ID")]
        public int LicenseId { get; set; }

        [Display(Name = "License Name")]
        public string Name { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        // Navigation properties
        public virtual ICollection<Volunteer> Volunteers { get; set; }
    }
}