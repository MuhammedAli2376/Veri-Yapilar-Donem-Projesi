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
    public partial class OtelIslemForm : Form
    {
        public OtelIslemForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var otel = new Otel();
            OtelORM orm = new OtelORM();
            Aktar(otel);
            if (orm.Ekle(otel))
                MessageBox.Show("Ekleme Başarılı");
            else
                MessageBox.Show("HATA");
        }
        void Aktar(Otel otel)
        {
            int sayac = 0;
            PropertyInfo[] pr = typeof(Otel).GetProperties();
            foreach (Control item in this.Controls)
            {
                if (item is TextBox || item is MaskedTextBox)
                    pr[++sayac].SetValue(otel, item.Text);
                else if (item is ComboBox)
                    pr[++sayac].SetValue(otel, ((ComboBox)item).SelectedValue);
                else if (item is NumericUpDown)
                    pr[++sayac].SetValue(otel, (Convert.ToInt32(item.Text)));
            }
        }
        private void OtelIslemForm_Load(object sender, EventArgs e)
        {
            OdaTip od = new OdaTip();
            OdaTipORM orm = new OdaTipORM();
            comboBox1.DataSource = orm.Listele();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "Adi";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Otel otel = new Otel();
            OtelORM orm = new OtelORM();
            Aktar(otel);
            otel.id = Convert.ToInt32(button1.Tag);
            if (orm.Guncelle(otel, Convert.ToInt32(button1.Tag)))
                MessageBox.Show("Guncelleme Başarılı");
            else
                MessageBox.Show("HATA");
        }
    }
}
