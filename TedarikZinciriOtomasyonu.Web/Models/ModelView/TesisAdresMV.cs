using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TedarikZinciriOtomasyonu.VarlikKatmani;

namespace TedarikZinciriOtomasyonu.Web.Models.ModelView
{
    public class TesisAdresMV
    {
        public adres Adres { get; set; }
        public uretimtesisi UretimTesisi{ get; set; }
    }
}