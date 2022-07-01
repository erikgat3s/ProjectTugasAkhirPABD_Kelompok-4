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
    public partial class Pengaturan : Form
    {
        public Pengaturan()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();
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
            DataPegawai dp = new DataPegawai();
            dp.Show();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            DataSuplier ds = new DataSuplier();
            ds.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }
    }
}
