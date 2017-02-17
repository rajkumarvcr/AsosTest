namespace App.Customer.Services
{
    using App.Company.Services;

    public class CustomerService : ICustomerService
    {
        private readonly ICompanyRepository companyRepository;
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICompanyRepository companyRepository,
                                ICustomerRepository customerRepository
                                )
        {
            this.companyRepository = companyRepository;
            this.customerRepository = customerRepository;
        }

        public IAddCustomerResponse AddCustomer(IAddCustomerRequest request)
        {
            var response = new AddCustomerResponse(request);
            var company = this.companyRepository.GetById(request.CompanyId);

            var customer = new Customer
            {
                Company = company,
                DateOfBirth = request.DateOfBirth,
                EmailAddress = request.Email,
                Firstname = request.FirstName,
                Surname = request.SurName
            };

            if (company.Name == "VeryImportantClient")
            {
                // Skip credit check
                customer.HasCreditLimit = false;
            }
            else if (company.Name == "ImportantClient")
            {
                // Do credit check and double credit limit
                customer.HasCreditLimit = true;
                using (var customerCreditService = new CustomerCreditServiceClient())
                {
                    var creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    customer.CreditLimit = creditLimit;
                }
            }
            else
            {
                // Do credit check
                customer.HasCreditLimit = true;
                using (var customerCreditService = new CustomerCreditServiceClient())
                {
                    var creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
                    customer.CreditLimit = creditLimit;
                }
            }

            if (customer.HasCreditLimit && customer.CreditLimit < 500)
            {
                response.IsCustomerAdded = false;
                return response;
            }
            
            CustomerDataAccess.AddCustomer(customer);

            response.IsCustomerAdded = true;
            return response;

        }
    }
}