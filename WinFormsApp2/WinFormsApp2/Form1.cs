using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox3.Text = "windows32" + Environment.NewLine + "system"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name_file = textBox1.Text;
            if (name_file != "")
            {
                fileproxyitem fileprox = new fileproxy(name_file);
                string result = fileprox.executeop();
                textBox2.Text = result;

            }
        }

        public interface fileproxyitem
        {
            string executeop();
        }
        public class originalfile : fileproxyitem
        {
            private string name_file;
            public originalfile(string name_file)
            {
                this.name_file = name_file;
            }
            public string executeop()
            {
                return $"доступ до файлу {name_file} отриманий";
            }
        }

        public class fileproxy : fileproxyitem
        {
            private originalfile files;
            private string name_file;
            public fileproxy(string name_file)
            {
                this.name_file = name_file;
            }
            public string executeop()
            {
                if (checkaccess(name_file))
                {
                    if (files == null)
                    {
                        files = new originalfile(name_file);
                    }
                    return files.executeop();
                }
                else
                {
                    return "досутп не дозволений";
                }
            }
            public bool checkaccess(string x)
            {
                if(x != "windows32" && x != "system")
                {
                    return true; 
                }
                return false; 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
