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
    public partial class Police_Ekle_UC : UserControl
    {
        Database_Control dc = new Database_Control();

        int komisyon = 1;


        public Police_Ekle_UC()
        {
            InitializeComponent();
        }

        private void Police_Ekle_UC_Load(object sender, EventArgs e)
        {
            dc.PopulateComboBox("sirketler", sigorta);
            dc.PopulateComboBox("police_type", police);
            sigorta.SelectedIndex = 0;
            police.SelectedIndex = 0;
            asil_turu.SelectedIndex = 1;
            brut_turu.SelectedIndex = 0;
            taksit.SelectedIndex = 0;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if  (!empty_control())
            {
                List<string> data_list = new List<string>() { sigorta.Text , police.Text, tc_vergi.Text,
            tam_ad.Text, tel_no.Text, sigorta_ettiren.Text, police_teklif.Text, plaka.Text, belge_seri.Text , tanzim.Value.ToString("yyyy-MM-dd"),
            baslangic.Value.ToString("yyyy-MM-dd") , bitis.Value.ToString("yyyy-MM-dd") , asil_turu.Text , asil.Text , net.Text , brut_turu.Text , brut.Text, taksit.Text
            , ucret.Text , ucret.Text, aciklama.Text};

                string data_ = "";
                long status;

                #region Ana Kayıt
                foreach (string s in data_list)
                {
                    data_ += "'" + s + "',";
                }
                data_ = data_.Substring(0, data_.Length - 1);

                 status = dc.Insert_Data("Police_list", dc.police_table_columns, data_);

                if (status != -1)
                {
                    MessageBox.Show("Veri Kaydı Başarılı" , "PolicyFlow Poliçe Takip Sistemi" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Veri Kaydı Başarısız", "PolicyFlow Poliçe Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
                #region Taksit Kayıt


                int taksit_sayisi = taksit_();

                
                DateTime dateTime = baslangic.Value;
                DateTime dateTime2 = dateTime.AddMonths(-1);

                double odenecek_miktar = Convert.ToDouble(net.Text) / taksit_sayisi;
                for (int i = 1; i <= taksit_sayisi; i++)
                {
                    DateTime dateTime3 = dateTime2.AddMonths(i);
                    data_ = "'" + status.ToString() + "','" + i.ToString() + "/" + taksit_sayisi.ToString() + "' , '" +  dateTime3.ToString("yyyy-MM-dd") + "','" + odenecek_miktar.ToString("0.00") + "' , '" + false + "'";
                    dc.Insert_Data("Odemeler",dc.odeme_table_columns, data_);
                }
                

                #endregion


            }
                clear_ui();
            }
            catch (Exception ex) { dc.Message_Box(Database_Control.m_status.Error, Database_Control.crud_type.Insert); }

            
        }


        private List<TextBox> GetTextBoxes(Control control)
        {
            var textBoxes = control.Controls.OfType<TextBox>().ToList();

            foreach (Control ctrl in control.Controls)
            {
                textBoxes.AddRange(GetTextBoxes(ctrl));
            }

            return textBoxes;
        }

        private bool empty_control()
        {
            bool empty = false; 

            List<TextBox> textBoxList = GetTextBoxes(this).ToList();

            errorProvider1.Clear();
            foreach (var textBox in textBoxList)
            {
                if (String.IsNullOrWhiteSpace(textBox.Text))
                {
                    errorProvider1.SetError(textBox, "Bu alan boş bırakılamaz"); 
                    empty = true;
                }
            }
            return empty;
        }

        private void brut_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (asil_turu.Text)
                {
                    case "Yüzde":
                        komisyon = 1;
                        break;
                    case "TL":
                        komisyon = 2;
                        break;
                }
                if (komisyon == 1)
                {
                    net.Text = (Convert.ToDouble(brut.Text) + ((Convert.ToDouble(brut.Text) * Convert.ToDouble(asil.Text)) / 100 )).ToString("0.00");
                }
                else
                {
                    net.Text = (Convert.ToDouble(brut.Text) + Convert.ToDouble(asil.Text)).ToString("0.00");
                }
            }
            catch (OverflowException oex) { }
            catch (Exception ex) { }

           
        }

        private int taksit_()
        {
            int taksit_sayisi = 1;
            switch (taksit.Text)
            {
                case "Taksitsiz":
                    taksit_sayisi = 1;
                    break;
                case "3 Taksit":
                    taksit_sayisi = 3;
                    break;
                case "6 Taksit":
                    taksit_sayisi = 6;
                    break;
                case "9 Taksit":
                    taksit_sayisi = 9;
                    break;
                case "12 Taksit":
                    taksit_sayisi = 12;
                    break;
                case "24 Taksit":
                    taksit_sayisi = 24;
                    break;
                case "36 Taksit":
                    taksit_sayisi = 36;
                    break;
                default:
                    taksit_sayisi = 1;
                    break;
            }
            return taksit_sayisi;
        }
        private void net_TextChanged(object sender, EventArgs e)
        {try
            {
                int taksit_sayisi = taksit_();
                ucret.Text = (Convert.ToDouble(net.Text) / taksit_sayisi).ToString("0.00");
            }
            catch (Exception ex) { }   
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            clear_ui();
        }

        private void clear_ui()
        {
            List<Control> data_list = new List<Control>() { sigorta , police, tc_vergi,
            tam_ad, tel_no, sigorta_ettiren, police_teklif, plaka, belge_seri , tanzim,
            baslangic , bitis , asil_turu , asil , net , brut_turu , brut, taksit
            , ucret , ucret, aciklama};

            foreach (Control c in data_list)
            {
                c.Text = String.Empty;
                try { c.ResetText(); } catch { }
            }
        }
    }
}
