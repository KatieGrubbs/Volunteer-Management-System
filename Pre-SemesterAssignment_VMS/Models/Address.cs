using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pre_SemesterAssignment_VMS.Models
{
    [ComplexType]
    public class Address
    {
        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        [MaxLength(2)]
        public string State { get; set; }

        [Display(Name = "ZIP")]
        public string ZipCode { get; set; }
    }
}