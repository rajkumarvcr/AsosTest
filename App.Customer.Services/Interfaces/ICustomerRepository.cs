using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Customer.Services
{
    public interface ICustomerRepository
    {
        bool AddCustomer(string firname, string surname, string email, DateTime dateOfBirth, int companyId);
    }
}