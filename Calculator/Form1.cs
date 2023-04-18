using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
   // inhertaince från form som skapar automatiskt
    public partial class Form1 : Form
    {
        // Dessa variabler kommer att användas för att lagra det aktuella resultatvärdet, den operatör som senast utfördes och en flagga som anger om en operatör har utförts.
        Double Result_Value = 0;
        String Operator_Performed = " ";
        bool PerformedOp = false;


        // Detta är konstruktören för klassen Form1. Den initialiserar formulärets komponenter.
        public Form1()
        {
            InitializeComponent();
        }
        // laddar formen yäni laddar Form1.CS
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Den här metoden anropas när du klickar på en av sifferknapparna eller decimalpunktsknappen.
        private void button15_Click(object sender, EventArgs e)
        {
            // Om textrutan visar "0" eller om en operatör just har hänt, rensar  textrutan.
            if (textBox_Result.Text == "0" || PerformedOp)
                textBox_Result.Clear();

            PerformedOp = false;
            //Du lägger decimal

            Button button = (Button)sender;
            if(button.Text == ".")
            {
                if(!textBox_Result.Text.Contains("."))
                    textBox_Result.Text += button.Text;
            }
            // Om knappen är ett nummer läggs det till i textrutan
            else
            textBox_Result.Text += button.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Den här metoden anropas när en av operatörsknapparna klickas.
        private void Operator_click_Event(object sender, EventArgs e)
        {
            try { 
            // +, -, *, / operators
            // Hämta den knapp som klickades.
            Button button = (Button)sender;

                //  Om ett resulat finns radan, gör den förra operator och stora i den nya operatoner
                if (Result_Value != 0)
                {
                    button16.PerformClick(); // Simulera ett klick på likhetsknappen för att utföra den sista åtgärden.
                    Operator_Performed = button.Text;
                    label_Show_Op.Text = Result_Value + " " + Operator_Performed;
                    PerformedOp = true;
                }
                else
                // Om det ännu inte finns något resultatvärde, lagrar du det aktuella värdet och den nya operatören.
                {

                    Operator_Performed = button.Text;
                    Result_Value = Double.Parse(textBox_Result.Text);
                    label_Show_Op.Text = Result_Value + " " + Operator_Performed;
                    PerformedOp = true;

                }
            }
            catch (Exception)
            {
                
            }
        }

        // Denna är CE Den tar bort om du har råkat skrivit fel
        private void button5_Click(object sender, EventArgs e)
        {
            
            textBox_Result.Text = "0";
        }

        // C denna tar bort allt och startar om
        private void button6_Click(object sender, EventArgs e)
        {
          
            textBox_Result.Text = "0";
             Result_Value = 0;
            label_Show_Op.Text = " ";
        }
        // Den här metoden anropas när du klickar på lika med knappen.
        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Operator_Performed)
                {

                    case "+":
                       
                        textBox_Result.Text = (Result_Value + Double.Parse(textBox_Result.Text)).ToString();
                        break;


                    case "-":
                      
                        textBox_Result.Text = (Result_Value - Double.Parse(textBox_Result.Text)).ToString();
                        break;

                    case "*":
                       
                        textBox_Result.Text = (Result_Value * Double.Parse(textBox_Result.Text)).ToString();
                        break;

                    case "/":
                       
                        textBox_Result.Text = (Result_Value / Double.Parse(textBox_Result.Text)).ToString();
                        break;

                    default:
                        break;

                }
                Result_Value = Double.Parse(textBox_Result.Text);
                label_Show_Op.Text = " ";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               

            }

        }

        private void textBox_Result_TextChanged(object sender, EventArgs e)
        {
            // Den här metoden anropas när texten i textrutan ändras.
            
        }

    }
    }

