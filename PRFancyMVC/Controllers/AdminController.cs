using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRFancy;
using System.Drawing;
using System.Data.Linq;
using PRFancyMVC.Repository;

namespace PRFancyMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult AdminHome(string Length)
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            return View();
        }
        public ActionResult LogOut()
        {
            Session["user"] = null;
            return RedirectToAction("home", "home");
        }
        public ActionResult ViewAllProducts()
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<product, Models.product> map = new PRFancyAutoMapper<product, Models.product>();
            List<Models.product> modellstProduct = new List<Models.product>();
            List<product> lstProduct;
            try
            {
                lstProduct = dal.GetAllProduct();
                foreach (var item in lstProduct)
                    modellstProduct.Add(map.Translate(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return View(modellstProduct);
        }
        public ActionResult ViewAllCategory()
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<category, Models.Category> map = new PRFancyAutoMapper<category, Models.Category>();
            List<Models.Category> modellstCategory = new List<Models.Category>();
            List<category> lstCategory;
            try
            {
                lstCategory = dal.GetCategories();
                foreach (var item in lstCategory)
                    modellstCategory.Add(map.Translate(item));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return View(modellstCategory);
        }
        public ActionResult AddProduct()
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            PRFancyRepository dal = new PRFancyRepository();
            ViewBag.lstCategory = dal.GetCategories();
            return View();
        }
        [HttpPost]
        public ActionResult SaveAddedProduct(Models.product product)
        {
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<Models.product, product> map = new PRFancyAutoMapper<Models.product, product>();
            try
            {
                if (dal.AddProduct(map.Translate(product)))
                    return RedirectToAction("ViewAllProducts");
                return View("Error");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public ActionResult AddCategory()
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            return View();
        }
        [HttpPost]
        public ActionResult SaveAddedCategory(Models.Category category)
        {
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<Models.Category, category> map = new PRFancyAutoMapper<Models.Category, category>();
            try
            {
                if (dal.AddCategory(map.Translate(category)))
                    return RedirectToAction("ViewAllCategory");
                return View("Error");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public ActionResult EditCategory(string categoryId)
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<category, Models.Category> map = new PRFancyAutoMapper<category, Models.Category>();
            try
            {
                var categoryObj = dal.GetCategory(categoryId);
                return View(map.Translate(categoryObj));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult SaveEditCategory(Models.Category category)
        {
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<Models.Category, category> map = new PRFancyAutoMapper<Models.Category, category>();
            try
            {
                if (dal.UpdateCategory(map.Translate(category)))
                    return RedirectToAction("ViewAllCategory");
                return View("Error");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public ActionResult EditProduct(string productId)
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<product, Models.product> map = new PRFancyAutoMapper<product, Models.product>();
            try
            {
                ViewBag.lstCategory = dal.GetCategories();
                var prodObj = dal.GetProduct(productId);
                return View(map.Translate(prodObj));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult SaveEditProduct(Models.product product)
        {
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<Models.product, product> map = new PRFancyAutoMapper<Models.product, product>();
            try
            {
                if (dal.UpdateProduct(map.Translate(product)))
                    return RedirectToAction("ViewAllProducts");
                return View("Error");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public ActionResult DeleteProduct(string productId)
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<product, Models.product> map = new PRFancyAutoMapper<product, Models.product>();
            try
            {
                ViewBag.lstCategory = dal.GetCategories();
                var prodObj = dal.GetProduct(productId);
                return View(map.Translate(prodObj));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult SaveDeleteProduct(Models.product product)
        {
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<Models.product, product> map = new PRFancyAutoMapper<Models.product, product>();
            try
            {
                if (dal.DeleteProduct(map.Translate(product)))
                    return RedirectToAction("ViewAllProducts");
                return View("Error");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public ActionResult DeleteCategory(string categoryId)
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<category, Models.Category> map = new PRFancyAutoMapper<category, Models.Category>();
            try
            {
                var categoryObj = dal.GetCategory(categoryId);
                return View(map.Translate(categoryObj));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult SaveDeleteCategory(Models.Category category)
        {
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<Models.Category, category> map = new PRFancyAutoMapper<Models.Category, category>();
            try
            {
                if (dal.DeleteCategory(map.Translate(category)))
                    return RedirectToAction("ViewAllCategory");
                return View("Error");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public ActionResult ImageHome()
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<productImage, Models.ProductImage> map = new PRFancyAutoMapper<productImage, Models.ProductImage>();
            List<productImage> lstproductImages;
            List<Models.ProductImage> lstModelImages = new List<Models.ProductImage>();
            try
            {
                lstproductImages = dal.GetProductImages();
                foreach (var item in lstproductImages)
                    lstModelImages.Add(map.Translate(item));
                int i = 0;
                foreach(var item in lstModelImages)
                {
                    if (lstproductImages[i].productImage1 != null)
                    {
                        item.Image1 = ConvertToImage(item.productImage1);
                    }
                    if (lstproductImages[i].productImage2 != null)
                    {
                        item.Image2 = ConvertToImage(item.productImage2);
                    }
                    if (lstproductImages[i].productImage3 != null)
                    {
                        item.Image3 = ConvertToImage(item.productImage3);
                    }
                    if (lstproductImages[i].productImage4 != null)
                    {
                        item.Image4 = ConvertToImage(item.productImage4);
                    }
                    ++i;
                }
                return View(lstModelImages);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public ActionResult EditImage(string productId)
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<productImage, Models.ProductImage> map = new PRFancyAutoMapper<productImage, Models.ProductImage>();
            try
            {
                productImage obj = dal.GetProductImage(productId);
                Models.ProductImage modObj = map.Translate(obj);
                return View(map.Translate(obj));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult SaveImage([Bind(Exclude = "productImage1,productImage2,productImage3,productImage4,ImageData1,ImageData2,ImageData3,ImageData4,Image1,Image2,Image3,Image4")]Models.ProductImage imageObj)
        {
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<Models.ProductImage, productImage> map = new PRFancyAutoMapper<Models.ProductImage, productImage>();
            try
            {
                HttpPostedFileBase file1 = Request.Files["ImageData1"];
                HttpPostedFileBase file2 = Request.Files["ImageData2"];
                HttpPostedFileBase file3 = Request.Files["ImageData3"];
                HttpPostedFileBase file4 = Request.Files["ImageData4"];
                bool result = dal.SaveImage(imageObj.productId,file1, file2, file3, file4);
                if (result)
                    return RedirectToAction("ImageHome");
                return View("Error");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public Image ConvertToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        public FileContentResult GetPhoto(string productId,int i)
        {
            PRFancyRepository dal = new PRFancyRepository();
            byte[] image = dal.GetPhoto(productId,i);
            if (image == null)
                return null;
            return File(image, "image/jpeg");
        }
        public ActionResult DeleteImage(string productId)
        {
            if (Session["user"] == null)
                return RedirectToAction("home", "home");
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<productImage, Models.ProductImage> map = new PRFancyAutoMapper<productImage, Models.ProductImage>();
            try
            {
                var obj = dal.GetProductImage(productId);
                return View(map.Translate(obj));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult SaveDeleteImage(string productId,int i)
        {
            PRFancyRepository dal = new PRFancyRepository();
            try
            {
                bool result = dal.DeleteImage(productId, i);
                if (result)
                    return RedirectToAction("ImageHome");
                return View("Error");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}