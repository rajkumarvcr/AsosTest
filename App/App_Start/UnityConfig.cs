using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using App.Database;
using System.Configuration;
using App.Company.Services;
using App.Customer.Services;
using App.Customer.Services.Concretes;

namespace App
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<ICustomerService, ValidatingCustomerService>(new InjectionConstructor(typeof(PersistingCustomerService)));            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}