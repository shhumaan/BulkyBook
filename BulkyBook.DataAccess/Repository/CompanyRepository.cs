using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) :base(db)
        {
            _db = db; //geting DbContext object
        }

        public void Update(Company company)
        {
            /* var objfromDb = _db.Companies.FirstOrDefault(s=>s.Id==company.Id); //Helps in either retrieving first matched record in db or return null object
             if (objfromDb != null)
             {
                 objfromDb.Name = company.Name; //assiging value to the company name 
             }*/
            _db.Update(company);

        }
    }
}
