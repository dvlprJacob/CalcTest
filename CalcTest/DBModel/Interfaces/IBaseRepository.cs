using System.Collections.Generic;

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
        /// <param name="flag">Автоматически подгрузить все зависимости</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(bool flag);
    }
}
