using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
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

        string path;
        int index = 0;
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
            label6.Text = textBox1.Text;
            BarcodeLib.Barcode b1 = new BarcodeLib.Barcode();           
            Image img1 = b1.Encode(BarcodeLib.TYPE.CODE128, textBox6.Text, forecolor, backcolor, (int)(W), (int)(H));
            pictureBox2.Image = img1;
            label8.Text = textBox6.Text;
        }       

        private void TestSave_Click(object sender, EventArgs e)
        {
            index += 1;                                       
                int width, height;
                width = panel1.Width;
                height = panel1.Height;
                Bitmap bmp = new Bitmap(width, height);
                panel1.DrawToBitmap(bmp, panel1.ClientRectangle);            
                bmp.Save(path+"/"+index+".jpg", ImageFormat.Jpeg);
            String fullAppName = Application.ExecutablePath;
            String fullAppPath = Path.GetDirectoryName(fullAppName);
            String fullFileName = Path.Combine(fullAppPath, "sound_046.wav");
            SoundPlayer sp = new SoundPlayer(fullFileName);
            sp.Play();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Выберите путь для сохранения файлов";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Выбранный путь для автосохранения файлов: " + FBD.SelectedPath);
            }
            path = FBD.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;           
            string excelfile = ofd.FileName;
            string fileText = File.ReadAllText(excelfile);
            
        }

       
    }
}
