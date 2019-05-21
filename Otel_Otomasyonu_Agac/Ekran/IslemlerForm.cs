using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Otel_Otomasyonu_Agac.ORM;
using Otel_Otomasyonu_Agac.BagliListe;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
namespace Otel_Otomasyonu_Agac
{
    public partial class IslemlerForm : Form
    {
        public IslemlerForm()
        {
            InitializeComponent();
        }
        private void IslemlerForm_Load(object sender, EventArgs e)
        {
        }

        private void eKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            OtelIslemForm  a = new OtelIslemForm();
            a.ShowDialog();
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtelORM orm = new OtelORM();
            if (orm.Sil(Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value)))
                MessageBox.Show("Silme Başarılı");
            else
                MessageBox.Show("HATA");
        }

        private void gUNCELLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtelIslemForm  frm = new OtelIslemForm();
            frm.button1.Tag= Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            Guncelle(frm);
        }
        private void pERSONELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ContextMenuStrip = contextMenuStrip2;
            PersonelORM porm = new PersonelORM();
            dataGridView1.DataSource = porm.Listele();
        }

        private void oTELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            OtelORM orm = new OtelORM();
            dataGridView1.DataSource = orm.Listele();
        }
       

        private void personelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelIslem p = new PersonelIslem();
            p.button2.Tag = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            p.ShowDialog();
        }

        private void personelSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personel p = new Personel();
            if (Sil(p))
                MessageBox.Show("Silme Başarılı");
            else
                MessageBox.Show("HATA");
        }

        private void personelGuncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelIslem per = new PersonelIslem();
            per.texadi.Tag = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            per.texsoyadi.Tag = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Otelid"].Value);
            Guncelle(per);
        }
        bool Sil(object a)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            if (a is Personel)
            {
                PersonelORM porm = new PersonelORM();
                return porm.Sil(id);
            }
                
            else
            {
                OtelORM oorm = new OtelORM();
                return oorm.Sil(id);
            }
        }
        void Guncelle(Form f)
        {
            int sayac = 0;
            foreach (Control item in f.Controls)
            {
                if (item is TextBox || item is ComboBox || item is MaskedTextBox)
                {
                    item.Text = dataGridView1.CurrentRow.Cells[++sayac].Value.ToString();
                }
            }
            if (f is PersonelIslem)
            {
                ((PersonelIslem)f).button1.Visible = false;
                ((PersonelIslem)f).button2.Visible = true;
            }
            else
            {
                ((OtelIslemForm)f).button1.Visible = false;
                ((OtelIslemForm)f).button2.Visible = true;
            }
            
            f.ShowDialog();
        }
        private void departmanaGöreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmanORM dorm = new DepartmanORM();
            toolStripComboBox1.ComboBox.BindingContext = this.BindingContext;
            toolStripComboBox1.ComboBox.DataSource = dorm.Listele();
            toolStripComboBox1.ComboBox.DisplayMember = "Adi";
        }
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            toolStripComboBox1.ComboBox.ValueMember = "id";
            DepartmanORM dorm = new DepartmanORM();
            dataGridView1.DataSource = dorm.Listele(Convert.ToInt32(toolStripComboBox1.ComboBox.SelectedValue));
        }
        private void puanVerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PersonelORM porm = new PersonelORM();
            Personel per = new Personel();
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
            Araclar.PropertyDoldur<Personel>(per, dataGridView1);
            string ad = dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
            try
            { per.Puan = Convert.ToInt32(Interaction.InputBox(string.Format("{0} Personeline Puan Ver", ad))); }
            catch { }
            porm.Guncelle(per, id);
            dataGridView1.DataSource= porm.Listele();
        }

        private void puanaGöreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter("sıralıgetir", Araclar.Baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
