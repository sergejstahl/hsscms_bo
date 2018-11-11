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

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Adress> Adreses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Good> Goods { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}