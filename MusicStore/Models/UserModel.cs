using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class UserModel
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "The First Name is required")]
        [StringLength(40, ErrorMessage = "the field must be have maximum 40 character")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name is required")]
        [StringLength(20, ErrorMessage = "the field must be have maximum 20 character")]
        public string LastName { get; set; }

        [StringLength(80, ErrorMessage = "the field must be have maximum 80 character")]
        public string Company { get; set; }

        [StringLength(70, ErrorMessage = "the field must be have maximum 70 character")]
        public string Address { get; set; }

        [StringLength(40, ErrorMessage = "the field must be have maximum 40 character")]
        public string City { get; set; }

        [StringLength(40, ErrorMessage = "the field must be have maximum 40 character")]
        public string State { get; set; }

        [StringLength(40, ErrorMessage = "the field must be have maximum 40 character")]
        public string Country { get; set; }

        [StringLength(10, ErrorMessage = "the field must be have maximum 10 character")]
        public string PostalCode { get; set; }

        [StringLength(24, ErrorMessage = "the field must be have maximum 24 character")]
        public string Phone { get; set; }

        [StringLength(24, ErrorMessage = "the field must be have maximum 24 character")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        [StringLength(60, ErrorMessage = "the field must be have maximum 60 character")]
        public string Email { get; set; }

        [StringLength(20, ErrorMessage = "the field must be have maximum 20 character")]
        public string Username { get; set; }

        [StringLength(50, ErrorMessage = "the field must be have maximum 50 character")]
        public string Password { get; set; }

        public string RepeatPassword { get; set; }
        public int Active { get; set; }
        public string LastUpdate { get; set; }
    }
}