using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pre_SemesterAssignment_VMS.Models
{
    [ComplexType]
    public class Contact
    {
        public Contact()
        {
            this.Address = new Address();
        }

        [Display(Name = "Name")]
        [StringLength(70)]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public Address Address { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string EmailAddress { get; set; }
    }
}