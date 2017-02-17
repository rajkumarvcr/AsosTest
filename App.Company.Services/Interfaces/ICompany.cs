namespace App.Company.Services
{
    using App.Common;

    public interface ICompany
    {
        int Id { get; }

        string Name { get; }

        Classification Classification { get; }
    }
}