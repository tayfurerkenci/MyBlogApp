using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tayfur.Blog.Common.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, new() //TEntity class olmalı , IEntity türünde olmalı , newlenebilmeli.
      where TContext : DbContext, new()  //TContext DbContext türünde olmalı , newlenebilmeli 
    {
        public bool Add(TEntity entity)
        {
            using (TContext context = new TContext())//using içindeki context garbage collector yardımıyla belleği hızlıca temizler.Performans için yazdık.
            {
                var addedEntity = context.Entry(entity);

                addedEntity.State = EntityState.Added;//Ekleme işlemi yapılacağını bildirdik. 

                return context.SaveChanges()>0;//İşlemleri gerçekleştir.
            }
        }

        public bool Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);

                deletedEntity.State = EntityState.Deleted;

                return context.SaveChanges()>0;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {           //filter boş mu     EVET ise bütün datayı döndür           HAYIR ise filtreyi uygula 
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public bool Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);

                updatedEntity.State = EntityState.Modified;

                return context.SaveChanges()>0;
            }
        }
    }
}
