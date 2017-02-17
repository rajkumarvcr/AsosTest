namespace App.Company.Services
{  

    public interface ICompanyRepository
    {
        Company GetById(int id);
    }
}