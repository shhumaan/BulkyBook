using System;
using System.Collections.Generic;
using System.Text;

namespace BulkyBook.DataAccess.Repository.IRepository
{
     public interface IUnitOfWork :IDisposable
    {
        ICategoryRepository Category { get; }
        ICompanyRepository Company { get; }

        ISP_Call SP_Call { get; }
        void Save();
        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }
        IApplicationUserRepository ApplicationUser { get; }

    }
}
