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
    public partial class TambahBarang : Form
    {
        public TambahBarang()
        {
            InitializeComponent();
            Fill_Combo_Suplier();
            Fill_Combo_Pegawai();
        }

        void Fill_Combo_Suplier()
        {
            SqlConnection conn = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            SqlCommand query = new SqlCommand("Select * From Suplier", conn);
            SqlDataAdapter sda = new SqlDataAdapter(query);

            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                sda.Fill(dt);

                cbidsuplier.DisplayMember = "Id_Suplier";
                cbidsuplier.DataSource = dt;
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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

                cbidpegawai.DisplayMember = "Id_Pegawai";
                cbidpegawai.DataSource = dt;
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
            SqlCommand query = new SqlCommand("exec insertBarang '" + txtIdBarang.Text + "', '" + txtNamaBarang.Text + "', '" + txtStokBarang.Text + "', '" + txtHargaBarang.Text +  "', '" + cbidsuplier.Text + "', '" +cbidpegawai.Text + "'", con);
            
            query.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Tersimpan");
            getData();

        }

        void getData()
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            SqlCommand cmd = new SqlCommand("Select * From Barang", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        void updateData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI\\MSSQLSERVER02;Initial Catalog=datapenjualan;User ID=sa;Password=123");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Barang (Id_Barang,nama_pembeli,Nama_Barang,Stok_Barang,Harga_Barang,Id_Suplier,Id_Pegawai) " +
                "values('" + txtIdBarang.Text + "', '" + txtNamaBarang.Text + "', '" + txtStokBarang.Text + "', '" + txtHargaBarang.Text + "', '" + cbidsuplier.Text + "', '" + cbidpegawai + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Succes Edit Data...");
            con.Close();
            getData();
        }

        void deleteData()
        {
            SqlConnection con = new SqlConnection("Data Source=MSI\\MSSQLSERVER02;Initial Catalog=datapenjualan;User ID=sa;Password=123");
            con.Open();
            SqlCommand delete = new SqlCommand("insert into barang '" + txtIdBarang.Text + "'", con);
            delete.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Berhasil di Hapus");
            getData();
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBarang bt = new DataBarang();
            bt.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            insertData();
            con.Close();
        }
    }
}
