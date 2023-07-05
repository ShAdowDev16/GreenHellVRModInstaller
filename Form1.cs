using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.IO.Compression;

namespace GreenHellVRModManager
{
    public partial class Form1 : Form
    {
        private string gameExecutablePath;
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please lead us the the GHVR.exe file ", "Green Hell Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Prompt the user to select the game executable
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files|*.exe";
            openFileDialog.Title = "Select the game executable";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                gameExecutablePath = openFileDialog.FileName;
                ChangeStatus("Game executable selected: " + gameExecutablePath);
            }
            else
            {
                MessageBox.Show("You must select the game executable to continue.");
                Application.Exit();
            }
        }

        public void InstallBepinex()
        {
            string downloadLink = "https://github.com/ShAdowDev16/BepinexGHVR/raw/main/BepinexGHVR.zip"; // Replace with the actual download link

            string destinationFolder = Path.GetDirectoryName(gameExecutablePath);
            string tempZipFile = Path.Combine(Path.GetTempPath(), "bepinex.zip");

            try
            {
                using (WebClient client = new WebClient())
                {
                    ChangeStatus("Downloading BepInEx...");

                    client.DownloadFile(downloadLink, tempZipFile);

                    ChangeStatus("Extracting BepInEx...");

                    ZipFile.ExtractToDirectory(tempZipFile, destinationFolder);

                    ChangeStatus("BepInEx installed successfully!");
                }
            }
            catch (Exception ex)
            {
                ChangeStatus("Error installing BepInEx: " + ex.Message);
            }
            finally
            {
                // Clean up the temporary zip file if it exists
                if (File.Exists(tempZipFile))
                {
                    File.Delete(tempZipFile);
                }
            }
        }




        public void ChangeStatus(string NewStatus)
        {
            StatusBar.Text = NewStatus;
        }




        public void FindMods()
        {
           string folderPath = Path.Combine(Path.GetDirectoryName(gameExecutablePath), "BepInEx\\plugins"); ;

            // Get all the files in the specified folder
            string[] files = Directory.GetFiles(folderPath);

            // Clear existing items in the ListBox
            PluginsList.Items.Clear();

            // Add each file name to the ListBox
            foreach (string file in files)
            {
                PluginsList.Items.Add(Path.GetFileName(file));
            }
        }






        private void guna2Button2_Click(object sender, EventArgs e)//oculusButton
        {
            Process.Start("cmd", "/c start https://www.oculus.com/experiences/quest/3815577785147028/");
        }

        private void guna2Button1_Click(object sender, EventArgs e)//steambutton
        {
            Process.Start("cmd", "/c start https://store.steampowered.com/app/1782330/Green_Hell_VR/");

        }

        private void DiscordButton_Click(object sender, EventArgs e)//discordbutton
        {
            Process.Start("cmd", "/c start https://discord.gg/XNXHmv8V2t");
        }

        private void GuideButton_Click(object sender, EventArgs e)//guidebutton
        {
            Process.Start("cmd", "/c start https://www.youtube.com/channel/UCwFuV5PhIs38fPujJ37pJOA");//change this later
        }

        private void PluginsFoundList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)//plugins list
        {

        }

        private void FindModsButton_Click(object sender, EventArgs e)
        {
            FindMods();
        }

        private void InstallBepinexButton_Click(object sender, EventArgs e)
        {
            InstallBepinex();
        }
    }
}
