using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PRFancyMVC.Models
{
    public class user
    {
        //public string userId { get; set; }
        [Required(ErrorMessage ="Username is required")]
        public string Username { get; set; }
        //public Nullable<int> roleId { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}