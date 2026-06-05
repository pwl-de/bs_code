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


        private int Round(double value)
        {
            return Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero));
        }

        private int calculateNote(int points)
        {
            // punkte evtl auf die 100 Notenschlüsselbringen?
            if (points >= 92)
            {
                return 1;
            }
            else if (points >= 81)
            {
                return 2;
            }
            else if (points >= 67)
            {
                return 3;
            }
            else if (points >= 50)
            {
                return 4;
            }
            else if (points >= 30)
            {
                return 5;
            }
            else
            {
                return 6;
            }
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


                txtNote1.Text = Convert.ToString(calculateNote(punkte1));
                txtNote2.Text = Convert.ToString(calculateNote(punkte1));



            }
            catch (Exception ex)
            {
                MessageBox.Show("Beim updaten von Part 1 der Tabelle ist ein Fehler aufgetreten. \n \n" + ex);
            }


        
        }


        private bool checkIfNeededIsFilled()
        {
            bool needIsFilled = false;

            // Checkt ob needed filled ist.
            if (!txtPunkteTheorie1.Text.Equals("") && !txtPunkteTheorie2.Text.Equals("") && !txtPunkteWiSo.Text.Equals("") && !txtPunkteDoku.Text.Equals("") && !txtPunktePrFa.Text.Equals(""))
            { needIsFilled = true; }
            return needIsFilled;
        }

        private void updatePartTwo() // kann nur ausgeführt bzw. wird nur bei vollständiger ausfüllung ausgeführt
        {
            // Nimmt Calculation vor.
            try
            {
                if (checkIfNeededIsFilled())
                {
                    // TODO: Clearlabels

                    
                    // THEORIE 1:
                    int punkteTheorie1 = Convert.ToInt32(txtPunkteTheorie1.Text);
                    //check ob mepr da ist sonst int =-1
                    int punkteMEpr1 = -1;
                    if (!txtMEpr1.Text.Equals("")) {
                        punkteMEpr1 = Convert.ToInt32(txtMEpr1.Text);
                        result1Theorie1.Text = Convert.ToString(punkteTheorie1 * 2 + punkteMEpr1);
                        
                        
                        
                        result2Theorie1.Text = Convert.ToString(Round(Convert.ToDouble(result1Theorie1.Text) / 3)); // TODO: Runden




                    } else
                    {
                        //txtMEpr1.Text = "N"; wenn todo clearlabels erfolgt ist
                        result1Theorie1.Text = "";
                        result2Theorie1.Text = Convert.ToString(punkteTheorie1);
                    }
                    result3Theorie1.Text = Convert.ToString(Convert.ToInt32(result2Theorie1.Text) * 10);
                    totPunkteTheorie1.Text = result2Theorie1.Text;
                    txtNoteTheorie1.Text = Convert.ToString(calculateNote(Convert.ToInt32(result2Theorie1.Text)));
                    // 


                    // THEORIE 2:
                    int punkteTheorie2 = Convert.ToInt32(txtPunkteTheorie2.Text);
                    //check ob mepr da ist sonst int =-1
                    int punkteMEpr2 = -1;
                    if (!txtMEpr2.Text.Equals(""))
                    {
                        punkteMEpr2 = Convert.ToInt32(txtMEpr2.Text);
                        result1Theorie2.Text = Convert.ToString(punkteTheorie2 * 2 + punkteMEpr2);
                        result2Theorie2.Text = Convert.ToString(Round(Convert.ToDouble(result1Theorie2.Text) / 3)); // TODO: Runden
                    }
                    else
                    {
                        //txtMEpr2.Text = "N"; wenn todo clearlabels erfolgt ist
                        result1Theorie2.Text = "";
                        result2Theorie2.Text = Convert.ToString(punkteTheorie2);
                    }
                    result3Theorie2.Text = Convert.ToString(Convert.ToInt32(result2Theorie2.Text) * 10);
                    totPunkteTheorie2.Text = result2Theorie2.Text;
                    txtNoteTheorie2.Text = Convert.ToString(calculateNote(Convert.ToInt32(result2Theorie2.Text)));


                    // WiSo:
                    int punkteWiSo = Convert.ToInt32(txtPunkteWiSo.Text);
                    //check ob mepr da ist sonst int =-1
                    int punkteMEprWiSo = -1;
                    if (!txtMEprWiSo.Text.Equals(""))
                    {
                        punkteMEprWiSo = Convert.ToInt32(txtMEprWiSo.Text);
                        result1WiSo.Text = Convert.ToString(punkteWiSo * 2 + punkteMEprWiSo);
                        result2WiSo.Text = Convert.ToString(Round(Convert.ToDouble(result1WiSo.Text) / 3)); // TODO: Runden
                    }
                    else
                    {
                        //txtMEprWiSo.Text = "N"; wenn todo clearlabels erfolgt ist
                        result1WiSo.Text = "";
                        result2WiSo.Text = Convert.ToString(punkteWiSo);
                    }
                    result3WiSo.Text = Convert.ToString(Convert.ToInt32(result2WiSo.Text) * 10);
                    totPunkteWiSo.Text = result2WiSo.Text;
                    txtNoteWiSo.Text = Convert.ToString(calculateNote(Convert.ToInt32(result2WiSo.Text)));



                    // Doku:
                    int punkteDoku = Convert.ToInt32(txtPunkteDoku.Text);
                    result1Doku.Text = Convert.ToString(punkteDoku * 50);
                    // prFA:
                    int punktePrFa = Convert.ToInt32(txtPunktePrFa.Text);
                    result1PrFa.Text = Convert.ToString(punktePrFa * 50);
                    // Gesamt Projekt:
                    txtSumProjekt.Text = Convert.ToString(Convert.ToInt32(result1PrFa.Text) + Convert.ToInt32(result1Doku.Text));
                    result2Projekt.Text = Convert.ToString(Round(Convert.ToDouble(txtSumProjekt.Text) / 100));
                    result3Projekt.Text = Convert.ToString(Convert.ToInt32(result2Projekt.Text) * 50);

                    totPunkteProjekt.Text = result2Projekt.Text;
                    txtNoteProjekt.Text = Convert.ToString(calculateNote(Convert.ToInt32(totPunkteProjekt.Text)));

                }
            }
            catch (Exception ex) {
                MessageBox.Show("Beim updaten von Part 2 der Tabelle ist ein Fehler aufgetreten. \n \n" + ex);
            }



        }










        // setter für die einzelnen Kategorien
        // -----------------------------------




        // THeorie 1:
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
                updatePartTwo();
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
                updatePartTwo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
            }
        }

        // Theorie 2:
        private void setInputPunkteTheorie2(object sender, EventArgs e)
        {
            try
            {
                // Zeile Theorie 2
                int punkteTheorie2 = 0;
                if (!Int32.TryParse(txtPunkteTheorie2.Text, out punkteTheorie2) && !txtPunkteTheorie2.Text.Equals(""))
                {
                    throw new ArgumentException("Input not valid");
                }
                punkteTheorie2 = correctIfMoreThanHundred(punkteTheorie2, txtPunkteTheorie2);
                updatePartTwo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
            }
        }

        private void setInputMEpr2(object sender, EventArgs e)
        {
            try
            {
                // Zeile Theorie 2
                int punkteMEpr2 = 0;
                if (!Int32.TryParse(txtMEpr2.Text, out punkteMEpr2) && !txtMEpr2.Text.Equals(""))
                {
                    throw new ArgumentException("Input not valid");
                }
                punkteMEpr2 = correctIfMoreThanHundred(punkteMEpr2, txtMEpr2);
                updatePartTwo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
            }
        }

        // WiSo:

        private void setInputPunkteWiSo(object sender, EventArgs e)
        {
            try
            {
                // Zeile Theorie 2
                int punkteWiSo = 0;
                if (!Int32.TryParse(txtPunkteWiSo.Text, out punkteWiSo) && !txtPunkteWiSo.Text.Equals(""))
                {
                    throw new ArgumentException("Input not valid");
                }
                punkteWiSo = correctIfMoreThanHundred(punkteWiSo, txtPunkteWiSo);
                updatePartTwo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
            }
        }

        private void setInputMEprWiSo(object sender, EventArgs e)
        {
            try
            {
                // Zeile Theorie 2
                int punkteMEprWiSo = 0;
                if (!Int32.TryParse(txtMEprWiSo.Text, out punkteMEprWiSo) && !txtMEprWiSo.Text.Equals(""))
                {
                    throw new ArgumentException("Input not valid");
                }
                punkteMEprWiSo = correctIfMoreThanHundred(punkteMEprWiSo, txtMEprWiSo);
                updatePartTwo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
            }
        }

        // Doku:

        private void setInputPunkteDoku(object sender, EventArgs e)
        {
            try
            {
                // Zeile Theorie 2
                int punkteDoku = 0;
                if (!Int32.TryParse(txtPunkteDoku.Text, out punkteDoku) && !txtPunkteDoku.Text.Equals(""))
                {
                    throw new ArgumentException("Input not valid");
                }
                punkteDoku = correctIfMoreThanHundred(punkteDoku, txtPunkteDoku);
                updatePartTwo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
            }
        }



        private void setInputPunktePrFa(object sender, EventArgs e)
        {
            try
            {
                // Zeile Theorie 2
                int punktePrFa = 0;
                if (!Int32.TryParse(txtPunktePrFa.Text, out punktePrFa) && !txtPunktePrFa.Text.Equals(""))
                {
                    throw new ArgumentException("Input not valid");
                }
                punktePrFa = correctIfMoreThanHundred(punktePrFa, txtPunktePrFa);
                updatePartTwo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
            }
        }








    }
}
