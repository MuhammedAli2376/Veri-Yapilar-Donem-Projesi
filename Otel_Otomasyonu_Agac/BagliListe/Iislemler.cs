using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Otomasyonu_Agac
{
    interface Iislemler<T>
    {
        DataTable Listele();
        bool Ekle(T entity);
        bool Sil(int id);
        bool Guncelle(T entity,int id);
    }
}
