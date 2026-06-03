namespace Windows_GUI_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void berechnen_Click(object sender, EventArgs e)
        {
            try
            {
                string Input = txtInput1.Text;
                int inputInt = Convert.ToInt32(Input);
                int Result = inputInt * 2;

                txtOutput.Text = Result.ToString();
                //MessageBox.Show("Button wurde gedrückt.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten");
            }
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtInput1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Input = txtInput1.Text;
                int inputInt = Convert.ToInt32(Input);
                int Result = inputInt * 2;

                txtOutput.Text = Result.ToString();
                //MessageBox.Show("Button wurde gedrückt.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ein Fehler ist aufgetreten");
            }
        }
    }
}
