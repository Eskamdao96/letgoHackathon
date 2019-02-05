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
    public class Tbl_Urun2Controller : Controller
    {
        private CodeNightEntities db = new CodeNightEntities();

        // GET: Tbl_Urun2
        public ActionResult Index()
        {
            var tbl_Urun = db.Tbl_Urun.Include(t => t.Tbl_Kategori).Include(t => t.Tbl_Kullanici);
            return View(tbl_Urun.ToList());
        }

        // GET: Tbl_Urun2/Details/5
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

        // GET: Tbl_Urun2/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Tbl_Kategori, "KategoriId", "Adi");
            ViewBag.KullaniciID = new SelectList(db.Tbl_Kullanici, "KullaniciId", "Adi");
            return View();
        }

        // POST: Tbl_Urun2/Create
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

        // GET: Tbl_Urun2/Edit/5
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


        public ActionResult AldigimUrunler()
        {
           
            var alinanurunler = db.Tbl_UrunAl.Include(k=>k.Tbl_Kullanici).Include(u=>u.UrunID);
            return View(alinanurunler);

        }
        [HttpPost]
        public ActionResult FavoriEkle(int urunid)
        {
            var urun = db.Tbl_Urun.FirstOrDefault(i => i.UrunId == urunid);
            db.Tbl_Favori.Add(urun);

        }

        public ActionResult Favorilerim()
        {
           
            var favorilerim = db.Tbl_Favori.Include(k => k.Tbl_Kullanici).Include(u => u.UrunID);
            return View(favorilerim);
        }


        // POST: Tbl_Urun2/Edit/5
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

        // GET: Tbl_Urun2/Delete/5
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

        // POST: Tbl_Urun2/Delete/5
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
