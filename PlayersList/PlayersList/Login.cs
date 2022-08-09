namespace PlayersList
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(idTb.Text == "" || passwordTb.Text == "")
            {
                MessageBox.Show("Brakuje informacji");
            }
            else if(idTb.Text == "Admin" && passwordTb.Text=="Admin")
            {
                MainForm main = new MainForm();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("B³êdny login lub has³o");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}