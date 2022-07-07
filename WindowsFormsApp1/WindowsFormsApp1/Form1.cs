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
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            int W = Convert.ToInt32(this.textBox3.Text.Trim());
            int H = Convert.ToInt32(this.textBox4.Text.Trim());



            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            Color forecolor = Color.Black;
            Color backcolor = Color.White;
            Image img = b.Encode(BarcodeLib.TYPE.CODE128, textBox1.Text, forecolor, backcolor, (int)(W), (int)(H));
            pictureBox1.Image = img;
            //BarcodeWriter writer = new BarcodeWriter()
            //{
            //    Format = BarcodeFormat.CODE_128,
            //    Options = new ZXing.Common.EncodingOptions
            //    {
            //        Width = 200,
            //        Height = 100
            //    }
            //};
            //pictureBox1.Height = H;
            //pictureBox1.Width = W;
            //pictureBox1.Image = writer.Write(textBox1.Text);            
            label6.Text = textBox1.Text;
            BarcodeLib.Barcode b1 = new BarcodeLib.Barcode();           
            Image img1 = b1.Encode(BarcodeLib.TYPE.CODE128, textBox6.Text, forecolor, backcolor, (int)(W), (int)(H));
            pictureBox2.Image = img1;
            label8.Text = textBox6.Text;
        }       
        private void TestSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".png | *.png";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                int width, height;
                width = panel1.Width;
                height = panel1.Height;
                Bitmap bmp = new Bitmap(width, height);
                panel1.DrawToBitmap(bmp, panel1.ClientRectangle);
                bmp.Save(sfd.FileName);
            }
        }
    }
}
