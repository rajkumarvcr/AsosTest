using Customer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Services.Services
{
    public class Customer : ICustomer
    {
        private readonly ICustomerRepository repository;

        public Customer(ICustomerRepository repository)
        {

        }

        public bool AddCustomer(string firname, string surname, string email, DateTime dateOfBirth, int companyId)
        {
            throw new NotImplementedException();
        }


    }
}
