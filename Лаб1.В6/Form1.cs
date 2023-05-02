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

namespace Лаб1.В6
{
    public partial class Form1 : Form
    {
        
        int[] price = new int[5];
        string[] mfr = new string[5];
        string[] description = new string[5];
        int sum = 0;

        public Form1()
        {
            InitializeComponent();

            int i = 0, n = 5;
            StreamReader sr = new StreamReader(@"C:\Users\User\source\repos\Лаб1\text.txt", Encoding.UTF8);
            
            while (i < n)
            {
                comboBox1.Items.Add(sr.ReadLine());
                price[i] = Convert.ToInt32(sr.ReadLine());
                mfr[i] = sr.ReadLine();
                description[i] = sr.ReadLine();
                i++;
            }
            comboBox1.Text = comboBox1.Items[0].ToString();

            sr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = price[comboBox1.SelectedIndex] + "p.";
            label6.Text = mfr[comboBox1.SelectedIndex];
            label7.Text = description[comboBox1.SelectedIndex];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label9.Text = "";
            sum = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += comboBox1.Items[comboBox1.SelectedIndex].ToString() + "      " + price[comboBox1.SelectedIndex] + "p.      " + numericUpDown1.Value.ToString() + " шт." + '\r' + '\n';
            sum += price[comboBox1.SelectedIndex] * (int)numericUpDown1.Value;
            label9.Text = sum.ToString() + " руб.";
            numericUpDown1.Value = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "txt files(*.txt)|*.txt|All files(*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    {
                        string lines = "Заказ:" + '\r' + '\n' + textBox1.Text + '\r' + '\n' + "ИТОГО: " + label9.Text;
                        sw.WriteLine(lines);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
