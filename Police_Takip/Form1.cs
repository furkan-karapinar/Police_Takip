using Guna.UI2.WinForms;
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
    public partial class Form1 : Form
    {
        Database_Control dc = new Database_Control();
        public Form1()
        {
            InitializeComponent();
        }

        int yetki_ = 1;

        public void set_status(byte yetki)
        {
            if (yetki != 1)
            {
                guna2Button7.Visible = false;
                guna2Button6.Visible = false;
                yetki_ = yetki;
            }
        }
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            ReturnedValue = "Exit";
            Application.Exit();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                (sender as Guna2ImageButton).Image = Properties.Resources.resize_black;
                
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                (sender as Guna2ImageButton).Image = Properties.Resources.max_black;
                
            }
            
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            btn_codes(sender, new Custom_Tab_Control_UC());
        }

        private void menu_check()
        {
            guna2Button1.Checked = false;
            guna2Button2.Checked = false;
            guna2Button3.Checked = false;
            guna2Button4.Checked = false;
            guna2Button5.Checked = false;
            guna2Button6.Checked = false;
            panel4.Controls.Clear();
        }

        private void btn_codes(object sender , UserControl uc)
        {
            menu_check();
            (sender as Guna2Button).Checked = true;
            uc.Dock = DockStyle.Fill;
            panel4.Controls.Add(uc);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            btn_codes(sender,new Police_Ekle_UC());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //menu_check();
            //(sender as Guna2Button).Checked = true;

            //Police_Duzenle_UC cus = new Police_Duzenle_UC();
            //cus.Dock = DockStyle.Fill;

            //panel4.Controls.Add(cus);

            btn_codes(sender, new Police_Duzenle_UC());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Police_Duzenle_UC uc = new Police_Duzenle_UC();
            uc.Switch_Page(Police_Duzenle_UC.page.Delete);
            btn_codes(sender, uc); // Silme
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            btn_codes(sender, new Tum_Kayitlar_UC());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Custom_Tab_Control3_UC uc = new Custom_Tab_Control3_UC();
            uc.yetki_kontrol(yetki_);
            btn_codes(sender, uc );
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Custom_Tab_Control_UC cus = new Custom_Tab_Control_UC();
            cus.Dock = DockStyle.Fill;

            panel4.Controls.Clear();
            panel4.Controls.Add(cus);

            center_menu_buttons();
        }

        private void center_menu_buttons()
        {
 flowLayoutPanel1.Dock = DockStyle.None; // FlowLayoutPanel'in dökme stilini None olarak ayarla
            flowLayoutPanel1.AutoSize = true; // Otomatik boyutlandırmayı aktifleştir
            flowLayoutPanel1.WrapContents = false; // İçeriği sarma işlemini devre dışı bırak

            // FlowLayoutPanel'in genişliğini belirle
            flowLayoutPanel1.Width = panel1.Width; // Panel'in genişliği kadar yapılabilir, istediğiniz değeri atayabilirsiniz

            guna2Button1.Width = panel1.Width;
            guna2Button2.Width = panel1.Width;
            guna2Button3.Width = panel1.Width;
            guna2Button4.Width = panel1.Width;
            guna2Button5.Width = panel1.Width;
            guna2Button6.Width = panel1.Width;

            // Panel'e FlowLayoutPanel'i yatayda ortalamak için FlowLayoutPanel'in konumunu ayarla
            flowLayoutPanel1.Location = new Point((panel1.Width - flowLayoutPanel1.Width) / 2, flowLayoutPanel1.Location.Y);
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public string ReturnedValue { get; private set; }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            ReturnedValue = "Logout";
            Close();
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Bu proje Görsel Programlama 2 kapsamında Furkan Karapınar tarafından oluşturulmuştur.",dc.app_name , MessageBoxButtons.OK,MessageBoxIcon.Information);
            Info info = new Info();
            info.ShowDialog();
        }
    }
}
