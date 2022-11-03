using decay_gaming_shop.Data;
using decay_gaming_shop.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace decay_gaming_shop.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<ProductModel> products = new List<ProductModel>();

            ProductDAO productDAO = new ProductDAO();

            products = productDAO.FetchAll();
            
            return View("Index", products);
        }
    }
}