using Otel_Otomasyonu_Agac.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Otomasyonu_Agac
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        //deneeeee
        private void button2_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            MusteriORM orm = new MusteriORM();
            musteri.Adi = texadi.Text;
            musteri.SoyAdi = texsoyadi.Text;
            musteri.Eposta = texeposta.Text;
            musteri.Parola = texparola.Text;
            if (orm.Ekle(musteri))
                MessageBox.Show("Kayıt Ekleme Başarılı");
            else
                MessageBox.Show("Hata");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            string deger;
            if (radioButton1.Checked)
                deger = "Musteri";
            else
                deger = "Yetkili";
            komut.CommandText = string.Format("select*from {0} where Eposta='{1}' and Parola='{2}'",deger,gtexeposta.Text,gtexparola.Text);
            komut.Connection = Araclar.Baglanti;
            komut.Connection.Open();
            SqlDataReader oku = komut.ExecuteReader();
            if (deger=="Yetkili"&&oku.Read())
            {
                IslemlerForm ıslem = new IslemlerForm();
                komut.Connection.Close();
                ıslem.Show();
                this.Hide();
            }
            else if(deger=="Musteri"&&oku.Read())
            {
                MusteriAnaForm m = new MusteriAnaForm();
                Musteri musteri = new Musteri();
                PropertyInfo []p = typeof(Musteri).GetProperties();
                int sayac = 0;
                foreach (PropertyInfo item in p)
                {
                    if (item.PropertyType.Name == "String")
                        item.SetValue(musteri, oku[sayac++].ToString());
                    else
                        item.SetValue(musteri, Convert.ToInt32(oku[sayac++].ToString()));
                }
                Araclar.AktifMusteri = musteri;
                komut.Connection.Close();
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı adı veya Parola");
                komut.Connection.Close();
            }
        }
        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
