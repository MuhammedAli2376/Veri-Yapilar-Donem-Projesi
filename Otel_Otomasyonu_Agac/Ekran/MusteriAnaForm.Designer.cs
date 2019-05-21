namespace Otel_Otomasyonu_Agac
{
    partial class MusteriAnaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.puanVerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yorumYapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yorumlaırıGosterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personelGösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textil = new System.Windows.Forms.TextBox();
            this.textilce = new System.Windows.Forms.TextBox();
            this.lblil = new System.Windows.Forms.Label();
            this.lblilce = new System.Windows.Forms.Label();
            this.Ara = new System.Windows.Forms.Button();
            this.radioyildiz = new System.Windows.Forms.RadioButton();
            this.radiopuan = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 297);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(865, 408);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puanVerToolStripMenuItem,
            this.yorumYapToolStripMenuItem,
            this.yorumlaırıGosterToolStripMenuItem,
            this.personelGösterToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(236, 132);
            // 
            // puanVerToolStripMenuItem
            // 
            this.puanVerToolStripMenuItem.Name = "puanVerToolStripMenuItem";
            this.puanVerToolStripMenuItem.Size = new System.Drawing.Size(235, 32);
            this.puanVerToolStripMenuItem.Text = "Puan Ver";
            this.puanVerToolStripMenuItem.Click += new System.EventHandler(this.puanVerToolStripMenuItem_Click);
            // 
            // yorumYapToolStripMenuItem
            // 
            this.yorumYapToolStripMenuItem.Name = "yorumYapToolStripMenuItem";
            this.yorumYapToolStripMenuItem.Size = new System.Drawing.Size(235, 32);
            this.yorumYapToolStripMenuItem.Text = "Yorum Yap";
            this.yorumYapToolStripMenuItem.Click += new System.EventHandler(this.yorumYapToolStripMenuItem_Click);
            // 
            // yorumlaırıGosterToolStripMenuItem
            // 
            this.yorumlaırıGosterToolStripMenuItem.Name = "yorumlaırıGosterToolStripMenuItem";
            this.yorumlaırıGosterToolStripMenuItem.Size = new System.Drawing.Size(235, 32);
            this.yorumlaırıGosterToolStripMenuItem.Text = "Yorumlaırı Goster";
            this.yorumlaırıGosterToolStripMenuItem.Click += new System.EventHandler(this.yorumlaırıGosterToolStripMenuItem_Click);
            // 
            // personelGösterToolStripMenuItem
            // 
            this.personelGösterToolStripMenuItem.Name = "personelGösterToolStripMenuItem";
            this.personelGösterToolStripMenuItem.Size = new System.Drawing.Size(235, 32);
            this.personelGösterToolStripMenuItem.Text = "Personel Göster";
            this.personelGösterToolStripMenuItem.Click += new System.EventHandler(this.personelGösterToolStripMenuItem_Click);
            // 
            // textil
            // 
            this.textil.Location = new System.Drawing.Point(618, 111);
            this.textil.Name = "textil";
            this.textil.Size = new System.Drawing.Size(199, 22);
            this.textil.TabIndex = 2;
            // 
            // textilce
            // 
            this.textilce.Location = new System.Drawing.Point(618, 164);
            this.textilce.Name = "textilce";
            this.textilce.Size = new System.Drawing.Size(199, 22);
            this.textilce.TabIndex = 2;
            // 
            // lblil
            // 
            this.lblil.AutoSize = true;
            this.lblil.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblil.ForeColor = System.Drawing.Color.Silver;
            this.lblil.Location = new System.Drawing.Point(521, 111);
            this.lblil.Name = "lblil";
            this.lblil.Size = new System.Drawing.Size(36, 26);
            this.lblil.TabIndex = 5;
            this.lblil.Text = "İL:";
            // 
            // lblilce
            // 
            this.lblilce.AutoSize = true;
            this.lblilce.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblilce.ForeColor = System.Drawing.Color.Silver;
            this.lblilce.Location = new System.Drawing.Point(521, 164);
            this.lblilce.Name = "lblilce";
            this.lblilce.Size = new System.Drawing.Size(48, 25);
            this.lblilce.TabIndex = 5;
            this.lblilce.Text = "İlçe:";
            // 
            // Ara
            // 
            this.Ara.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ara.Location = new System.Drawing.Point(618, 216);
            this.Ara.Name = "Ara";
            this.Ara.Size = new System.Drawing.Size(199, 49);
            this.Ara.TabIndex = 6;
            this.Ara.Text = "ARA";
            this.Ara.UseVisualStyleBackColor = true;
            this.Ara.Click += new System.EventHandler(this.BTNİleGore_Click);
            // 
            // radioyildiz
            // 
            this.radioyildiz.AutoSize = true;
            this.radioyildiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioyildiz.ForeColor = System.Drawing.Color.Silver;
            this.radioyildiz.Location = new System.Drawing.Point(436, 63);
            this.radioyildiz.Name = "radioyildiz";
            this.radioyildiz.Size = new System.Drawing.Size(207, 29);
            this.radioyildiz.TabIndex = 8;
            this.radioyildiz.TabStop = true;
            this.radioyildiz.Text = "Yıldız Sayısına Göre";
            this.radioyildiz.UseVisualStyleBackColor = true;
            // 
            // radiopuan
            // 
            this.radiopuan.AutoSize = true;
            this.radiopuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radiopuan.ForeColor = System.Drawing.Color.Silver;
            this.radiopuan.Location = new System.Drawing.Point(686, 63);
            this.radiopuan.Name = "radiopuan";
            this.radiopuan.Size = new System.Drawing.Size(142, 29);
            this.radiopuan.TabIndex = 8;
            this.radiopuan.TabStop = true;
            this.radiopuan.Text = "Puan\'a Göre";
            this.radiopuan.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(12, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 45);
            this.button1.TabIndex = 9;
            this.button1.Text = "Yenile";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MusteriAnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(865, 701);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radiopuan);
            this.Controls.Add(this.radioyildiz);
            this.Controls.Add(this.Ara);
            this.Controls.Add(this.lblilce);
            this.Controls.Add(this.lblil);
            this.Controls.Add(this.textilce);
            this.Controls.Add(this.textil);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MusteriAnaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MusteriAnaForm";
            this.Load += new System.EventHandler(this.MusteriAnaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem puanVerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yorumYapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yorumlaırıGosterToolStripMenuItem;
        private System.Windows.Forms.TextBox textil;
        private System.Windows.Forms.TextBox textilce;
        private System.Windows.Forms.Label lblil;
        private System.Windows.Forms.Label lblilce;
        private System.Windows.Forms.Button Ara;
        private System.Windows.Forms.RadioButton radioyildiz;
        private System.Windows.Forms.RadioButton radiopuan;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem personelGösterToolStripMenuItem;
    }
}