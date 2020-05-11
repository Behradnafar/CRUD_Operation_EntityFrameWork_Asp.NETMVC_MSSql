using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using System.IO;   //For using PATH to upload IMG

namespace MyCms.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        private IPageRespository pageRepository;
        private IPageGroupRepository pageGroupRepository;
        private MyCmsContext db = new MyCmsContext();
        public PagesController()
        {
            pageRepository = new PageRepository(db);
            pageGroupRepository = new PageGroupRepository(db);
        }

        // GET: Admin/Pages
        public ActionResult Index()
        {
            return View(pageRepository.GetAllPage());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(pageGroupRepository.GetAllGroups(), "GroupId", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OageId,GroupId,Title,ShortDescription,PageText,Visit,ImageName,ShowInSlider,CreateDate,Tags")] Page page,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateDate = DateTime.Now;
                if (imgUp != null)
                {
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName); // Create new name and find the suffix of IMG
                    imgUp.SaveAs(Server.MapPath("/PageImages/" + page.ImageName));
                }
                pageRepository.InsertPage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(db.PageGroups, "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(pageGroupRepository.GetAllGroups(), "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OageId,GroupId,Title,ShortDescription,PageText,Visit,ImageName,ShowInSlider,CreateDate,Tags")] Page page,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if(page.ImageName!=null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
                    }

                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName); // Edit new name and find the suffix of IMG
                    imgUp.SaveAs(Server.MapPath("/PageImages/" + page.ImageName));
                }
                pageRepository.UpdatePage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(db.PageGroups, "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page =pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var page = pageRepository.GetPageById(id);
            if (page.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
            }
            pageRepository.DeletePage(page);
            pageRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageGroupRepository.Dispose();
                pageRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
