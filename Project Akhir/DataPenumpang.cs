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
        string connstring = "data source= DESKTOP-LAFVQ8T\\MAHFUDZSIDDIQ;Initial Catalog=Terminal_Bus_CEO;Persist Security Info=True;User ID = sa; Password = 123";
        public SqlConnection koneksi;


        public object IdPenumpang { get; private set; }

        public DataPenumpang()
        {
            InitializeComponent();
            koneksi = new SqlConnection(connstring);
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
            string idPenumpang = textBox1.Text;
            string nama = textBox2.Text;
            string alamat = textBox3.Text;
            string noHp = textBox4.Text;

            if (idPenumpang == "")
            {
                MessageBox.Show("MASUKKAN ID PENUMPANG", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Penumpang (Id_Penumpang, Nama, Alamat, No_HP)" + "values(@Id_Penumpang, @Nama, @Alamat. @N0_HP)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Penumpang", idPenumpang));
                cmd.Parameters.Add(new SqlParameter("Nama", nama));
                cmd.Parameters.Add(new SqlParameter("Alamat", alamat));
                cmd.Parameters.Add(new SqlParameter("No_HP", noHp));


                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "SUKSES",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idPenumpang = textBox1.Text;
            string nama = textBox2.Text;
            string alamat = textBox3.Text;
            string noHp = textBox4.Text;


            if (idPenumpang == "")
            {
                MessageBox.Show("MASUKKAN ID PENUMPANG", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "UPDATE Penumpang SET Id_Penumpang = @Id_Penumpang, Nama = @Nama, Alamat = @Alamat, No_HP = @No_HP";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Penumpang", idPenumpang));
                cmd.Parameters.Add(new SqlParameter("Nama", nama));
                cmd.Parameters.Add(new SqlParameter("Alamat", alamat));
                cmd.Parameters.Add(new SqlParameter("No_HP", noHp));


                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string idPenumpang = textBox1.Text;


            if (idPenumpang == "")
            {
                MessageBox.Show("MASUKKAN ID PENUMPANG", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "DELETE FROM Penumpang WHERE Id_Penumpang = @Id_Penumpang";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Penumpang", idPenumpang));



                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string nama = textBox2.Text;


            if (nama == "")
            {
                MessageBox.Show("MASUKKAN NAMA PENUMPANG", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "SELECT * FROM Penumpang WHERE Nama = @Nama";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Nama", nama));



                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            koneksi.Open();
            string str = "Select * From dbo.Penumpang";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }
    }
}

        