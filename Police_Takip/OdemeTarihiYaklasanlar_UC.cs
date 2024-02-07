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
    public partial class OdemeTarihiYaklasanlar_UC : UserControl
    {
        public OdemeTarihiYaklasanlar_UC()
        {
            InitializeComponent();
        }
        Database_Control dc = new Database_Control();

        public void tab_names(string tab1_name , string tab2_name)
        {
            guna2GroupBox1.Text = tab1_name;
            guna2GroupBox2.Text = tab2_name;
        }

        public void tab_controls()
        {
           // kontroller
        }

        private void OdemeTarihiYaklasanlar_UC_Load(object sender, EventArgs e)
        {
            if (guna2GroupBox1.Text == "Ödeme Süresi Dolanlar")
            {
                guna2DataGridView2.DataSource = dc.GetOdemelerData();
                guna2DataGridView2.Columns["id"].Visible = false;
                guna2DataGridView2.Columns["data_id"].Visible = false;
                guna2DataGridView2.Columns["musteri_tam_ad"].HeaderText = "Tam Ad";
                guna2DataGridView2.Columns["musteri_tel"].HeaderText = "Tel No";
                guna2DataGridView2.Columns["taksit_sayisi"].HeaderText = "Taksit Sayısı";
                guna2DataGridView2.Columns["odeme_tarihi"].HeaderText = "Ödeme Tarihi";
                guna2DataGridView2.Columns["odenecek_miktar"].HeaderText = "Ödenecek Miktar";

                guna2DataGridView1.DataSource = dc.GetOdemelerData2();
                guna2DataGridView1.Columns["id"].Visible = false;
                guna2DataGridView1.Columns["data_id"].Visible = false;
                guna2DataGridView1.Columns["musteri_tam_ad"].HeaderText = "Tam Ad";
                guna2DataGridView1.Columns["musteri_tel"].HeaderText = "Tel No";
                guna2DataGridView1.Columns["taksit_sayisi"].HeaderText = "Taksit Sayısı";
                guna2DataGridView1.Columns["odeme_tarihi"].HeaderText = "Ödeme Tarihi";
                guna2DataGridView1.Columns["odenecek_miktar"].HeaderText = "Ödenecek Miktar";
            }
            else
            {
                guna2DataGridView2.DataSource = dc.GetBitisTarihiGecenPoliceler();
                guna2DataGridView2.Columns["id"].Visible = false;
                guna2DataGridView2.Columns["musteri_tam_ad"].HeaderText = "Tam Ad";
                guna2DataGridView2.Columns["musteri_tel"].HeaderText = "Tel No";
                guna2DataGridView2.Columns["police_turu"].HeaderText = "Poliçe Türü";
                guna2DataGridView2.Columns["police_teklif_no"].HeaderText = "Poliçe / Teklif No";
                guna2DataGridView2.Columns["baslangic_tarihi"].HeaderText = "Başlangıç Tarihi";
                guna2DataGridView2.Columns["bitis_tarihi"].HeaderText = "Son Geçerlilik Tarihi";

                guna2DataGridView1.DataSource = dc.GetBitisTarihiGecenPoliceler2();
                guna2DataGridView1.Columns["id"].Visible = false;
                guna2DataGridView1.Columns["musteri_tam_ad"].HeaderText = "Tam Ad";
                guna2DataGridView1.Columns["musteri_tel"].HeaderText = "Tel No";
                guna2DataGridView1.Columns["police_turu"].HeaderText = "Poliçe Türü";
                guna2DataGridView1.Columns["police_teklif_no"].HeaderText = "Poliçe / Teklif No";
                guna2DataGridView1.Columns["baslangic_tarihi"].HeaderText = "Başlangıç Tarihi";
                guna2DataGridView1.Columns["bitis_tarihi"].HeaderText = "Son Geçerlilik Tarihi";
            }
            

        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value);
            Duzenle_Form duzenle = new Duzenle_Form();
            duzenle.info(id);
            duzenle.ShowDialog();
        }



        private void guna2DataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = 0;
            if (guna2GroupBox1.Text == "Ödeme Süresi Dolanlar")
            {
                id = Convert.ToInt32(guna2DataGridView2.Rows[e.RowIndex].Cells[1].Value);
            }
            else
            {
                id = Convert.ToInt32(guna2DataGridView2.Rows[e.RowIndex].Cells[0].Value);
            }
            Duzenle_Form duzenle = new Duzenle_Form();
            duzenle.info(id);
            duzenle.ShowDialog();
        }
    }
}
