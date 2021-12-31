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

namespace GalE_Studio
{
    public partial class NewPrject : Form
    {
        public NewPrject()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new()
            {
                Description = "请选择项目目录"
            };
            dialog.ShowNewFolderButton = false;
            if (MainUI.defaultPath != "")
            {
                //设置此次默认目录为上一次选中目录  
                dialog.SelectedPath = MainUI.defaultPath;
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
                    MainUI.defaultPath = dialog.SelectedPath;
                    textBox2.Text = dialog.SelectedPath;
                }
            }
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            string path = textBox2.Text;
            if (Directory.Exists(path))
            {
                string[] information =
                {
                    "GalE Prject File",
                    "Studio Version = " + MainUI.studioVersion,
                    "GalE Version = " + MainUI.GalEVersion,
                    "Prject name = " + textBox1.Text
                };
                path += textBox1.Text + "\\";
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path + "UI");
                Directory.CreateDirectory(path + "music");
                Directory.CreateDirectory(path + "video");
                Directory.CreateDirectory(path + "cg");
                Directory.CreateDirectory(path + "UI");
                File.CreateText(path + "script.ges");
                File.CreateText(path + "people.gep");
                await File.WriteAllLinesAsync(path + textBox1.Text + ".prject", information);
                MainUI.main.Text = "GalE studio - " + textBox1.Text;
                MainUI.main.listBox1.Show();
                MainUI.main.richTextBox1.Show();
                Close();
            }
            else
            {
                MessageBox.Show("路径无效","错误");
            }
        }
    }
}
