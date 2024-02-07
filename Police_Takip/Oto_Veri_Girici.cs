using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Police_Takip
{
    public partial class Oto_Veri_Girici : Form
    {
        public Oto_Veri_Girici()
        {
            InitializeComponent();
        }
        List<string> stringList = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            int a = take_data();
            apply(a);
            richTextBox1.Clear();
           
        }
        Database_Control dc = new Database_Control();
        private void apply(int taksit_sayisi)
        {
            try
            {
                string datam = richTextBox1.Text.Replace('.', ',');
                  long  status = dc.Insert_Data("Police_list", dc.police_table_columns, datam);

                    if (status != -1)
                    {
                        MessageBox.Show("Veri Kaydı Başarılı", "PolicyFlow Poliçe Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Veri Kaydı Başarısız", "PolicyFlow Poliçe Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                #region Taksit Kayıt





                DateTime dateTime = DateTime.Now;
                DateTime dateTime2 = dateTime.AddMonths(-1);

                string a = stringList[stringList.Count - 2].Substring(2, stringList[stringList.Count - 2].Length - 3);
                    double odenecek_miktar = Convert.ToDouble(a) / taksit_sayisi;
                    for (int i = 1; i <= taksit_sayisi; i++)
                    {
                        DateTime dateTime3 = dateTime2.AddMonths(i);
                       string data_ = "'" + status.ToString() + "','" + i.ToString() + "/" + taksit_sayisi.ToString() + "' , '" + dateTime3.ToString("yyyy-MM-dd") + "','" + odenecek_miktar.ToString("0.00") + "' , '" + false + "'";
                        dc.Insert_Data("Odemeler", dc.odeme_table_columns, data_);
                    }


                    #endregion


                
            
            }
            catch (Exception ex) { dc.Message_Box(Database_Control.m_status.Error, Database_Control.crud_type.Insert); }


        }

        private int take_data()
        {
            stringList.Clear();

            // richTextBox1 is your RichTextBox control
            foreach (string line in richTextBox1.Lines)
            {
                string[] parts = line.Split('.');
                stringList.AddRange(parts);
            }

            string taksitItem = stringList.FirstOrDefault(item => item.Contains("Taksit"));

            int extractedNumber = 1;

            if (taksitItem != null)
            {
                // 'Taksit' içeren öğeyi bulduk, şimdi içindeki sayıları çıkarmak için biraz işlem yapalım
                string[] parts = taksitItem.Split(' ');
                foreach (string part in parts)
                {
                    // Eğer içinde rakam varsa
                    if (System.Text.RegularExpressions.Regex.IsMatch(part, @"\d+"))
                    {
                        // Rakamları bulup int'e dönüştürelim
                        string numberString = new string(part.Where(char.IsDigit).ToArray());
                        if (int.TryParse(numberString, out int number))
                        {
                            // İlk bulduğumuz sayıyı extractedNumber'a ata ve döngüyü sonlandır
                            extractedNumber = number;
                            break;
                        }
                    }
                }
            }

            return extractedNumber;
        }
    }
}
