using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PRFancyMVC.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PRFancyMVC.Models
{
    public class product
    {
        [ScaffoldColumn(false)]
        public string productId { get; set; }
        [DisplayName("Product Name")]
        [StringLength(50, ErrorMessage = "Product Name should be less than 50 characters")]
        public string productName { get; set; }
        [DisplayName("Category Id")]
        [Required]
        public string categoryId { get; set; }
        
        [DisplayName("Small Size MRP")]
        [Range(0, 9999.99, ErrorMessage = "Range of price is between 0 and 9999.99")]
        public Nullable<decimal> sPrice { get; set; }
        [DisplayName("Medium Size MRP")]
        [Range(0, 9999.99, ErrorMessage = "Range of price is between 0 and 9999.99")]
        public Nullable<decimal> mPrice { get; set; }
        [DisplayName("Large Size MRP")]
        [Range(0, 9999.99, ErrorMessage = "Range of price is between 0 and 9999.99")]
        public Nullable<decimal> lPrice { get; set; }
        [DisplayName("Very Large Size MRP")]
        [Range(0, 9999.99, ErrorMessage = "Range of price is between 0 and 9999.99")]
        public Nullable<decimal> vlPrice { get; set; }
        [DisplayName("Small Size Rent")]
        [Range(0, 9999.99, ErrorMessage = "Range of price is between 0 and 9999.99")]
        public Nullable<decimal> sRentPrice { get; set; }
        [DisplayName("Medium Size Rent")]
        [Range(0, 9999.99, ErrorMessage = "Range of price is between 0 and 9999.99")]
        public Nullable<decimal> mRentPrice { get; set; }
        [DisplayName("Large Size Rent")]
        [Range(0, 9999.99, ErrorMessage = "Range of price is between 0 and 9999.99")]
        public Nullable<decimal> lRentPrice { get; set; }
        [DisplayName("Very Large Size Rent")]
        [Range(0, 9999.99, ErrorMessage = "Range of price is between 0 and 9999.99")]
        public Nullable<decimal> vlRentPrice { get; set; }
        [DisplayName("Product Description")]
        [StringLength(200, ErrorMessage = "Product Description")]
        public string productDesc { get; set; }
        [ForeignKey("categoryId")]
        public virtual Category category {
            get;
            set;
        }
        
    }
}