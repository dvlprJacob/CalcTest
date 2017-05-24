using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebCalc.Managers
{
    /// <summary>
    /// Базовый интерфейс хранилища данных
    /// </summary>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class 
    {
        protected DbContext _db { get; set; }

        public BaseRepository(DbContext context)
        {
            _db = context;
        }

        public virtual T Load(long id)
        {
            return null;
        }

        public virtual void Save(T entity)
        {
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> GetAll(bool flag)
        {
            throw new NotImplementedException();
        }
    }
}
