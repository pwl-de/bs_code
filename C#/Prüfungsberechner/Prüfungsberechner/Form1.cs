using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Prüfungsberechner
{
    public partial class Prüfungsrechner : Form
    {
        public Prüfungsrechner()
        {
            
            InitializeComponent();
        }




        // Programm: 
        // ----------------------------------------




        // nur digits akzeptieren:
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


        private bool checkIfNeededIsFilled()
        {
            //bool needIsFilled = false;

            // Checkt ob needed filled ist.
            if (!txtPunkteTheorie1.Text.Equals("") && !txtPunkteTheorie2.Text.Equals("") && !txtPunkteWiSo.Text.Equals("") && !txtPunkteDoku.Text.Equals("") && !txtPunktePrFa.Text.Equals(""))
            { return true; }
            return false;
        }


        private bool checkIfNeededIsFilledForTotalResult()
        {
            //bool needIsFilled = false;

            // Checkt ob needed filled ist.
            if (!txtPunkteTheorie1.Text.Equals("") && !txtPunkteTheorie2.Text.Equals("") && !txtPunkteWiSo.Text.Equals("") && !txtPunkteDoku.Text.Equals("") && !txtPunktePrFa.Text.Equals("") && !txtPunkte1.Text.Equals(""))
            { return true; }
            return false;
        }

        private void resetAll(object sender, EventArgs e)
        {

            // Alle Inputs clearen:

            txtStudentName.Text = "";
            txtCompany.Text = "";
            txtStudentNumber.Text = "";
            txtPunkte1.Text = "";
            txtPunkteTheorie1.Text = "";
            txtPunkteTheorie2.Text = "";
            txtPunkteWiSo.Text = "";
            txtPunkteDoku.Text = "";
            txtPunktePrFa.Text = "";

            // alle Labels clearen:!
            //Teil 1:
            lblErgebnis1.Text = "";
            lblErgebnis2.Text = "";
            totPunkte1.Text = "";
            totPunkte2.Text = "";
            txtNote1.Text = "";
            txtNote2.Text = "";
            

            //theorie 1:
            result1Theorie1.Text = "";
            result2Theorie1.Text = "";
            result3Theorie1.Text = "";
            totPunkteTheorie1.Text = "";
            txtNoteTheorie1.Text = "";

            //Theorie 2:
            result1Theorie2.Text = "";
            result2Theorie2.Text = "";
            result3Theorie2.Text = "";
            totPunkteTheorie2.Text = "";
            txtNoteTheorie2.Text = "";

            // wusi:
            result1WiSo.Text = "";
            result2WiSo.Text = "";
            result3WiSo.Text = "";
            totPunkteWiSo.Text = "";
            txtNoteWiSo.Text = "";

            //Projek
            result1Doku.Text = "";
            result1PrFa.Text = "";
            txtSumProjekt.Text = "";
            result2Projekt.Text = "";
            result3Projekt.Text = "";
            totPunkteProjekt.Text = "";
            txtNoteProjekt.Text = "";

            // Part 2
            result3Part2.Text = "";
            totPunktePart2.Text = "";
            txtNotePart2.Text = "";

            //Gesamtergebnis
            sumPart1.Text = "";
            sumPart2.Text = "";
            totalPunkteAll.Text = "";
            txtNoteAll.Text = "";


            //mepr
            txtMEpr1.Text = "";
            txtMEpr2.Text = "";
            txtMEprWiSo.Text = "";
            

        }
        /*
        private void setMEprN()
        {



            if (txtMEpr1.Text.Equals(""))
            {
                txtMEpr1.Text = "N";
            }
            if (txtMEpr2.Text.Equals(""))
            {
                txtMEpr2.Text = "N";
            }
            if (txtMEprWiSo.Text.Equals(""))
            {
                txtMEprWiSo.Text = "N";
            }
        }
        */
        private void clearLabels()
        {

            //Teil 1:
            /*
            lblErgebnis1.Text = "";
            lblErgebnis2.Text = "";
            totPunkte1.Text = "";
            totPunkte2.Text = "";
            txtNote1.Text = "";
            txtNote2.Text = "";
            */

            //theorie 1:
            result1Theorie1.Text = "";
            result2Theorie1.Text = "";
            result3Theorie1.Text = "";
            totPunkteTheorie1.Text = "";
            txtNoteTheorie1.Text = "";

            //Theorie 2:
            result1Theorie2.Text = "";
            result2Theorie2.Text = "";
            result3Theorie2.Text = "";
            totPunkteTheorie2.Text = "";
            txtNoteTheorie2.Text = "";

            // wusi:
            result1WiSo.Text = "";
            result2WiSo.Text = "";
            result3WiSo.Text = "";
            totPunkteWiSo.Text = "";
            txtNoteWiSo.Text = "";

            //Projek
            result1Doku.Text = "";
            result1PrFa.Text = "";
            txtSumProjekt.Text = "";
            result2Projekt.Text = "";
            result3Projekt.Text = "";
            totPunkteProjekt.Text = "";
            txtNoteProjekt.Text = "";

            // Part 2
            result3Part2.Text = "";
            totPunktePart2.Text = "";
            txtNotePart2.Text = "";

            //Gesamtergebnis
            sumPart1.Text = "";
            sumPart2.Text = "";
            totalPunkteAll.Text = "";
            txtNoteAll.Text = "";

            
            //mepr N if empty
            /*
            if (txtMEpr1.Text.Equals("")) { 
                txtMEpr1.Text = "N";
            }
            if (txtMEpr2.Text.Equals("")) { 
                txtMEpr2.Text = "N";
            }
            if (txtMEprWiSo.Text.Equals("")) { 
                txtMEprWiSo.Text = "N";
            }
            */
            labPassed.Text = "Noch kein Ergebnis vorhanden, bitte tragen Sie Werte ein!";



        }
        // 
        private void updatePartOne(object sender, EventArgs e)
        {
            int punkte1 = 0;
            try {

                lblErgebnis1.Text = "";
                lblErgebnis2.Text = "";
                totPunkte1.Text = "";
                totPunkte2.Text = "";
                txtNote1.Text = "";
                txtNote2.Text = "";


                if (!Int32.TryParse(txtPunkte1.Text, out punkte1) && !txtPunkte1.Text.Equals(""))
                {
                    throw new ArgumentException("Input not valid");
                }
                if (txtPunkte1.Text.Equals(""))
                {
                    updateGesamtResult();
                    return;
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

                updateGesamtResult();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Beim updaten von Part 1 der Tabelle ist ein Fehler aufgetreten. \n \n" + ex.Message);
                lblErgebnis1.Text = "";
                lblErgebnis2.Text = "";
                totPunkte1.Text = "";
                totPunkte2.Text = "";
                txtNote1.Text = "";
                txtNote2.Text = "";
            }
        }


        private int calculateBereich(int points, System.Windows.Forms.TextBox txtMEpr, System.Windows.Forms.Label result1, System.Windows.Forms.Label result2, System.Windows.Forms.Label result3, System.Windows.Forms.Label totpoints, System.Windows.Forms.Label txtNote)
        {
            if (!txtMEpr.Text.Equals("") && !txtMEpr.Text.Equals("N"))
            {
                int mepr = Convert.ToInt32(txtMEpr.Text);
                double total = points * 2 + mepr;
                result1.Text = total.ToString();
                int gerundet = Round(total / 3);
                result2.Text = gerundet.ToString();
            }
            else
            { 
                result1.Text = "";
                result2.Text = points.ToString();
            }

            int ergebnis = Convert.ToInt32(result2.Text);
            result3.Text = (ergebnis * 10).ToString();
            totpoints.Text = ergebnis.ToString();
            txtNote.Text = calculateNote(ergebnis).ToString();
            return ergebnis;
        }


        private void updatePartTwo()
        {
            try
            {
                clearLabels();
                if (!checkIfNeededIsFilled()) 
                    return;





                //Theorie + WiSo
                calculateBereich(Convert.ToInt32(txtPunkteTheorie1.Text),txtMEpr1, result1Theorie1, result2Theorie1, result3Theorie1,totPunkteTheorie1, txtNoteTheorie1);

                calculateBereich(Convert.ToInt32(txtPunkteTheorie2.Text),txtMEpr2, result1Theorie2, result2Theorie2, result3Theorie2,totPunkteTheorie2, txtNoteTheorie2);

                calculateBereich(Convert.ToInt32(txtPunkteWiSo.Text),txtMEprWiSo, result1WiSo, result2WiSo, result3WiSo,totPunkteWiSo, txtNoteWiSo);

                // Projekt 
                int doku = Convert.ToInt32(txtPunkteDoku.Text) * 50;
                int prfa = Convert.ToInt32(txtPunktePrFa.Text) * 50;
                result1Doku.Text = doku.ToString();
                result1PrFa.Text = prfa.ToString();
                int sumProjekt = doku + prfa;
                txtSumProjekt.Text = sumProjekt.ToString();
                int projektGerundet = Round(sumProjekt / 100.0);
                result2Projekt.Text = projektGerundet.ToString();
                result3Projekt.Text = (projektGerundet * 50).ToString();
                totPunkteProjekt.Text = projektGerundet.ToString();
                txtNoteProjekt.Text = calculateNote(projektGerundet).ToString();

                // Part2 total:
                int sumPart2Int = Convert.ToInt32(result3Projekt.Text) + Convert.ToInt32(result3Theorie1.Text) + Convert.ToInt32(result3Theorie2.Text) + Convert.ToInt32(result3WiSo.Text);
                result3Part2.Text = sumPart2Int.ToString();
                int part2Punkte = Round(sumPart2Int / 80.0);
                totPunktePart2.Text = part2Punkte.ToString();
                txtNotePart2.Text = calculateNote(part2Punkte).ToString();

                updateGesamtResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler in Part 2 der Berechnung: \n\n" + ex.Message);
                clearLabels();
            }
        }

        private void updateGesamtResult()
        {

            try
            {
                //Gesamtergebnis clearen
                sumPart1.Text = "";
                sumPart2.Text = "";
                totalPunkteAll.Text = "";
                txtNoteAll.Text = "";

                if (!checkIfNeededIsFilledForTotalResult())
                    return;
                //Gesamtergebnis:
                sumPart1.Text = lblErgebnis2.Text;
                sumPart2.Text = result3Part2.Text;


                int total = Round((Convert.ToDouble(sumPart1.Text) + Convert.ToDouble(sumPart2.Text)) / 100);
                
                
                totalPunkteAll.Text = total.ToString();
                txtNoteAll.Text = calculateNote(total).ToString();

                //Passed or not passed?:
                //Get Infos über den Schüler
                string studentName = txtStudentName.Text;
                string company = txtCompany.Text;
                string studentNumber = txtStudentNumber.Text;
                //setMEprN();
                if (Convert.ToInt32(txtNoteAll.Text) <= 4)
                {
                    labPassed.Text = "Der Schüler hat die Prüfung bestanden.";
                }
                else
                {
                    labPassed.Text = "Der Schüler hat die Prüfung nicht bestanden.";
                }
            } catch (Exception ex) { MessageBox.Show("Fehler bei der Berechnung der gesamten Note:  \n \n" + ex.Message); }
        }



        /*
        private void updatePartTwo() // kann nur ausgeführt bzw. wird nur bei vollständiger ausfüllung ausgeführt
        {
            // Nimmt Calculation vor.
            try
            {
                if (checkIfNeededIsFilled())
                {
                    clearLabels();

                    // Update Part One muss vor Finale Berechnung aufgerufen werden!
                    //updatePartOne
                    
                    // THEORIE 1:
                    int punkteTheorie1 = Convert.ToInt32(txtPunkteTheorie1.Text);
                    //check ob mepr da ist sonst int =-1
                    int punkteMEpr1 = -1;
                    if (!txtMEpr1.Text.Equals("")) {
                        punkteMEpr1 = Convert.ToInt32(txtMEpr1.Text);
                        result1Theorie1.Text = Convert.ToString(punkteTheorie1 * 2 + punkteMEpr1);
                        
                        
                        
                        result2Theorie1.Text = Convert.ToString(Round(Convert.ToDouble(result1Theorie1.Text) / 3)); //  Runden




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
                        result2Theorie2.Text = Convert.ToString(Round(Convert.ToDouble(result1Theorie2.Text) / 3)); // Runden
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
                        result2WiSo.Text = Convert.ToString(Round(Convert.ToDouble(result1WiSo.Text) / 3)); // Runden
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






                    // Ergebnis Teil 2 Der Abschlussprüfung:                  
                    result3Part2.Text = Convert.ToString(Convert.ToInt32(result3Projekt.Text) + Convert.ToInt32(result3Theorie1.Text) + Convert.ToInt32(result3Theorie2.Text) + Convert.ToInt32(result3WiSo.Text));
                    totPunktePart2.Text = Convert.ToString(Round(Convert.ToDouble(result3Part2.Text) / 80));
                    txtNotePart2.Text = Convert.ToString(calculateNote(Convert.ToInt32(totPunktePart2.Text)));

                    //Gesamtergebnis:
                    sumPart1.Text = lblErgebnis2.Text;
                    sumPart2.Text = result3Part2.Text;
                    totalPunkteAll.Text = Convert.ToString(Round((Convert.ToDouble(sumPart1.Text) + Convert.ToDouble(sumPart2.Text)) / 100)); // Runden
                    txtNoteAll.Text = Convert.ToString(calculateNote(Convert.ToInt32(totalPunkteAll.Text)));


                }
            }
            catch (Exception ex) {
                MessageBox.Show("Beim updaten von Part 2 der Tabelle ist ein Fehler aufgetreten. \n \n" + ex);
            }



        }
        */






        // setter für die einzelnen Kategorien
        // -----------------------------------
        // THeorie 1:

        private void setInput(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            try
            {
                int punkte = 0;
                if (!Int32.TryParse(textBox.Text, out punkte) && !textBox.Text.Equals(""))
                {
                    if (textBox.Text == "N")
                    {
                        return;
                    }
                    throw new ArgumentException("Input not valid");
                }
                punkte = correctIfMoreThanHundred(punkte, textBox);
                updatePartTwo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex.Message);
            }
        }


        /*


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
                    if (txtMEpr1.Text == "N")
                    {
                        //updatePartTwo();
                        return;
                    }
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
                    if (txtMEpr2.Text == "N")
                    {
                        //updatePartTwo();
                        return;
                    }
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
                    if (txtMEprWiSo.Text == "N")
                    {
                        //updatePartTwo();
                        return;
                    }
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
        */

        private void Prüfungsrechner_Load(object sender, EventArgs e)
        {
            selectJob.SelectedIndex = 0;
            updateTheoJob(sender, e);

            clearLabels();
            resetAll(sender, e);
        }

        private void updateTheoJob(object sender, EventArgs e)
        {
            switch (selectJob.SelectedIndex) 
            {
                case 0:
                    {
                        //sys
                        labTheorie1.Text = "Konzeption und Administration von IT-Systemen";
                        labTheorie2.Text = "Analyse und Entwicklung";
                        break;
                    }
                case 1:
                    {
                        //anwendung
                        labTheorie1.Text = "Planen eines Softwareproduktes";
                        labTheorie2.Text = "Entwicklung und Umsetzung von Algorithmen";
                        break;
                    }
                case 2:
                    {
                        //daten
                        labTheorie1.Text = "Durchführen einer Prozessanalyse";
                        labTheorie2.Text = "Sicherstellen der Datenqualität";
                        break;
                    }
                case 3:
                    {
                        //digitale vernetzung
                        labTheorie1.Text = "Diagnose und Störungsbeseitigung \n in vernetzten Systemen";
                        labTheorie2.Text = "Betrieb und Erweiterung \n von vernetzten Systemen";
                        break;
                    }
                case 4:
                    {
                        // IT-System-Elektroniker
                        labTheorie1.Text = "Installation von und Service an IT-Geräten, \n IT-Systemen und IT-Infrastrukturen";
                        labTheorie2.Text = "Anbindung von Geräten,Systemen und \n Betriebsmitteln an die Stromversorgung";
                        break;
                    }
                case 5:
                    {
                        // Kaufmann für Digitalisierungsmanagement
                        labTheorie1.Text = "Entwicklung eines digitalen Geschäftsmodells";
                        labTheorie2.Text = "Kaufmännische Unterstützungsprozesse";
                        break;
                    }
                case 6:
                    {
                        // it sys management
                        labTheorie1.Text = "Einführen einer IT-Systemlösung";
                        labTheorie2.Text = "Kaufmännische Unterstützungsprozesse";
                        break;
                    }
            }
        }



        private void enterMEprBox(object sender, EventArgs e)
        {
            var selectedBox = sender as System.Windows.Forms.TextBox;
            if (selectedBox.Text.Equals("N"))
            {
                selectedBox.Clear();
            }
        }

        private void leaveMEprBox(object sender, EventArgs e)
        {
            var selectedBox = sender as System.Windows.Forms.TextBox;
            if (selectedBox.Text.Equals(""))
            {
                selectedBox.Text = "N";
            }
        }
    }
}
