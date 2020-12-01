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
    public class OrderProductBLL
    {
        private static RetailDBContext db = new RetailDBContext();
        public static Paged<Models.OrderProduct> Search(int pageIndex = 1, int pageSize = 1, string sortBy = "product name", string sortOrderProduct = "asc", string keyword = "")
        {
            IQueryable<OrderProduct> allorderProducts = (IQueryable<OrderProduct>)db.OrderProducts;
            Paged<Models.OrderProduct> orderProducts = new Paged<OrderProduct>();

            if (!string.IsNullOrEmpty(keyword))
            {
                allorderProducts = allorderProducts.Where(e => e.ProductName.Contains(keyword));
            }

            var queryCount = allorderProducts.Count();
            var skip = pageSize * (pageIndex - 1);

            long pageCount = (long)Math.Ceiling((decimal)((queryCount) / pageSize));
            if ((queryCount % pageSize) > 0)
            { pageCount += 1; }

            if (sortBy.ToLower() == "product name" && sortOrderProduct.ToLower() == "asc")
            {
                orderProducts.Items = allorderProducts.OrderBy(e => e.ProductName).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "product name" && sortOrderProduct.ToLower() == "desc")
            {
                orderProducts.Items = allorderProducts.OrderByDescending(e => e.ProductName).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "customer name" && sortOrderProduct.ToLower() == "asc")
            {
                orderProducts.Items = allorderProducts.OrderBy(e => e.CustomerName).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                orderProducts.Items = allorderProducts.OrderByDescending(e => e.CustomerName).Skip(skip).Take(pageSize).ToList();
            }

            orderProducts.PageCount = pageCount;
            orderProducts.PageIndex = pageIndex;
            orderProducts.PageSize = pageSize;
            orderProducts.QueryCount = queryCount;

            return orderProducts;
        }
        public static Operation Add(OrderProduct orderProduct)
        {
            try
            {

                db.OrderProducts.Add(orderProduct);
                db.SaveChanges();

                return new Operation()
                {
                    Code = "200",
                    Message = "Ok",
                    ReferenceId = orderProduct.Id
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
