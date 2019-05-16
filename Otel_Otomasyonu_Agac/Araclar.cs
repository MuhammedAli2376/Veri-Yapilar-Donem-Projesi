using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu_Agac
{
   public static class Araclar
    {
        private static SqlConnection baglanti { get; set; }
        public static SqlConnection Baglanti
        {
            get
            {
                if (baglanti == null)
                    baglanti = new SqlConnection("Server=DESKTOP-TO5VRLK\\SQLEXPRESS;Database=Otel_Otomasyonu_Agac;Integrated Security=true");
                return baglanti;
            }
        }
        public static bool Calıstır(SqlCommand komut)
        {
            try
            {
                if (komut.Connection.State == ConnectionState.Closed)
                    komut.Connection.Open();
                int etk = komut.ExecuteNonQuery();
                return etk > 0 ? true : false;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (komut.Connection.State == ConnectionState.Open)
                    komut.Connection.Close();
            }


        }
        public static Musteri AktifMusteri { get; set; }
        public static int id { get; set; }
    }

}

