using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hackathon.Controllers
{
   
    public class UrunApiController : ApiController
    {
        private CodeNightEntities db = new CodeNightEntities();

        [HttpGet]
        public IEnumerable<Tbl_Urun> GetUrunler()
        {
            return db.Tbl_Urun.ToList();
        }
        [HttpPost]
        public void PostEkle(Tbl_Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Urun.Add(urun);
            }
            
        }
    }
}
