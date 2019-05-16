using Otel_Otomasyonu_Agac.BagliListe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu_Agac
{
   public  class Otel
    {
        public Otel Sag;
        public Otel Sol;
        public  int id { get; set; }
        public string Adi { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public int YildizSayisi { get; set; }
        public int OdaSayisi { get; set; }
        public int OdaTipid { get; set; }
        public int OtelPuani { get; set; }
        public Personel personeller;
        public Yorum Yorumlar;
        public Otel()
        {
            Sag = null;
            Sol = null;
        }
    }
}
