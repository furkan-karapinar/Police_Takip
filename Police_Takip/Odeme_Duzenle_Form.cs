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
    public partial class Odeme_Duzenle_Form : Form
    {
        public Odeme_Duzenle_Form()
        {
            InitializeComponent();
        }
        int sel_id = 0;
       

        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void Odeme_Düzenle_Form_Load(object sender, EventArgs e)
        {

        }

        public void bilgi(int id,string odendi_mi,string fiyat)
        {
            if (odendi_mi == "Ödendi") { guna2ComboBox1.SelectedIndex = 1; } else { guna2ComboBox1.SelectedIndex = 0; }
            guna2TextBox2.Text = fiyat;
            sel_id=id;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Database_Control dc = new Database_Control();
            if (guna2ComboBox1.Text != String.Empty && guna2TextBox2.Text != String.Empty)
            {
            string durum = "";
            if (guna2ComboBox1.SelectedIndex == 1) { durum = "True"; } else { durum = "False"; }
            dc.Update_Data("Odemeler", "id", sel_id.ToString(), "odenen_miktar", durum);
            dc.Update_Data("Odemeler", "id", sel_id.ToString(), "odenecek_miktar", guna2TextBox2.Text);
            MessageBox.Show("Değişiklikler kaydedildi! Değişiklikleri görebilmek için ayrıntılar sayfasını yeniden açın.",dc.app_name , MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            } else { MessageBox.Show("Lütfen boş alanları doldurunuz!" , dc.app_name , MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
