using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    btnLoad.Text = "Working...";
                    btnLoad.Enabled = false;


                    int amt = ofdImageSelector.FileNames.Length;
                    foreach (var file in ofdImageSelector.FileNames)
                    {
                        txtOutput.Text += $"Testing {Path.GetFileName(file)}...";

                        var result = await Task.Run(() =>
                        {
                            using (var img = (Bitmap)Image.FromFile(file))
                            {
                                FixRotation(img);

                                var bcr = new BarcodeReader();
                                bcr.Options.PossibleFormats = new[] { BarcodeFormat.PDF_417 };
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

                    sw.Stop();
                    double avg = sw.Elapsed.TotalSeconds / amt * 1000;
                    txtOutput.Text += $"\r\n\r\nTook: {avg:F2} milliseconds per detect \r\n\r\n";
                }
                finally
                {
                    btnLoad.Text = "Load";
                    btnLoad.Enabled = true;
                }
            }
        }

        private void FixRotation(Bitmap img)
        {
            if (Array.IndexOf(img.PropertyIdList, 274) > -1)
            {
                var orientation = (int)img.GetPropertyItem(274).Value[0];
                switch (orientation)
                {
                    case 1:
                        // No rotation required.
                        break;
                    case 2:
                        img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        break;
                    case 3:
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 4:
                        img.RotateFlip(RotateFlipType.Rotate180FlipX);
                        break;
                    case 5:
                        img.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case 6:
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 7:
                        img.RotateFlip(RotateFlipType.Rotate270FlipX);
                        break;
                    case 8:
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
                // This EXIF data is now invalid and should be removed.
                img.RemovePropertyItem(274);
            }
        }

        private void Log(string s)
        {
            txtOutput.Text += s + "\r\n";
        }
    }
}
