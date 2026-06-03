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

namespace Prüfungsberechner
{
    public partial class Prüfungsrechner : Form
    {
        public Prüfungsrechner()
        {
            
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }





        // Programm: 
        // ----------------------------------------




        // nur digits
        private void onlyAcceptDigits(object sender, KeyPressEventArgs e)
        {
            //nur zahlen und backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true; //blockt input
            }
        }


        private int correctIfMoreThanHundred(int input, System.Windows.Forms.TextBox textBox)
        {
            if (input <= 100) //niederiger alsa 0 wegen onlyacceptdigits nicht möglich
            {
                return input;
            }
            else
            {
                textBox.Clear();
                throw new Exception("Input kann nicht größer als 100 sein. Textbox wird dadurch gecleared"); 
            }
        }


        private int calculateNote(int points)
        {
            int note = 0;

            // punkte evtl auf die 100 Notenschlüsselbringen?


            if (points <= 100 && points >= 92)
                note = 1;




            return note;
        }


        // 
        private void updatePartOne(object sender, EventArgs e)
        {
            int punkte1 = 0;
            try {
                if (!Int32.TryParse(txtPunkte1.Text, out punkte1) && !txtPunkte1.Text.Equals(""))
                {
                    throw new ArgumentException("Input not valid");
                }
                punkte1 = correctIfMoreThanHundred(punkte1, txtPunkte1);

                // Calculation
                lblErgebnis1.Text = Convert.ToString((punkte1 * 20));
                lblErgebnis2.Text = Convert.ToString((punkte1 * 20));
                // Update der Note bzw. Punkte Rechts
                totPunkte1.Text = Convert.ToString(punkte1);
                totPunkte2.Text = Convert.ToString(punkte1);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
            }


        
        }


        private bool checkIfNeededIsFilled()
        {
            bool needIsFilled = false;

            // Checkt ob needed filled ist.
            if (!txtPunkteTheorie1.Text.Equals("") && !txtPunkteTheorie1.Text.Equals(""))
                { needIsFilled = true; }
            return needIsFilled;
        }

        private void updatePartTwo(object sender, EventArgs e)
        {
            // Nimmt Calculation vor.
            try
            {
                if (checkIfNeededIsFilled())
                {
                    // TODO: Clearlabels



                    // Berechnung für Part 2 vornehmen:
                    int punkteTheorie1 = Convert.ToInt32(txtPunkteTheorie1.Text);

                    //check ob mepr da ist sonst int =-1
                    int punkteMEpr1 = -1;
                    if (!txtMEpr1.Text.Equals("")) {
                        punkteMEpr1 = Convert.ToInt32(txtMEpr1.Text);
                        result1Theorie1.Text = Convert.ToString(punkteTheorie1 * 2 + punkteMEpr1);
                        result2Theorie1.Text = Convert.ToString(Convert.ToInt32(result1Theorie1.Text)/3); // TODO: Runden






                    } else
                    {
                        //txtMEpr1.Text = "N"; wenn todo clearlabels erfolgt ist
                        result1Theorie1.Text = "";
                        result2Theorie1.Text = Convert.ToString(punkteTheorie1);
                    }





                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
            }



        }

        private void setInputPunkteTheorie1(object sender, EventArgs e)
        {
            try {
                // Zeile Theorie 1
                int punkteTheorie1 = 0;
                if (!Int32.TryParse(txtPunkteTheorie1.Text, out punkteTheorie1) && !txtPunkteTheorie1.Text.Equals(""))
                {
                    throw new ArgumentException("Input not valid");
                }
                punkteTheorie1 = correctIfMoreThanHundred(punkteTheorie1, txtPunkteTheorie1);
            } catch (Exception ex) { 
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
            }
        }
        
        private void setInputMEpr1(object sender, EventArgs e)
        {
            try
            {
                // Zeile Theorie 1
                int punkteMEpr1 = 0;
                if (!Int32.TryParse(txtMEpr1.Text, out punkteMEpr1) && !txtMEpr1.Text.Equals(""))
                {
                    throw new ArgumentException("Input not valid");
                }
                punkteMEpr1 = correctIfMoreThanHundred(punkteMEpr1, txtMEpr1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
            }
        }
    }
}
