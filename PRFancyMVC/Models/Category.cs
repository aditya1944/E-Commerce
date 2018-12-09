using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PRFancyMVC.Models
{
    public class Category
    {
        [ScaffoldColumn(false)]
        [Key]
        public string categoryId { get; set; }
        [DisplayName("Category Name")]
        [StringLength(40,ErrorMessage ="Category Name should be less than 40 characters")]
        public string categoryName { get; set; }
    }
}