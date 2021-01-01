using Microsoft.EntityFrameworkCore;
using Skinet_DomainModels;
using Skinet_Repository.Specification;
using Skinet_Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet_Repository
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> GetByIDAsync(int ID);

        Task<IReadOnlyList<T>> GetListAsync();
        Task<T> GetEntityWithSpecification(ISpecification<T> specification);
        Task<IReadOnlyList<T>> GetListWithSpecification(ISpecification<T> specification);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext db;

        public GenericRepository(DataContext db)
        {
            this.db = db;
        }
        public async Task<T> GetByIDAsync(int ID)
        {
            return await db.Set<T>().FindAsync(ID);
        }

        public async Task<IReadOnlyList<T>> GetListAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }
        public async Task<IReadOnlyList<T>> GetListWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(db.Set<T>().AsQueryable(), specification);
        }
    }
}
