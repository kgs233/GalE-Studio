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
/// ������UI
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

        private void �½���ĿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPrject form2 = new();
            form2.ShowDialog();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new();
            about.ShowDialog();
        }

        private void ��Ŀ��ַToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.baidu.com");
        }

        private void ����ĿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Version = "";
            OpenFileDialog openFileDialog = new()
            {
                Filter = "��Ŀ�ļ� (*.prject)|*.prject"
            };
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    MessageBox.Show("·������Ϊ��", "����");
                    return;
                }
                else
                {
                    string path = openFileDialog.FileName;
                    string[] lines = File.ReadAllLines(path);
                    Version = lines[2].Split(" = ")[1];
                    if(Version != GalEVersion)
                    {
                        if (MessageBox.Show("����Ŀ�뵱ǰGalE�汾��һ�£��Ƿ������", "����", MessageBoxButtons.OKCancel) == DialogResult.OK)
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