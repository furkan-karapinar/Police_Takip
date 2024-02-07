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
    public partial class Tum_Kayitlar_UC : UserControl
    {
        public Tum_Kayitlar_UC()
        {
            InitializeComponent();
        }
        int limit = 20;
        int btn_limit = 10;
        int totalPages = 0;
        List<Guna.UI2.WinForms.Guna2Button> created_btn_list = new List<Guna.UI2.WinForms.Guna2Button>();
        Database_Control dc = new Database_Control();
        private void Tum_Kayitlar_UC_Load(object sender, EventArgs e)
        {
            refresh_dataviewer();
        }

        private void refresh_dataviewer()
        {
            button_creator();
            guna2DataGridView1.DataSource = dc.GetTableFromDatabase("Police_List", limit);
            hide_columns();
        }
        private void button_creator()
        {
            label2.Text = "Sayfa: 1";
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
            button1.Size = guna2Button1.Size;
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
                button.Name = $"page_{i + 1}";
                button.Text = $"{i + 1}";
                button.Tag = i * limit;
                button.Size = guna2Button1.Size;
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
                button.Size = guna2Button1.Size;
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
                button.Size = guna2Button1.Size;
                button.BackColor = Color.FromKnownColor(KnownColor.DarkCyan);
                button.ForeColor = Color.White;
                button.FillColor = Color.Transparent;

                button.Click += end_button;
                created_btn_list.Add(button);
                flowLayoutPanel1.Controls.Add(button);
            }

        }
        private void hide_columns()
        {
            List<string> columns = new List<string>() { "id", "belge_seri_diger_uavt", "tanzim_tarihi", "asil_komisyon_sekli", "asil_komisyon_degeri", "net_prim", "brut_prim_sekli", "brut_prim_degeri", "alinan_ucret_sekli", "alinan_ucret_degeri", "kalan_ucret", "aciklama" };
            foreach (string column in columns)
            {
                guna2DataGridView1.Columns[column].Visible = false;
            }

        }

        private void next_button(object sender, EventArgs e)
        {
            int i = int.Parse(Regex.Match(label2.Text, @"\d+").Value);
            int offset = (limit * Convert.ToInt32(i + 1)) - limit;

            if (totalPages >= i)
            {
                guna2DataGridView1.DataSource = dc.GetTableFromDatabase("Police_List", limit, offset);
                label2.Text = $"Sayfa: {i + 1}";
            }
            hide_columns();
        }

        private void previous_button(object sender, EventArgs e)
        {
            int i = int.Parse(Regex.Match(label2.Text, @"\d+").Value);
            int offset = (limit * Convert.ToInt32(i - 1)) - limit;

            if (1 < i)
            {
                guna2DataGridView1.DataSource = dc.GetTableFromDatabase("Police_List", limit, offset);
                label2.Text = $"Sayfa: {i - 1}";
            }
            hide_columns();

        }

        private void created_button(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button btn = (sender as Guna.UI2.WinForms.Guna2Button);

            int offset = (limit * Convert.ToInt32(btn.Text)) - limit;
            int row_count = dc.GetRowCount("Police_List");
            guna2DataGridView1.DataSource = dc.GetTableFromDatabase("Police_List", limit, offset);
            label2.Text = $"Sayfa: {btn.Text}";
            hide_columns();
        }

        private void end_button(object sender, EventArgs e)
        {

            int offset = (limit * Convert.ToInt32(totalPages + 1)) - limit;
            guna2DataGridView1.DataSource = dc.GetTableFromDatabase("Police_List", limit, offset);
            label2.Text = $"Sayfa: {totalPages + 1}";
            hide_columns();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            refresh_dataviewer();
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView1.DataSource = dc.ListPoliceByTcVergiNo((sender as Guna.UI2.WinForms.Guna2TextBox).Text);
                hide_columns();
            }
            catch { refresh_dataviewer(); }
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value);
            Duzenle_Form duzenle = new Duzenle_Form();
            duzenle.info(id);
            duzenle.ShowDialog();
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
            catch (Exception ex){ }
           

            
        }
    }
}
