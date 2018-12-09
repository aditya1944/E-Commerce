using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace PRFancy
{
    public class PRFancyRepository
    {
        PRFancyEntities context;
        public PRFancyRepository()
        {
            context = new PRFancyEntities();
        }
        public bool ValidateLogin(user user)
        {
            try
            {
                user a = (context.users.Where(x => x.username == user.username && x.password == user.password)).SingleOrDefault<user>();
                if (a == null)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool AddProduct(product product)
        {
            try
            {
                string a = context.Database.SqlQuery<string>("Select dbo.ufn_GenerateNewProductId()").FirstOrDefault<string>();
                product.productId = a;
                context.products.Add(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool AddCategory(category category)
        {
            try
            {
                string a = context.Database.SqlQuery<string>("Select dbo.ufn_GenerateNewCategoryId()").FirstOrDefault<string>();
                category.categoryId = a;
                context.categories.Add(category);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool AddUser(user user)
        {
            try
            {
                string a = context.Database.SqlQuery<string>("Select dbo.ufn_GenerateNewUserId()").FirstOrDefault<string>();
                user.userId = a;
                context.users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool AddImage(productImage productImage)
        {
            try
            {
                var obj = (context.productImages.Where(x => x.productId == productImage.productId)).SingleOrDefault();
                obj.productImage1 = productImage.productImage1;
                obj.productImage2 = productImage.productImage2;
                obj.productImage3 = productImage.productImage3;
                obj.productImage4 = productImage.productImage4;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public string getUserId(string username)
        {
            try
            {
                var a = context.users.Where(x => x.username == username).SingleOrDefault();
                return a.userId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public productImage GetProductImage(string productId)
        {
            productImage productImage;
            try
            {
                productImage = context.productImages.Where(x => x.productId == productId).Single<productImage>();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                productImage = null;
            }
            return productImage;
        }
        public string GetCategoryId(string categoryName)
        {
            string categoryId;
            try
            {
                categoryId = (from c in context.categories
                              where c.categoryName == categoryName
                              select c.categoryId).ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
            return categoryId;
        }
        public List<product> GetProductsByCategory(string categoryId)
        {
            List<product> lstProducts;
            try
            {
                lstProducts = (context.products.Where(x => x.categoryId == categoryId)).ToList<product>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lstProducts = null;
            }
            return lstProducts;
        }
        public List<productImage> GetAllProductImage()
        {
            List<productImage> lstProduct;
            try
            {
                lstProduct = (from c in context.productImages
                              select c).ToList<productImage>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lstProduct = null;
            }
            return lstProduct;
        }
        public List<user> GetAllUsers()
        {
            List<user> lstUser;
            try
            {
                lstUser = (from c in context.users
                              select c).ToList<user>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lstUser = null;
            }
            return lstUser;
        }
        public bool UpdatePassword(user user)
        {
            try
            {
                context.users.Where(x => x.userId == user.userId).SingleOrDefault().password = user.password;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateUsername(user user)
        {
            try
            {
                context.users.Where(x => x.userId == user.userId).SingleOrDefault().username = user.username;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public category GetCategory(string categoryId)
        {
            try
            {
                return (context.categories.Where(x => x.categoryId == categoryId)).SingleOrDefault<category>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public product GetProduct(string productId)
        {
            try
            {
                return context.products.Where(x => x.productId == productId).SingleOrDefault<product>();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw;
            }
        }
        public List<category> GetCategories()
        {
            List<category> lstCategory;
            try
            {
                lstCategory = (from c in context.categories
                               select c).ToList<category>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lstCategory = null;
            }
            return lstCategory;
        }
        public List<product> GetAllProduct()
        {
            List<product> lstProduct;
            try
            {
                lstProduct = (from c in context.products
                              select c).ToList<product>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                lstProduct = null;
            }
            return lstProduct;
        }
        public bool UpdateCategory(category category)
        {
            try
            {
                context.categories.Where(x => x.categoryId == category.categoryId).Single<category>().categoryName = category.categoryName;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool UpdateProduct(product product)
        {
            try
            {
                product obj = (context.products.Where(x => x.productId == product.productId)).SingleOrDefault();
                obj.productName = product.productName;
                obj.categoryId = product.categoryId;
                obj.productDesc = product.productDesc;
                obj.lPrice = product.lPrice;
                obj.mPrice = product.mPrice;
                obj.sPrice = product.sPrice;
                obj.vlPrice = product.vlPrice;
                obj.sRentPrice = product.sRentPrice;
                obj.mRentPrice = product.mRentPrice;
                obj.lRentPrice = product.lRentPrice;
                obj.vlRentPrice = product.vlRentPrice;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool DeleteProduct(product product)
        {
            try
            {
                productImage productImageObj = context.productImages.Where(x => x.productId == product.productId).SingleOrDefault<productImage>();
                product productObj = (context.products.Where(x => x.productId == product.productId)).SingleOrDefault<product>();
                context.productImages.Remove(productImageObj);
                context.products.Remove(productObj);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public bool DeleteCategory(category category)
        {
            List<product> lstProduct;
            category categoryObj;
            try
            {
                lstProduct = context.products.Where(x => x.categoryId == category.categoryId).ToList<product>();
                foreach(var item in lstProduct)
                {
                    DeleteProduct(item);
                }
                categoryObj = (context.categories.Where(x => x.categoryId == category.categoryId)).SingleOrDefault<category>();
                context.categories.Remove(categoryObj);
                
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
        //public  GetImagesCount()
        //{
            
        //    try
        //    {
        //       var lstImageCount = (from p in context.products
        //                         join
        //                          c in context.categories
        //                        on p.categoryId equals c.categoryId
        //                         join i in context.productImages
        //                         on p.productId equals i.productId
        //                         select new
        //                         {
        //                             productName = p.productName,
        //                             categoryName = c.categoryName,
        //                             imagesCount = (from l in context.productImages
        //                                            where l.productId == p.productId
        //                                            select l).Count(x => x.productImage1 == null
        //                                           || x.productImage2 == null)
        //                         }).ToList();


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        throw;
        //    }
        //    return lstImageCount;
        //}
        public int getProductCount()
        {
            try
            {
                return context.products.Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public List<productImage> GetProductImages()
        {
            //List<productImage> lstProductImages;
            try
            {
                return context.productImages.ToList<productImage>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
        public bool SaveImage(string productId,HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {

            try
            {
                var obj = (context.productImages.Where(x => x.productId == productId)).SingleOrDefault<productImage>();
                if(file1.ContentLength>0)
                    obj.productImage1 = ConvertToBytes(file1);
                if (file2.ContentLength > 0)
                    obj.productImage2 = ConvertToBytes(file2);
                if (file3.ContentLength > 0)
                    obj.productImage3 = ConvertToBytes(file3);
                if (file4.ContentLength > 0)
                    obj.productImage4 = ConvertToBytes(file4);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public bool DeleteImage(string productId, int i)
        {
            try
            {
                var obj = (context.productImages.Where(x => x.productId == productId)).SingleOrDefault<productImage>();
                if (i == 1)
                    obj.productImage1 = null;
                else if (i == 2)
                    obj.productImage2 = null;
                else if (i == 3)
                    obj.productImage3 = null;
                else
                    obj.productImage4 = null;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
        public byte[] GetPhoto(string productId, int i)
        {
            try
            {
                var obj = (context.productImages.Where(x => x.productId == productId)).SingleOrDefault<productImage>();
                if (i == 1)
                    return obj.productImage1;
                else if (i == 2)
                    return obj.productImage2;
                else if (i == 3)
                    return obj.productImage3;
                else
                    return obj.productImage4;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
