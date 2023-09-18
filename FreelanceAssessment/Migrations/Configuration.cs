namespace FreelanceAssessment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FreelanceAssessment.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FreelanceAssessment.Data.FreelanceAssessmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FreelanceAssessment.Data.FreelanceAssessmentContext context)
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
            context.Freelances.AddOrUpdate(x => x.Id,
            new Freelance() { Id = 1, username = "ob1kenotbi", email = "ob1kenotbi@email.com", phone = "0123456789", skillsets = "coding", hobby = "skating"}
            );
        }
    }
}
