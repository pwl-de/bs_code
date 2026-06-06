//Todo:
//1. Output Bestanden / nicht bestandne
//2. updatePartOne bei updatePartTwo aufrufen ???
//3. Buttons: Clear, Calc



private void setInput(object sender, EventArgs e) { 
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
        MessageBox.Show("Ein Fehler ist aufgetreten \n \n" + ex);
    }
}

// --------------------------------------------------------------------