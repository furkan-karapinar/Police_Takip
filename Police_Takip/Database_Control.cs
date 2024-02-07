using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Police_Takip
{
    internal class Database_Control
    {
        string path = "database.db", cs = @"URI=file:" + Application.StartupPath + "\\database.db";

        public string app_name = "PolicyFlow Poliçe Takip Sistemi";

        public enum crud_type
        {
            Insert, Update, Delete
        }

        public enum m_status
        {
            Success, Error
        }


        // Gerekli tanımlamalar
        SQLiteConnection data_connection;
        SQLiteCommand command;
        SQLiteDataReader reader;

        public string police_table_columns = "sigorta_sirketi , police_turu , tc_vergi_no , musteri_tam_ad , musteri_tel , sigorta_ettiren , police_teklif_no , plaka_no , belge_seri_diger_uavt , tanzim_tarihi , baslangic_tarihi , bitis_tarihi , asil_komisyon_sekli , asil_komisyon_degeri , net_prim , brut_prim_sekli , brut_prim_degeri , alinan_ucret_sekli , alinan_ucret_degeri , kalan_ucret , aciklama";
        public string odeme_table_columns = "data_id , taksit_sayisi , odeme_tarihi , odenecek_miktar , odenen_miktar";


        public void Create_Database(String datatable_name, String data_options)
        {

            try
            {
                if (!System.IO.File.Exists(path))
                {
                    SQLiteConnection.CreateFile(path);
                }

                using (var sqlite = new SQLiteConnection(@"Data Source=" + path))
                {
                    sqlite.Open();
                    string sql = "CREATE TABLE IF NOT EXISTS " + datatable_name + " (" + data_options + ")";
                    using (var cmd = new SQLiteCommand(sql, sqlite))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Veritabanı Oluşturma Hatası");
            }
        }

        public long Insert_Data(String datatable_name, String item_names, String item_values)
        {
            long insertedId = -1;
            try
            {
                using (var con = new SQLiteConnection(cs))
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = "INSERT INTO " + datatable_name + "(" + item_names + ") VALUES(" + item_values + "); SELECT last_insert_rowid();";
                        insertedId = (long)cmd.ExecuteScalar();
                    }
                }
                return insertedId;
            }
            catch
            {
                return insertedId;
            }
        }

        public bool Update_Data(String datatable_name, String where_item_name, string where_item_value, String item_name, String item_value)
        {
            try
            {
                using (var con = new SQLiteConnection(cs))
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = "UPDATE " + datatable_name + " SET " + item_name + "=@value WHERE " + where_item_name + "=@name";
                        cmd.Parameters.AddWithValue("@name", where_item_value);
                        cmd.Parameters.AddWithValue("@value", item_value);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true; // Başarıyla güncellendiğini belirtmek için bir değer döndürebilirsiniz.
            }
            catch
            {
                MessageBox.Show("Veri İşleme Hatası");
                return false; // Güncelleme işlemi başarısız olduğunda bir değer döndürebilirsiniz.
            }
        }

        public bool Delete_Data(String datatable_name, String database_item_name, String item_name)
        {
            try
            {
                using (var con = new SQLiteConnection(cs))
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = "DELETE FROM " + datatable_name + " WHERE " + database_item_name + "=@name";
                        cmd.Parameters.AddWithValue("@name", item_name);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Check_Data_Exists(string datatable_name, string columnName, string valueToCheck)
        {
            bool exists = false;

            try
            {
                using (var con = new SQLiteConnection(cs))
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = "SELECT COUNT(*) FROM " + datatable_name + " WHERE " + columnName + " = @value";
                        cmd.Parameters.AddWithValue("@value", valueToCheck);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            exists = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri Erişim Sorunu");
            }

            return exists;
        }

        public object Get_Data(string tableName, string selectColumns, string whereConditions)
        {
            object result = null;

            try
            {
                using (var con = new SQLiteConnection(cs))
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(con))
                    {
                        cmd.CommandText = "SELECT " + selectColumns + " FROM " + tableName + " WHERE " + whereConditions;

                        // Birden fazla sonuç dönebilir ya da tek bir değer dönebilir, 
                        // bu nedenle ExecuteScalar kullanımı yerine ExecuteReader tercih edilebilir.

                        // SQLiteDataReader kullanarak birden fazla sonuç alınabilir.
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = reader.GetValue(0); // İstenilen sütundan değeri alabilirsiniz.
                                                             // Örnek: reader.GetValue(0) 0. sütundaki değeri alır.
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda gerekli işlemler yapılabilir.
                MessageBox.Show("Veri Getirme Hatası: " + ex.Message);
            }

            return result; // İstenilen veri ya da null döndürülür.
        }

        public DataTable GetTableFromDatabase(string tableName, int limit = 0, int start = 0)
        {
            string qlimit = "";
            if (limit != 0)
            {
                if (start != 0)
                {
                    qlimit = $"LIMIT {limit} OFFSET {start}";
                }
                else { qlimit = $"LIMIT {limit}"; }
            }


            string connectionString = $"Data Source={path};Version=3;"; // Veritabanı bağlantı dizesi
            string query = $"SELECT * FROM {tableName} {qlimit};";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        public DataTable ListPoliceByTcVergiNo(string tcVergiNo)
        {
            string connectionString = $"Data Source={path};Version=3;"; // Veritabanı bağlantı dizesi
            string query = $"SELECT * FROM Police_List WHERE tc_vergi_no LIKE @tcVergiNo;"; // Sorgu

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tcVergiNo", tcVergiNo + "%");

                    connection.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        public int GetRowCount(string tableName)
        {
            string connectionString = $"Data Source={path};Version=3;"; // Veritabanı bağlantı dizesi
            string query = $"SELECT COUNT(*) FROM {tableName};"; // Sorgu

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    int rowCount = Convert.ToInt32(command.ExecuteScalar());

                    return rowCount;
                }
            }
        }
        public void Message_Box(m_status status, crud_type type)
        {
            string title = app_name;
            string getted_event = "";



            switch (type)
            {
                case crud_type.Insert:
                    getted_event = "Giriş";
                    break;
                case crud_type.Update:
                    getted_event = "Güncelleme";
                    break;
                case crud_type.Delete:
                    getted_event = "Silme";
                    break;
                default:
                    getted_event = "Giriş";
                    break;
            }

            string success_message = $"Veri {getted_event} İşlemi Başarılı";
            string error_message = $"Veri {getted_event} İşlemi Başarısız";


            switch (status)
            {
                case m_status.Success:
                    MessageBox.Show(success_message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case m_status.Error:
                    MessageBox.Show(error_message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("I don't know. Maybe successfully :D", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        public void PopulateComboBox(string tableName, ComboBox comboBox)
        {
            string connectionString = $"Data Source={path};Version=3;"; // Veritabanı bağlantı dizesi
            string query = $"SELECT data FROM {tableName};"; // Sorgu

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["data"].ToString());
                    }
                }
            }
        }

        public decimal ToplamOdenmeyenMiktar(int dataId)
        {
            string connectionString = $"Data Source={path};Version=3;"; // Veritabanı bağlantı dizesi
            string query = $"SELECT SUM(odenecek_miktar) FROM Odemeler WHERE data_id = @dataId AND odenen_miktar = 'False';"; // Sorgu

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dataId", dataId);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                }
            }

            return 0; // Eğer veri bulunamazsa 0 döndür
        }

        public DataTable GetOdemelerData()
        {
            string connectionString = $"Data Source={path};Version=3;";
            string query = @"
            SELECT o.id, o.data_id , pl.musteri_tam_ad, pl.musteri_tel, o.taksit_sayisi, o.odeme_tarihi, o.odenecek_miktar
            FROM Odemeler AS o
            JOIN Police_List AS pl ON pl.id = o.data_id
            WHERE o.odenen_miktar = 'False' 
            AND strftime('%Y', o.odeme_tarihi) = strftime('%Y', 'now') 
            AND strftime('%m', o.odeme_tarihi) = strftime('%m', 'now') 
            AND strftime('%d', o.odeme_tarihi) BETWEEN strftime('%d', 'now') AND strftime('%d', date('now', '+15 day'));
        ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable; // DataTable'i döndürme
                }
            }
        }

        public DataTable GetOdemelerData2()
        {
            string connectionString = $"Data Source={path};Version=3;";
            string query = @"
            SELECT o.id , o.data_id, pl.musteri_tam_ad, pl.musteri_tel, o.taksit_sayisi, o.odeme_tarihi, o.odenecek_miktar
            FROM Odemeler AS o
            JOIN Police_List AS pl ON pl.id = o.data_id
            WHERE o.odenen_miktar = 'False' 
            AND (CAST(strftime('%Y', o.odeme_tarihi) AS INTEGER) < CAST(strftime('%Y', 'now') AS INTEGER)
                OR (CAST(strftime('%Y', o.odeme_tarihi) AS INTEGER) = CAST(strftime('%Y', 'now') AS INTEGER)
                    AND CAST(strftime('%m', o.odeme_tarihi) AS INTEGER) < CAST(strftime('%m', 'now') AS INTEGER)));
        ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable; // DataTable'i döndürme
                }
            }
        }

        public DataTable GetBitisTarihiGecenPoliceler()
        {
            string connectionString = $"Data Source={path};Version=3;";
            string query = @"
            SELECT pl.id, pl.police_turu, pl.police_teklif_no, pl.musteri_tam_ad, pl.musteri_tel, pl.baslangic_tarihi, pl.bitis_tarihi
            FROM Police_List AS pl
            WHERE strftime('%d.%m.%Y', pl.bitis_tarihi) BETWEEN strftime('%d.%m.%Y', 'now') AND strftime('%d.%m.%Y', date('now', '+15 days'));
        ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable; // DataTable'i döndürme
                }
            }
        }

        public DataTable GetBitisTarihiGecenPoliceler2()
        {
            string connectionString = $"Data Source={path};Version=3;";
            string query = @"
            SELECT pl.id, pl.police_turu, pl.police_teklif_no, pl.musteri_tam_ad, pl.musteri_tel, pl.baslangic_tarihi, pl.bitis_tarihi
FROM Police_List AS pl
WHERE pl.bitis_tarihi BETWEEN date('now', '-15 days') AND date('now');
        ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable; // DataTable'i döndürme
                }
            }
        }

        public DataTable GetOdemelerData3(int id)
        {
            string connectionString = $"Data Source={path};Version=3;";
            string query = $"SELECT * FROM Odemeler WHERE data_id = {id}";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (dataTable.Rows[i]["odenen_miktar"].ToString() == "True")
                        {
                            dataTable.Rows[i]["odenen_miktar"] = "Ödendi";
                        } else { dataTable.Rows[i]["odenen_miktar"] = "Ödenmedi"; }
                    }

                    return dataTable; // DataTable'i döndürme
                }
            }
        }

       
    }
}
