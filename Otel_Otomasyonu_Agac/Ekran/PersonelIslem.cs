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
    public partial class PersonelIslem : Form
    {
        public PersonelIslem()
        {
            InitializeComponent();
        }
        PersonelORM porm = new PersonelORM();
        private void button1_Click(object sender, EventArgs e)
        {
            Personel p = new Personel();
            p.Adi = texadi.Text;
            p.Soyadi = texsoyadi.Text;
            p.Puan = Convert.ToInt32(texpuan.Text);
            p.TCKN =maskedtckn.Text;
            p.Telefon = maskedtel.Text;
            p.Adres = texadres.Text;
            p.Eposta = texeposta.Text;
            p.Departmanid =Convert.ToInt32(cmbdepartman.SelectedValue);
            p.Pozisyonid = (int)cmbpozisyon.SelectedValue;
            p.Otelid = Convert.ToInt32(button2.Tag);
            if (porm.Ekle(p))
                MessageBox.Show("Ekleme Başarılı");
            else
                MessageBox.Show("HATA");
        }

        private void PersonelIslem_Load(object sender, EventArgs e)
        {
            DepartmanORM dorm = new DepartmanORM();
            cmbdepartman.DataSource = dorm.Listele();
            cmbdepartman.ValueMember = "id";
            cmbdepartman.DisplayMember = "Adi";
            PozisyonORM porm = new PozisyonORM();
            cmbpozisyon.DataSource = porm.Listele();
            cmbpozisyon.ValueMember = "id";
            cmbpozisyon.DisplayMember = "Adi";
            OtelORM orm = new OtelORM();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sayac = 0;
            var personel = new Personel();
            personel.Otelid = Convert.ToInt32(texsoyadi.Tag);
            PropertyInfo[] pr = typeof(Personel).GetProperties();
            foreach (Control item in Controls)
            {       
                if(item.Name=="texpuan")
                    pr[++sayac].SetValue(personel, Convert.ToInt32(item.Text));
               else if (item is TextBox || item is MaskedTextBox)
                    pr[++sayac].SetValue(personel,item.Text);
                else  if (item is ComboBox)
                    pr[++sayac].SetValue(personel, ((ComboBox)item).SelectedValue);
            }
            if (porm.guncelle(personel,(int)texadi.Tag))
                MessageBox.Show("Güncelleme Başarılı");
            else
                MessageBox.Show("HATA");
        }      
    }
}
