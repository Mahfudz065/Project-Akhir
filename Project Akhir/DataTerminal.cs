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
    public partial class DataTerminal : Form
    {
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
    }
}
