using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu_Agac.ORM
{
   public class PersonelORM:Ana<Personel>
    {
        public bool guncelle(Personel personel,int id)
        {
            PropertyInfo[] Proplar = typeof(Personel).GetProperties();
            SqlCommand komut = new SqlCommand(string.Format("{0}_Guncelle", typeof(Personel).Name), Araclar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", id);
            foreach (PropertyInfo p in Proplar)
            {
                string adi = p.Name;
                if (adi == "id")
                    continue;
                Object deger = p.GetValue(personel);
                komut.Parameters.AddWithValue("@" + adi, deger);
            }
            return Araclar.Calıstır(komut);
        }
    }
}
