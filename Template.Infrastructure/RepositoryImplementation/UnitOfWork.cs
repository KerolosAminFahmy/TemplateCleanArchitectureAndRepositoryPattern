using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.RepositoryInterfaces;
using Template.Infrastructure.Data;

namespace Template.Infrastructure.RepositoryImplementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
         


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;


        }
        /// <summary>
        /// The UnitOfWork is a central place where all repositories are declared.
        /// To use a new model with the UnitOfWork, follow these steps:
        /// 
        /// 1. Declare a property for the new model's repository in UnitOfWork.
        ///    For example, for a 'Category' model:
        ///    
        ///    private IBaseRepository<Category> _categories;
        ///
        ///    public IBaseRepository<Category> Categories
        ///    {
        ///        get
        ///        {
        ///            // Initialize the Category repository only when needed.
        ///            return _categories ??= new BaseRepository<Category>(_context);
        ///        }
        ///    }
        /// 
        /// 2. Use the repository property to access the repository operations in the service layer:
        ///    - _unitOfWork.Categories.GetByIdAsync(id);
        ///    - _unitOfWork.Categories.AddAsync(category);
        /// 
        /// 3. Don't forget to call `_unitOfWork.Complete()` to commit changes to the database.
        /// </summary>

        /// <summary>
        /// Saves all changes made across repositories.
        /// This method commits all pending changes to the database in a single transaction.
        /// </summary>
        /// <returns>The number of state entries written to the database.</returns>

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
