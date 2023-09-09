using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rich_store.Core.Models;
using Rich_store.DataAccess.InMemory;

namespace Rich_store.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository context;
        public ProductController()
        {
            context = new ProductRepository();
        }
        // GET: Product
        public ActionResult Index()
        {   

            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                return View(product);
            }else
            {
                context.Insert(product);
                context.Comit();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }else
            {
                return View(product);
            }
        }
        [HttpPost]
        public ActionResult Edit(Product product, string Id)
        {
            Product prod = context.Find(Id);
            if (prod == null)
            {
                return HttpNotFound();
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return View(product);
                }
                prod.Category = product.Category;
                prod.Description = product.Description;
                prod.Image = product.Image;
                prod.Name = product.Name;
                prod.Price = product.Price;
                context.Comit();
                return RedirectToAction("Index");
            }
        }
    }
}