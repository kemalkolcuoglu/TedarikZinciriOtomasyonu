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
    
    public partial class tesiskategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tesiskategori()
        {
            this.uretimtesisi = new HashSet<uretimtesisi>();
        }
    
        public int TesisKategoriID { get; set; }
        public string TesisKategoriAdi { get; set; }
        public string TesisKategoriAciklama { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<uretimtesisi> uretimtesisi { get; set; }
    }
}