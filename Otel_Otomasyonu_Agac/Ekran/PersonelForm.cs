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
    public partial class PersonelForm : Form
    {
        public PersonelForm()
        {
            InitializeComponent();
        }
        private void PersonelForm_Load(object sender, EventArgs e)
        {
            Otel otel = (Otel)label1.Tag;
            OtellerAgac agac = new OtellerAgac();
            OtellerAgac.PersonelTable.Rows.Clear();
            agac.PersonelGetir(otel, (int)data1.Tag);
            data1.DataSource = OtellerAgac.PersonelTable;
        }
    }
}
