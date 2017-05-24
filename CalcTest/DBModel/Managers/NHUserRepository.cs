using System;
using System.Linq;
using System.Collections.Generic;
using DBModel.Models;
using WebCalc.Managers;
using NHibernate;
using DBModel.Helpers;

namespace DBModel.Managers
{
    public class NHUserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<User>().List<User>();
            }

        }

        public IEnumerable<User> GetAll(bool flag)
        {
            return GetAll();
        }

        public User Load(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(User entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string userName, string password)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.QueryOver<User>()
                              .Where(user => user.Email == userName && user.Password == password)
                              .SingleOrDefault() != null;
            }
        }
    }
}
