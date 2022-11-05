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

        // GET: Product
        public ActionResult Details(int ID)
        { 
            ProductDAO productDAO = new ProductDAO();

            ProductModel product = productDAO.FetchProduct(ID);

            return View("Details", product);
        }

        public ActionResult Create()
        {
            return View("ProductForm");
        }

        public ActionResult Edit(int ID)
        {
            ProductDAO productDAO = new ProductDAO();

            ProductModel product = productDAO.FetchProduct(ID);

            return View("ProductForm", product);
        }
        public ActionResult Delete(int ID)
        {
            ProductDAO productDAO = new ProductDAO();

            productDAO.Delete(ID);

            List<ProductModel> products = productDAO.FetchAll();

            return View("Index", products);
        }

        public ActionResult ProcessCreate(ProductModel productModel)
        {
            ProductDAO productDAO = new ProductDAO();

            productDAO.CreateOrUpdate(productModel);

            return View("Details", productModel);
        }
    }
}