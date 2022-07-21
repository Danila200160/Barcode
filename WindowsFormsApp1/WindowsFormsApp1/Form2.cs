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
        _imagesList.AddRange(new DirectoryInfo(@"C:\Windows\Temp\Hidden").GetFiles("*.png", SearchOption.AllDirectories));
            //int Colvo;
            //Colvo = Directory.GetFiles(@"C:\Windows\Temp\Hidden").Length;           
            //DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            //imageColumn.HeaderText = "Штрихкоды";
            //imageColumn.Name = "Штрихкоды";
            //for (int i = 1; i < Colvo; i++)
            //{
            //    Preview.Rows[i].Cells[0].Value = new Bitmap(@"C:\Windows\Temp\Hidden\" + i + ".png");
            //imageColumn.Image = Image.FromFile(@"C:\Windows\Temp\Hidden\" + i + ".png");
            //}
            _currentImageId = 0;
            pictureBox1.Load(_imagesList[_currentImageId].FullName);
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
