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
        private void MusteriAnaForm_Load(object sender, EventArgs e)
        {
            Otel otel = new Otel();
            OtelORM orm = new OtelORM();
            PropertyInfo[] proplar = typeof(Otel).GetProperties();
            foreach (PropertyInfo item in proplar)
            {
               OtellerAgac.table.Columns.Add(item.Name);
            }
            Aktar.OtelAktar(orm.Listele(), otel);
            dataGridView1.DataSource = OtellerAgac.table;
            OtelGetir();
        }
        private void puanVerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PuanForm frm = new PuanForm();
            OtelORM orm = new OtelORM();
            frm.ShowDialog();
            Otel otel = new Otel();
            PropertyInfo[] proplar = typeof(Otel).GetProperties();
            foreach (PropertyInfo item in proplar)
            {
                if(item.PropertyType.Name=="String")
                    item.SetValue(otel, dataGridView1.CurrentRow.Cells[item.Name].Value.ToString());
                else
                    item.SetValue(otel, Convert.ToInt32(dataGridView1.CurrentRow.Cells[item.Name].Value.ToString()));
            }
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
                MessageBox.Show("Başarılı");
        }
        private void yorumlaırıGosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YorumForm frm = new YorumForm();
            frm.label1.Tag = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            frm.ShowDialog();
        }
        HashMapChain asd = new HashMapChain();
        void OtelGetir()
        {
            DataTable table = OtellerAgac.table;
            table = OtellerAgac.table;
            Otel[] oteller = new Otel[table.Rows.Count];
            PropertyInfo[] proplar = typeof(Otel).GetProperties();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int sayac = 0;
                Otel otel = new Otel();
                foreach (PropertyInfo item in proplar)
                {
                    if (item.PropertyType.Name == "String")
                        item.SetValue(otel, table.Rows[i][sayac++].ToString());
                    else
                        item.SetValue(otel, Convert.ToInt32(table.Rows[i][sayac++].ToString()));
                }
                oteller[i] = otel;
            }

            for (int h = 0; h < oteller.Length; h++)
            {
                asd.OtelEkle(oteller[h].Il, oteller[h].Ilce, oteller[h]);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Otel[] otel = asd.il_ve_ilceye_gore(textil.Text, textilce.Text);
            if (otel==null)
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
        int Param=0;
        private void BTNİleGore_Click(object sender, EventArgs e)
        {
            Param = 1;
            if (textilce.Text != ""&&!radiopuan.Checked&&!radioyildiz.Checked)
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
    }
}
