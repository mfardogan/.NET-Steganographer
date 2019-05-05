using Steganography;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace App
{
    public partial class SteganographyBaseForm : Form
    {
        public SteganographyBaseForm()
        {
            InitializeComponent();
        }

        protected SecretInformationStaganographer SecretInformationSteganographer { get; set; }

        protected Bitmap bitmapBase = null;
        protected CancellationTokenSource tokenSource = null;

        protected OpenFileDialog openFile = new OpenFileDialog() { Filter = "Image Files|*.png;*.bmp;*.jpg;*.gif;" };
        void BtnSaveAs_Click(object sender, EventArgs e)
        {
            if (pictSteganographedImage.Image == null)
            {
                return;
            }

            var save = new SaveFileDialog() { Filter = "Png File|*.png;", FileName = "steganographed.png" };
            if (save.ShowDialog() == DialogResult.OK)
            {
                pictSteganographedImage.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        void BtnOpenBaseImage_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                bitmapBase = new Bitmap(openFile.FileName);
                pictBaseImage.Image = bitmapBase;
                groupBox1.Text = $"Base Image ({bitmapBase.Width} X {bitmapBase.Height})";
            }
        }

        void BtnCancel_Click(object sender, EventArgs e)
        {
            if (tokenSource == null)
            {
                return;
            }

            tokenSource.Cancel();
        }
    }
}
