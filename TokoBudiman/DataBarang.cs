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
    public partial class DataBarang : Form
    {
        public DataBarang()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
        void getData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            SqlCommand cmd = new SqlCommand("Select * From Barang", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void updateData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            con.Open();
            SqlCommand cmd = new SqlCommand("exec updatebarang '" + txtidbarang.Text + "', '" + txtnamabarang.Text + "', '" + txtstok.Text + "', '" + txtharga.Text + "', '" + txtidsuplier.Text +"', '" + txtidpegawai.Text +"'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Success Edit Data...");
            con.Close();
            getData();
        }
        void deleteData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            con.Open();
            SqlCommand delete = new SqlCommand("exec deleteBarang '" + txtidbarang.Text + "'", con);
            delete.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Berhasil di Hapus");
            getData();
        }

        private void DataBarang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tokoBudimanDataSet.Barang' table. You can move, or remove it, as needed.
            this.barangTableAdapter.Fill(this.tokoBudimanDataSet.Barang);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void label3_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TambahBarang tb = new TambahBarang();
            tb.Show();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txtidbarang.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txtnamabarang.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtstok.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtharga.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtidsuplier.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtidpegawai.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            SqlCommand cmd = new SqlCommand("exec searchBarang '" + txtidbarangsearch.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
