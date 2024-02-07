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
    public partial class Custom_Tab_Control2_UC : UserControl
    {
        public Custom_Tab_Control2_UC()
        {
            InitializeComponent();
        }

        private void Custom_Tab_Control2_UC_Load(object sender, EventArgs e)
        {
            Tum_Kayitlar_UC odm = new Tum_Kayitlar_UC();

            odm.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(odm);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Tum_Kayitlar_UC odm = new Tum_Kayitlar_UC();

            odm.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(odm);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Genel_Rapor_UC odm = new Genel_Rapor_UC();

            odm.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(odm);
        }
    }
}
