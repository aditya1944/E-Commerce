using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Drawing;
using System.Data.Linq;
using PRFancy;

namespace PRFancyMVC.Models
{
    
    public class ProductImage
    {
        public virtual product Product { get; set; }
        public virtual Category Category { get; set; }
        public string productId { get; set; }
        [DisplayName("Upload Image 1")]
        public HttpPostedFileBase ImageData1 { get; set; }
        [DisplayName("Upload Image 2")]
        public HttpPostedFileBase ImageData2 { get; set; }
        [DisplayName("Upload Image 3")]
        public HttpPostedFileBase ImageData3 { get; set; }
        [DisplayName("Upload Image 4")]
        public HttpPostedFileBase ImageData4 { get; set; }

        public Image Image1 { get; set; }
        public Image Image2 { get; set; }
        public Image Image3 { get; set; }
        public Image Image4 { get; set; }

        public byte[] productImage1 { get; set; }
        public byte[] productImage2 { get; set; }
        public byte[] productImage3 { get; set; }
        public byte[] productImage4 { get; set; }
    }
}