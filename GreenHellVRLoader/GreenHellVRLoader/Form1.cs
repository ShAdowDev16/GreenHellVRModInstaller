using System.Diagnostics;

namespace GreenHellVRLoader
{
    public partial class Form1 : Form
    {
        public string PasswordEntered = "";
        public string Password = "CapybaraTasty";
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            Process.Start("cmd", "/c start https://discord.gg/XNXHmv8V2t");
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}