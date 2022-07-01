using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokoBudiman
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            DataBarang db = new DataBarang();
            db.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            DataPenjual dp = new DataPenjual();
            dp.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            DataPegawai dpw = new DataPegawai();
            dpw.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DataSuplier ds = new DataSuplier();
            ds.Show();
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Pengaturan pt = new Pengaturan();
            pt.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }
    }
}
