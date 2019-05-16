using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Otel_Otomasyonu_Agac
{
    public class Ana<T> : Iislemler<T>
    {
        PropertyInfo[] Proplar = typeof(T).GetProperties();
        
        public bool Ekle(T entity)
        {
            SqlCommand komut = new SqlCommand(string.Format("{0}_ekle",typeof(T).Name),Araclar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            foreach (PropertyInfo p in Proplar)
            {
                string adi = p.Name;
                Object deger = p.GetValue(entity);
                komut.Parameters.AddWithValue("@"+adi, deger);
            }
            return Araclar.Calıstır(komut);

        }

        public bool Guncelle(T entity,int id)
        {
            SqlCommand komut = new SqlCommand(string.Format("{0}_Guncelle", typeof(T).Name), Araclar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            foreach (PropertyInfo p in Proplar)
            {
                string adi = p.Name;
                Object deger = p.GetValue(entity);
                komut.Parameters.AddWithValue("@" + adi, deger);
            }
            return Araclar.Calıstır(komut);
        }

        public DataTable Listele()
        {
            string adi = typeof(T).Name;
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("{0}_listele",adi), Araclar.Baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
            
        }

        public bool Sil(int id)
        {
            SqlCommand komut = new SqlCommand(string.Format("{0}_sil", typeof(T).Name), Araclar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", id);
            return Araclar.Calıstır(komut);
        }
    }
}
