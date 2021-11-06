using HH5VQ6_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected GameDbContext gameDbContext;

        public Repository(GameDbContext gameDbContext)
        {
            this.gameDbContext = gameDbContext;
        }

        public IQueryable<T> GetAll()
        {
            return gameDbContext.Set<T>();
        }

        public abstract T GetOne(int id);

        public void Add(T entity)
        {
            gameDbContext.Set<T>().Add(entity);
            gameDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            gameDbContext.Set<T>().Remove(entity);
            gameDbContext.SaveChanges();
        }
    }
}
