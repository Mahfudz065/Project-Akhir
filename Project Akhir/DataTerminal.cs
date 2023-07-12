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
        string connstring = "data source= DESKTOP-LAFVQ8T\\MAHFUDZSIDDIQ;Initial Catalog=Terminal_Bus_CEO;Persist Security Info=True;User ID = sa; Password = 123";
        public SqlConnection koneksi;

        public DataTerminal()
        {
            InitializeComponent();
            koneksi = new SqlConnection(connstring);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataPenumpang dataPenumpang = new DataPenumpang();
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

            string idBus = textBox1.Text;
            string namaBus = textBox2.Text;
            string typeBus = textBox3.Text;


            if (idBus == "")
            {
                MessageBox.Show("masukan id bus", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "insert into dbo.Bus (Id_Bus, Nama_Bus, Type_Bus)" + "values(@Id_Bus, @Nama_Bus, @Type_Bus)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Bus", idBus));
                cmd.Parameters.Add(new SqlParameter("Nama_Bus", namaBus));
                cmd.Parameters.Add(new SqlParameter("nh", typeBus));


                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            koneksi.Open();
            string str = "Select * From dbo.Bus";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string idBus = textBox1.Text;
            string namaBus = textBox2.Text;
            string typeBus = textBox3.Text;


            if (idBus == "")
            {
                MessageBox.Show("masukan id bus", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "UPDATE Bus SET Id_Bus = @Id_bus, Nama Bus = @Nama Bus, Type Bus = @TypeBus";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Bus", idBus));
                cmd.Parameters.Add(new SqlParameter("Nama_Bus", namaBus));
                cmd.Parameters.Add(new SqlParameter("nh", typeBus));


                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string idBus = textBox1.Text;


            if (idBus == "")
            {
                MessageBox.Show("masukan id bus", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "DELETE FROM Bus WHERE Id_Bus = @Id_Bus";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Bus", idBus));



                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string namaBus = textBox2.Text;


            if (namaBus == "")
            {
                MessageBox.Show("MASUKKAN NAMA BUS", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                koneksi.Open();
                string str = "SELECT * FROM Bus WHERE Nama_Bus = @Nama_Bus";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id_Bus", namaBus));



                koneksi.Close();
                MessageBox.Show("Data Berhasil disimpan", "sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

        