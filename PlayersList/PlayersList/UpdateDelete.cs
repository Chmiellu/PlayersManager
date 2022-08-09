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
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tomek\OneDrive\Dokumenty\PlayersDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from PlayersDb";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            Player.DataSource = ds.Tables[0];
            Con.Close();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            populate();
        }
        int key=0;
        private void Player_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(Player.SelectedRows[0].Cells[0].Value.ToString());
            NameTb.Text = Player.SelectedRows[0].Cells[1].Value.ToString();
            FornameTb.Text = Player.SelectedRows[0].Cells[2].Value.ToString();
            WiekTb.Text = Player.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = Player.SelectedRows[0].Cells[4].Value.ToString();
            PositionCb.Text = Player.SelectedRows[0].Cells[5].Value.ToString();
            FootCb.Text = Player.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            FornameTb.Text = "";
            WiekTb.Text = "";
            PhoneTb.Text = "";
            PositionCb.Text = "";
            FootCb.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(key==0)
            {
                MessageBox.Show("Wybierz zawodnika którego chcesz usunąć");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from PlayersDb where Id=" + key + ";"; 
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Zawodnik został usunięty");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0 || NameTb.Text == "" || FornameTb.Text == "" || WiekTb.Text == ""  || PhoneTb.Text == "" ||PositionCb.Text == "" || FootCb.Text == "" )
            {
                MessageBox.Show("Brakuje informacji");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update PlayersDb set Name='"+ NameTb.Text +"', Phone='"+PhoneTb.Text+ "', Forname='" + FornameTb.Text + "', Age='" + WiekTb.Text + "', Position='" + PositionCb.Text + "', Foot='" + FootCb.Text +"' where Id="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Zawodnik został zaktualizowany");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void x_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
