using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Police_Takip
{
    public partial class Custom_Tab_Control3_UC : UserControl
    {
        public Custom_Tab_Control3_UC()
        {
            InitializeComponent();
        }


        public void yetki_kontrol(int yetki)
        {
            if (yetki == 0) { guna2Button3.Visible = false; }
        }
        private void Custom_Tab_Control3_UC_Load(object sender, EventArgs e)
        {
            Police_Turleri_UC odm = new Police_Turleri_UC();

            odm.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(odm);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Police_Turleri_UC odm = new Police_Turleri_UC();

            odm.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(odm);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Sirketler_Listesi odm = new Sirketler_Listesi();

            odm.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(odm);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Kullanici_Ekle_UC odm = new Kullanici_Ekle_UC();
            odm.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(odm);
        }
    }
}
