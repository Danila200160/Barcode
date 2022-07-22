using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private int _currentImageId = 0;
        private readonly List<FileInfo> _imagesList = new List<FileInfo>();
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                _imagesList.AddRange(new DirectoryInfo(@"C:\Windows\Temp\Hidden").GetFiles("*.png", SearchOption.AllDirectories));
                _currentImageId = 0;
                pictureBox1.Load(_imagesList[_currentImageId].FullName);
            }
            catch
            {
                MessageBox.Show("Предпросмотр пуст");                
                this.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_currentImageId > 0)
                pictureBox1.Load(_imagesList[--_currentImageId].FullName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_currentImageId < _imagesList.Count - 1)
                pictureBox1.Load(_imagesList[++_currentImageId].FullName);
        }
    }
}
