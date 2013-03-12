using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asset_Management.Models;
using System.Data.Entity;

namespace Asset_Management.DAL
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var providers = new List<Provider>
            {
                new Provider {ProviderName = "FPT", Adress = "Quan 1, HCMC", Manager = "Nguyen Van A", Phone = "090123456"},
                new Provider {ProviderName = "Vietel", Adress = "Quan 3, HCMC", Manager = "Nguyen Van B", Phone = "090123457"},
                new Provider {ProviderName = "VNPT", Adress = "Quan 5, HCMC", Manager = "Nguyen Van C", Phone = "090123458"},
                new Provider {ProviderName = "Oracle", Adress = "Quan 7, HCMC", Manager = "Nguyen Van D", Phone = "090123459"},
                new Provider {ProviderName = "IBM", Adress = "Quan 8, HCMC", Manager = "Nguyen Van E", Phone = "090123450"}
            };
            providers.ForEach(s => context.Providers.Add(s));
            context.SaveChanges();

            var products = new List<Product> 
            { 
                new Product {ProductName = "PC core i3", DateBuyed = DateTime.Parse("03-03-2013"), DateExpireMaintance = DateTime.Parse("03-03-2014"), 
                AcceptBy = "Phan Minh Tai", InputBy = "Thuyvnb", OfficeID = "0001", PriceUnit = "12trieu", Status = "Warranty",SerialNumber = 120320139999},
                new Product {ProductName = "PC core i5", DateBuyed = DateTime.Parse("04-04-2013"), DateExpireMaintance = DateTime.Parse("04-04-2014"), 
                AcceptBy = "Phan Minh Tai", InputBy = "Thuyvnb", OfficeID = "0002", PriceUnit = "14trieu", Status = "Warranty",SerialNumber = 120320139998},
                new Product {ProductName = "PC core i7", DateBuyed = DateTime.Parse("04-04-2013"), DateExpireMaintance = DateTime.Parse("04-04-2014"), 
                AcceptBy = "Phan Minh Tai", InputBy = "Thuyvnb", OfficeID = "0003", PriceUnit = "16trieu", Status = "Warranty",SerialNumber = 120320139997},
                new Product {ProductName = "Lap", DateBuyed = DateTime.Parse("04-04-2013"), DateExpireMaintance = DateTime.Parse("04-04-2014"), 
                AcceptBy = "Phan Minh Tai", InputBy = "Thuyvnb", OfficeID = "0004", PriceUnit = "20trieu", Status = "out of Warranty",SerialNumber = 120320139996}
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();

            var contracts = new List<Contract>
            {
                new Contract {DateSigned = DateTime.Parse("02-03-2013"), PriceContract = "150tr", SignedBy = "Tran Thanh Dat", Title = "Hop dong mua tranh thiet bi 2013", ContractNumber = "HD12032013", InputDate = DateTime.Parse("02-03-2013") },
                new Contract {DateSigned = DateTime.Parse("12-03-2013"), PriceContract = "150tr", SignedBy = "Tran Thanh Dat", Title = "Hop dong mua tranh thiet bi 2013", ContractNumber = "HD13042011", InputDate = DateTime.Parse("02-03-2013") },
                new Contract {DateSigned = DateTime.Parse("12-03-2013"), PriceContract = "150tr", SignedBy = "Tran Thanh Dat", Title = "Hop dong mua tranh thiet bi 2013", ContractNumber = "HD14052012", InputDate = DateTime.Parse("02-03-2013") }
            };
            contracts.ForEach(s => context.Contracts.Add(s));
            context.SaveChanges();
        }

    }
}