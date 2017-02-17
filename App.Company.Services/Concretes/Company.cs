namespace App.Company.Services
{
    using System;
    using App.Common;

    public class Company : ICompany
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Classification Classification { get; set; }
    }
}