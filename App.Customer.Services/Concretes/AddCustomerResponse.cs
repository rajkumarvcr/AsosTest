namespace App.Customer.Services
{
    using App.Customer.Services;

    public class AddCustomerResponse : IAddCustomerResponse
    {
        public AddCustomerResponse(IAddCustomerRequest request)
        {
            this.OriginalRequest = request;
        }

        public IAddCustomerRequest OriginalRequest { get; set; }
        public bool IsCustomerAdded { get; set; }
    }
}