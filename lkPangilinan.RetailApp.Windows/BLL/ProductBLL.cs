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
    public class ProductBLL
    {
        private static RetailDBContext db = new RetailDBContext();
        public static Paged<Models.Product> Search(int pageIndex = 1, int pageSize = 1, string sortBy = "BillingAddress", string sortproducts = "asc", string keyword = "")
        {
            IQueryable<Product> allproducts = (IQueryable<Product>)db.Products;
            Paged<Models.Product> products = new Paged<Product>();

            if (!string.IsNullOrEmpty(keyword))
            {
                allproducts = allproducts.Where(e => e.ProductName.Contains(keyword));
            }

            var queryCount = allproducts.Count();
            var skip = pageSize * (pageIndex - 1);

            long pageCount = (long)Math.Ceiling((decimal)((queryCount) / pageSize));
            if ((queryCount % pageSize) > 0)
            { pageCount += 1; }

            if (sortBy.ToLower() == "" && sortproducts.ToLower() == "asc")
            {
                products.Items = allproducts.OrderBy(e => e.ProductName).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "date" && sortproducts.ToLower() == "desc")
            {
                products.Items = allproducts.OrderByDescending(e => e.ProductName).Skip(skip).Take(pageSize).ToList();
            }


            else if (sortBy.ToLower() == "billing address" && sortproducts.ToLower() == "asc")
            {
                products.Items = allproducts.OrderBy(e => e.ProductQuantity).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                products.Items = allproducts.OrderByDescending(e => e.ProductQuantity).Skip(skip).Take(pageSize).ToList();
            }

                products.PageCount = pageCount;
                products.PageIndex = pageIndex;
                products.PageSize = pageSize;
                products.QueryCount = queryCount;

                return products;
            }
        public static Operation Add(Product product)
        {
            try
            {

                db.Products.Add(product);
                db.SaveChanges();

                return new Operation()
                {
                    Code = "200",
                    Message = "Ok",
                    ReferenceId = product.Id
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

