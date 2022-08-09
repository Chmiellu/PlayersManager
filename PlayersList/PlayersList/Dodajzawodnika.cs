using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace PlayersList
{
    public partial class Dodajzawodnika : Form
    {
        public Dodajzawodnika()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tomek\OneDrive\Dokumenty\PlayersDb.mdf;Integrated Security=True;Connect Timeout=30");

        public void Dodajzawodnika_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(ImieTb.Text == "" || NazwiskoTb.Text == "" || WiekTb.Text == "" || TelefonTb.Text == "" )
            {
                MessageBox.Show("Brakuje wymaganych informacji");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into PlayersDb values('" + ImieTb.Text + "','" + NazwiskoTb.Text + "','" + WiekTb.Text + "','" + TelefonTb.Text + "','" + PozycjaCb.SelectedItem.ToString() + "','" + NogaCb.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Zawodnik został dodany pomyślnie");

                    Con.Close();
                    ImieTb.Text = "";
                    NazwiskoTb.Text = "";
                    WiekTb.Text = "";
                    TelefonTb.Text = "";
                    PozycjaCb.Text = "";
                    NogaCb.Text = "";
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImieTb.Text = "";
            NazwiskoTb.Text = "";
            WiekTb.Text = "";
            TelefonTb.Text = "";
            PozycjaCb.Text = "";
            NogaCb.Text = "";
        }

        private void x_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm frm = new MainForm();
            frm.Show();
            this.Hide();
        }
    }
}
