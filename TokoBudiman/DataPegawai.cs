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
    public partial class DataPegawai : Form
    {
        public DataPegawai()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
        void getData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            SqlCommand cmd = new SqlCommand("Select * From Pegawai", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void updateData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            con.Open();
            SqlCommand cmd = new SqlCommand("exec updatePegawai '" + txtidPegawai.Text + "', '" + txtnama.Text + "', '" + txtnotlp.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Edit Data Success");
            con.Close();
            getData();
        }
        void deleteData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=TokoBudiman;Persist Security Info=True;User ID=sa;Password=erikaja12");
            con.Open();
            SqlCommand delete = new SqlCommand("exec deletePegawai '" + txtidPegawai.Text + "'", con);
            delete.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Berhasil di Hapus");
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

        private void label5_Click(object sender, EventArgs e)
        {
            DataPenjual dp = new DataPenjual();
            dp.Show();
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
            TambahPegawai tp = new TambahPegawai();
            tp.Show();
            this.Close();
        }

        private void DataPegawai_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tokoBudimanDataSet.Pegawai' table. You can move, or remove it, as needed.
            this.pegawaiTableAdapter.Fill(this.tokoBudimanDataSet.Pegawai);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txtidPegawai.Text = dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                txtnama.Text = dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtnotlp.Text = dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("exec searchPegawai '" + txtidpegawaisearch.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
