namespace App.Customer.Services
{
    using System;

    public interface IAddCustomerRequest
    {
        string FirstName { get; }

        string SurName { get; }

        string Email { get; }

        DateTime DateOfBirth { get; }

        int CompanyId { get; }
    }
}