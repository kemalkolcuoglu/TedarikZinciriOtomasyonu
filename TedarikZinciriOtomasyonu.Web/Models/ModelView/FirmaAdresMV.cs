using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TedarikZinciriOtomasyonu.VarlikKatmani;

namespace TedarikZinciriOtomasyonu.Web.Models.ModelView
{
    public class FirmaAdresMV
    {
        public firma firma { get; set; }

        public adres adres { get; set; }
    }
}