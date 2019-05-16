using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu_Agac
{
  public class Yorum
    {
        public Yorum Next;
        public int Otelid { get; set; }
        public Musteri Musterid { get; set; }
        public string yorum { get; set; }
    }
   
}
    