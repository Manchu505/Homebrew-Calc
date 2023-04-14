using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Homebrew_Recipe_Calc
{
    public partial class calcABV : Form
    {
        // variable used throughout math calculations
        double num1; //OG variable
        double num2; //FG variable
        double num3 = 76.08;
        double num4 = 1.775;
        double num5 = .794;
        double num6 = 131.25;
        double num7 = 258.6;
        double num8 = 258.2;
        double num9 = 227.1;
        double num10; //Plato Gravity
        double num11; //Plato Gravity
        double platoOG; //Converted Plato Gravity
        double platoFG; //Converted Plato Gravity
    
        public calcABV()
        { InitializeComponent(); }


        private void button1_Click(object sender, EventArgs e)
        {
            //Calculate Button

            try
            {
                if (radioSG.Checked == true)
                {
                    num1 = double.Parse(inputOG.Text);
                    num2 = double.Parse(inputFG.Text);
                }
                else
                {

                }
                if (radioPlato.Checked == true)
                // this will detail out the radio button to specify which formula to use
                //=1+(A2/(258.6 - ((A2/258.2)*227.1)))
                {
                    num10 = double.Parse(inputOG.Text);
                    num11 = double.Parse(inputFG.Text);
                    // exception to determine valid data entry
                    if (num10 < 1.1)
                    {
                        MessageBox.Show("Input OG in Plato");
                    }
                    // exception to determine valid data entry
                    else if (num11 < 1.1)
                    {
                        MessageBox.Show("Input FG in Plato");
                    }
                    platoOG = 1 + (num10 / (num7 - ((num10 / num8) * num9)));
                    platoFG = 1 + (num11 / (num7 - ((num11 / num8) * num9)));
                }
                else
                {
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please use valid numbers");
            }
            if (radioStandard.Checked == true && radioSG.Checked == true)
            {
                double sum1 = (num1 - num2) * num6;
                label10.Text = sum1.ToString("N2") + ("%");
            }

            else if (radioStandard.Checked == true && radioSG.Checked == false)
            {

                double sum4 = (platoOG - platoFG) * num6;

                label10.Text = sum4.ToString("N2") + ("%");
            }

            else if (radioAlternate.Checked == true && radioSG.Checked == true)
            {

                double sum2 = (num3 * (num1 - num2) / (num4 - num1)) * (num2 / num5);
                label10.Text = sum2.ToString("N2") + ("%");
            }

            else
            {
                double sum3 = (num3 * (platoOG - platoFG) / (num4 - platoOG)) * (platoFG / num5);
                label10.Text = sum3.ToString("N2") + ("%");
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            //Close Button
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Clear Button
            inputFG.Clear();
            inputOG.Clear();
            label10.Text = "";

        }

    }
}