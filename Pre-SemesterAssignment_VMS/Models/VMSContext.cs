using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Pre_SemesterAssignment_VMS.Models
{
    public class VMSContext : DbContext
    {
        public VMSContext() : base("VMSDatabase") { }

        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<Center> Centers { get; set; }
        public virtual DbSet<Opportunity> Opportunities { get; set; }
        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }

        // use singular table names
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Volunteer>()
                .HasMany<Availability>(v => v.Availabilities)
                .WithMany(a => a.Volunteers)
                .Map(va =>
                {
                    va.MapLeftKey("VolunteerId");
                    va.MapRightKey("AvailabilityId");
                    va.ToTable("VolunteerAvailability");
                });

            modelBuilder.Entity<Volunteer>()
                .HasMany<License>(v => v.CurrentLicenses)
                .WithMany(l => l.Volunteers)
                .Map(vl =>
                {
                    vl.MapLeftKey("VolunteerId");
                    vl.MapRightKey("LicenseId");
                    vl.ToTable("VolunteerLicense");
                });

            modelBuilder.Entity<Volunteer>()
                .HasMany<Skill>(v => v.Skills)
                .WithMany(s => s.Volunteers)
                .Map(vs =>
                {
                    vs.MapLeftKey("VolunteerId");
                    vs.MapRightKey("SkillId");
                    vs.ToTable("VolunteerSkill");
                });

            modelBuilder.Entity<Volunteer>()
                .HasMany<Interest>(v => v.Interests)
                .WithMany(i => i.Volunteers)
                .Map(vi =>
                {
                    vi.MapLeftKey("VolunteerId");
                    vi.MapRightKey("InterestId");
                    vi.ToTable("VolunteerInterest");
                });

            modelBuilder.Entity<Volunteer>()
                .HasMany<Center>(v => v.PreferredCenters)
                .WithMany(c => c.Volunteers)
                .Map(vc =>
                {
                    vc.MapLeftKey("VolunteerId");
                    vc.MapRightKey("CenterId");
                    vc.ToTable("VolunteerCenter");
                });

            modelBuilder.ComplexType<Address>();
            modelBuilder.ComplexType<Contact>();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}