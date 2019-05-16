using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu_Agac.ORM
{
    public class YorumORM:Ana<Yorum>
    {
        public bool Ekle(int otelid,int musteriid,string yorum)
        {
            SqlCommand komut = new SqlCommand("Yorum_Ekle", Araclar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Otelid",otelid);
            komut.Parameters.AddWithValue("@Musterid", musteriid);
            komut.Parameters.AddWithValue("@Yorum", yorum);
            return Araclar.Calıstır(komut);
        }
    }
}
