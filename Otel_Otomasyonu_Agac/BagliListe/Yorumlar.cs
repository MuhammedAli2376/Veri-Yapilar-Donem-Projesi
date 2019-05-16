using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu_Agac.BagliListe
{
   public  class Yorumlar:BagliListe
    {
        public Yorum InsertFirst(Yorum y)
        {
            //Node tmpHead = new Node
            //{
            //    Data = value
            //};

            if (YHead == null)
                YHead = y;
            else
            {
                //En kritik nokta: tmpHead'in next'i eski Head'i göstermeli
                y.Next = YHead;
                //Yeni Head artık tmpHead oldu
                YHead = y;
            }
            return YHead;
        }
    }
}
