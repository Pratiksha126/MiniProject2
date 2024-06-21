using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject2.Models;
using MiniProject2.Services;

namespace MiniProject2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;
        private readonly ICategoryService service1;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

        public ProductController(IProductService service, ICategoryService service1, Microsoft.AspNetCore.Hosting.IHostingEnvironment e)
        {
            this.service = service;
            this.service1 = service1;
            this.env = e;

        }
        // GET: ProductController
        public ActionResult Index()
        {
            var model = service.GetAllProducts();
            return View(model);
            
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = service.GetProductById(id);
            return View(product);
           
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, IFormFile file)
        {
             try
            {
                using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fs);
                }
                product.ImageURL = "~/images/" + file.FileName;

                var pro = new Product
                {
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    Stock = product.Stock,
                    ImageURL = product.ImageURL,
					CategoryId = product.CategoryId,
					CategoryName = product.CategoryName,
                    Discount=product.Discount
                    
                };

                int result = service.AddProduct(pro);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Errormsg = "something went wrong";
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = service.GetProductById(id);
            HttpContext.Session.SetString("oldImageURL", product.ImageURL);

            return View(product);
            
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, IFormFile file)
        {
            

            try
            {
                string oldimageurl = HttpContext.Session.GetString("oldImageURL");
                if (file != null)
                {
                    using (var fs = new FileStream(env.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fs);
                    }
                    product.ImageURL = "~/images/" + file.FileName;

                    string[] str = oldimageurl.Split("/");
                    string str1 = (str[str.Length - 1]);
                    string path = env.WebRootPath + "\\images\\" + str1;
                    System.IO.File.Delete(path);


                }
                else
                {
                    product.ImageURL = oldimageurl;
                }
                var _product = new Product
                {
                    ProductId=product.ProductId,
                    ProductName=product.ProductName,
                    Price=product.Price,
                    ImageURL=product.ImageURL,

                     CategoryId=product.CategoryId,
                     CategoryName=product.CategoryName,
                     Discount=product.Discount,
                     Description=product.Description,
                     Stock=product.Stock

                     


                };
                int result = service.UpdateProduct(_product);

                if (result >= 1)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }


            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = service.GetProductById(id);
            return View(product);
            
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = service.DeleteProduct(id);

                if (result >= 1)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
    }
}
