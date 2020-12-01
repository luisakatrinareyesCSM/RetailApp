using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lkPangilinan.RetailApp.Windows.DAL;
using lkPangilinan.RetailApp.Windows.Helpers;
using lkPangilinan.RetailApp.Windows.Models;


namespace lkPangilinan.RetailApp.Windows.BLL
{
    public class CustomerBLL
    {
        private static RetailDBContext db = new RetailDBContext();
        public static Paged<Models.Customer> Search(int pageIndex = 1, int pageSize = 1,string sortBy ="customername",string sortOrder = "asc",string keyword = "" )
        {
            IQueryable<Customer> allCustomers = (IQueryable<Customer>)db.Customers;
            Paged<Models.Customer> customers = new Paged<Customer>();

            if(!string.IsNullOrEmpty(keyword))
            {
                allCustomers = allCustomers.Where(e => e.CustomerName.Contains(keyword)); 
            }

            var queryCount = allCustomers.Count();
            var skip = pageSize * (pageIndex - 1);

            long pageCount = (long)Math.Ceiling((decimal)((queryCount) / pageSize));
            if ((queryCount % pageSize) > 0)
            { pageCount += 1; }

            if (sortBy.ToLower() == "customer name" && sortOrder.ToLower() == "asc"     )
            {
                customers.Items = allCustomers.OrderBy(e => e.CustomerName).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "customer name" && sortOrder.ToLower() == "desc")
            {
                customers.Items = allCustomers.OrderByDescending(e => e.CustomerName).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "email" && sortOrder.ToLower() == "asc")
            {
                customers.Items = allCustomers.OrderBy(e => e.Customer_EmailAddress).Skip(skip).Take(pageSize).ToList();
            }
            else  
            {
                customers.Items = allCustomers.OrderByDescending(e => e.Customer_EmailAddress).Skip(skip).Take(pageSize).ToList();
            }

            customers.PageCount = pageCount;
            customers.PageIndex = pageIndex;
            customers.PageSize = pageSize;
            customers.QueryCount = queryCount;

            return customers;
        }
        public static Operation Add(Customer customer)
        {
            try
            {
                
                db.Customers.Add(customer);
                db.SaveChanges();

                return new Operation()
                {
                    Code = "200",
                    Message = "Ok",
                    ReferenceId = customer.Id
                };
            }
            catch (Exception e)
            {
                return new Operation()
                {
                    Code = "500",
                    Message = e.Message
                };
            }
        }
        public static Operation Update(Customer newRecord)
        {
            try
            {
                Customer oldRecord = db.Customers.FirstOrDefault(e => e.Id == newRecord.Id);

                if (oldRecord != null)
                {
                    oldRecord.BillingAddress = newRecord.BillingAddress;
                    oldRecord.Customer_EmailAddress = newRecord.Customer_EmailAddress;
                    oldRecord.CustomerName = newRecord.CustomerName;
                    oldRecord.Default_ShippingAddress = newRecord.Default_ShippingAddress;
                    oldRecord.Customer_ContactNumber = newRecord.Customer_ContactNumber;


                    db.SaveChanges();

                    return new Operation()
                    {
                        Code = "200",
                        Message = "OK"
                    };
                }


                return new Operation()
                {
                    Code = "500",
                    Message = "Not found"
                };
            }
            catch (Exception e)
            {
                return new Operation()
                {
                    Code = "500",
                    Message = e.Message
                };
            }
        }
    }
}
