using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.Data.Entity;

namespace MyCms.Controllers
{
    public class SearchController : Controller
    {
        private IPageRespository pageRepository;
        MyCmsContext db = new MyCmsContext();
        public SearchController()
        {
            pageRepository = new PageRepository(db);
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.name = q;
            return View(pageRepository.SearchPage(q));
        }
    }
}