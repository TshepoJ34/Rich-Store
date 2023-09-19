using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rich_store.Core.Contracts;
using Rich_store.Core.Models;
using Rich_store.DataAccess.InMemory;

namespace Rich_store.UI.Controllers
{
    public class CategoryController : Controller
    {
        Core.Contracts.IRepository<ProductCategory> context;
        public CategoryController(Core.Contracts.IRepository<ProductCategory> categoryContext)
        {
            context = categoryContext;
        }
        // GET: Category
        public ActionResult Index()
        {
            List<ProductCategory> categories = context.Collection().ToList();
            return View(categories);
        }
        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
                context.Comit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory CategoryToEdit = context.Find(Id);
            if (CategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                CategoryToEdit.Category = productCategory.Category;
                context.Comit();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory CategoryToDelete = context.Find(Id);
            if (CategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(CategoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory CategoryToDelete = context.Find(Id);
            if (CategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                return RedirectToAction("Index");
            }
        }
    }
}