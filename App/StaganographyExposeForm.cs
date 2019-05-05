using Steganography;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace App
{
    public partial class StaganographyExposeForm : Form
    {
        public StaganographyExposeForm()
        {
            InitializeComponent();
        }

        Bitmap bitmap1;
        OpenFileDialog openFile = new OpenFileDialog() { Filter = "Image Files|*.png;*.bmp;*.jpg;*.gif;" };
        private void BtnImage_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                bitmap1 = new Bitmap(openFile.FileName);
                pictImage.Image = bitmap1;
            }
        }

        IConfidentialExpose data;
        void BtnRead_Click(object sender, EventArgs e)
        {
            try
            {
                if (bitmap1 == null)
                {
                    return;
                }

                data = ConfidentialDataExposer.Attract(bitmap1, (int)numericUpDown1.Value);

                if (radioButton1.Checked)
                {

                    using (MemoryStream memoryStream = new MemoryStream(data.RawData))
                    {
                        pictResultImage.Image = Image.FromStream(memoryStream);
                    }
                }
                else
                {
                    txtResult.Text = Encoding.UTF8.GetString(data.RawData);
                }
            }
            catch
            {
                MessageBox.Show("Veri istenilen format için uygun değil!");
            }
        }

        void BtnExport_Click(object sender, EventArgs e)
        {


            if (data == null)
            {
                return;
            }

            if (radioButton1.Checked)
            {
                var save = new SaveFileDialog() { Filter = "Png File|*.png;", FileName = "original.png" };
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(save.FileName, data.RawData);
                }
            }
            else
            {
                var save = new SaveFileDialog() { Filter = "Text File|*.txt;", FileName = "original.txt" };
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(save.FileName, txtResult.Text);
                }
            }
        }
    }
}
