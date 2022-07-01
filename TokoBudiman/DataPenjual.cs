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
    public partial class DataPenjual : Form
    {
        public DataPenjual()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
        void getData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            SqlCommand cmd = new SqlCommand("Select * From Transaksi", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void updateData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            con.Open();
            SqlCommand cmd = new SqlCommand("exec updateTransaksi '" + txtidtransaksi.Text + "', '" + txtjumlah.Text + "', '" + txttotal.Text + "', '" + dttgl.Value.ToString("yyyy-MM-dd") + "','"+ txtidpegawai.Text+"', '"+ txtidbarang.Text +"'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Succes Edit Data...");
            con.Close();
            getData();
        }
        void deleteData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            con.Open();
            SqlCommand delete = new SqlCommand("exec deleteTransaksi '" + txtidtransaksi.Text + "'", con);
            delete.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Berhasil di Hapus");
            getData();
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

        private void button1_Click(object sender, EventArgs e)
        {
            TambahPenjual tp = new TambahPenjual();
            tp.Show();
            this.Close();
        }

        private void DataPenjual_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tokoBudimanDataSet.Transaksi' table. You can move, or remove it, as needed.
            this.transaksiTableAdapter.Fill(this.tokoBudimanDataSet.Transaksi);

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            updateData();
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
                txtidtransaksi.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txtjumlah.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txttotal.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                dttgl.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtidpegawai.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtidbarang.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("exec searchTransaksi '" + txtidtrxsearch.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
