using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// 主界面UI
/// </summary>

namespace GalE_Studio
{
    
    public partial class MainUI : Form
    {
        public static string nowPrjectName = "";
        public static string defaultPath = "";
        public static string studioVersion = "1.0 Debug";
        public static string GalEVersion = "1.0 Beta";
        public static MainUI main  = new();
        private void MainUI_Load(object sender, EventArgs e)
        {
            richTextBox1.Hide();
            listBox1.Hide();
        }

        public MainUI()
        {
            InitializeComponent();
            main = this;
        }

        private void 新建项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPrject form2 = new();
            form2.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new();
            about.ShowDialog();
        }

        private void 项目地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.baidu.com");
        }

        private void 打开项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Version = "";
            OpenFileDialog openFileDialog = new()
            {
                Filter = "项目文件 (*.prject)|*.prject"
            };
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    MessageBox.Show("路径不能为空", "错误");
                    return;
                }
                else
                {
                    string path = openFileDialog.FileName;
                    string[] lines = File.ReadAllLines(path);
                    Version = lines[2].Split(" = ")[1];
                    if(Version != GalEVersion)
                    {
                        if (MessageBox.Show("此项目与当前GalE版本不一致，是否继续打开", "警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            Text = "GalE studio - " + lines[3].Split(" = ")[1];
                            listBox1.Show();
                            richTextBox1.Show();
                        }
                    }
                    else
                    {
                        Text = "GalE studio - " + lines[3].Split(" = ")[1];
                        listBox1.Show();
                        richTextBox1.Show();
                    }
                }
            }
        }
    }
}