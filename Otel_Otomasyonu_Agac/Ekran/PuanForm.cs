using Otel_Otomasyonu_Agac.Entity;
using Otel_Otomasyonu_Agac.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Otomasyonu_Agac.Ekran
{
    public partial class PuanForm : Form
    {
        public PuanForm()
        {
            InitializeComponent();
        }

        private void PuanForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int puani = 0;
            foreach (Control item in Controls)
            {
                if (item is RadioButton)
                    if (((RadioButton)item).Checked)
                        puani = Convert.ToInt32(item.Tag);
            }
            button1.Tag = puani;
            this.Close();
        }
    }
}
