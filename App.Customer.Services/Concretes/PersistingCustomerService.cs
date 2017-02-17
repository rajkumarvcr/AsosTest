namespace App.Customer.Services
{
    public class PersistingCustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;

        public PersistingCustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public IAddCustomerResponse AddCustomer(IAddCustomerRequest request)
        {
            var isCustomerAdded = this.repository.AddCustomer(request.FirstName, request.SurName, request.Email, request.DateOfBirth, request.CompanyId);
            var response = new AddCustomerResponse(request) { IsCustomerAdded = isCustomerAdded };

            return response;
        }
    }
}