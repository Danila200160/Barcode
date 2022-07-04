using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using ZXing;




namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }       

        // Generate для Barcode
        private void button2_Click(object sender, EventArgs e)
        {
            int W = Convert.ToInt32(this.textBox3.Text.Trim());
            int H = Convert.ToInt32(this.textBox4.Text.Trim());
            //BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            //Color forecolor = Color.Black;
            //Color backcolor = Color.White;
            //Image img = b.Encode(BarcodeLib.TYPE.CODE128, textBox1.Text, forecolor, backcolor, (int)(W), (int)(H));
            //pictureBox1.Image = img;           
            BarcodeWriter writer = new BarcodeWriter() 
            { 
                Format = BarcodeFormat.CODE_128, 
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = W,
                    Height = H                    
                }
            };
            pictureBox1.Image = writer.Write(textBox1.Text);           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Save для Barcode
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PNG|*.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    pictureBox1.Image.Save(saveFileDialog.FileName);
            }
        }
        // Save для QRCODE
        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PNG|*.png" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    pictureBox1.Image.Save(saveFileDialog.FileName);
            }
        }
        // Generate для QRCODE
        private void button2_Click_1(object sender, EventArgs e)
        {
            int S = Convert.ToInt32(this.textBox5.Text.Trim());            
            QRCodeGenerator qr = new QRCodeGenerator();
            var MyData = qr.CreateQrCode(textBox2.Text, QRCodeGenerator.ECCLevel.M);
            var data = new QRCode(MyData);
            pictureBox1.Image = data.GetGraphic(S);
            

        }
    }
}
