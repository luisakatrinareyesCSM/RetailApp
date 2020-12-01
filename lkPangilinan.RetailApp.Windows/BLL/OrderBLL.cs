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
    public class OrderBLL
    {
        private static RetailDBContext db = new RetailDBContext();
        public static Paged<Models.Order> Search(int pageIndex = 1, int pageSize = 1, string sortBy = "BillingAddress", string sortOrder = "asc", string keyword = "")
        {
            IQueryable<Order> allOrders = (IQueryable<Order>)db.Orders;
            Paged<Models.Order> orders = new Paged<Order>();

            if (!string.IsNullOrEmpty(keyword))
            {
                allOrders = allOrders.Where(e => e.Customer_EmailAddress.Contains(keyword));
            }

            var queryCount = allOrders.Count();
            var skip = pageSize * (pageIndex - 1);

            long pageCount = (long)Math.Ceiling((decimal)((queryCount) / pageSize));
            if ((queryCount % pageSize) > 0)
            { pageCount += 1; }

            if (sortBy.ToLower() == "date" && sortOrder.ToLower() == "asc")
            {
                orders.Items = allOrders.OrderBy(e => e.DateTime).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "date" && sortOrder.ToLower() == "desc")
            {
                orders.Items = allOrders.OrderByDescending(e => e.DateTime).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "billing address" && sortOrder.ToLower() == "asc")
            {
                orders.Items = allOrders.OrderBy(e => e.BillingAddress).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                orders.Items = allOrders.OrderByDescending(e => e.BillingAddress).Skip(skip).Take(pageSize).ToList();
            }

            orders.PageCount = pageCount;
            orders.PageIndex = pageIndex;
            orders.PageSize = pageSize;
            orders.QueryCount = queryCount;

            return orders;
        }

        public static Operation Add(Order order)
        {
            try
            {

                db.Orders.Add(order);
                db.SaveChanges();

                return new Operation()
                {
                    Code = "200",
                    Message = "Ok",
                    ReferenceId = order.Id
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
