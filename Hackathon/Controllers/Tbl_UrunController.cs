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
    public class Tbl_UrunController : Controller
    {
        private CodeNightEntities db = new CodeNightEntities();

        // GET: Tbl_Urun
        public ActionResult Index()
        {
            var tbl_Urun = db.Tbl_Urun.Include(t => t.Tbl_Kategori);
            return View(tbl_Urun.ToList());
        }

        // GET: Tbl_Urun/Details/5
        public ActionResult Details(int? id)
        {

            var kb = db.Tbl_Kullanici.FirstOrDefault(i => i.KullaniciAdi == "ahmet"); //ürünü ekleyen kişinin kullanıcı adı gelecek
            ViewBag.Konumx = kb.konumx;
            ViewBag.Konumy = kb.konumt;
            


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

        // GET: Tbl_Urun/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Tbl_Kategori, "KategoriId", "Adi");
            return View();
        }

        // POST: Tbl_Urun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrunId,Adi,Marka,KategoriID,Fiyat,Aciklama,SatildiMi,Resim,KullaniciID")] Tbl_Urun tbl_Urun)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Urun.Add(tbl_Urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriID = new SelectList(db.Tbl_Kategori, "KategoriId", "Adi", tbl_Urun.KategoriID);
            return View(tbl_Urun);
        }

        // GET: Tbl_Urun/Edit/5
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
            return View(tbl_Urun);
        }

        // POST: Tbl_Urun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrunId,Adi,Marka,KategoriID,Fiyat,Aciklama,SatildiMi,Resim,KullaniciID")] Tbl_Urun tbl_Urun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Urun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriID = new SelectList(db.Tbl_Kategori, "KategoriId", "Adi", tbl_Urun.KategoriID);
            return View(tbl_Urun);
        }

        // GET: Tbl_Urun/Delete/5
        public ActionResult Delete(int? id)
        {

            ViewBag.KullaniciBilgi = db.Tbl_Kullanici.FirstOrDefault(i => i.KullaniciAdi == "Mehmet");
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

        // POST: Tbl_Urun/Delete/5
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
