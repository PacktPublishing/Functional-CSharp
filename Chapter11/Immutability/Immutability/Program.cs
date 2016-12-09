using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immutability
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

namespace Immutability
{
    //public class UserMembership
    //{
    //    private User _user;
    //    private DateTime _memberSince;

    //    public void UpdateUser(
    //        int userId, string name)
    //    {
    //        _user = new User(
    //            userId, 
    //            name);
    //    }
    //}

    public class UserMembership
    {
        private readonly User _user;
        private readonly DateTime _memberSince;

        public UserMembership(
            User user, 
            DateTime memberSince)
        {
            _user = user;
            _memberSince = memberSince;
        }

        public UserMembership UpdateUser(
            int userId, 
            string name)
        {
            var newUser = new User(
                userId, 
                name);

            return new UserMembership(
                newUser, 
                _memberSince);
        }
    }

    public class User
    {
        public int Id { get; }
        public string Name { get; }

        public User(
            int id, 
            string name)
        {
            Id = id;
            Name = name;
        }
    }
}
