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
using ZXing;

namespace zxingtest
{
    public partial class BarcodeTesterForm : Form
    {
        public BarcodeTesterForm()
        {
            InitializeComponent();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            if (ofdImageSelector.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    btnLoad.Text = "Working...";
                    btnLoad.Enabled = false;

                    foreach (var file in ofdImageSelector.FileNames)
                    {
                        txtOutput.Text += $"Testing {Path.GetFileName(file)}...";

                        var result = await Task.Run(() =>
                        {
                            using (var img = (Bitmap)Image.FromFile(file))
                            {
                                var bcr = new BarcodeReader();
                                bcr.Options.PossibleFormats = new[] { BarcodeFormat.PDF_417 };
                                bcr.AutoRotate = true;
                                return bcr.Decode(img);
                            }
                        });

                        if (result != null && !string.IsNullOrEmpty(result.Text))
                        {
                            txtOutput.Text += "OK!\r\n";
                        }
                        else
                        {
                            txtOutput.Text += "BAD\r\n";
                        }
                    }
                }
                finally
                {
                    btnLoad.Text = "Load";
                    btnLoad.Enabled = true;
                }
            }
        }

        private void Log(string s)
        {
            txtOutput.Text += s + "\r\n";
        }
    }
}
