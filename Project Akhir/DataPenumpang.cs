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
    public partial class DataPenumpang : Form
    {
        public SqlConnection sqlConnection;

        public object IdPenumpang { get; private set; }

        public DataPenumpang()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void DataPenumpang_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "data source= DESKTOP-LAFVQ8T\\MAHFUDZSIDDIQ;Initial Catalog=Terminal_Bus_CEO;Persist Security Info=True;User ID = sa; Password = 123";
            string query = "INSERT INTO Penumpang values(@Id_Penumpang, @Nama, @Alamat, No_HP)";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Id_Penumpang", textBox1);
                    cmd.Parameters.AddWithValue("@Nama", textBox2);
                    cmd.Parameters.AddWithValue("@Alamat", textBox3);
                    cmd.Parameters.AddWithValue("@No_HP", textBox4);
                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show("Data successfully added.");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connString = "data source= DESKTOP-LAFVQ8T\\MAHFUDZSIDDIQ;Initial Catalog=Terminal_Bus_CEO;Persist Security Info=True;User ID = sa; Password = 123";
            string query = "UPDATE Penumpang SET Id_Penumpang = @Id_Penumpang, Nama = @Nama, Alamat = @Alamat, No_HP = @No_HP";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Id_Penumpang", textBox1);
                    cmd.Parameters.AddWithValue("@Nama", textBox2);
                    cmd.Parameters.AddWithValue("@Alamat", textBox3);
                    cmd.Parameters.AddWithValue("@No_HP", textBox4);
                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show("DATA BERHASIL DITAMBAHKAN");
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

        private void button6_Click(object sender, EventArgs e)
        {
            DataTerminal dataTerminal = new DataTerminal();
            dataTerminal.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = "data source= DESKTOP-LAFVQ8T\\MAHFUDZSIDDIQ;Initial Catalog=Terminal_Bus_CEO;Persist Security Info=True;User ID = sa; Password = 123";
            string query = "DELETE FROM Penumpang WHERE Id_Penumpang = @Id_Penumpang";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@Id_Penumpang", textBox1);
                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show("DATA BERHASIL DITAMBAHKAN");
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
