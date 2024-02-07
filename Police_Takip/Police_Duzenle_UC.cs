using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Police_Takip
{
    public partial class Police_Duzenle_UC : UserControl
    {
        public Police_Duzenle_UC()
        {
            InitializeComponent();
        }
        Database_Control dc = new Database_Control();
        int limit = 10;
        int btn_limit = 3;
        int totalPages = 0;
        int selected_id = 0;
        List<Guna.UI2.WinForms.Guna2Button> created_btn_list = new List<Guna.UI2.WinForms.Guna2Button>();

        public enum page { Update , Delete }

        private void Police_Duzenle_UC_SizeChanged(object sender, EventArgs e)
        {
            
            guna2DataGridView1.Width = this.Width - 40 ;

            guna2DataGridView1.Location = new Point((this.Width - guna2DataGridView1.Width) / 2, guna2DataGridView1.Location.Y);
        }

        public void Switch_Page(page page)
        {
            if (page == page.Update) { guna2Button1.Text = "Düzenle"; } 
            else 
            {
                guna2Button1.Text = "Sil";
                List<Control> control_list = new List<Control>() {comboBox1,comboBox2, textBox1 ,textBox2 ,textBox3 , textBox4 ,textBox5 ,textBox6 , textBox7 ,
            dateTimePicker1 , dateTimePicker2 , dateTimePicker3 , comboBox3 , textBox8 , textBox10 , comboBox4 , textBox9 , comboBox5 , textBox11 , richTextBox1};

                foreach (Control control in control_list) 
                    {
                    control.Enabled = false;
                    }
            }
        }

        private void Police_Duzenle_UC_Load(object sender, EventArgs e)
        {
            refresh_dataviewer();
        }

        private string GetDataFromSelectedRow(string cell)
        {

            if (guna2DataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = guna2DataGridView1.SelectedCells[0].RowIndex;
                return guna2DataGridView1.Rows[selectedRowIndex].Cells[cell].Value.ToString();

            }
            return "";
        }
        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            List<string> baslik_liste = new List<string>();
            baslik_liste.AddRange(dc.police_table_columns.Split(new string[] { " , " }, StringSplitOptions.RemoveEmptyEntries));
            baslik_liste.Remove("kalan_ucret");
            
            List<Control> control_list = new List<Control>() {comboBox1,comboBox2, textBox1 ,textBox2 ,textBox3 , textBox4 ,textBox5 ,textBox6 , textBox7 ,
            dateTimePicker1 , dateTimePicker2 , dateTimePicker3 , comboBox3 , textBox8 , textBox10 , comboBox4 , textBox9 , comboBox5 , textBox11 , richTextBox1};
            
            foreach (Control control in control_list)
            {
                 control.Text = GetDataFromSelectedRow(baslik_liste[control_list.IndexOf(control)]);
            }

            try { selected_id = Convert.ToInt32(GetDataFromSelectedRow("id")); } catch { }

        }

        private void refresh_dataviewer()
        {
            dc.PopulateComboBox("sirketler",comboBox1);
            dc.PopulateComboBox("police_type", comboBox2);
            comboBox3.SelectedIndex = 1;
            comboBox4.SelectedIndex = 1;
            comboBox5.SelectedIndex = 0;
            button_creator();
            guna2DataGridView1.DataSource = dc.GetTableFromDatabase("Police_List",limit);
            hide_columns();
           
        }

        private void button_creator()
        {
            label19.Text = "Sayfa: 1";
            foreach (Guna.UI2.WinForms.Guna2Button button in created_btn_list)
            {
                flowLayoutPanel1.Controls.Remove(button);
            }
            created_btn_list.Clear();

            int totalRows = dc.GetRowCount("police_list"); // Veritabanındaki toplam veri sayısı
            bool t_b = false;
            totalPages = (int)Math.Ceiling((double)totalRows / limit); // Toplam sayfa sayısını hesaplama


            Guna.UI2.WinForms.Guna2Button button1 = new Guna.UI2.WinForms.Guna2Button();
            button1.Name = "previous";
            button1.Text = "<";
            button1.Tag = "";
            button1.Size = guna2Button3.Size;
            button1.BackColor = Color.FromKnownColor(KnownColor.DarkCyan);
            button1.ForeColor = Color.White;
            button1.FillColor = Color.Transparent;


            button1.Click += previous_button;
            created_btn_list.Add(button1);
            flowLayoutPanel1.Controls.Add(button1);

            if (totalPages > btn_limit) { totalPages = btn_limit; t_b = true; }
            // Butonları oluşturma
            for (int i = 0; i < totalPages; i++)
            {
                Guna.UI2.WinForms.Guna2Button button = new Guna.UI2.WinForms.Guna2Button();
                button.Name = $"page_{i+1}";
                button.Text = $"{i+1}";
                button.Tag = i * limit;
                button.Size = guna2Button3.Size;
                button.BackColor = Color.FromKnownColor(KnownColor.DarkCyan);
                button.ForeColor = Color.White;
                button.FillColor = Color.Transparent;

                button.Click += created_button;
                created_btn_list.Add(button);
                flowLayoutPanel1.Controls.Add(button);
            }
            if (t_b)
            {
                    Guna.UI2.WinForms.Guna2Button button = new Guna.UI2.WinForms.Guna2Button();
                    button.Name = "next";
                    button.Text = ">";
                    button.Tag = "";
                    button.Size = guna2Button3.Size;
                    button.BackColor = Color.FromKnownColor(KnownColor.DarkCyan);
                    button.ForeColor = Color.White;
                    button.FillColor = Color.Transparent;


                   button.Click += next_button;
                    created_btn_list.Add(button);
                    flowLayoutPanel1.Controls.Add(button);

                button = new Guna.UI2.WinForms.Guna2Button();
                button.Name = "end";
                button.Text = ">>";
                button.Tag = "";
                button.Size = guna2Button3.Size;
                button.BackColor = Color.FromKnownColor(KnownColor.DarkCyan);
                button.ForeColor = Color.White;
                button.FillColor = Color.Transparent;

               button.Click += end_button;
                created_btn_list.Add(button);
                flowLayoutPanel1.Controls.Add(button);
            }

        }

        private void next_button(object sender , EventArgs e)
        {
            int i = int.Parse(Regex.Match(label19.Text, @"\d+").Value);
            int offset = (limit * Convert.ToInt32(i + 1)) - limit;

            if (totalPages >= i)
            {
                guna2DataGridView1.DataSource = dc.GetTableFromDatabase("Police_List", limit, offset);
                label19.Text = $"Sayfa: {i + 1}";
            }
            hide_columns();
        }

        private void previous_button(object sender, EventArgs e)
        {
            int i = int.Parse(Regex.Match(label19.Text, @"\d+").Value);
            int offset = (limit * Convert.ToInt32(i - 1)) - limit;

            if (1 < i)
            {
                guna2DataGridView1.DataSource = dc.GetTableFromDatabase("Police_List", limit, offset);
                label19.Text = $"Sayfa: {i - 1}";
            }

            hide_columns();
        }

        private void created_button(object sender , EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = (sender as Guna.UI2.WinForms.Guna2Button);

            int offset = (limit * Convert.ToInt32(btn.Text)) - limit;
            int row_count = dc.GetRowCount("Police_List");
            guna2DataGridView1.DataSource = dc.GetTableFromDatabase("Police_List" , limit, offset);
            label19.Text = $"Sayfa: {btn.Text}";
            hide_columns();
        }

        private void end_button(object sender , EventArgs e)
        {
            
            int offset = (limit * Convert.ToInt32(totalPages + 1)) - limit;
                guna2DataGridView1.DataSource = dc.GetTableFromDatabase("Police_List", limit, offset);
                label19.Text = $"Sayfa: {totalPages + 1}";
            hide_columns();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            refresh_dataviewer();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Clear UI
            clear_ui();
         }

        private void clear_ui()
        {
                List<Control> inputbox = new List<Control>() { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, textBox1, 
                textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9 , textBox10 , textBox11 , richTextBox1};

            foreach (Control control in inputbox)
            {
                control.Text = String.Empty;
                try { control.ResetText(); } catch { }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView1.DataSource = dc.ListPoliceByTcVergiNo((sender as Guna.UI2.WinForms.Guna2TextBox).Text);
                hide_columns();
            } catch { refresh_dataviewer(); }
           
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        
        private void hide_columns()
        { List<string> columns = new List<string>() { "id", "belge_seri_diger_uavt", "tanzim_tarihi", "asil_komisyon_sekli", "asil_komisyon_degeri", "net_prim", "brut_prim_sekli", "brut_prim_degeri", "alinan_ucret_sekli" ,"alinan_ucret_degeri" , "kalan_ucret", "aciklama"};
            foreach (string column in columns)
            {
                guna2DataGridView1.Columns[column].Visible = false;
            }
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button button = (sender as Guna.UI2.WinForms.Guna2Button);
            
            if (button.Text == "Düzenle")
            {
                DialogResult result = MessageBox.Show("Düzenlemek istediğinizden emin misiniz?", dc.app_name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                { update_all_data(); }
                   
            }
            else
            {
                DialogResult result = MessageBox.Show("Silmek istediğinizden emin misiniz?", dc.app_name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                { delete_all_data(); }
            }

        }

        private void update_all_data()
        {
            try
            {
                List<string> baslik_liste = new List<string>();
                baslik_liste.AddRange(dc.police_table_columns.Split(new string[] { " , " }, StringSplitOptions.RemoveEmptyEntries));
                baslik_liste.Remove("kalan_ucret");

                List<Control> control_list = new List<Control>() {comboBox1,comboBox2, textBox1 ,textBox2 ,textBox3 , textBox4 ,textBox5 ,textBox6 , textBox7 ,
            dateTimePicker1 , dateTimePicker2 , dateTimePicker3 , comboBox3 , textBox8 , textBox10 , comboBox4 , textBox9 , comboBox5 , textBox11 , richTextBox1};

                foreach (Control control in control_list)
                {

                    dc.Update_Data("Police_List", "id", selected_id.ToString(), baslik_liste[control_list.IndexOf(control)], control.Text);
                }

                dc.Update_Data("Odemeler", "data_id", selected_id.ToString(), "odenecek_miktar", textBox11.Text);
                decimal kalan = dc.ToplamOdenmeyenMiktar(selected_id);
                dc.Update_Data("Police_List", "id", selected_id.ToString(), "kalan_ucret", kalan.ToString());
                refresh_dataviewer();
                dc.Message_Box(Database_Control.m_status.Success, Database_Control.crud_type.Update);
            }
            catch { dc.Message_Box(Database_Control.m_status.Error, Database_Control.crud_type.Update); }
            
        }

        private void delete_all_data()
        {
            try
            {
                    dc.Delete_Data("Police_List", "id", selected_id.ToString());
                    dc.Delete_Data("Odemeler", "data_id", selected_id.ToString());
                refresh_dataviewer();
                dc.Message_Box(Database_Control.m_status.Success, Database_Control.crud_type.Delete);
            }
            catch { dc.Message_Box(Database_Control.m_status.Error, Database_Control.crud_type.Delete); }
        }

        private void guna2DataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                List<string> headers = new List<string>() { "sigorta_sirketi" , "police_turu" , "tc_vergi_no" , "musteri_tam_ad"
                , "musteri_tel" , "sigorta_ettiren" , "police_teklif_no" , "plaka_no" , "baslangic_tarihi" , "bitis_tarihi"};

                List<string> header_values = new List<string>() {"Sigorta Şirketi" , "Poliçe Türü" , "TC / Vergi No" , "Tam Adı"
                , "Tel No" , "Sigorta Ettiren" , "Poliçe / Teklif No" , "Plaka No" , "Başlangıç Tarihi" , "Son Tarih"};

                foreach (string header in headers)
                {
                    guna2DataGridView1.Columns[header].HeaderText = header_values[headers.IndexOf(header)];
                }
            }
            catch (Exception ex) { }

        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value);
            Duzenle_Form duzenle = new Duzenle_Form();
            duzenle.info(id);
            duzenle.ShowDialog();
        }
    }
}
