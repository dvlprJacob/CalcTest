using System.Collections.Generic;
using System.Linq;
using DBModel.Models;
using WebCalc.Managers;
using System.Data.Entity;
using System;

namespace DBModel.Managers
{
    [Obsolete("Отстой", true)]
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private DbSet<User> Users { get; set; }

        public UserRepository(DbContext context) : base(context)
        {
            Users = _db.Set<User>();
        }
        public override IEnumerable<User> GetAll()
        {
            return Users.ToList();
        }

        public override void Save(User entity)
        {
            Users.Add(entity);
            _db.SaveChanges();
        }

        public bool Validate(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return false;

            if (string.IsNullOrWhiteSpace(password))
                return false;

            return Users.FirstOrDefault(u => u.Login == userName && u.Password == password) != null;
        }
    }
}
