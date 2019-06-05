using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TedarikZinciriOtomasyonu.VarlikKatmani
{
    public class BlokZinciri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), DisplayName("Blok ID.")]
        public int BlokID { get; set; }

        [Required, DisplayName("Önceki Blok")]
        public string OncekiBlokID { get; set; }

        [Required, DisplayName("Hash Kodu")]
        public string HashKodu { get; set; }

        [Required, DisplayName("Farklılık Değişkeni")]
        public int FarkDegiskeni { get; set; }
 
        [Required, DisplayName("Oluşturma Tarihi")]
        public DateTime OlusturmaTarihi { get; set; }

        public virtual BlokZinciri OncekiBlok { get; set; }
    }
}
