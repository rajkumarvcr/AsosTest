using System;
using App.Customer.Services;

namespace App.Customer.Services.Concretes
{
    public class ValidatingCustomerService : ICustomerService
    {
        private readonly ICustomerService service;

        public ValidatingCustomerService(ICustomerService service)
        {
            this.service = service;
        }

        public IAddCustomerResponse AddCustomer(IAddCustomerRequest request)
        {
            if (null == request)
            {
                throw new ArgumentNullException(nameof(IAddCustomerRequest));
            }

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                throw new ArgumentOutOfRangeException(nameof(request.FirstName));
            }

            if (string.IsNullOrWhiteSpace(request.SurName))
            {
                throw new ArgumentOutOfRangeException(nameof(request.SurName));
            }

            if (string.IsNullOrWhiteSpace(request.SurName))
            {
                throw new ArgumentOutOfRangeException(nameof(request.SurName));
            }

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new ArgumentOutOfRangeException(nameof(request.SurName));
            }

            var now = DateTime.Now;
            var dob = request.DateOfBirth;
            int age = now.Year - dob.Year;
            if (now.Month < dob.Month || (now.Month == dob.Month && now.Day < dob.Day)) age--;

            if (age < 21)
            {
                throw new ArgumentOutOfRangeException(nameof(request.DateOfBirth));
            }

            return this.service.AddCustomer(request);
        }
    }
}