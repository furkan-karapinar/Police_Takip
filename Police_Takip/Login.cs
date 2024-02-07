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
    public partial class Login : Form
    {
        Database_Control dc = new Database_Control();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            panel3.Location = new Point((panel2.Width - panel3.Width) / 2, (panel2.Height - panel3.Height) / 2);

            panel1.Location = new Point((panel4.Width - panel1.Width) / 2, (panel4.Height - panel1.Height) / 2);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty && textBox2.Text != String.Empty)
            {
                login_check();
            }
        }

        private void login_check()
        {
            string pass =  Convert.ToString(dc.Get_Data("kullanicilar","sifre","kullanici_adi='" + textBox1.Text + "'"));
            
            if (pass == textBox2.Text)
            {
                Form1 frm = new Form1();
                frm.set_status(status_check());
                this.Hide();
                
                frm.ShowDialog();

                // Diyalog formundan gelen sonucu kontrol et
                if (frm.ReturnedValue == "Exit")
                {
                    this.Close();
                } else { textBox1.Clear(); textBox2.Clear(); this.Show(); }
                
            }
            else { MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış", "Hatalı Giriş",MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private byte status_check()
        {
          return  Convert.ToByte(dc.Get_Data("kullanicilar", "yetki", "kullanici_adi='" + textBox1.Text + "'"));
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
