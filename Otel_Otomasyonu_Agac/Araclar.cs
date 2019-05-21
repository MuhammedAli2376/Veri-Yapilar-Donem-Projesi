using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static void PropertyDoldur<T>(T entity, DataGridView data)
        {
            
            PropertyInfo[] proplar = typeof(T).GetProperties();
            foreach (PropertyInfo item in proplar)
            {
                if (item.PropertyType.Name == "String")
                    item.SetValue(entity, data.CurrentRow.Cells[item.Name].Value.ToString());
                else
                    item.SetValue(entity, Convert.ToInt32(data.CurrentRow.Cells[item.Name].Value.ToString()));
            }
        }
        public static void PropertyDoldur<T>(T entity, DataTable data,int i)
        {
            PropertyInfo[] proplar = typeof(T).GetProperties();

                foreach (PropertyInfo item in proplar)
                {
                    if (item.PropertyType.Name == "String")
                        item.SetValue(entity, data.Rows[i][item.Name].ToString());
                    else
                        item.SetValue(entity, Convert.ToInt32(data.Rows[i][item.Name].ToString()));
                }
        }
    }

}

