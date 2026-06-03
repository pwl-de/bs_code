namespace Windows_GUI_Test
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            berechnen = new Button();
            txtInput1 = new TextBox();
            txtOutput = new TextBox();
            labelInput = new Label();
            labelOutput = new Label();
            SuspendLayout();
            // 
            // berechnen
            // 
            berechnen.Location = new Point(202, 111);
            berechnen.Name = "berechnen";
            berechnen.Size = new Size(170, 41);
            berechnen.TabIndex = 0;
            berechnen.Text = "Berechnen";
            berechnen.UseVisualStyleBackColor = true;
            berechnen.Click += berechnen_Click;
            // 
            // txtInput1
            // 
            txtInput1.Location = new Point(202, 48);
            txtInput1.Name = "txtInput1";
            txtInput1.Size = new Size(170, 27);
            txtInput1.TabIndex = 1;
            txtInput1.TextChanged += txtInput1_TextChanged;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(202, 187);
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(170, 27);
            txtOutput.TabIndex = 2;
            txtOutput.TextChanged += txtOutput_TextChanged;
            // 
            // labelInput
            // 
            labelInput.AutoSize = true;
            labelInput.Location = new Point(57, 51);
            labelInput.Name = "labelInput";
            labelInput.Size = new Size(63, 20);
            labelInput.TabIndex = 3;
            labelInput.Text = "Eingabe";
            // 
            // labelOutput
            // 
            labelOutput.AutoSize = true;
            labelOutput.Location = new Point(53, 194);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(67, 20);
            labelOutput.TabIndex = 5;
            labelOutput.Text = "Ausgabe";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 325);
            Controls.Add(labelOutput);
            Controls.Add(labelInput);
            Controls.Add(txtOutput);
            Controls.Add(txtInput1);
            Controls.Add(berechnen);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button berechnen;
        private TextBox txtInput1;
        private TextBox txtOutput;
        private Label labelInput;
        private Label labelOutput;
    }
}
