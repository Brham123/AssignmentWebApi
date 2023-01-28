namespace PhoneBook.Repositories.Repository
{
    using PhoneBook.Repositories.IRepository;
    using PhoneBookApi.Models.DataModels;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// This class contains methods which perform CRUD operations on given TEntity.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        #region Properties

        /// <summary>
        /// The database context.
        /// </summary>
        protected readonly PhoneBookContext _databaseContext;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="databaseContext">The <see cref="OCCDbContext"/>.</param>
        public BaseRepository(PhoneBookContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        #endregion

        #region Public Methods

        public TEntity Get(object id)
        {
            var entity = _databaseContext.Find<TEntity>(id);
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var entities = _databaseContext.Set<TEntity>();
            return entities;
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var createdEntity = _databaseContext.Add(entity);
            _databaseContext.SaveChanges();
            return createdEntity.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var createdEntity = _databaseContext.Update(entity);
            _databaseContext.SaveChanges();
            return createdEntity.Entity;
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _databaseContext.Remove(entity);
            _databaseContext.SaveChanges();
        }

        #endregion
    }
}
