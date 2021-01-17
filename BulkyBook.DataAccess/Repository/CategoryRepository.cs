using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) :base(db)
        {
            _db = db; //geting DbContext object
        }

        public void Update(Category category)
        {
            var objfromDb = _db.Categories.FirstOrDefault(s=>s.Id==category.Id); //Helps in either retrieving first matched record in db or return null object
            if (objfromDb != null)
            {
                objfromDb.Name = category.Name; //assiging value to the category name 
                _db.SaveChanges();   //For Save Changes
            }

        }
    }
}
