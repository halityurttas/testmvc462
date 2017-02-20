using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public abstract class EFRepositoryBase<TContext, TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class where TContext : DbContext
    {
        private readonly DbContext m_dbContext;

        public EFRepositoryBase()
            : this(Activator.CreateInstance<TContext>())
        {

        }

        public EFRepositoryBase(DbContext context)
        {
            this.m_dbContext = context;
        }

        public virtual bool Delete(TKey id)
        {
            try
            {
                var model = this.Get(id);
                this.GetSet().Remove(model);
                this.m_dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return this.GetSet().Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return new List<TEntity>();
            }
        }

        public TEntity Get(TKey id)
        {
            try
            {
                return this.GetSet().Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }






        public ICollection<TEntity> GetAll()
        {
            try
            {
                return this.GetSet().ToList();
            }
            catch (Exception ex)
            {
                return new List<TEntity>();
            }
        }

        public TKey Insert(TEntity model)
        {
            try
            {
                this.GetSet().Add(model);
                this.m_dbContext.SaveChanges();
                IEntity<TKey> entity = model as IEntity<TKey>;
                return entity.Id;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                return Activator.CreateInstance<TKey>();
            }
        }

        public bool Remove(TKey id)
        {
            return Delete(id);
        }

        public bool Update(TEntity model)
        {
            try
            {
                this.GetSet().Attach(model);
                this.m_dbContext.Entry(model).State = EntityState.Modified;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                this.m_dbContext.SaveChanges();
            }
            return true;
        }

        protected DbSet<TEntity> GetSet()
        {
            return this.m_dbContext.Set<TEntity>();
        }
    }
}
