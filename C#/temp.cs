//Todo:
//1. Output Bestanden / nicht bestandne
//2. updatePartOne bei updatePartTwo aufrufen ???
//3. Buttons: Clear, Calc







                //Gesamtergebnis:
                sumPart1.Text = lblErgebnis2.Text;
                sumPart2.Text = sumPart2Int.ToString(); 
                int total = Round((Convert.ToDouble(lblErgebnis2.Text) + sumPart2Int) / 100);
                totalPunkteAll.Text = total.ToString();
                txtNoteAll.Text = calculateNote(total).ToString();

                //Passed or not passed?:
                //Get Infos über den Schüler
                string studentName = txtStudentName.Text;
                string company = txtCompany.Text;
                string studentNumber = txtStudentNumber.Text;
                if (Convert.ToInt32(txtNoteAll.Text) <= 4)
                {
                    labPassed.Text = "Der Schüler " + studentName + " mit der Nummer " + studentNumber + "hat die Prüfung bestanden.";
                } else
                {
                    labPassed.Text = "Der Schüler " + studentName + " mit der Nummer " + studentNumber + "hat die Prüfung nicht bestanden.";
                }



            if (txtMEpr1.Text.Equals("")) { 
                txtMEpr1.Text = "N";
            }
            if (txtMEpr2.Text.Equals("")) { 
                txtMEpr2.Text = "N";
            }
            if (txtMEprWiSo.Text.Equals("")) { 
                txtMEprWiSo.Text = "N";
            }