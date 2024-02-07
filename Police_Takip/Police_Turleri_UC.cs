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
    public partial class Police_Turleri_UC : UserControl
    {
        Database_Control dc = new Database_Control();
        int selected_id = 0;
        public Police_Turleri_UC()
        {
            InitializeComponent();
        }

        private void Police_Turleri_UC_Load(object sender, EventArgs e)
        {
            refresh_dataviewer();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dc.Check_Data_Exists("police_type","data",guna2TextBox1.Text)) { MessageBox.Show("Aynı veri zaten mevcut",dc.app_name,MessageBoxButtons.OK,MessageBoxIcon.Error);}
            else 
            { 
                if (dc.Insert_Data("police_type","'data'","'" + guna2TextBox1.Text + "'") != -1)
                {
                    dc.Message_Box(Database_Control.m_status.Success, Database_Control.crud_type.Insert);
                }
                else { dc.Message_Box(Database_Control.m_status.Error, Database_Control.crud_type.Insert); }
            }
            refresh_dataviewer();
        }

        private void refresh_dataviewer()
        {
            guna2DataGridView1.DataSource = dc.GetTableFromDatabase("police_type");
            guna2DataGridView1.Columns["id"].HeaderText = "ID";
            guna2DataGridView1.Columns["data"].HeaderText = "Poliçe Adı";
        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = guna2DataGridView1.SelectedRows[0];

                // ID değeri ID sütununun indeksine göre alınabilir
                selected_id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                guna2TextBox1.Text = Convert.ToString(selectedRow.Cells["data"].Value);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Silmek istediğinizden emin misiniz?",dc.app_name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
               if (dc.Delete_Data("police_type","id",selected_id.ToString()) == true)
                {
                    dc.Message_Box(Database_Control.m_status.Success, Database_Control.crud_type.Delete);
                }
               else { dc.Message_Box(Database_Control.m_status.Error, Database_Control.crud_type.Delete); }
            }
            refresh_dataviewer();
            
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (dc.Check_Data_Exists("police_type", "data", guna2TextBox1.Text)) { MessageBox.Show("Aynı veri zaten mevcut", dc.app_name, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                DialogResult result = MessageBox.Show("Düzenlemek istediğinizden emin misiniz?", dc.app_name, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (dc.Update_Data("police_type", "id",selected_id.ToString(),"'data'",guna2TextBox1.Text) == true)
                {
                    dc.Message_Box(Database_Control.m_status.Success, Database_Control.crud_type.Update);
                }
                else { dc.Message_Box(Database_Control.m_status.Error, Database_Control.crud_type.Update); }
            }
            refresh_dataviewer();

            }

            
        }
    }
}
