namespace SerialTerminal.Main
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.logLabel2 = new System.Windows.Forms.Label();
			this.optionsLogTextBox = new System.Windows.Forms.TextBox();
			this.buttonOptionsLogFileBrowse = new System.Windows.Forms.Button();
			this.buttonOptionsOK = new System.Windows.Forms.Button();
			this.buttonOptionsCancel = new System.Windows.Forms.Button();
			this.logLabel = new System.Windows.Forms.TextBox();
			this.advancedSettingsTickBox = new System.Windows.Forms.CheckBox();
			this.buttonFirmwarePath = new System.Windows.Forms.Button();
			this.optionsFirmwarePathTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.opt_serialBin_CB = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// logLabel2
			// 
			this.logLabel2.AutoSize = true;
			this.logLabel2.Location = new System.Drawing.Point(12, 39);
			this.logLabel2.Name = "logLabel2";
			this.logLabel2.Size = new System.Drawing.Size(69, 13);
			this.logLabel2.TabIndex = 0;
			this.logLabel2.Text = "Log File Path";
			// 
			// optionsLogTextBox
			// 
			this.optionsLogTextBox.Location = new System.Drawing.Point(116, 36);
			this.optionsLogTextBox.Name = "optionsLogTextBox";
			this.optionsLogTextBox.Size = new System.Drawing.Size(214, 20);
			this.optionsLogTextBox.TabIndex = 1;
			// 
			// buttonOptionsLogFileBrowse
			// 
			this.buttonOptionsLogFileBrowse.Location = new System.Drawing.Point(346, 34);
			this.buttonOptionsLogFileBrowse.Name = "buttonOptionsLogFileBrowse";
			this.buttonOptionsLogFileBrowse.Size = new System.Drawing.Size(75, 23);
			this.buttonOptionsLogFileBrowse.TabIndex = 2;
			this.buttonOptionsLogFileBrowse.Text = "Browse";
			this.buttonOptionsLogFileBrowse.UseVisualStyleBackColor = true;
			this.buttonOptionsLogFileBrowse.Click += new System.EventHandler(this.buttonOptionsLogFileBrowse_Click);
			// 
			// buttonOptionsOK
			// 
			this.buttonOptionsOK.Location = new System.Drawing.Point(255, 174);
			this.buttonOptionsOK.Name = "buttonOptionsOK";
			this.buttonOptionsOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOptionsOK.TabIndex = 3;
			this.buttonOptionsOK.Text = "OK";
			this.buttonOptionsOK.UseVisualStyleBackColor = true;
			this.buttonOptionsOK.Click += new System.EventHandler(this.buttonOptionsOK_Click);
			// 
			// buttonOptionsCancel
			// 
			this.buttonOptionsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOptionsCancel.Location = new System.Drawing.Point(346, 174);
			this.buttonOptionsCancel.Name = "buttonOptionsCancel";
			this.buttonOptionsCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonOptionsCancel.TabIndex = 4;
			this.buttonOptionsCancel.Text = "Cancel";
			this.buttonOptionsCancel.UseVisualStyleBackColor = true;
			this.buttonOptionsCancel.Click += new System.EventHandler(this.buttonOptionsCancel_Click);
			// 
			// logLabel
			// 
			this.logLabel.BackColor = System.Drawing.SystemColors.Control;
			this.logLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.logLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logLabel.Location = new System.Drawing.Point(15, 10);
			this.logLabel.Multiline = true;
			this.logLabel.Name = "logLabel";
			this.logLabel.Size = new System.Drawing.Size(394, 18);
			this.logLabel.TabIndex = 6;
			this.logLabel.Text = "Folder that will contain all the log files for both Serial and Tcp logging";
			// 
			// advancedSettingsTickBox
			// 
			this.advancedSettingsTickBox.AutoSize = true;
			this.advancedSettingsTickBox.Location = new System.Drawing.Point(15, 174);
			this.advancedSettingsTickBox.Name = "advancedSettingsTickBox";
			this.advancedSettingsTickBox.Size = new System.Drawing.Size(152, 17);
			this.advancedSettingsTickBox.TabIndex = 7;
			this.advancedSettingsTickBox.Text = "Enable Advanced Settings";
			this.advancedSettingsTickBox.UseVisualStyleBackColor = true;
			// 
			// buttonFirmwarePath
			// 
			this.buttonFirmwarePath.Location = new System.Drawing.Point(346, 73);
			this.buttonFirmwarePath.Name = "buttonFirmwarePath";
			this.buttonFirmwarePath.Size = new System.Drawing.Size(75, 23);
			this.buttonFirmwarePath.TabIndex = 10;
			this.buttonFirmwarePath.Text = "Browse";
			this.buttonFirmwarePath.UseVisualStyleBackColor = true;
			this.buttonFirmwarePath.Click += new System.EventHandler(this.buttonFirmwarePath_Click);
			// 
			// optionsFirmwarePathTextBox
			// 
			this.optionsFirmwarePathTextBox.Location = new System.Drawing.Point(116, 75);
			this.optionsFirmwarePathTextBox.Name = "optionsFirmwarePathTextBox";
			this.optionsFirmwarePathTextBox.Size = new System.Drawing.Size(214, 20);
			this.optionsFirmwarePathTextBox.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 78);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Serial Tab Firmware";
			// 
			// opt_serialBin_CB
			// 
			this.opt_serialBin_CB.AutoSize = true;
			this.opt_serialBin_CB.Enabled = false;
			this.opt_serialBin_CB.Location = new System.Drawing.Point(15, 151);
			this.opt_serialBin_CB.Name = "opt_serialBin_CB";
			this.opt_serialBin_CB.Size = new System.Drawing.Size(161, 17);
			this.opt_serialBin_CB.TabIndex = 12;
			this.opt_serialBin_CB.Text = "Serial Program Binary Format";
			this.opt_serialBin_CB.UseVisualStyleBackColor = true;
			// 
			// Options
			// 
			this.AcceptButton = this.buttonOptionsOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonOptionsCancel;
			this.ClientSize = new System.Drawing.Size(433, 219);
			this.Controls.Add(this.opt_serialBin_CB);
			this.Controls.Add(this.buttonFirmwarePath);
			this.Controls.Add(this.optionsFirmwarePathTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.advancedSettingsTickBox);
			this.Controls.Add(this.logLabel);
			this.Controls.Add(this.buttonOptionsCancel);
			this.Controls.Add(this.buttonOptionsOK);
			this.Controls.Add(this.buttonOptionsLogFileBrowse);
			this.Controls.Add(this.optionsLogTextBox);
			this.Controls.Add(this.logLabel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Options";
			this.ShowIcon = false;
			this.Text = "Options";
			this.Load += new System.EventHandler(this.OptionsForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label logLabel2;
        public System.Windows.Forms.TextBox optionsLogTextBox;
        private System.Windows.Forms.Button buttonOptionsLogFileBrowse;
        private System.Windows.Forms.Button buttonOptionsOK;
        private System.Windows.Forms.Button buttonOptionsCancel;
        private System.Windows.Forms.TextBox logLabel;
        public System.Windows.Forms.CheckBox advancedSettingsTickBox;
        private System.Windows.Forms.Button buttonFirmwarePath;
        public System.Windows.Forms.TextBox optionsFirmwarePathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox opt_serialBin_CB;
    }
}