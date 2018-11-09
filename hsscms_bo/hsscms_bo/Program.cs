using Newtonsoft.Json;
using System;
using System.Configuration;

namespace hsscms_bo
{
    class Program
    {
        static void Main(string[] args)
        {

            // import data from json
            StarterImportJson starterImportJson = new StarterImportJson();
            starterImportJson.ImportFileJson(ConfigurationManager.AppSettings["pathImportJsonPredpr"]);

            Console.Read();
        }
    }
}



//*Delete from [CatalogOrganisations].[dbo].[Cities];

//DBCC CHECKIDENT ("[CatalogOrganisations].[dbo].[Cities]", RESEED, 0);*/

//Delete from[CatalogOrganisations].[dbo].[Organisations];
//DBCC CHECKIDENT("[CatalogOrganisations].[dbo].[Organisations]", RESEED, 0);


//SELECT TOP(1000) [id]
//      ,[name]
//FROM[CatalogOrganisations].[dbo].[Cities];