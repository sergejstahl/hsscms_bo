using System;
using System.Configuration;
using System.Windows;
using ui;

namespace hsscms_bo
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var app = new Application();
            app.Run(new ui.MainWindow());

            //// import data from json
            //StarterImportJson starterImportJson = new StarterImportJson();
            //starterImportJson.ImportFileJson(ConfigurationManager.AppSettings["pathImportJsonPredpr"]);
        }
    }
}



/*
Delete from[CatalogOrganisations].[dbo].[ContactTypes];
Delete from[CatalogOrganisations].[dbo].[Cities];
Delete from[CatalogOrganisations].[dbo].[Organisations];
Delete from[CatalogOrganisations].[dbo].[Adresses];
Delete from[CatalogOrganisations].[dbo].[Contacts];
Delete from[CatalogOrganisations].[dbo].[Goods];

DBCC CHECKIDENT("[CatalogOrganisations].[dbo].[Goods]", RESEED, 0);
DBCC CHECKIDENT("[CatalogOrganisations].[dbo].[Contacts]", RESEED, 0);
DBCC CHECKIDENT("[CatalogOrganisations].[dbo].[ContactTypes]", RESEED, 0);
DBCC CHECKIDENT("[CatalogOrganisations].[dbo].[Cities]", RESEED, 0);
DBCC CHECKIDENT("[CatalogOrganisations].[dbo].[Organisations]", RESEED, 0);
DBCC CHECKIDENT("[CatalogOrganisations].[dbo].[Adresses]", RESEED, 0);


SELECT TOP(1000) *
 FROM[CatalogOrganisations].[dbo].[Contacts];

SELECT TOP(1000) *
 FROM[CatalogOrganisations].[dbo].[Adresses];

 SELECT TOP(1000) *
 FROM[CatalogOrganisations].[dbo].[Goods];

SELECT TOP(1000) *
 FROM[CatalogOrganisations].[dbo].[ContactTypes];

SELECT TOP(1000) *
 FROM[CatalogOrganisations].[dbo].[Cities];

SELECT TOP(1000) *
 FROM[CatalogOrganisations].[dbo].[Organisations];
 */
