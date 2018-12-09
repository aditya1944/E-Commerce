using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRFancy;
using PRFancyMVC.Repository;

namespace PRFancyMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            PRFancyRepository dal = new PRFancyRepository();
            ViewBag.lstCategories = dal.GetCategories();
            return View();
        }
        [HttpPost]
        public JsonResult GetProductsByCategory(string categoryId)
        {
            PRFancyRepository dal = new PRFancyRepository();
            List<product> lstProduct = dal.GetProductsByCategory(categoryId);
            PRFancyAutoMapper<product, Models.product> map = new PRFancyAutoMapper<product, Models.product>();
            List<Models.product> lstModelProduct = new List<Models.product>() ;
            foreach(var item in lstProduct)
            {
                lstModelProduct.Add(map.Translate(item));
            }
            return Json(lstModelProduct);
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AfterLogin(Models.user user)
        {
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<Models.user, user> map = new PRFancyAutoMapper<Models.user, user>();
            try
            {
                if (dal.ValidateLogin(map.Translate(user))){
                    Session["user"] = user.Username;
                    return Redirect("/Admin/AdminHome?user=" + user.Username.Split('@')[0]);
                }
                return View("Login",user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        [AllowAnonymous]
        public ActionResult ProductDetails(string productId)
        {
            PRFancyRepository dal = new PRFancyRepository();
            PRFancyAutoMapper<product, Models.product> map = new PRFancyAutoMapper<product, Models.product>();
            try
            {
                return View(map.Translate(dal.GetProduct(productId)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public FileContentResult GetPhoto(string productId, int i)
        {
            PRFancyRepository dal = new PRFancyRepository();
            byte[] image = dal.GetPhoto(productId, i);
            if (image == null)
                return null;
            return File(image, "image/jpeg");
        }
    }
}