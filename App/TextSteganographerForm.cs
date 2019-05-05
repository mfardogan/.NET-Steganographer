using Steganography;
using System;
using System.Threading;
using System.Windows.Forms;

namespace App
{
    public partial class TextSteganographerForm : SteganographyBaseForm
    {
        public TextSteganographerForm()
        {
            InitializeComponent();
        }

        async void BtnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (bitmapBase == null)
                {
                    MessageBox.Show("Please select base  image!");
                    return;
                }

                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please enter secret text!");
                    return;
                }

                tokenSource = new CancellationTokenSource();

                IConfidential information = new TextConfidential(textBox1.Text)
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
