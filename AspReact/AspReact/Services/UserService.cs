using System;
using System.Collections.Generic;
using System.Linq;
using AspReact.Models;

namespace AspReact.Services
{
    public class UserService
    {
        private static List<User> users = new List<User>();
        private static int Count = 1;
        private static readonly string[] Names = { "Jonathan", "Mary", "Susan", "Joe", "Paul", "Carl", "Amanda", "Neil" };
        private static readonly string[] Surnames = { "Smith", "O'Neil", "MacDonald", "Gay", "Bailee", "Saigan", "Strip", "Spenser" };
        private static readonly string[] Extensions = { "@gmail.com", "@hotmail.com", "@outlook.com", "@icloud.com", "@yahoo.com" };

        static UserService()
        {
            var rnd = new Random();

            for (var i = 0; i < 5; i++)
            {
                var currName = Names[rnd.Next(Names.Length)];
                var user = new User
                {
                    Id = Count++,
                    Name = currName + " " + Surnames[rnd.Next(Surnames.Length)],
                    Email = currName.ToLower() + Extensions[rnd.Next(Extensions.Length)],
                    Document = (rnd.Next(0, 100000) * rnd.Next(0, 100000)).ToString().PadLeft(10, '0'),
                    Phone = "+375(29) 352-08-74"
                };

                users.Add(user);
            }
        }

        public List<User> GetAll() => users;

        public User GetById(int id) => users.FirstOrDefault(user => user.Id == id);

        public User Create(User user)
        {
            user.Id = Count++;
            users.Add(user);

            return user;
        }

        public void Update(int id, User user)
        {
            var userFound = users.FirstOrDefault(u => u.Id == id);

            if (userFound == null)
            { throw new NullReferenceException(); }

            userFound.Name = user.Name;
            userFound.Email = user.Email;
            userFound.Document = user.Document;
            userFound.Phone = user.Phone;
        }

        public void Delete(int id) => users.RemoveAll(x => x.Id == id);
    }
}
