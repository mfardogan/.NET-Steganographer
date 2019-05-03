namespace App
{
    partial class ImageSteganographerForm
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
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictSecretImage = new System.Windows.Forms.PictureBox();
            this.btnOpenSecretImage = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictSteganographedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictSecretImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(374, 506);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(98, 23);
            this.btnEncrypt.TabIndex = 15;
            this.btnEncrypt.Text = "Step 3: Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.BtnEncrypt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictSecretImage);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(7, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 230);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Secret Image";
            // 
            // pictSecretImage
            // 
            this.pictSecretImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictSecretImage.Location = new System.Drawing.Point(3, 16);
            this.pictSecretImage.Name = "pictSecretImage";
            this.pictSecretImage.Size = new System.Drawing.Size(219, 211);
            this.pictSecretImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictSecretImage.TabIndex = 1;
            this.pictSecretImage.TabStop = false;
            // 
            // btnOpenSecretImage
            // 
            this.btnOpenSecretImage.Location = new System.Drawing.Point(8, 500);
            this.btnOpenSecretImage.Name = "btnOpenSecretImage";
            this.btnOpenSecretImage.Size = new System.Drawing.Size(224, 23);
            this.btnOpenSecretImage.TabIndex = 18;
            this.btnOpenSecretImage.Text = "Step 2: Open Secret Image";
            this.btnOpenSecretImage.UseVisualStyleBackColor = true;
            this.btnOpenSecretImage.Click += new System.EventHandler(this.BtnOpenSecretImage_Click);
            // 
            // ImageSteganographerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(693, 533);
            this.Controls.Add(this.btnOpenSecretImage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnEncrypt);
            this.Name = "ImageSteganographerForm";
            this.Controls.SetChildIndex(this.numericUpDown1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.btnEncrypt, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnOpenSecretImage, 0);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictSteganographedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictSecretImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictSecretImage;
        private System.Windows.Forms.Button btnOpenSecretImage;
    }
}
