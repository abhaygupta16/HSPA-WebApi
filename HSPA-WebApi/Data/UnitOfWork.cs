/* 
    this file is use for save transition of data
    and it call the other repository and pass the data context in it,as well as save changes method as it is common for 
    all the repositories.
*/

using HSPA_WebApi.Data.Repo;
using HSPA_WebApi.Interfaces;

using System.Threading.Tasks;

namespace HSPA_WebApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public ICityRepository CityRepository => new CityRepository(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync()>=0;
        }
    }
}
