using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Services.Interfaces
{
    public interface ICustomer
    {
        bool AddCustomer(string firname, string surname, string email, DateTime dateOfBirth, int companyId);
    }
}