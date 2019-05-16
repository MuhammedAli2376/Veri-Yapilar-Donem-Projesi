using Otel_Otomasyonu_Agac.BagliListe;
using Otel_Otomasyonu_Agac.ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu_Agac
{
  public static class Aktar
    {
      public static void OtelAktar(DataTable dt,Otel kok)
        {
            
            PersonelAktar();
            YorumAktar();
            int sayac = 0;
            int sutun = dt.Rows.Count;
            OtellerAgac ana = new OtellerAgac();
            PropertyInfo[] pr = typeof(Otel).GetProperties();
            for (int i = 0; i < sutun; i++)
            {
                Personeller personeller = new Personeller();
                Yorumlar yorumlar = new Yorumlar();
                Otel dal = new Otel();
                foreach (PropertyInfo item in pr)
                {
                    if (i == 0)
                    {
                        if (item.PropertyType.Name == "String")
                        {
                            item.SetValue(kok, dt.Rows[i][sayac++].ToString());
                        }
                        else
                            item.SetValue(kok, Convert.ToInt32(dt.Rows[i][sayac++].ToString()));
                    }
                    else
                    {
                        if (item.PropertyType.Name == "String")
                            item.SetValue(dal, dt.Rows[i][sayac++].ToString());
                        else
                            item.SetValue(dal, Convert.ToInt32(dt.Rows[i][sayac++].ToString()));
                    }
                }
                if (i == 0)
                {
                    for (int k = 0; k < Pdizi.Length; k++)
                    {
                        if (kok.id == Pdizi[k].Otelid)
                            kok.personeller = personeller.InsertFirst(Pdizi[k]);
                    }
                    for(int h = 0; h < ydizi.Length; h++)
                    {
                        if (kok.id == ydizi[h].Otelid)
                            kok.Yorumlar = yorumlar.InsertFirst(ydizi[h]);
                    }
                }
                else
                {
                    for (int k = 0; k < Pdizi.Length; k++)
                    {
                        if (dal.id == Pdizi[k].Otelid)
                            dal.personeller = personeller.InsertFirst(Pdizi[k]);
                    }
                    for (int h = 0; h < ydizi.Length; h++)
                    {
                        if (dal.id == ydizi[h].Otelid)
                            dal.Yorumlar = yorumlar.InsertFirst(ydizi[h]);
                    }
                    ana.Ekle<Otel>(kok, dal, Convert.ToInt32(dt.Rows[i]["YildizSayisi"].ToString()));
                }
                sayac = 0;
            }
            ana.InOrderInt(kok);
        }
        public static Personel[] Pdizi = new Personel[0];
        private static void PersonelAktar()
        {
            DataTable pt = new DataTable();
            PersonelORM porm = new PersonelORM();
            pt = porm.Listele();
            int sayac = 0;
            int satır = pt.Rows.Count;
            PropertyInfo[] pr = typeof(Personel).GetProperties();
            for (int i = 0; i < satır; i++)
            {
                Personel personel = new Personel();
                foreach (PropertyInfo item in pr)
                {
                    if (item.PropertyType.Name == "String")
                        item.SetValue(personel, pt.Rows[i][sayac++].ToString());
                    else
                        item.SetValue(personel, Convert.ToInt32(pt.Rows[i][sayac++].ToString()));
                }
                Array.Resize(ref Pdizi, Pdizi.Length + 1);
                Pdizi[i] = personel;
                sayac = 0;
            }
        }
        public static Yorum[] ydizi = new Yorum[0];
        private static void YorumAktar()
        {
            MusteriAktar();
            DataTable dy = new DataTable();
            YorumORM yorm = new YorumORM();
            Yorumlar yorumlar = new Yorumlar();
            dy = yorm.Listele();
            int satır = dy.Rows.Count;
            for (int i = 0; i < satır; i++)
            {
                Yorum yorum = new Yorum();
                for(int k = 0; k < mdizi.Length; k++)
                {
                    if (Convert.ToInt32(dy.Rows[i]["Musteriid"]) == mdizi[k].id)
                    {
                        yorum.Musterid = mdizi[k];
                        yorum.yorum = dy.Rows[i]["Yorum"].ToString();
                    }
                }
                yorum.Otelid = Convert.ToInt32(dy.Rows[i]["Otelid"]);
                Array.Resize(ref ydizi, ydizi.Length + 1);
                ydizi[i] = yorum;
                
            }
        }
        public static Musteri[] mdizi = new Musteri[0];
        private static void MusteriAktar()
        {
            DataTable dm = new DataTable();
            MusteriORM morm = new MusteriORM();
            dm = morm.Listele();
            int sayac = 0;
            int satır = dm.Rows.Count;
            PropertyInfo[] pr = typeof(Musteri).GetProperties();
            for (int i = 0; i < satır; i++)
            {
                Musteri musteri = new Musteri();
                foreach (PropertyInfo item in pr)
                {
                    if (item.PropertyType.Name == "String")
                        item.SetValue(musteri, dm.Rows[i][sayac++].ToString());
                    else
                        item.SetValue(musteri, Convert.ToInt32(dm.Rows[i][sayac++].ToString()));
                }
                Array.Resize(ref mdizi, mdizi.Length + 1);
                mdizi[i] = musteri;
                sayac = 0;
            }
        }
    }
}
