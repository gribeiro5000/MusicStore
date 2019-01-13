using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Entity
{
    public class Login
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
        public string LastUpdate { get; set; }
    }
}