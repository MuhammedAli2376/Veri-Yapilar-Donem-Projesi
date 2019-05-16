using Otel_Otomasyonu_Agac.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Otomasyonu_Agac.Ekran
{
    public partial class YorumForm : Form
    {
        public YorumForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yorum y = new Yorum();
            int id =  Araclar.AktifMusteri.id;
            int otelid = (int)label1.Tag;
            string yorum = textBox1.Text;
            y.Musterid = Araclar.AktifMusteri;
            YorumORM orm = new YorumORM();
            if (orm.Ekle(otelid,id,yorum))
                this.Close();
        }

        private void YorumForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
