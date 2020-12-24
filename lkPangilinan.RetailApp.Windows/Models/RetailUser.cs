using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lkPangilinan.RetailApp.Windows.Models
{
    public class RetailUser
    {
        public Guid? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ContactNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

    }
}
