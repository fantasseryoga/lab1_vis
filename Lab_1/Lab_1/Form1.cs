using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    public partial class Form1 : Form
    {
        private TextBox lastFocusedTextBox;
        public Form1()
        {
            InitializeComponent();
            checkBoxS.Checked = true;
        }
        private double square(double a, double b, double c)
        {
            double p = (a+b+c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        private double perimeter(double a, double b, double c)
        {
            return (a+b+c);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            lastFocusedTextBox.Text += (sender as Button).Tag;
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            lastFocusedTextBox = sender as TextBox;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9'|| e.KeyChar == '\b'))
                e.Handled = true;
            if (e.KeyChar == '.')
            {
                if ((sender as TextBox).Text.Contains("."))
                    e.Handled = true;
                else
                    e.Handled = false;
            }
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            double a, b, c;
            textBoxResult.Text = "";
            string newLine = Environment.NewLine;
            try
            {
                a = double.Parse(textBoxA.Text);
                b = double.Parse(textBoxB.Text);
                c = double.Parse(textBoxC.Text);
                if (checkBoxS.Checked)
                    textBoxResult.Text +=("S="+ square(a, b, c).ToString())+newLine;
                //textBoxResult.
                if(checkBoxP.Checked)
                    textBoxResult.Text+=("P="+perimeter(a, b, c).ToString());
                if (!checkBoxS.Checked && !checkBoxP.Checked)
                {
                    toolStripStatusLabelError.ForeColor = Color.Red;
                    toolStripStatusLabelError.Text = "Вибери принаймні одну операцію";
                }
            }
            catch(Exception exception)
            {
                toolStripStatusLabelError.Text = exception.Message;
            } 
        }
        //cleaning
        private void button13_Click(object sender, EventArgs e)
        {
            if (textBoxA.Text.Length != 0)
                textBoxA.Text = textBoxA.Text.Substring(0, textBoxA.Text.Length - 1);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            if (textBoxB.Text.Length != 0)
                textBoxB.Text = textBoxB.Text.Substring(0, textBoxB.Text.Length - 1);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (textBoxC.Text.Length != 0)
                textBoxC.Text = textBoxC.Text.Substring(0, textBoxC.Text.Length - 1);
        }
        //checkBox
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void checkBox2_CheckedChanged(object sender, EventArgs e) { } 
    }
}
