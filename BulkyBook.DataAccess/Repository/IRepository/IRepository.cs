using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        //CRUD operations for Category Menu.
        //All comments below are based on their on above function!!! 
        //Dont be Confused!!


        T Get(int id);
        //based on id retrieve category from Database.

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );
        // get number of list either based on requirement or based on orderBy and Filter

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );
        //get only one record of category, Filteration can also be applied

        void Add(T entity);
        // to Add something to db

        void Remove(int id);
        // to Remove something from db based on id

        void Remove(T entity);
        // to Remove something from db based on entity
        void RemoveRange(IEnumerable<T> entity);
        //remove range of records from db

    }
}
