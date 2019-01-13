using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Entity
{
    public class User
    {
        public User()
        {
            customer = new Customer();
            login = new Login();
        }
        public Login login { get; set; }
        public Customer customer { get; set; }
    }
}