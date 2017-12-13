using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTalo.Models
{
    public class ValoViewModel
    {
        public int Id { get; set; }
        public string Koodi { get; set; }
        public string Tyyppi { get; set; }
        public string Tila { get; set; }
        public int? Valonmaara { get; set; }
    }
}