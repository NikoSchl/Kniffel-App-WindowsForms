namespace Kniffel
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
            gesamtPunkte = new Label();
            Anweisung = new Label();
            SuspendLayout();
            // 
            // gesamtPunkte
            // 
            gesamtPunkte.BackColor = Color.Transparent;
            gesamtPunkte.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gesamtPunkte.ForeColor = Color.White;
            gesamtPunkte.ImageAlign = ContentAlignment.MiddleLeft;
            gesamtPunkte.Location = new Point(30, 450);
            gesamtPunkte.Name = "gesamtPunkte";
            gesamtPunkte.Size = new Size(211, 22);
            gesamtPunkte.TabIndex = 0;
            gesamtPunkte.Text = "Gesamtpunkte:";
            // 
            // Anweisung
            // 
            Anweisung.BackColor = Color.Transparent;
            Anweisung.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Anweisung.ForeColor = Color.White;
            Anweisung.Location = new Point(442, 30);
            Anweisung.Name = "Anweisung";
            Anweisung.Size = new Size(341, 40);
            Anweisung.TabIndex = 1;
            Anweisung.Text = "Sie dürfen 3x Würfeln";
            Anweisung.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 515);
            Controls.Add(Anweisung);
            Controls.Add(gesamtPunkte);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label gesamtPunkte;
        private Label Anweisung;
    }
}
