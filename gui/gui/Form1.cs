using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace gui
{
    public partial class Form1 : Form
    {
        public string filename;
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                filename = select_file();
                label4.Visible = false;
                textBox3.Visible = false;
                label3.Text = filename;
                label2.Visible = true;
                label3.Visible = true;
                files_pro fp = new files_pro(filename, '.');
                flowLayoutPanel1.Controls.Add(fp);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                filename = select_file();
                button1.Visible = true;
                label4.Visible = true;
                textBox3.Visible = true;
                label3.Text = filename;
                label2.Visible = true;
                label3.Visible = true;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            files_pro fp = new files_pro(filename, textBox3.Text[0]);
            flowLayoutPanel1.Controls.Add(fp);
            textBox3.Clear();
        }
        private string select_file()
        {
            string path = string.Empty;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
            }
            string filename = Path.GetFileName(path);
            return filename;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
