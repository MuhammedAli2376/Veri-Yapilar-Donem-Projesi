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
  public  class Aktar
    {
      public void OtelAktar(DataTable dt,Otel kok)
        {
            OtellerAgac ana = new OtellerAgac();
            PersonelAktar();
            YorumAktar();
            int sutun = dt.Rows.Count;
            for (int i = 0; i < sutun; i++)
            {
                Personeller personeller = new Personeller();
                Yorumlar yorumlar = new Yorumlar();
                Otel dal = new Otel();
                if (i == 0)
                {
                    Araclar.PropertyDoldur<Otel>(kok, dt, i);
                    for (int k = 0; k < Pdizi.Length; k++)
                        if (kok.id == Pdizi[k].Otelid)
                            kok.personeller = personeller.InsertFirst(Pdizi[k]);
                    for(int h = 0; h < ydizi.Length; h++)
                        if (kok.id == ydizi[h].Otelid)
                            kok.Yorumlar = yorumlar.InsertFirst(ydizi[h]);
                }
                else
                {
                    Araclar.PropertyDoldur<Otel>(dal, dt, i);
                    for (int k = 0; k < Pdizi.Length; k++)
                        if (dal.id == Pdizi[k].Otelid)
                            dal.personeller = personeller.InsertFirst(Pdizi[k]);
                    for (int h = 0; h < ydizi.Length; h++)
                        if (dal.id == ydizi[h].Otelid)
                            dal.Yorumlar = yorumlar.InsertFirst(ydizi[h]);
                    ana.Ekle(kok, dal);
                }
            }
            ana.OtelGetir(kok);
        }
        private  Personel[] Pdizi;
        private  void PersonelAktar()
        {
            Pdizi = new Personel[0];
            DataTable pt = new DataTable();
            PersonelORM porm = new PersonelORM();
            pt = porm.Listele();
            int satır = pt.Rows.Count;
            
            for (int i = 0; i < satır; i++)
            {
                Personel personel = new Personel();
                Araclar.PropertyDoldur<Personel>(personel, pt, i);
                Array.Resize(ref Pdizi, Pdizi.Length + 1);
                Pdizi[i] = personel;
            }
        }
        private  Yorum[] ydizi;
        private  void YorumAktar()
        {
            ydizi = new Yorum[0];
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
       private  Musteri[] mdizi;
        private  void MusteriAktar()
        {
            mdizi = new Musteri[0]; 
            DataTable dm = new DataTable();
            MusteriORM morm = new MusteriORM();
            dm = morm.Listele();
            int satır = dm.Rows.Count;
            for (int i = 0; i < satır; i++)
            {
                Musteri musteri = new Musteri();
                Araclar.PropertyDoldur<Musteri>(musteri, dm, i);
                Array.Resize(ref mdizi, mdizi.Length + 1);
                mdizi[i] = musteri;
            }
        }
    }
}
