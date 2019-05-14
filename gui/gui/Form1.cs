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
using System.Linq;
namespace gui
{
    public partial class Form1 : Form
    {
        string path = string.Empty;
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
                if (filename == null)
                {
                    radioButton2.Checked = false;
                    return;
                }
                label4.Visible = false;
                textBox3.Visible = false;
                label3.Text = filename;
                label2.Visible = true;
                label3.Visible = true;
                button1.Visible = false;
                files_pro fp = new files_pro(path , filename);
                flowLayoutPanel1.Controls.Add(fp);
            }
            radioButton2.Checked = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                filename = select_file();
                if (filename == null)
                {
                    radioButton1.Checked = false;
                    return;
                }
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
            /*List<Control> listControls = flowLayoutPanel1.Controls.Cast<Control>().ToList();

            foreach (Control control in listControls)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }*/
            if (textBox3.Text==string.Empty && radioButton1.Checked)
            {
                MessageBox.Show("Please Enter delimeter");
            }
           
            else { 
            files_pro fp = new files_pro(path , filename, textBox3.Text[0]);
            flowLayoutPanel1.Controls.Add(fp);
            textBox3.Clear();
            }
            radioButton1.Checked = false;
        }
        private string select_file()
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
            }
            else
            {
                MessageBox.Show("please select a file ");
                return null;
            }
            List<Control> listControls = flowLayoutPanel1.Controls.Cast<Control>().ToList();

            foreach (Control control in listControls)
            {
                flowLayoutPanel1.Controls.Remove(control);
                control.Dispose();
            }
            string filename = Path.GetFileName(path);
            string fileExt = System.IO.Path.GetExtension(filename);
            if (fileExt != ".txt" && fileExt != ".xlsx")
            {
                MessageBox.Show("please select a text file or excel file");
                return null;
            }
            return filename;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
