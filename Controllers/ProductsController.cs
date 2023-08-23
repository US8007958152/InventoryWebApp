using InventoryWebApp.BusinessLogicLayer;
using InventoryWebApp.Common;
using InventoryWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private IProduct _Product;

        public ProductsController(IProduct product)
        {
            _Product = product;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            IEnumerable<Product> products = _Product.GetProducts();
            return View("GetProducts", products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var userProfile = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "UserProfile");
            if(userProfile == null)
                return RedirectToAction("GetProducts");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.SalesPrice = (product.CostPrice * Convert.ToDecimal(122.50 / 100)) + (10 * product.CostPrice / 100);
                    _Product.Create(product);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("GetProducts");
        }

        [HttpGet]
        public IActionResult Update(int productId)
        {
            var userProfile = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "UserProfile");
            if (userProfile == null)
                return RedirectToAction("GetProducts");
            Product product=_Product.GetProductById(productId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.SalesPrice = (product.CostPrice * Convert.ToDecimal(122.50 / 100)) + (10 * product.CostPrice / 100);
                    _Product.Update(product);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("GetProducts");
        }


        [HttpGet]
        public IActionResult Delete(int productId)
        {
            _Product.Delete(productId);
            return RedirectToAction("GetProducts");
        }
    }
}
