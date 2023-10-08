using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rich_store.Core.Contracts;
using Rich_store.Core.Models;
using Rich_store.Core.View_Models;
using Rich_store.DataAccess.InMemory;

namespace Rich_store.UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        IRepository<Product> context;
        IRepository<ProductCategory> productCategories;
        public ProductController(IRepository<Product> productContext,
            IRepository<ProductCategory> categoryContext)
        {
            context = productContext;
            productCategories = categoryContext;
        }
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            ProductVM View_Models = new ProductVM();
            View_Models.Product = new Product();
            View_Models.ProductCategories = productCategories.Collection();
            return View(View_Models);
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }else
            {
                context.Insert(product);
                context.Comit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            Product product = context.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }else
            {
                ProductVM View_Models = new ProductVM();
                View_Models.Product = product;
                View_Models.ProductCategories = productCategories.Collection();
                return View(View_Models);
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
                if (!ModelState.IsValid)
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

        public ActionResult Delete(string id)
        {
            Product productToDelete = context.Find(id);
            if(productToDelete == null)
            {
                return HttpNotFound();
            }else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            Product productToDelete = context.Find(id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                context.Comit();
                return RedirectToAction("Index");
            }
        }
    }
}
       
      