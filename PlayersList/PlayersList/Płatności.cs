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

namespace PlayersList
{
    public partial class Płatności : Form
    {
        public Płatności()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tomek\OneDrive\Dokumenty\PlayersDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void FillName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Name from PlayersDb", Con);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();  
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Load(sdr);
            NameCb.ValueMember = "Name";
            NameCb.DataSource = dt;
            Con.Close();
        }

        private void FillForname()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Forname from PlayersDb", Con);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Forname", typeof(string));
            dt.Load(sdr);
            FornameCb.ValueMember = "Forname";
            FornameCb.DataSource = dt;
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from PaymentDb";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            Payment.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void filterby()
        {
            Con.Open();
            string query = "select * from PaymentDb where Zawodnik='"+Search.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            Payment.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void x_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //nameTb.Text = "";
            AmountTb.Text = "";
            //FornameTb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Hide();
        }

        private void Płatności_Load(object sender, EventArgs e)
        {
            FillName();
            FillForname();
            populate(); 
        }
  

        private void button2_Click(object sender, EventArgs e)
        {
            if(NameCb.Text==""||FornameCb.Text==""|| AmountTb.Text=="")
            {
                MessageBox.Show("Brakuje informacji");
            }
            else
            {
                string payperiod=Period.Value.Month.ToString()+Period.Value.Year.ToString();
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PaymentDb where Zawodnik='" + NameCb.SelectedValue.ToString() + FornameCb.SelectedValue.ToString() + "' and Miesiąc='" + payperiod + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);   
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Już zapłacone");
                }
                else
                {
                    string query = "insert into PaymentDb values('" + payperiod + "','" + NameCb.SelectedValue.ToString() +" "+ FornameCb.SelectedValue.ToString() + "'," + AmountTb.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kwota zapłacona");
                }
                Con.Close();
                populate();

                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            filterby();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            populate();
        }
    }
}
