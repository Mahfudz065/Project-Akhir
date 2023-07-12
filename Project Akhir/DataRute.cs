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
    public partial class DataRute : Form
    {
        string connstring = "data source= DESKTOP-LAFVQ8T\\MAHFUDZSIDDIQ;Initial Catalog=Terminal_Bus_CEO;Persist Security Info=True;User ID = sa; Password = 123";
        public SqlConnection koneksi;
        public DataRute()
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

        private void button1_Click(object sender, EventArgs e)
        {
            string idRute = textBox1.Text;
            string namaRute = textBox2.Text;
            string waktuKeberangkatan = textBox3.Text;
            string waktuKedatangan = textBox4.Text;


            if (idRute == "")
            {
                MessageBox.Show("MASUKKAN ID RUTE", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Rute (Id_Rute, Nama_Rute, Waktu_Keberangkatan, Waktu_Kedatangan)" + "values(@Id_Rute, @Nama_Rute, @Waktu_Keberangkatan, @Waktu_Kedatangan)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Rute", idRute));
                cmd.Parameters.Add(new SqlParameter("Nama_Rute", namaRute));
                cmd.Parameters.Add(new SqlParameter("Waktu_Keberangkatan", waktuKeberangkatan));
                cmd.Parameters.Add(new SqlParameter("Waktu_Kedatangan", waktuKedatangan));


                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idRute = textBox1.Text;
            string namaRute = textBox2.Text;
            string waktuKeberangkatan = textBox3.Text;
            string waktuKedatangan = textBox4.Text;


            if (idRute == "")
            {
                MessageBox.Show("MASUKKAN ID RUTE", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "UPDATE Rute SET Id_Rute = @Id_Rute, Nama_Rute = @Nama_Rute, Waktu_Keberangkatan = @Waktu_Keberangkatan, Waktu_Kedatangan = @Waktu_Kedatangan";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Rute", idRute));
                cmd.Parameters.Add(new SqlParameter("Nama_Rute", namaRute));
                cmd.Parameters.Add(new SqlParameter("Waktu_Kebrangkatan",  waktuKeberangkatan));
                cmd.Parameters.Add(new SqlParameter("Waktui_Kedatangan", waktuKedatangan));


                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
