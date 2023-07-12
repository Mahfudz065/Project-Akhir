using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Akhir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataPenumpang dataPenumpang = new DataPenumpang();
            dataPenumpang.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTerminal dataTerminal = new DataTerminal();
            dataTerminal.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DataStatusPenumpang dataStatusPenumpang = new DataStatusPenumpang();
            dataStatusPenumpang.Show();
            this.Hide();
        }
    }
}
