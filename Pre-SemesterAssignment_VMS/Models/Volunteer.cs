using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pre_SemesterAssignment_VMS.Models
{
    public class Volunteer
    {
        public Volunteer()
        {
            this.Address = new Address();
            this.CurrentLicenses = new HashSet<License>();
            this.Skills = new HashSet<Skill>();
            this.Interests = new HashSet<Interest>();
            this.PreferredCenters = new HashSet<Center>();
        }

        [Display(Name = "Volunteer ID")]
        public int VolunteerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(35)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(35)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Address")]
        public Address Address { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Emergency Contact")]
        public Contact EmergencyContact { get; set; }

        [Display(Name = "Driver's License on File")]
        public bool DriversLicenseOnFile { get; set; }

        [Display(Name = "Social Security Card on File")]
        public bool SSCardOnFile { get; set; }

        // Navigation properties
        public virtual Education Education { get; set; }
        // Foreign key
        public int EducationId { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
        public virtual ICollection<License> CurrentLicenses { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<Center> PreferredCenters { get; set; }
    }
}