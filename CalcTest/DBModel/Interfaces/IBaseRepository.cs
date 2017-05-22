using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalc.Managers
{
    /// <summary>
    /// Базовый интерфейс хранилища данных
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        T Load(long id);
        void Save(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        /// <summary>
        /// Загрузить все сущности
        /// </summary>
        /// <param name="flag"></param>Автоматически подгрузить все зависимости
        /// <returns></returns>
        IEnumerable<T> GetAll(bool flag);

    }
}
