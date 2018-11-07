namespace hsscms_bo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<hsscms_bo.Entities.CatalogOrganisationsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "hsscms_bo.Entities.CatalogOrganisationsContext";
        }

        protected override void Seed(hsscms_bo.Entities.CatalogOrganisationsContext context) { }
    }
}
