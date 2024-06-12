using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject2.Models;
using MiniProject2.Services;

namespace MiniProject2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;  

        public ProductController(IProductService service)
        {
            this.service = service;
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
        public ActionResult Create(Product product)
        {
            using (var fs = new FileStream(_iHostEnv.WebRootPath + "\\images\\" + file.FileName, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fs);
            }
            try
            {
                int result = service.AddProduct(product);
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

            return View(product);
            
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                int result = service.UpdateProduct(product);

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
