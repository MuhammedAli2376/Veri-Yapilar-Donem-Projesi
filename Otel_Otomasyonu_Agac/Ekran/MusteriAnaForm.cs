using HashUygulama;
using Microsoft.VisualBasic;
using Otel_Otomasyonu_Agac.Ekran;
using Otel_Otomasyonu_Agac.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Otomasyonu_Agac
{
    public partial class MusteriAnaForm : Form
    {
        public MusteriAnaForm()
        {
            InitializeComponent();
        }
        Otel otel;
        private void MusteriAnaForm_Load(object sender, EventArgs e)
        {
            otel = new Otel();
            OtelORM orm = new OtelORM();
            PropertyInfo[] proplar = typeof(Otel).GetProperties();
            foreach (PropertyInfo item in proplar)
            {
                OtellerAgac.Oteltable.Columns.Add(item.Name);
            }
            Aktar aktar = new Aktar();
            aktar.OtelAktar(orm.Listele(), otel);
            dataGridView1.DataSource = OtellerAgac.Oteltable;
            OtelGetir();
        }
        private void puanVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PuanForm frm = new PuanForm();
            OtelORM orm = new OtelORM();
            frm.ShowDialog();
            Otel otel = new Otel();
            Araclar.PropertyDoldur<Otel>(otel, dataGridView1);
            otel.OtelPuani = Convert.ToInt32(frm.button1.Tag);
            if (orm.Guncelle(otel, Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString())))
              dataGridView1.DataSource= orm.Listele();

        }
        private void yorumYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Yorum y = new Yorum();
            int id = Araclar.AktifMusteri.id;
            int otelid = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            string yorum = Interaction.InputBox(string.Format("{0} Oteline Yorum Yap", dataGridView1.CurrentRow.Cells["Adi"].Value.ToString()));
            y.Musterid = Araclar.AktifMusteri;
            YorumORM orm = new YorumORM();
            if (orm.Ekle(otelid, id, yorum))
            {
                MessageBox.Show("Başarılı");
                OtelORM orm1 = new OtelORM();
                dataGridView1.DataSource = orm1.Listele();
            }
                
        }
        private void yorumlaırıGosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YorumForm frm = new YorumForm();
            frm.data1.Tag = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            frm.label1.Tag = otel;
            frm.ShowDialog();
        }
        HashMapChain asd;
        void OtelGetir()
        {
            asd = new HashMapChain();
            DataTable table = OtellerAgac.Oteltable;
            Otel[] oteller = new Otel[table.Rows.Count];
           
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Otel otel = new Otel();  
                Araclar.PropertyDoldur<Otel>(otel, table,i);
                oteller[i] = otel;
                asd.OtelEkle(oteller[i].Il, oteller[i].Ilce, oteller[i]);
            }
        }
        private void BTNİleGore_Click(object sender, EventArgs e)
        {
           
            int Param = 0;
            if (textilce.Text == ""&&!radiopuan.Checked&&!radioyildiz.Checked)
                Param = 1;
          else  if (textilce.Text != "" && !radiopuan.Checked && !radioyildiz.Checked)
                Param = 2;
            else if (radiopuan.Checked && textilce.Text == "")
                Param = 3;
            else if (radiopuan.Checked && textilce.Text != "")
                Param = 4;
            else if (radioyildiz.Checked && textilce.Text == "")
                Param = 5;
            else
                Param = 6;
            DataTable dt = new DataTable();
            Otel[] otel = asd.OtelGetir(Param,textil.Text,textilce.Text);
            if (otel == null)
            {
                MessageBox.Show("Kayıt bulunamdı");
                return;
            }
            PropertyInfo[] proplar = typeof(Otel).GetProperties();
            DataRow row;
            for (int i = 0; i < otel.Length; i++)
            {
                row = dt.NewRow();
                foreach (PropertyInfo p in proplar)
                {
                    if (i == 0)
                        dt.Columns.Add(p.Name);
                    row[p.Name] = p.GetValue(otel[i]);
                }
                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
            textil.Text = String.Empty;
            textilce.Text = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            otel = new Otel();
            OtelORM orm = new OtelORM();
            PropertyInfo[] proplar = typeof(Otel).GetProperties();
            OtellerAgac.Oteltable.Columns.Clear();
            OtellerAgac.Oteltable.Rows.Clear();
            foreach (PropertyInfo item in proplar)
            {
                OtellerAgac.Oteltable.Columns.Add(item.Name);
            }
            Aktar aktar = new Aktar();
            aktar.OtelAktar(orm.Listele(), otel);
            dataGridView1.DataSource = OtellerAgac.Oteltable;
            OtelGetir();
            radiopuan.Checked = false;
            radioyildiz.Checked = false;
        }

        private void personelGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelForm frm = new PersonelForm();
            frm.label1.Tag = otel;
            frm.data1.Tag = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            frm.ShowDialog();
        }
    }
}
