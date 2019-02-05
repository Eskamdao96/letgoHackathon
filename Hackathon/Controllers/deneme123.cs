using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hackathon;

namespace Hackathon.Controllers
{
    public class deneme123 : Controller
    {
        private CodeNightEntities db = new CodeNightEntities();

        // GET: deneme123
        public ActionResult Index()
        {
            var tbl_Urun = db.Tbl_Urun.Include(t => t.Tbl_Kategori).Include(t => t.Tbl_Kullanici);
            return View(tbl_Urun.ToList());
        }

        // GET: deneme123/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Urun tbl_Urun = db.Tbl_Urun.Find(id);
            if (tbl_Urun == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Urun);
        }

        // GET: deneme123/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Tbl_Kategori, "KategoriId", "Adi");
            ViewBag.KullaniciID = new SelectList(db.Tbl_Kullanici, "KullaniciId", "Adi");
            return View();
        }

        // POST: deneme123/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrunId,Adi,Marka,KategoriID,Fiyat,Aciklama,Resim,SatildiMi,KullaniciID,Tarih")] Tbl_Urun tbl_Urun)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Urun.Add(tbl_Urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriID = new SelectList(db.Tbl_Kategori, "KategoriId", "Adi", tbl_Urun.KategoriID);
            ViewBag.KullaniciID = new SelectList(db.Tbl_Kullanici, "KullaniciId", "Adi", tbl_Urun.KullaniciID);
            return View(tbl_Urun);
        }

        // GET: deneme123/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Urun tbl_Urun = db.Tbl_Urun.Find(id);
            if (tbl_Urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.Tbl_Kategori, "KategoriId", "Adi", tbl_Urun.KategoriID);
            ViewBag.KullaniciID = new SelectList(db.Tbl_Kullanici, "KullaniciId", "Adi", tbl_Urun.KullaniciID);
            return View(tbl_Urun);
        }

        // POST: deneme123/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunId,Adi,Marka,KategoriID,Fiyat,Aciklama,Resim,SatildiMi,KullaniciID,Tarih")] Tbl_Urun tbl_Urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Tbl_Kategori, "KategoriId", "Adi", tbl_Urun.KategoriID);
            ViewBag.KullaniciID = new SelectList(db.Tbl_Kullanici, "KullaniciId", "Adi", tbl_Urun.KullaniciID);
            return View(tbl_Urun);
        }

        // GET: deneme123/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Urun tbl_Urun = db.Tbl_Urun.Find(id);
            if (tbl_Urun == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Urun);
        }

        // POST: deneme123/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Urun tbl_Urun = db.Tbl_Urun.Find(id);
            db.Tbl_Urun.Remove(tbl_Urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
