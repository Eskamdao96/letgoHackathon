//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hackathon
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Urun()
        {
            this.Tbl_Favori = new HashSet<Tbl_Favori>();
            this.Tbl_UrunAl = new HashSet<Tbl_UrunAl>();
        }
    
        public int UrunId { get; set; }
        public string Adi { get; set; }
        public string Marka { get; set; }
        public Nullable<int> KategoriID { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public Nullable<bool> SatildiMi { get; set; }
        public Nullable<int> KullaniciID { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Favori> Tbl_Favori { get; set; }
        public virtual Tbl_Kategori Tbl_Kategori { get; set; }
        public virtual Tbl_Kullanici Tbl_Kullanici { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UrunAl> Tbl_UrunAl { get; set; }
    }
}
