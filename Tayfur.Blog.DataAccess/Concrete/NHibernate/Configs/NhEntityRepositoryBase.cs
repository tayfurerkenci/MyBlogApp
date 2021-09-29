using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tayfur.Blog.Common.DataAccess;
using Tayfur.Blog.DataAccess.Concrete.NHibernate;

namespace Tayfur.Blog.DataAccess.NHibernate
{
    public class NhEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, new()
    {
        ISession session = MyNHibernateHelper.OpenSession();
        //private readonly ISession session;

        //public NhEntityRepositoryBase(ISession session)
        //{
        //    this.session = session;
        //}

        public bool Add(TEntity entity)
        {
            //using (ISession session = MyNHibernateHelper.OpenSession())
            //{
            if (!session.IsOpen)
            {
                session= MyNHibernateHelper.OpenSession();
            }
            //using (var transaction = session.BeginTransaction())
            //{
                session.Save(entity);
                session.Flush();
                return true;
            //}
            //}
        }

        public bool Delete(TEntity entity)
        {
            //using (ISession session = MyNHibernateHelper.OpenSession())
            //{
            if (!session.IsOpen)
            {
                session = MyNHibernateHelper.OpenSession();
            }
            //using (var transaction = session.BeginTransaction())
            //{
                session.Delete(entity);
                session.Flush();

                return true;
            //}
            //}
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            //using (ISession session = MyNHibernateHelper.OpenSession())
            //{
            if (!session.IsOpen)
            {
                session = MyNHibernateHelper.OpenSession();
            }
            //using (var transaction = session.BeginTransaction())
            //{
                return FilterBy(filter).FirstOrDefault();
            //}
            //}
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //using (ISession session = MyNHibernateHelper.OpenSession())
            //{
            if (!session.IsOpen)
            {
                session = MyNHibernateHelper.OpenSession();
            }
            //using (var transaction = session.BeginTransaction())
            //{
                return FilterBy(filter).ToList();
            //}
            //}
        }

        public bool Update(TEntity entity)
        {
            //using (ISession session = MyNHibernateHelper.OpenSession())
            //{
            if (!session.IsOpen)
            {
                session = MyNHibernateHelper.OpenSession();
            }
            //using (var transaction = session.BeginTransaction())
            //{
                session.Update(entity);
                session.Flush();
                return true;
            //}
            //}
        }

        public IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter = null)
        {
            //using (ISession session = MyNHibernateHelper.OpenSession())
            //{
            //filter boş mu? EVET ise bütün datayı döndür :  HAYIR ise filtreyi uygula 
            if (!session.IsOpen)
            {
                session = MyNHibernateHelper.OpenSession();
            }
            //using (var transaction = session.BeginTransaction())
            //{
                return filter == null ? All().AsQueryable() : All().Where(filter).AsQueryable();
            //}
            //}
        }
        public IQueryable<TEntity> All()
        {
            //    using (ISession session = MyNHibernateHelper.OpenSession())
            //    {
            if (!session.IsOpen)
            {
                session = MyNHibernateHelper.OpenSession();
            }
            //using (var transaction = session.BeginTransaction())
            //{
                return session.Query<TEntity>();
            //}
            //}
        }
    }
}