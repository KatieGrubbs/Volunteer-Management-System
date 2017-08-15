using Pre_SemesterAssignment_VMS.Models;

namespace Pre_SemesterAssignment_VMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pre_SemesterAssignment_VMS.Models.VMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pre_SemesterAssignment_VMS.Models.VMSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Populate the Education table
            context.Educations.AddOrUpdate(x => x.EducationId,
                new Education() { EducationId = 1, EducationLevel = "High school graduate" },
                new Education() { EducationId = 2, EducationLevel = "Some college" },
                new Education() { EducationId = 3, EducationLevel = "Associate's degree" },
                new Education() { EducationId = 4, EducationLevel = "Bachelor's degree" },
                new Education() { EducationId = 5, EducationLevel = "Master's degree" },
                new Education() { EducationId = 6, EducationLevel = "Doctorate or professional degree" }
            );
        }
    }
}
