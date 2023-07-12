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
    public partial class DataStatusPenumpang : Form
    {
        string connstring = "data source= DESKTOP-LAFVQ8T\\MAHFUDZSIDDIQ;Initial Catalog=Terminal_Bus_CEO;Persist Security Info=True;User ID = sa; Password = 123";
        public SqlConnection koneksi;
        public DataStatusPenumpang()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            koneksi.Open();
            string str = "Select * From dbo.Tiket";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idTiket = textBox1.Text;
            string nomorSeat = textBox2.Text;
            string tanggal = textBox3.Text;
            string harga = textBox4.Text;


            if (idTiket == "")
            {
                MessageBox.Show("MASUKKAN ID TIKET", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Tiket (Id_Tiket, Nomor_Seat, Tanggal, Harga)" + "values(@Id_Tiket, @Nomor_Seat, @Tanggal, @Harga)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Tiket", idTiket));
                cmd.Parameters.Add(new SqlParameter("Nomor_Seat", nomorSeat));
                cmd.Parameters.Add(new SqlParameter("Tanggal", tanggal));
                cmd.Parameters.Add(new SqlParameter("Harga", harga));


                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idTiket = textBox1.Text;
            string nomorSeat = textBox2.Text;
            string tanggal = textBox3.Text;
            string harga = textBox4.Text;


            if (idTiket == "")
            {
                MessageBox.Show("MASUKKAN ID PENUMPANG", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "UPDATE Tiket SET Id_Tiket = @Id_Tiket, Nomor_Seat = @Nomor_Seat, Tanggal = @Tanggal, Harga = @Harga";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Tiket", idTiket));
                cmd.Parameters.Add(new SqlParameter("Nomor_Seat", nomorSeat));
                cmd.Parameters.Add(new SqlParameter("Tanggal", tanggal));
                cmd.Parameters.Add(new SqlParameter("Harga", harga));


                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
