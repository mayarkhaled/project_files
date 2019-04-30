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
        bool isNull = false;
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
        public files_pro(string file_name, char delimiter)
        {
            InitializeComponent();
            _file_name = file_name;
            _delimiter = delimiter;
        }
        string[] recordes;

        private void files_pro_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string fileExt = System.IO.Path.GetExtension(_file_name);


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
            for (int i = 0; i < colums.Length; i++)
            {
                List<string> mylist = new List<string>();
                for (int j = 1; j < recordes.Length; j++)
                {
                    string[] arr;
                    arr = recordes[j].Split('@');
                    mylist.Add(arr[i]);
                }

                map[colums[i]] = mylist;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Check")
            {
                label4.Visible =false;
                textBox3.Visible = false;
                label2.Visible = true;
                comboBox2.Visible = true;
                textBox2.Visible = true;
            }
            if (comboBox1.Text == "Default")
            {
                label2.Visible = false;
                comboBox2.Visible = false;
                textBox2.Visible = false;
                label4.Visible = true;
                textBox3.Visible = true;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            string col_name = textBox1.Text.Trim();
            string _col = Array.Find(colums, Col => Col == textBox1.Text);
            if (_col != null)
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Please Enter correct name for column");
            }
            if (comboBox1.Text == "NOT NULL")
            {
                list = map[col_name];
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == "")
                    {
                        MessageBox.Show(col_name + " contains NULL values ");
                        return;
                    }
                }
            }
            if (comboBox1.Text == "Defult")
            {
                string defult = textBox3.Text.Trim();
                list = map[col_name];
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == "")
                    {
                        list[i] = defult;
                    }
                }
            }
            if (comboBox1.Text == "Unique")
            {
                HashSet<string> set = new HashSet<string>();
                list = map[col_name];
                for (int i = 0; i < list.Count; i++)
                {
                    set.Add(list[i]);
                }

                if (set.Count != list.Count)
                {
                    MessageBox.Show(col_name + " contains repeated values ");
                    return;
                }
            }
            if (comboBox1.Text == "Check")
            {
                if (comboBox2.Text == ">")
                {
                    int cond = 0;
                    Int32.TryParse(textBox2.Text, out cond);
                    int c = 0;
                    list = map[col_name];
                    for (int i = 0; i < list.Count; i++)
                    {
                        int list_int = 0;
                        Int32.TryParse(list[i], out list_int);
                        if (list_int > cond)
                        {
                            c++;
                        }
                    }
                    if (c != list.Count)
                    {
                        MessageBox.Show("Some values do not apply this condition in " + col_name);
                        return;
                    }
                }
                if (comboBox2.Text == "<")
                {
                    int cond = 0;
                    Int32.TryParse(textBox2.Text, out cond);
                    int c = 0;
                    list = map[col_name];
                    for (int i = 0; i < list.Count; i++)
                    {
                        int list_int = 0;
                        Int32.TryParse(list[i], out list_int);
                        if (list_int < cond)
                        {
                            c++;
                        }
                    }
                    if (c != list.Count)
                    {
                        MessageBox.Show("Some values do not apply this condition in " + col_name);
                        return;
                    }
                }
                if (comboBox2.Text == ">=")
                {
                    int cond = 0;
                    Int32.TryParse(textBox2.Text, out cond);
                    int c = 0;
                    list = map[col_name];
                    for (int i = 0; i < list.Count; i++)
                    {
                        int list_int = 0;
                        Int32.TryParse(list[i], out list_int);
                        if (list_int >= cond)
                        {
                            c++;
                        }
                    }
                    if (c != list.Count)
                    {
                        MessageBox.Show("Some values do not apply this condition in " + col_name);
                        return;
                    }
                }
                if (comboBox2.Text == "<=")
                {
                    int cond = 0;
                    Int32.TryParse(textBox2.Text, out cond);
                    int c = 0;
                    list = map[col_name];
                    for (int i = 0; i < list.Count; i++)
                    {
                        int list_int = 0;
                        Int32.TryParse(list[i], out list_int);
                        if (list_int <= cond)
                        {
                            c++;
                        }
                    }
                    if (c != list.Count)
                    {
                        MessageBox.Show("Some values do not apply this condition in " + col_name);
                        return;
                    }
                }
                if (comboBox2.Text == "=")
                {
                    int c = 0;
                    list = map[col_name];
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] == textBox2.Text)
                        {
                            c++;
                        }
                    }
                    if (c != list.Count)
                    {
                        MessageBox.Show("Some values do not apply this condition in " + col_name);
                        return;
                    }
                }
                if (comboBox2.Text == "!=")
                {
                    int c = 0;
                    list = map[col_name];
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] != textBox2.Text)
                        {
                            c++;
                        }
                    }
                    if (c != list.Count)
                    {
                        MessageBox.Show("Some values do not apply this condition in " + col_name);
                        return;
                    }
                }


            }

            textBox1.Text = string.Empty;
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            textBox2.Text = string.Empty;

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
