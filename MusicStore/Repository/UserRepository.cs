using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple.Data;
using MusicStore.Entity;

namespace MusicStore.Repository
{
    public class UserRepository : BaseRepository
    {
        public User GetUser(string username, string password)
        {
            User user = new User();
            var chinookDb = Database.OpenConnection(_connectionString);
            user.login = chinookDb.login.Find(chinookDb.login.Username == username && chinookDb.login.Password == password);
            try
            {
                user.customer = chinookDb.customers.Find(chinookDb.customers.CustomerId == user.login.CustomerId);
            }
            catch
            {
                user = null;
            }

            return user;
        }

        public void InsertUser(User user)
        {
            Customer _customer = new Customer();
            var chinookDb = Database.OpenConnection(_connectionString);
            chinookDb.customers.Insert(user.customer);
            _customer = chinookDb.customers.Find(chinookDb.customers.Email == user.customer.Email);
            user.login.CustomerId = _customer.CustomerId;
            chinookDb.login.Insert(user.login);            
        }
    }
}