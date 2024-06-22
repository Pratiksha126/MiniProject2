using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniProject2.Data;
using MiniProject2.Models;
using MiniProject2.Services;

namespace MiniProject2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ApplicationDbContext context;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

        public ProductController(IProductService productService, 
            ICategoryService categoryService,
            ApplicationDbContext context,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment e)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.context = context;
            this.env = e;

        }
        // GET: ProductController
        public ActionResult Index()
        {
           
            var model = productService.GetAllProducts();
            return View(model);
            
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = productService.GetProductById(id);
            return View(product);
           
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(context.Categories, "CategoryId", "CategoryName");
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
                    Discount=product.Discount
                    
                };

                int result = productService.AddProduct(pro);
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
            var product = productService.GetProductById(id);
            HttpContext.Session.SetString("oldImageURL", product.ImageURL);
            ViewData["CategoryId"] = new SelectList(context.Categories, "CategoryId", "CategoryName");
            return View(product);
            
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product, IFormFile file)
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
                     Discount=product.Discount,
                     Description=product.Description,
                     Stock=product.Stock

                     


                };
                int result = productService.UpdateProduct(_product);

                if (result >= 1)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["CategoryId"] = new SelectList(context.Categories, "CategoryId", "CategoryName");
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
            var product = productService.GetProductById(id);
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
                int result = productService.DeleteProduct(id);

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
