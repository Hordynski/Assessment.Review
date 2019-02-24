using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assessment.Review.DAL;
using Assessment.Review.Models;
using Assessment.Review.Services;

namespace Assessment.Review.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductServices _service;

        public ProductsController(IProductServices service)
        {
            _service = service;
        }

        // GET: Products
        public async Task<ActionResult> Index()
        {
            return View(await _service.Get());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Product product = await _service.Get(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Order(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewData["ID"] = id;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Order(Inventory inventory)
        {
            await _service.UpdateInventory(inventory);
            return RedirectToAction("Details", new { ID = inventory.ID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
