using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashUygulama
{
    public class LinkedHashEntry
    {
        public object deger { get; set; }
        public string Anahtar1 { get; set; }
        public string Anahtar2 { get; set; }
        public LinkedHashEntry Next { get; set; }
        public LinkedHashEntry(string  ıl,string ılce, object deger)
        {
            Anahtar1 = ıl;
            Anahtar2 = ılce;
            this.deger = deger;
            this.Next = null;
        }

    }
}
