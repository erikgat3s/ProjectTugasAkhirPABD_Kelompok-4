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

namespace TokoBudiman
{
    public partial class DataSuplier : Form
    {
        public DataSuplier()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
        void getData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            SqlCommand cmd = new SqlCommand("Select * From Suplier", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void updateData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            con.Open();
            SqlCommand cmd = new SqlCommand("exec updateSuplier '" + txtidsuplier.Text + "', '" + txtnamasuplier.Text + "', '" + txttlpsupplier.Text + "', '" + txtalamat.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Succes Edit Data...");
            con.Close();
            getData();
        }
        void deleteData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            con.Open();
            SqlCommand delete = new SqlCommand("exec deleteSuplier '" + txtidsuplier.Text + "'", con);
            delete.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Berhasil di Hapus");
            getData();
        }
        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            TambahSuplier ts = new TambahSuplier();
            ts.Show();
            this.Close();
        }

        private void DataSuplier_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tokoBudimanDataSet.Suplier' table. You can move, or remove it, as needed.
            this.suplierTableAdapter.Fill(this.tokoBudimanDataSet.Suplier);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txtidsuplier.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txtnamasuplier.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txttlpsupplier.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtalamat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("exec searchSuplier '" + txtidsupliersearch.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
