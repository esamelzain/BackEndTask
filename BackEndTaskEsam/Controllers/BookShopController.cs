using BackEndTaskEsam.Models.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackEndTaskEsam.Controllers
{
    public class BookShopController : ApiController
    {
        private BookShopEntities _db = new BookShopEntities();
        [HttpPost]
        public List<Book> GetBooksByLINQ()
        {
            try
            {
                var Books = _db.Books.ToList();
                return Books;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpPost]
        public object GetCatFormStored()
        {
            try
            {
                return _db.GetCats();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
