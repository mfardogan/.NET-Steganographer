namespace App
{
    partial class SteganographyBaseForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictBaseImage = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictSteganographedImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnOpenBaseImage = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBaseImage)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictSteganographedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictBaseImage);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 236);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base Image";
            // 
            // pictBaseImage
            // 
            this.pictBaseImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictBaseImage.Location = new System.Drawing.Point(3, 16);
            this.pictBaseImage.Name = "pictBaseImage";
            this.pictBaseImage.Size = new System.Drawing.Size(218, 217);
            this.pictBaseImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictBaseImage.TabIndex = 0;
            this.pictBaseImage.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictSteganographedImage);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(238, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(447, 496);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Steganographed Image";
            // 
            // pictSteganographedImage
            // 
            this.pictSteganographedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictSteganographedImage.Location = new System.Drawing.Point(3, 16);
            this.pictSteganographedImage.Name = "pictSteganographedImage";
            this.pictSteganographedImage.Size = new System.Drawing.Size(441, 477);
            this.pictSteganographedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictSteganographedImage.TabIndex = 1;
            this.pictSteganographedImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 510);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Password:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(290, 507);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(74, 20);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(586, 506);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(99, 23);
            this.btnSaveAs.TabIndex = 9;
            this.btnSaveAs.Text = "Step 4: Save File";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
            // 
            // btnOpenBaseImage
            // 
            this.btnOpenBaseImage.Location = new System.Drawing.Point(8, 473);
            this.btnOpenBaseImage.Name = "btnOpenBaseImage";
            this.btnOpenBaseImage.Size = new System.Drawing.Size(224, 23);
            this.btnOpenBaseImage.TabIndex = 14;
            this.btnOpenBaseImage.Text = "Step1: Open Base Image";
            this.btnOpenBaseImage.UseVisualStyleBackColor = true;
            this.btnOpenBaseImage.Click += new System.EventHandler(this.BtnOpenBaseImage_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(476, 506);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 23);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel Encryption";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // SteganographyBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 533);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpenBaseImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SteganographyBaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".NET Steganography | mfardogan";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictBaseImage)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictSteganographedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictBaseImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnOpenBaseImage;
        protected System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.PictureBox pictSteganographedImage;
        protected System.Windows.Forms.NumericUpDown numericUpDown1;
        protected System.Windows.Forms.Button btnCancel;
    }
}