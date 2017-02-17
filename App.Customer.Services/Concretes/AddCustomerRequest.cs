using System;


namespace App.Customer.Services
{
    public class AddCustomerRequest : IAddCustomerRequest
    {
        public int CompanyId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }
        
    }
}