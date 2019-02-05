using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class UrunKullaniciViewModel
    {
        public Tbl_Kullanici Kullanici { get; set; }
        public Tbl_Urun Urun { get; set; }
    }
}