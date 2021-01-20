using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Sp_Call = new StoredProcedure_Call(_db);
            CoverType = new CoverTypeRepository(_db);
            Product = new ProductRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public ISP_Call Sp_Call { get; private set; }

        public ISP_Call SP_Call => throw new NotImplementedException();

        public ICoverTypeRepository CoverType { get; private set; }
        public IProductRepository Product { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
