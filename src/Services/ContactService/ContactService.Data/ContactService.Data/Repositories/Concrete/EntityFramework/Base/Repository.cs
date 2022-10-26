using ContactService.Data.Abstract.Base;
using ContactService.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Data.Repositories.Concrete.EntityFramework.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected ContactServiceContext _context;
        private DbSet<T> _dbSet;
        public Repository(ContactServiceContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


    }
}
