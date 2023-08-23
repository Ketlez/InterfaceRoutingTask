using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Diplom
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
           
            this.FormClosing += closingCallback;
            InitializeComponent();
            textBox4.Text = "newData.csv";
            textBox1.Text = "100";
            textBox2.Text = "100";
            textBox3.Text = "100";
            textBox5.Text = "3";
            textBox6.Text = "10";
            textBox7.Text = "10";
            textBox8.Text = "1";
            textBox9.Text = "3";
            textBox10.Text = "10000";
            textBox11.Text = "0.38";
            checkBox1.Checked = true;
        }
        public void closingCallback(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CurrentForm.f == this)
                CurrentForm.f = null;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label19.Text = "";
            label20.Text = "";
            label21.Text = "";
            label22.Text = "";
            label23.Text = "";
            label24.Text = "";
            if (checkBox2.Checked && checkBox1.Checked)
            {
                string message = "Выберите один из способов получения данных!";
                var result = MessageBox.Show(message);
                return;
            }
            if (!checkBox2.Checked && !checkBox1.Checked)
            {
                string message = "Выберите один из способов получения данных!";
                var result = MessageBox.Show(message);
                return;
            }
            if (checkBox1.Checked && checkBox2.Checked == false)
            {
                string text = textBox5.Text + "\n" + textBox6.Text + "," + textBox7.Text + "," + textBox8.Text + "," + textBox9.Text + "," +textBox10.Text + "," + textBox11.Text + "\n" + "create" +"\n"+ textBox1.Text+","+textBox2.Text+","+textBox3.Text;
                File.WriteAllText("fileEnter.txt", text);
            }
            if (checkBox2.Checked && checkBox1.Checked == false)
            {
                string text = textBox5.Text + "\n" + textBox6.Text + "," + textBox7.Text + "," + textBox8.Text + "," + textBox9.Text + "," + textBox10.Text + "," + textBox11.Text + "\n" + textBox4.Text;
                File.WriteAllText("fileEnter.txt", text);
            }
            var myProcess = new Process { StartInfo = new ProcessStartInfo("Clustering.exe") };
            myProcess.Start();
            myProcess.WaitForExit();
            try
            {
                string str = File.ReadAllText("fileOut.txt");
                if (str.Contains("error"))
                {
                    string message = str.Substring(7);
                    var result = MessageBox.Show(message);
                }
                else
                {
                    int i = 4;
                    if (str.Contains("ok"))
                    {
                        string message = "Модель объектов записана в файл: outFile.csv"+'\n'+ "Кластеризация муравьиным алгоритмом записана: outFileNewAnt.csv" + '\n' + "Кластеризация kmeans записана: outFileNewKmeans.csv" + '\n' + "Путь полученный муравьиным алгоритмом записан: outFilePathAnt.csv" + '\n' + "Путь полученный kmeans записан: outFilePathKmeans.csv";
                        var result = MessageBox.Show(message);

                        string strTemp = "";
                        while (str[i] != '\n')
                        {
                            strTemp += str[i];
                            i++;
                        }
                        i++;
                        label19.Text = strTemp;
                        strTemp = "";
                        while (str[i] != '\n')
                        {
                            strTemp += str[i];
                            i++;
                        }
                        i++;
                        label20.Text = strTemp;
                        strTemp = "";
                        while (str[i] != '\n')
                        {
                            strTemp += str[i];
                            i++;
                        }
                        i++;
                        label21.Text = strTemp;
                        strTemp = "";
                        while (str[i] != '\n')
                        {
                            strTemp += str[i];
                            i++;
                        }
                        i++;
                        label22.Text = strTemp;
                        strTemp = "";
                        while (str[i] != '\n')
                        {
                            strTemp += str[i];
                            i++;
                        }
                        i++;
                        label23.Text = strTemp;
                        strTemp = "";
                        while (str[i] != '\n')
                        {
                            strTemp += str[i];
                            i++;
                        }
                        i++;
                        label24.Text = strTemp;
                    }
                }
            }catch
            {
                string message = "Ошибка выходного файла!";
                var result = MessageBox.Show(message);
            }
        }

    }
}
