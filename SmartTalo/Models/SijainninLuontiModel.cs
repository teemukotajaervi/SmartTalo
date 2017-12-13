using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTalo.Models
{
    public class SijainninLuontiModel
    {
        public string Koodi { get; set; }
        public string Nimi { get; set; }
        public string Osoite { get; set; }
        public int TavoiteLampotila { get; set; }
        public int NykyLampotila { get; set; }


    }
}