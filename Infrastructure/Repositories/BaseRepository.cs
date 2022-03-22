using Domain.Models;
using Domain.Services;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual bool Delete(TKey id)
        {
            if (!Exists(id))
                return false;

            _context.Set<T>().Remove(GetById(id));
            _context.SaveChanges();
            return true;
        }

        public virtual bool Exists(TKey id) => GetById(id) != null;

        public virtual IList<T> GetAll() => _context.Set<T>().ToList();

        public virtual T GetById(TKey id) => _context.Set<T>().Find(id);

        public virtual IList<T> GetRandom(int count)
        {
            Random rng = new Random();
            return _context.Set<T>().OrderBy(c => rng.Next()).ToList();
        }

        public virtual bool Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
