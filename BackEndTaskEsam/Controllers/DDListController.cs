using BackEndTaskEsam.Models.DbModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackEndTaskEsam.Controllers
{
    public class DDListController : Controller
    {
        // GET: DDList
        private BookShopEntities _db = new BookShopEntities();
        public ActionResult Index()
        {
            ViewBag.Categories = _db.Categories;
            ViewBag.Books = new List<Book>();
            return View();
        }
        public JsonResult JsonResult(string id)
        {
            int intId = int.Parse(id);
            var obj = _db.Books.Where(book=>book.CategoryId==intId).ToList();
            string json = JsonConvert.SerializeObject(obj);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}