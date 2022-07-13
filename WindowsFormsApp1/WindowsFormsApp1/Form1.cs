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





namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataSet ds;
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
            label6.Parent = panel1;
            label6.BackColor = Color.Transparent;
            label8.Parent = panel1;
            label8.BackColor = Color.Transparent;
            label6.Text = textBox1.Text;
            BarcodeLib.Barcode b1 = new BarcodeLib.Barcode();
            Image img1 = b1.Encode(BarcodeLib.TYPE.CODE128, textBox6.Text, forecolor, backcolor, (int)(W), (int)(H));
            pictureBox2.Image = img1;
            label8.Text = textBox6.Text;
            panel1.BackColor = Color.Transparent;
        }

        private void TestSave_Click(object sender, EventArgs e)
        {
            index += 1;
            int width, height;
            width = panel1.Width;
            height = panel1.Height;
            Bitmap bmp = new Bitmap(width, height);            
            panel1.DrawToBitmap(bmp, panel1.ClientRectangle);              
            bmp.SetResolution(300.0F, 300.0F);
            bmp.MakeTransparent(Color.FromArgb(255, 255, 255));
            bmp.Save(path + "/" + index + ".png", ImageFormat.Png);
            string fullAppName = Application.ExecutablePath;
            string fullAppPath = Path.GetDirectoryName(fullAppName);
            string fullFileName = Path.Combine(fullAppPath, "sound_046.wav");
            SoundPlayer sp = new SoundPlayer(fullFileName);
            sp.Play();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.Description = "Выберите путь для сохранения файлов";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                label4.Text = "Выбранный путь для автосохранения файлов: " + FBD.SelectedPath;                
            }
            path = FBD.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            string file = "";   
            DataTable dt = new DataTable();   
            DataRow row;
            DialogResult result = openFileDialog1.ShowDialog();
            
            if (result == DialogResult.OK)   
            {
                file = openFileDialog1.FileName; 
                try
                {
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);
                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;
                    int rowCount = excelRange.Rows.Count;  
                    int colCount = excelRange.Columns.Count;                     
                    for (int i = 1; i <= rowCount; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString());
                        }
                        break;
                    }                          
                    int rowCounter;  
                    for (int i = 1; i <= rowCount; i++) 
                    {
                        row = dt.NewRow(); 
                        rowCounter = 0;
                        for (int j = 1; j <= colCount; j++) 
                        {                           
                            if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                            {
                                row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
                            }
                            else
                            {
                                row[i] = "";
                            }
                            rowCounter++;
                        }
                        dt.Rows.Add(row); 
                    }
                    dataGridView1.DataSource = dt; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount-1 ; i++)
            {               
                    textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    textBox6.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    button3_Click(sender, e);
                    TestSave_Click(sender, e);
            }            
        }
    }
}
