using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialInterface
{
    public partial class Options : Form
    {
        public String Default_OptionsLogText = "";
        public String FirmwarePath = "";
        public bool Default_AdvancedSettingsEnabled = false;


        public Options()
        {
            InitializeComponent();
        }

        private void buttonOptionsLogFileBrowse_Click(object sender, EventArgs e)
        {
            // New FolderBrowserDialog instance
            FolderBrowserDialog Fld = new FolderBrowserDialog();

            // Set initial selected folder
            if (optionsLogTextBox.Text.Equals(""))
                Fld.SelectedPath = "c:\\";
            else
                Fld.SelectedPath = optionsLogTextBox.Text;

            // Show the "Make new folder" button
            Fld.ShowNewFolderButton = true;

            MessageBox.Show("Please create a new folder that will contain the logs. A new log will be created and stamped each day.");

            if (Fld.ShowDialog() == DialogResult.OK)
            {
                // Select successful
                optionsLogTextBox.Text = Fld.SelectedPath;
            }
        }

        private void buttonOptionsCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonOptionsOK_Click(object sender, EventArgs e)
        {
            int fileCheck = 0;

            if (File.Exists(optionsFirmwarePathTextBox.Text) || optionsFirmwarePathTextBox.Text.Equals(""))
            {
                FirmwarePath = optionsFirmwarePathTextBox.Text;
                fileCheck++;
            }
            else
            {
                MessageBox.Show("Firmware Path does not exist, please select a real path or browse for one.");
            }

            if (Directory.Exists(optionsLogTextBox.Text) || optionsLogTextBox.Text.Equals(""))
            {
                Default_OptionsLogText = optionsLogTextBox.Text;
                fileCheck++;
            }
            else
            {
                MessageBox.Show("Folder Path does not exist, please select a real path or browse for one.");
            }

            if (fileCheck == 2)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            optionsLogTextBox.Text = Default_OptionsLogText;
            optionsFirmwarePathTextBox.Text = FirmwarePath;

            if (Default_AdvancedSettingsEnabled)
            {
                advancedSettingsTickBox.Checked = true;
            }
        }

        private void buttonFirmwarePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "hex|*.hex";
            //Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff|" + "All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                FirmwarePath = fileDialog.FileName;
                optionsFirmwarePathTextBox.Text = FirmwarePath;
            }
        }
    }
}
