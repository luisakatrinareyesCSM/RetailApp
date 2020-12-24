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
    public class RetailUserBLL
    {
        private static RetailDBContext db = new RetailDBContext();
        public static Paged<Models.RetailUser> Search(int pageIndex = 1, int pageSize = 1, string sortBy = "first name", string sortOrder = "asc", string keyword = "")
        {
            IQueryable<RetailUser> allRetailUsers = (IQueryable<RetailUser>)db.RetailUsers;
            Paged<Models.RetailUser> RetailUsers = new Paged<RetailUser>();

            if (!string.IsNullOrEmpty(keyword))
            {
                allRetailUsers = allRetailUsers.Where(e => e.FirstName.Contains(keyword) || e.LastName.Contains(keyword));
            }

            var queryCount = allRetailUsers.Count();
            var skip = pageSize * (pageIndex - 1);

            long pageCount = (long)Math.Ceiling((decimal)((queryCount) / pageSize));
            if ((queryCount % pageSize) > 0)
            { pageCount += 1; }

            if (sortBy.ToLower() == "first name" && sortOrder.ToLower() == "asc")
            {
                RetailUsers.Items = allRetailUsers.OrderBy(e => e.FirstName).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "first name" && sortOrder.ToLower() == "desc")
            {
                RetailUsers.Items = allRetailUsers.OrderByDescending(e => e.FirstName).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "last name" && sortOrder.ToLower() == "asc")
            {
                RetailUsers.Items = allRetailUsers.OrderBy(e => e.LastName).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                RetailUsers.Items = allRetailUsers.OrderByDescending(e => e.LastName).Skip(skip).Take(pageSize).ToList();
            }

            RetailUsers.PageCount = pageCount;
            RetailUsers.PageIndex = pageIndex;
            RetailUsers.PageSize = pageSize;
            RetailUsers.QueryCount = queryCount;

            return RetailUsers;
        }
        public static Operation Add(RetailUser user)
        {
            try
            {

                db.RetailUsers.Add(user);
                db.SaveChanges();

                return new Operation()
                {
                    Code = "200",
                    Message = "Ok",
                    ReferenceId = user.Id
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

        public static Operation Login(string emailAddress = "", string password = "")
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
                };
            }

            if (string.IsNullOrEmpty(password))
            {
                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
                };
            }

            try
            {
                RetailUser user = db.RetailUsers.FirstOrDefault(e => e.EmailAddress.ToLower() == emailAddress.ToLower());

                if (user == null)
                {
                    return new Operation()
                    {
                        Code = "500",
                        Message = "Invalid Login"
                    };
                }

                if (password == user.Password)
                {
                    return new Operation()
                    {
                        Code = "200",
                        Message = "Successful Login",
                        ReferenceId = user.Id
                    };
                }

                return new Operation()
                {
                    Code = "500",
                    Message = "Invalid Login"
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
