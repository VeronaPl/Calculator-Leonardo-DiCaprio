using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Калькулятор
{
    public partial class Form1 : Form
    {
        double arg, count;
        string[] a = { "", " + ", " - ", " * ", " / "};
        public string path;
        public bool flag = true;

        public void calculate(int ind)
        {
            try
            {
                switch (count)
                {
                    case 0:
                        arg = double.Parse(textBox1.Text);
                        count = ind;
                        break;
                    case 1:
                        arg += double.Parse(textBox1.Text);
                        count = ind;
                        break;
                    case 2:
                        arg -= double.Parse(textBox1.Text);
                        count = ind;
                        break;
                    case 3:
                        arg *= double.Parse(textBox1.Text);
                        count = ind;
                        break;
                    case 4:
                        if (double.Parse(textBox1.Text) != 0)
                        {
                            arg /= double.Parse(textBox1.Text);
                            count = ind;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("На ноль делить нельзя!");
                            flag = false;
                        }
                        break;
                    default:
                        break;
                }
                label1.Text += textBox1.Text + a[ind];
                textBox1.Clear();
            }
            catch
            {
                MessageBox.Show("Вы ввели неправильный формат!");
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.button0.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.button9.Text;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            calculate(1);
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "";
            arg = 0; count = 0;
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            if (count == 3 || count == 4)
                textBox1.Text = Convert.ToString(double.Parse(textBox1.Text) / 100);
            else if (count == 1 || count == 2)
                textBox1.Text = Convert.ToString(arg * double.Parse(textBox1.Text) / 100);
            else
                MessageBox.Show("Сначала введите число от которого хотите вычислить процент!");
        }

        private void buttonPosNeg_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Сначала введите число!");
            else if (double.Parse(textBox1.Text) > 0)
                textBox1.Text = "-" + textBox1.Text;
            else if (double.Parse(textBox1.Text) < 0)
                textBox1.Text = textBox1.Text.Replace("-", "");            
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            if (double.Parse(textBox1.Text) >= 0)
            {
                textBox1.Text = Convert.ToString(Math.Sqrt(double.Parse(textBox1.Text)));
                label1.Text = "";
            }
            else
                MessageBox.Show("Подкоренное выражение должно быть неотрицательно!");
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(textBox1.Text) != 0)
                {
                    textBox1.Text = Convert.ToString(double.Parse(textBox1.Text) * double.Parse(textBox1.Text));
                    label1.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Сначала введите число!");
            }
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            calculate(4);
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            calculate(3);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            calculate(2);
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text += textBox1.Text + " = ";
                switch (count)
                {
                    case 0:
                        arg = double.Parse(textBox1.Text);
                        count = 0;
                        textBox1.Text = Convert.ToString(arg);
                        break;
                    case 1:
                        arg += double.Parse(textBox1.Text);
                        count = 0;
                        textBox1.Text = Convert.ToString(arg);
                        break;
                    case 2:
                        arg -= double.Parse(textBox1.Text);
                        count = 0;
                        textBox1.Text = Convert.ToString(arg);
                        break;
                    case 3:
                        arg *= double.Parse(textBox1.Text);
                        count = 0;
                        textBox1.Text = Convert.ToString(arg);
                        break;
                    case 4:
                        if (double.Parse(textBox1.Text) != 0)
                        {
                            arg /= double.Parse(textBox1.Text);
                            count = 0;
                            textBox1.Text = Convert.ToString(arg);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("На ноль делить нельзя!");
                            flag = false;
                        }
                            
                        break;
                    default:
                        break;
                }
                string path = @"C:\Users\julia\OneDrive\Рабочий стол\sw.txt ";
                StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8);
                if (System.IO.File.Exists(path) && flag)
                {
                    sw.WriteLine(DateTime.Now + "  " + label1.Text + textBox1.Text + "; ");
                    //sw.Close();
                }
                else if (flag)
                {
                    StreamWriter sw1 = new StreamWriter(path, true, System.Text.Encoding.UTF8);
                    sw1.WriteLine(DateTime.Now + "  " + label1.Text + textBox1.Text + "; ");
                    sw1.Close();
                }
                flag = true;
                sw.Close();
            }
            catch
            {
                MessageBox.Show("Вы ввели неправильный формат!");
            }
        }

        private void buttonFloat_Click(object sender, EventArgs e)
        {
            textBox1.Text += this.buttonFloat.Text;
        }

    }
}
