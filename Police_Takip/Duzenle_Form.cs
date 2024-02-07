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
    public partial class Duzenle_Form : Form
    {
        public Duzenle_Form()
        {
            InitializeComponent();
        }
        Database_Control dc = new Database_Control();
        int id_ = 0;

        public void info(int id)
        {
            List<string> baslik_liste = new List<string>();
            baslik_liste.AddRange(dc.police_table_columns.Split(new string[] { " , " }, StringSplitOptions.RemoveEmptyEntries));
            baslik_liste.Remove("kalan_ucret");

            List<Control> control_list = new List<Control>() {comboBox1,comboBox2, textBox1 ,textBox2 ,textBox3 , textBox4 ,textBox5 ,textBox6 , textBox7 ,
            dateTimePicker1 , dateTimePicker2 , dateTimePicker3 , comboBox3 , textBox8 , textBox10 , comboBox4 , textBox9 , comboBox5 , textBox11 , richTextBox1};

            foreach (Control control in control_list)
            {
                control.Text = (string) dc.Get_Data("Police_List" ,baslik_liste[control_list.IndexOf(control)],$"id={id}");
            }
            label1.Text = textBox2.Text;

             DataTable dt = dc.GetOdemelerData3(id);
            
            guna2DataGridView1.DataSource = dt;

            guna2DataGridView1.Columns["id"].Visible = false;
            guna2DataGridView1.Columns["data_id"].Visible = false;
            guna2DataGridView1.Columns["taksit_sayisi"].HeaderText = "Taksit Sayısı";
            guna2DataGridView1.Columns["odeme_tarihi"].HeaderText = "Ödeme Tarihi";
            guna2DataGridView1.Columns["odenecek_miktar"].HeaderText = "Tutar";
            guna2DataGridView1.Columns["odenen_miktar"].HeaderText = "Ödeme Durumu";

            // Veritabanından veri çekildiğinde DataGridView doldurulacak
            // Örnek olarak bir DataTable kullandığımızı varsayalım

        }


        private void Duzenle_Form_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                (sender as Guna.UI2.WinForms.Guna2ImageButton).Image = Properties.Resources.resize_black;

            }
            else if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                (sender as Guna.UI2.WinForms.Guna2ImageButton).Image = Properties.Resources.max_black;

            }
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Satır tıklamasını kontrol etme
            {
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];

                // Satırın değerlerini alın
                id_ = Convert.ToInt32(selectedRow.Cells[0].Value);
                string fiyat = selectedRow.Cells[4].Value.ToString(); // İlgili sütunun değerini alın
                string odendi_mi = selectedRow.Cells[5].Value.ToString(); // Örnek olarak 2. sütunun değerini alın

                Odeme_Duzenle_Form odeme_ = new Odeme_Duzenle_Form();
                odeme_.bilgi(id_,odendi_mi, fiyat);
                odeme_.ShowDialog();


                
                
            }
        }


    }
}
