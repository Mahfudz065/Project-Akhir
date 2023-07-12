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
    public partial class DataDriver : Form
    {
        string connstring = "data source= DESKTOP-LAFVQ8T\\MAHFUDZSIDDIQ;Initial Catalog=Terminal_Bus_CEO;Persist Security Info=True;User ID = sa; Password = 123";
        public SqlConnection koneksi;
        public DataDriver()
        {
            InitializeComponent();
            koneksi = new SqlConnection(connstring);
        }

        private void DataDriver_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string idDriver = textBox1.Text;
            string nama = textBox2.Text;
            string noHP = textBox3.Text;


            if (idDriver == "")
            {
                MessageBox.Show("MASUKKAN ID DRIVER", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Driver (Id_Driver, Nama, No_HP)" + "values(@Id_Driver, @Nama, @No_HP)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Driver", idDriver));
                cmd.Parameters.Add(new SqlParameter("Nama", nama));
                cmd.Parameters.Add(new SqlParameter("No_HP", noHP));


                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string idDriver = textBox1.Text;
            string nama = textBox2.Text;
            string noHP = textBox3.Text;


            if (idDriver == "")
            {
                MessageBox.Show("MASUKKAN ID DRIVER", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "UPDATE Driver SET Id_Driver = @Id_Driver, Nama = @Nama, No_HP = @No_HP";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Driver", idDriver));
                cmd.Parameters.Add(new SqlParameter("Nama", nama));
                cmd.Parameters.Add(new SqlParameter("No_HP", noHP));


                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string nama = textBox2.Text;


            if (nama == "")
            {
                MessageBox.Show("MASUKKAN NAMA DRIVER", "PERINGATAN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "DELETE FROM Driver WHERE Nama = @Nama";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Nama", nama));



                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
