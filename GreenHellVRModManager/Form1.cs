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


        public void InstallCustomDayNight()
        {
            string downloadLink = "https://github.com/ShAdowDev16/BepinexGHVR/raw/main/CustomDayNight.dll\r\n"; // Replace with the URL of the .dll file you want to download
            string destinationPath = Path.Combine(Path.GetDirectoryName(gameExecutablePath), "BepInEx\\plugins\\CustomDayNight.dll"); // Replace with the desired destination path to save the downloaded .dll file

            try
            {
                using (WebClient client = new WebClient())
                {
                    ChangeStatus("Downloading file...");

                    client.DownloadFile(downloadLink, destinationPath);

                    ChangeStatus("File downloaded successfully!");
                }
            }
            catch (Exception ex)
            {
                ChangeStatus("Error downloading file: " + ex.Message);
                MessageBox.Show("Error occurred while downloading the file. Please check your internet connection or the file might already exist", "Green Hell Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void InstallBepinex()
        {
            string downloadLink = "https://github.com/BepInEx/BepInEx/releases/download/v5.4.21/BepInEx_x64_5.4.21.0.zip";//download link for Bepinex

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
                    MessageBox.Show("For Bepinex to configure itself correctly, start your GHVR for 20 seconds ", "Green Hell Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ChangeStatus("Error installing BepInEx: " + ex.Message);
                MessageBox.Show("Error while installing join the the discord for help maybe it is because you already have (a) file(s) installed from bepinex", "Green Hell Mod Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        //C:\Program Files\Oculus\Software\Software\incuvo-s-a-green-hell-vr\BepInEx\plugins

        public void ChangeStatus(string NewStatus)
        {
            StatusBar.Text = NewStatus;
        }



        // string folderPath = Path.Combine(Path.GetDirectoryName(gameExecutablePath), "BepInEx\\plugins");


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

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            InstallCustomDayNight();
        }
    }
}