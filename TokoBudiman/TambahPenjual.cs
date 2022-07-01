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
    public partial class TambahPenjual : Form
    {
        public TambahPenjual()
        {
            InitializeComponent();
            Fill_Combo_Barang();
            Fill_Combo_Pegawai();
        }

        void Fill_Combo_Pegawai()
        {
            SqlConnection conn = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            SqlCommand query = new SqlCommand("Select * From Pegawai", conn);
            SqlDataAdapter sda = new SqlDataAdapter(query);

            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);

                cbpegawai.DisplayMember = "Id_Pegawai";
                cbpegawai.DataSource = dt;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void Fill_Combo_Barang()
        {
            SqlConnection conn = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            SqlCommand query = new SqlCommand("Select * From Barang", conn);
            SqlDataAdapter sda = new SqlDataAdapter(query);

            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);

                cbbarang.DisplayMember = "Id_Barang";
                cbbarang.DataSource = dt;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void insertData()
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            con.Open();
            SqlCommand query = new SqlCommand("exec insertTransaksi '" + txtidpenjual.Text + "', '" + txtjumlah.Text + "', '" + txtharga.Text + "', '" + dttgl.Value.ToString("yyyy-MM-dd") + "', '" + cbpegawai.Text + "', '" + cbbarang.Text + "'", con);
            query.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Tersimpan");
            getData();

        }

        void getData()
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            SqlCommand cmd = new SqlCommand("Select * From Transaksi", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataPenjual bt = new DataPenjual();
            bt.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            insertData();
            con.Close();
        }

        private void txtharga_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
