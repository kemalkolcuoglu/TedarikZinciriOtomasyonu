//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TedarikZinciriOtomasyonu.VarlikKatmani
{
    using System;
    using System.Collections.Generic;
    
    public partial class urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public urun()
        {
            this.talep = new HashSet<talep>();
        }
    
        public int UrunID { get; set; }
        public int UrunKategoriID { get; set; }
        public Nullable<int> UretimTesisiID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklama { get; set; }
        public string UrunBirimi { get; set; }
        public Nullable<float> UrunFiyati { get; set; }
        public Nullable<float> Stok { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<talep> talep { get; set; }
        public virtual uretimtesisi uretimtesisi { get; set; }
        public virtual urunkategori urunkategori { get; set; }
    }
}