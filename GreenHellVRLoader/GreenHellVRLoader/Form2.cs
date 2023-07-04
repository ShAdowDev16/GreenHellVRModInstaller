using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GreenHellVRLoader
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }








        public void InstallBepinex()
        {
            ChangeStatus("Installing Bepinex");
            ResetStatus();// this will reset the status bar after the code is done
        }

        public void ChangeStatus(string NewStatus)
        {
            guna2TextBox1.Text = "Status:" + NewStatus;
        }
        private void ResetStatus()
        {
            guna2TextBox1.Text = "Status:";
        }



        private void guna2Button1_Click(object sender, EventArgs e)//InstallBepinex
        {
            InstallBepinex();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }













}
