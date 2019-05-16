using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace Otel_Otomasyonu_Agac
{
    public class OtellerAgac
    {
         int Sayac = 0;
        public void Ekle<T>(Otel kok,Otel yeni,int Yildizsayisi)
        {
            PropertyInfo[] pr = typeof(T).GetProperties();
            if (Sırala(kok.Adi) < Sırala(yeni.Adi))
            {
                if (kok.Sag == null)
                {
                    kok.Sag = new Otel();
                    foreach (PropertyInfo item in pr)
                    {
                        item.SetValue(kok.Sag, item.GetValue(yeni));
                    }
                    kok.Sag.personeller = yeni.personeller;
                    kok.Sag.Yorumlar = yeni.Yorumlar;
                    return;
                }
                Ekle<T>(kok.Sag,yeni,Yildizsayisi);
            }
            else
            {
                if (kok.Sol == null)
                {
                    kok.Sol = new Otel();
                    foreach (PropertyInfo item in pr)
                    {
                        item.SetValue(kok.Sol, item.GetValue(yeni));
                    }
                    kok.Sol.personeller = yeni.personeller;
                    kok.Sol.Yorumlar = yeni.Yorumlar;
                    return;
                }
                Ekle<T>(kok.Sol,yeni,Yildizsayisi);
            }
        }
        public void InOrderInt(Otel dugum)
        {
            if (dugum == null)
                return;
            InOrderInt(dugum.Sol);
            Ziyaret(dugum);
            InOrderInt(dugum.Sag);
        }
            public static DataTable table = new DataTable();
            PropertyInfo[] proplar = typeof(Otel).GetProperties();
            private void Ziyaret(Otel dugum)
            {
                DataRow row = table.NewRow();
                foreach (PropertyInfo p in proplar)
                {
                    row[p.Name]= p.GetValue(dugum);               
                }
                table.Rows.Add(row);
                Sayac++;
            }
        private int Sırala(string deger)
        {
            char[] karakterler = deger.ToCharArray();
            int sayac = 0;
            int gonder = 0;
            for (char i = 'a'; i < 'z'; i++)
            {
                if (karakterler[0] == i)
                    gonder = sayac;
                sayac++;
            }
            return gonder;
        }
    }
    
}
