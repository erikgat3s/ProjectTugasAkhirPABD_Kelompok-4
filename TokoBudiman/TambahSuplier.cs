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
    public partial class TambahSuplier : Form
    {
        public TambahSuplier()
        {
            InitializeComponent();
        }
        void insertData()
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            con.Open();
            SqlCommand query = new SqlCommand("exec insertSuplier '" + txtidsuplier.Text + "', '" + txtnamasuplier.Text + "', '" + txttlpsuplier.Text + "', '" + txtalamatsuplier.Text + "'", con);
            query.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Tersimpan");
            getData();

        }

        void getData()
        {
            SqlConnection con = new SqlConnection("Data Source = MSI; Initial Catalog = TokoBudiman; Persist Security Info = True; User ID = sa; Password = erikaja12");
            SqlCommand cmd = new SqlCommand("select * from Suplier", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DataSuplier bt = new DataSuplier();
            bt.Show();
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
