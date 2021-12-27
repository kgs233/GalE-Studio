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

namespace GalE
{
    public partial class Form2 : Form
    {
        string defaultPath = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new()
            {
                Description = "请选择项目目录"
            };
            dialog.ShowNewFolderButton = false;
            if (defaultPath != "")
            {
                //设置此次默认目录为上一次选中目录  
                dialog.SelectedPath = defaultPath;
            }

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show("路径不能为空","错误");
                    return;
                }
                else
                {
                    textBox2.Text = dialog.SelectedPath;
                }
            }
            defaultPath = dialog.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = textBox2.Text;
            if (Directory.Exists(path))
            {
                path += textBox1.Text + "\\";
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + "UI");
                Directory.CreateDirectory(path + "music");
                Directory.CreateDirectory(path + "video");
                Directory.CreateDirectory(path + "cg");
                Directory.CreateDirectory(path + "UI");
                File.CreateText(path + "script.ges");
                File.CreateText(path + "people.gepl");
                File.CreateText(path + textBox1.Text + ".redom");
                Close();
            }
            else
            {
                MessageBox.Show("路径无效","错误");
            }
        }
    }
}
