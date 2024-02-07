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
    public partial class Kullanici_Ekle_UC : UserControl
    {
        public Kullanici_Ekle_UC()
        {
            InitializeComponent();
        }
        Database_Control dc = new Database_Control();
        int selected_id = 0;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dc.Check_Data_Exists("kullanicilar", "kullanici_adi", guna2TextBox1.Text)) { MessageBox.Show("Aynı veri zaten mevcut", dc.app_name, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                int yetki =0;
                if (guna2ComboBox1.Text == "Admin") { yetki = 1; } else { yetki = 0; }
                string val = "'" + guna2TextBox1.Text + "' , '" + guna2TextBox2.Text + "','" + yetki + "'";
                if (dc.Insert_Data("kullanicilar", "'kullanici_adi' , 'sifre' , 'yetki'",val) != -1)
                {
                    dc.Message_Box(Database_Control.m_status.Success, Database_Control.crud_type.Insert);
                }
                else { dc.Message_Box(Database_Control.m_status.Error, Database_Control.crud_type.Insert); }
            }
            refresh_dataviewer();
        }

        private void refresh_dataviewer()
        {
            guna2DataGridView1.DataSource = dc.GetTableFromDatabase("kullanicilar");
            guna2DataGridView1.Columns["id"].Visible = false;
            guna2DataGridView1.Columns["kullanici_adi"].HeaderText = "Kullanıcı Adı";
            guna2DataGridView1.Columns["sifre"].Visible = false;
            guna2DataGridView1.Columns["yetki"].Visible = false;
        }

        private void Kullanici_Ekle_UC_Load(object sender, EventArgs e)
        {
            refresh_dataviewer();
        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

                // ID değeri ID sütununun indeksine göre alınabilir
                selected_id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                guna2TextBox1.Text = Convert.ToString(selectedRow.Cells["kullanici_adi"].Value);
                guna2TextBox2.Text = Convert.ToString(selectedRow.Cells["sifre"].Value);
                int yetki = Convert.ToInt32(selectedRow.Cells["yetki"].Value);
                if (yetki == 0) { guna2ComboBox1.SelectedIndex = 0; } else { guna2ComboBox1.SelectedIndex = 1; }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int yetki = 0;
            if (guna2ComboBox1.SelectedText == "Admin") { yetki = 1; } else { yetki = 0; }
            if (dc.Check_Data_Exists("kullanicilar", "kullanici_adi", guna2TextBox1.Text)) { MessageBox.Show("Aynı veri zaten mevcut", dc.app_name, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                DialogResult result = MessageBox.Show("Düzenlemek istediğinizden emin misiniz?", dc.app_name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (dc.Update_Data("kullanicilar", "id", selected_id.ToString(), "'kullanici_adi'", guna2TextBox1.Text) && dc.Update_Data("kullanicilar", "id", selected_id.ToString(), "'sifre'", guna2TextBox2.Text) && dc.Update_Data("kullanicilar", "id", selected_id.ToString(), "'yetki'", yetki.ToString()))
                    {
                        dc.Message_Box(Database_Control.m_status.Success, Database_Control.crud_type.Update);
                    }
                    else { dc.Message_Box(Database_Control.m_status.Error, Database_Control.crud_type.Update); }

                }
                refresh_dataviewer();

            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Silmek istediğinizden emin misiniz?", dc.app_name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (dc.Delete_Data("kullanicilar", "id", selected_id.ToString()) == true)
                {
                    dc.Message_Box(Database_Control.m_status.Success, Database_Control.crud_type.Delete);
                }
                else { dc.Message_Box(Database_Control.m_status.Error, Database_Control.crud_type.Delete); }
            }
            refresh_dataviewer();

        }
    }
}
