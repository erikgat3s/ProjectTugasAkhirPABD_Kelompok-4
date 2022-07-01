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
    public partial class TambahPegawai : Form
    {
        public TambahPegawai()
        {
            InitializeComponent();
        }

        void insertData()
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            con.Open();
            SqlCommand query = new SqlCommand("exec insertPegawai '" + txtidpegawai.Text + "', '" + txtnamapegawai.Text + "', '" + txtnohppegawai.Text +  "'", con);
            query.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Tersimpan");
            getData();

        }

        void getData()
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            SqlCommand cmd = new SqlCommand("Select * From Pegawai", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        void updateData()
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Pegawai (Id_Pegawai,Nama_Pegawai,Telpon_Pegawai) " +
                "values('" + txtidpegawai.Text + "', '" + txtnamapegawai.Text + "', '" + txtnohppegawai.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Succes Edit Data...");
            con.Close();
            getData();
        }

        void deleteData()
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            con.Open();
            SqlCommand delete = new SqlCommand("insert into Pegawai '" + txtidpegawai.Text + "'", con);
            delete.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Berhasil di Hapus");
            getData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataPegawai bk = new DataPegawai();
            bk.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            insertData();
            con.Close();
        }
    }
}
