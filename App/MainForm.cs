using Steganography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

           
        }

        void Button1_Click(object sender, EventArgs e)
        {
            ImageSteganographerForm imageSteganographerForm = new ImageSteganographerForm();
            imageSteganographerForm.ShowDialog();
        }

        void Button3_Click(object sender, EventArgs e)
        {
            StaganographyExposeForm form2 = new StaganographyExposeForm();
            form2.ShowDialog();
        }

        void Button2_Click(object sender, EventArgs e)
        {
            TextSteganographerForm textSteganographerForm = new TextSteganographerForm();
            textSteganographerForm.Show();
        }
    }
}
