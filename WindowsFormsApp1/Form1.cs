using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qrmetin = textBox1.Text;
            QRCodeGenerator qRGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRGenerator.CreateQrCode(qrmetin, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap qrCodeImage = qRCode.GetGraphic(20);
            pictureBox1.Image = qrCodeImage;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";

            sfd.Title = "Kayıt";

            sfd.FileName = textBox1.Text+""+"qrcode";

            DialogResult sonuç = sfd.ShowDialog();

            if (sonuç == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
            }
        }


        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
