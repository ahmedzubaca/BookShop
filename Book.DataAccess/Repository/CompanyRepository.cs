using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private BookShopDbContext _db;

        public CompanyRepository(BookShopDbContext db) : base(db)
        {
            _db = db;  
        }

        public void Update(Company company)
        {
            //_db.Companies.Add(company);
            var companyFromDb = _db.Companies.FirstOrDefault(u => u.Id == company.Id);
            companyFromDb!.Name = company.Name;
            companyFromDb.PhoneNumber = company.PhoneNumber;
            companyFromDb.StreetAddress = company.StreetAddress;
            companyFromDb.City = company.City;
            companyFromDb.State = company.State;
            companyFromDb.PostalCode = company.PostalCode;
        }
    }
}
