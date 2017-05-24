using System;
using System.Collections.Generic;
using WebCalc.Managers;

namespace DBModel.Models
{
    public class User
    {
        public User()
        {
            Operations = new List<OperationResult>();
        }

        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime BirthDate { get; set; }

        public virtual string Login { get; set; }
        public virtual string Password { get; set; }

        public virtual ICollection<OperationResult> Operations { get; set; }
    }


}
