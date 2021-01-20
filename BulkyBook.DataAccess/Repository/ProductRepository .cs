using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) :base(db)
        {
            _db = db; //geting DbContext object
        }

        public void Update(Product product)
        {
            var objfromDb = _db.Products.FirstOrDefault(s=>s.Id==product.Id); //Helps in either retrieving first matched record in db or return null object
            if (objfromDb != null)
            {
                if (product.ImageUrl != null)
                {
                    objfromDb.ImageUrl = product.ImageUrl;
                }
                objfromDb.ISBN = product.ISBN;
                objfromDb.Price = product.Price;
                objfromDb.Price50 = product.Price50;
                objfromDb.ListPrice = product.ListPrice;
                objfromDb.Price100 = product.Price100;
                objfromDb.Title = product.Title;
                objfromDb.Description = product.Description;
                objfromDb.CategoryId = product.CategoryId;
                objfromDb.Author = objfromDb.Author;
                objfromDb.CoverTypeId = objfromDb.CoverTypeId;
            }

        }
    }
}
