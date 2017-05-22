using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.Models;
using WebCalc.Managers;
using DBModel.Helpers;

namespace DBModel.Managers
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            using (var context = new UserContext())
            {
                return context.Users.ToList();
            }
        }

        public OperationResult Load(long id)
        {
            throw new NotImplementedException();
        }

        public void Save(User entity)
        {
            using (var context = new UserContext())
            {
                context.Users.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OperationResult entity)
        {
            throw new NotImplementedException();
        }
        public bool Validate(string userName,string password)
        {
            if (string.IsNullOrEmpty(userName))
                return false;
            if (string.IsNullOrWhiteSpace(password))
                return false;
            using (var context = new UserContext())
            {
                return context.Users.FirstOrDefault(u => u.Login == userName && u.Password == password) != null;
            }
            return false;
        }

        User IBaseRepository<User>.Load(long id)
        {
            throw new NotImplementedException();
        }
    }
}
