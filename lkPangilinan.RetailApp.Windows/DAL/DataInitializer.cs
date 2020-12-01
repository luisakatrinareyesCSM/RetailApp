using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lkPangilinan.RetailApp.Windows.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseAlways<RetailDBContext>
    {
        protected override void Seed(RetailDBContext context)
        {
            context.Customers.Add(new Models.Customer()
            {
                Id = Guid.Parse("68d0a749-70a8-41a0-aa91-9601701433ea"),
                CustomerName = "Angel Reinne Fernandez",
                Customer_ContactNumber = "09090941751",
                Customer_EmailAddress = "angelreinnefernandez@gmail.com",
                BillingAddress = "#141 Ligaya Street Pagalanggang Dinalupihan Bataan",
                Default_ShippingAddress = "#141 Ligaya Street Pagalanggang Dinalupihan Bataan"
            });

            context.Customers.Add(new Models.Customer()
            {
                Id = Guid.Parse("81bc9fed-7cfa-4272-bba1-9570b9f2bc24"),
                CustomerName = "Jane Dizon",
                Customer_ContactNumber = "09327693052",
                Customer_EmailAddress = "janedizon@gmail.com",
                BillingAddress = "#120 Purok 4 Lahar Vilage San Simon Dinalupihan Bataan",
                Default_ShippingAddress = "#120 Purok 4 Lahar Vilage San Simon Dinalupihan Bataan"
            });

            context.Customers.Add(new Models.Customer()
            {
                Id = Guid.Parse("fcab4d9e-f225-4015-99d9-572e646bf70a"),
                CustomerName = "Jessiree Bagang",
                Customer_ContactNumber = "09171628902",
                Customer_EmailAddress = "jessireebagang@gmail.com",
                BillingAddress = "#24 Purok 1 San Simon Dinalupihan Bataan",
                Default_ShippingAddress = "#24 Purok 1 San Simon Dinalupihan Bataan"
            });

            context.Customers.Add(new Models.Customer()
            {
                Id = Guid.Parse("2b6238c3-3ebe-4ecd-a71b-445004c574da"),
                CustomerName = "Bernalyn Fernandez",
                Customer_ContactNumber = "09078396267",
                Customer_EmailAddress = "bernanlynfernandez@gmail.com",
                BillingAddress = "#141 Ligaya Street Pagalanggang Dinalupihan Bataan",
                Default_ShippingAddress = "#141 Ligaya Street Pagalanggang Dinalupihan Bataan"
            });

            context.Customers.Add(new Models.Customer()
            {
                Id = Guid.Parse("a45a94ee-b00d-4482-b70a-9c43683e6efd"),
                CustomerName = "Nenita Corong",
                Customer_ContactNumber = "09063848677",
                Customer_EmailAddress = "nenitacorong@gmail.com",
                BillingAddress = "73 Purok 2 San Simon Dinalupihan Bataan",
                Default_ShippingAddress = "#123 Purok 2 San Simon Dinalupihan Bataan"
            });

            context.SaveChanges();
        }
    }

}
