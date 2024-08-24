using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.Infrastructure.Repository
{
    /// <summary>
    /// Репозиторий Crud операций
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Возвращает все элементы сущности <see cref="TEntity"/>
        /// </summary>
        /// <returns>Все элементы сущности <see cref="TEntity"/></returns>
        IQueryable<TEntity> GetAll();
     /// <summary>
     /// Возвращает По id
     /// </summary>
     /// <param name="id"></param>
     /// <returns></returns>
        Task<TEntity> GetByIdAsync(Guid id,CancellationToken cancellationToken); 
        /// <summary>
        /// Добавляет сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity, CancellationToken cancellationToken); 
        /// Обновление сущности
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken); 
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken); 
        /// <summary>
        /// Получение по фильтру
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllFiltered(Expression<Func<TEntity, bool>> filter);


    }
}
