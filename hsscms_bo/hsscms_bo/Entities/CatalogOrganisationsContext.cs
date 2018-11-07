namespace hsscms_bo.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CatalogOrganisationsContext : DbContext
    {
        public CatalogOrganisationsContext()
            : base("name=CatalogOrganisationsContext")
        {
        }

        //public DbSet<Organisation> Organisations { get; set; }
        public DbSet<City> Cities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}