using Steganography;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace App
{
    public partial class ImageSteganographerForm : SteganographyBaseForm
    {
        Bitmap bitmapSecret = null;
        public ImageSteganographerForm()
        {
            InitializeComponent();
        }

        void BtnOpenSecretImage_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                bitmapSecret = new Bitmap(openFile.FileName);
                pictSecretImage.Image = bitmapSecret;
                groupBox2.Text = $"Secret Image ({bitmapSecret.Width} X {bitmapSecret.Height})";

            }
        }

        async void BtnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (bitmapBase == null || bitmapSecret == null)
                {
                    MessageBox.Show("Please select base and secret images!");
                    return;
                }
                tokenSource = new CancellationTokenSource();

                IConfidential information = new ImageConfidential(bitmapSecret)
                {
                    Key = (int)numericUpDown1.Value,
                    Image = bitmapBase,
                };

                SecretInformationSteganographer = new SecretInformationStaganographer(information);
                IConfidentialResult result = await SecretInformationSteganographer.Inject(tokenSource.Token);

                pictSteganographedImage.Image = result.Image;
                groupBox3.Text = $"Steganographed Image({result.Image.Width} X {result.Image.Height})";
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("İşlem iptal edildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (tokenSource != null)
                {
                    tokenSource.Dispose();
                }
            }
        }
    }
}
