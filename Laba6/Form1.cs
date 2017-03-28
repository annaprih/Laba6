using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba6
{
    public partial class Laba6 : Form
    {
        private double calcul;
        private double memory;
        private bool memoryFlag;
        private string action;
        public Laba6()
        {
            InitializeComponent();
            this.calcul = 0;
            this.memory = 0;
            this.memoryFlag = false;
            this.action = "";
        }

       private void button_Click(object sender, EventArgs e)
       {
            textBox1.Text += ((Button) sender).Text;
       }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            try
            {
                this.calcul = Convert.ToDouble(textBox1.Text);
                this.action = ((Button) sender).Text;
                
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
            finally
            {
                textBox1.Text = "";
            }
           
        }
        private void buttonAction16_Click(object sender, EventArgs e)
        {
            try
            {
                this.calcul = Convert.ToDouble(textBox1.Text);
                this.calcul = Math.Sqrt(this.calcul);
                textBox1.Text = Convert.ToString(this.calcul);
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
           
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                this.memory = Convert.ToDouble(textBox1.Text);
                this.memoryFlag = true;
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (memoryFlag == true)
            {
                textBox1.Text = this.memory.ToString();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.memory = 0;
            this.memoryFlag = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Math.Sin(Convert.ToDouble(textBox1.Text)).ToString();

            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Math.Cos(Convert.ToDouble(textBox1.Text)).ToString();

            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkRed;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.Aqua;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.action == "+")
                {

                    textBox1.Text = (this.calcul + Convert.ToDouble(textBox1.Text)).ToString();

                }
                if (this.action == "-")
                {

                    textBox1.Text = (this.calcul - Convert.ToDouble(textBox1.Text)).ToString();

                }
                if (this.action == "*")
                {

                    textBox1.Text = (this.calcul * Convert.ToDouble(textBox1.Text)).ToString();

                }
                if (this.action == "/")
                {

                    textBox1.Text = (this.calcul / Convert.ToDouble(textBox1.Text)).ToString();
                    
                }
                
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }


        }
    }
}
