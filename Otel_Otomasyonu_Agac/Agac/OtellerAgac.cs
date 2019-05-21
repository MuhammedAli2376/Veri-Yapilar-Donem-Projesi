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
        public void Ekle(Otel kok,Otel yeni)
        {   if (yeni.Adi == null)
                return;
            if (Sırala(kok.Adi) < Sırala(yeni.Adi))
            {
                if (kok.Sag == null)
                {
                    kok.Sag = yeni;
                    return;
                }
                Ekle(kok.Sag,yeni);
            }
            else
            {
                if (kok.Sol == null)
                {
                    kok.Sol = yeni;
                    return;
                }
                Ekle(kok.Sol,yeni);
            }
        }
        public void OtelGetir(Otel dugum)
        {
            if (dugum == null)
                return;
            OtelGetir(dugum.Sol);
            OtelZiyaret(dugum);
            OtelGetir(dugum.Sag);
        }
        public static DataTable Oteltable = new DataTable();
        private void OtelZiyaret(Otel dugum)
        {
            PropertyInfo[] proplar = typeof(Otel).GetProperties();
            DataRow row = Oteltable.NewRow();
            foreach (PropertyInfo p in proplar)
            {
                row[p.Name] = p.GetValue(dugum);
            }
            Oteltable.Rows.Add(row);
        }
        public void YorumGetir(Otel dugum,int id)
        {
            if (dugum == null)
                return;
            if (dugum.id == id)
            {
                YorumZiyaret(dugum.Yorumlar);
                return;
            }
            YorumGetir(dugum.Sol,id);
            YorumGetir(dugum.Sag,id);
        }
       
        public static DataTable YorumTable = new DataTable();
        private  void YorumZiyaret(Yorum dugum)
        {
            if(YorumTable.Columns.Count==0)
            {
                YorumTable.Columns.Add("Musteri Adı");
                YorumTable.Columns.Add("Soyadı");
                YorumTable.Columns.Add("Eposta");
                YorumTable.Columns.Add("Yorumu");
            }
            if (dugum == null)
                return;
                DataRow row = YorumTable.NewRow();
                row["Musteri Adı"] = dugum.Musterid.Adi;
                row["Soyadı"] = dugum.Musterid.SoyAdi;
                row["Eposta"] = dugum.Musterid.Eposta;
                row["Yorumu"] = dugum.yorum;
                YorumTable.Rows.Add(row);
            YorumZiyaret(dugum.Next);
        }
        public void PersonelGetir(Otel dugum, int id)
        {
            if (dugum == null)
                return;
            if (dugum.id == id)
            {
                PersonelZiyaret(dugum.personeller);
                return;
            }
            PersonelGetir(dugum.Sol, id);
            PersonelGetir(dugum.Sag, id);
        }
        public static DataTable PersonelTable = new DataTable();
        private void PersonelZiyaret(Personel personeller)
        {
            if (PersonelTable.Columns.Count == 0)
            {
                PersonelTable.Columns.Add("Personel Adı");
                PersonelTable.Columns.Add("Personel Soyadı");
                PersonelTable.Columns.Add("Personel Eposta");
            }

            if (personeller == null)
                return;
                DataRow row = PersonelTable.NewRow();
                row["Personel Adı"] = personeller.Adi;
                row["Personel Soyadı"] = personeller.Soyadi;
                row["Personel Eposta"] = personeller.Eposta;
                PersonelTable.Rows.Add(row);
                PersonelZiyaret(personeller.next);
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
