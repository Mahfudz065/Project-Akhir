using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Akhir
{
    public partial class DataTerminal : Form
    {
        public SqlConnection sqlConnection;
        public DataTerminal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataPenumpang  dataPenumpang = new DataPenumpang();
            dataPenumpang.Show();
            this.Hide();
        }

        private void DataTerminal_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connString = "data source= DESKTOP-LAFVQ8T\\MAHFUDZSIDDIQ;Initial Catalog=Terminal_Bus_CEO;Persist Security Info=True;User ID = sa; Password = 123";
            string query = "INSERT INTO Bus Values (@Id_Bus, @Nama_Bus, @Type_Bus)";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Id_Bus", textBox1);
                    cmd.Parameters.AddWithValue("@Nama_Bus", textBox2);
                    cmd.Parameters.AddWithValue("@Type_Bus", textBox3);
                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Berhasil Ditambahkan.");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("TERJADI KESALAHAN: " + ex.Message + " (Error Code: " + ex.Number + ")");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("TERJADI KESALAHAN: " + ex.Message);
                    }
                }
            }
        }
    }
}
