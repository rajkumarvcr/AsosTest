namespace App.Customer.Services
{
    public interface ICustomerService
    {
        IAddCustomerResponse AddCustomer(IAddCustomerRequest request);
    }
}