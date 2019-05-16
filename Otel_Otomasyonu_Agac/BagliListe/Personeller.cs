using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu_Agac.BagliListe
{
    public class Personeller : BagliListe
    {
        public  Personel InsertFirst(Personel p)
        {
            //Node tmpHead = new Node
            //{
            //    Data = value
            //};

            if (PHead == null)
                PHead = p;
            else
            {
                //En kritik nokta: tmpHead'in next'i eski Head'i göstermeli
                p.next = PHead;
                //Yeni Head artık tmpHead oldu
                PHead = p;
            }
            return PHead;
        }
    }
}
