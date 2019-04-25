using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace gui
{
    public partial class files_pro : UserControl
    {
        string _file_name;
        char _delimiter;
        public string[] colums;
        public files_pro(string file_name, char delimiter)
        {
            InitializeComponent();
            _file_name = file_name;
            _delimiter = delimiter;
        }
        
        private void files_pro_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string fileExt = System.IO.Path.GetExtension(_file_name);
            string[] recordes;
            
            if (fileExt == ".txt")
            {
                FileStream f = new FileStream(_file_name, FileMode.OpenOrCreate);
                StreamReader SR = new StreamReader(f);
                recordes = SR.ReadLine().Split('/');
                colums = recordes[0].Split(_delimiter);
                dataGridView1.Columns.Add("columns1", "file columns");
                dataGridView1.Columns.Add("columns2", "columns name");
                for (int i = 0; i < colums.Length; i++)
                {
                    dataGridView1.Rows.Add(new string[] { "column" + (i + 1), colums[i] });
                }
                SR.Close();
                f.Close();
            }

            else if (fileExt == ".xls")
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Check")
            {
                label2.Visible = true;
                comboBox2.Visible = true;
                textBox2.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _col = Array.Find(colums, Col => Col == textBox1.Text);
            if (_col != null)
            {
                MessageBox.Show("Dond");
            }
            else
            {
                MessageBox.Show("Please Enter correct name for column");
            }
            textBox1.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox2.Text= string.Empty ;
            textBox2.Text= string.Empty;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
