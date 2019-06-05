using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TedarikZinciriOtomasyonu.VarlikKatmani.EkModel
{
    public class KullaniciGiris
    {
        [Required, MaxLength(15), DisplayName("Telefon No.")]
        public string TelefonNo { get; set; }

        [Required, MaxLength(25), DisplayName("Şifre"), DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}
