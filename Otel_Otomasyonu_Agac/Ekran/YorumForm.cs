﻿using Otel_Otomasyonu_Agac.ORM;
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
        private void YorumForm_Load(object sender, EventArgs e)
        { 
            Otel otel = (Otel)label1.Tag;
            OtellerAgac agac = new OtellerAgac();
            OtellerAgac.YorumTable.Rows.Clear();
            agac.YorumGetir(otel, (int)data1.Tag);
            data1.DataSource = OtellerAgac.YorumTable;
        }
    }
}
