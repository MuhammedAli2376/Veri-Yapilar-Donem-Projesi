using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu_Agac.ORM
{
    public class DepartmanORM:Ana<Departman>
    {
        public DataTable Listele(int id)
        {
            SqlCommand komut = new SqlCommand("depertman_listele", Araclar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Connection.Open();
            komut.Parameters.AddWithValue("id", id);
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = komut;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            komut.Connection.Close();
            return dt;
        }
    }
}
