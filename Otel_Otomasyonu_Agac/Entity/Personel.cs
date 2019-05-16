using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu_Agac
{
   public  class Personel
    {
        public Personel next;
        public  int id { get; set; }
        public string Adi { get; set; } 
        public string Soyadi { get; set; }
        public int Puan { get; set; }
        public string TCKN { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Eposta { get; set; }
        public int Departmanid { get; set; }
        public int Pozisyonid { get; set; }
        public int Otelid { get; set; }
    }
}
