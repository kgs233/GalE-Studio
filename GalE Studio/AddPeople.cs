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
/// 添加人物,还未完成
/// </summary>

namespace GalE_Studio
{
    public partial class AddPeople : Form
    {
        public AddPeople()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("人物名为空", "警告");
            }
            else
            {
                if (String.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("人物名为空", "警告");
                }
                else
                {
                    StreamWriter file = new(MainUI.nowPrjectPath + "\\people.gep", append: true);
                    switch (comboBox1.Text)
                    {
                        case "主角":
                            await file.WriteLineAsync(textBox1.Text + ',' + textBox2.Text + ",main");
                            break;
                        case "线路主角":
                            await file.WriteLineAsync(textBox1.Text + ',' + textBox2.Text + ",linemain");
                            Directory.CreateDirectory(MainUI.nowPrjectPath + "PeopleCG\\" + textBox2);
                            break;
                        case "配角":
                            await file.WriteLineAsync(textBox1.Text + ',' + textBox2.Text + ",supporting");
                            break;
                    }
                    Close();
                }
            }
        }
    }
}
