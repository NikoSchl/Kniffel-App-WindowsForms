using Kniffel.Properties;
using System.Collections.Immutable;
using System.Data;
using System.Globalization;
using System.Reflection.Emit;
using System.Windows.Forms;
using Kniffel.Models;

namespace Kniffel
{
    public partial class Form1 : Form
    {

        //////////////////////////////////////////////////////////////////////////////
        //                                                                          //
        //                Variablen, arrays, Listen und Objekte                     //
        //                                                                          //
        //////////////////////////////////////////////////////////////////////////////

        private Button Play = new Button();
        private Button Neustart = new Button();
        private Button Regeln = new Button();
        private Button Highscore = new Button();

        private Button WurfelBox1 = new Button();
        private Button WurfelBox2 = new Button();
        private Button WurfelBox3 = new Button();
        private Button WurfelBox4 = new Button();
        private Button WurfelBox5 = new Button();

        private Button Kniffel1 = new Button();
        private Button Kniffel2 = new Button();
        private Button Kniffel3 = new Button();
        private Button Kniffel4 = new Button();
        private Button Kniffel5 = new Button();
        private Button Kniffel6 = new Button();

        private Button KniffelDreier = new Button();
        private Button KniffelVierer = new Button();
        private Button KniffelFull = new Button();
        private Button KniffelKleinStr = new Button();
        private Button KniffelGrosseStr = new Button();
        private Button Kniffel = new Button();
        private Button KniffelChance = new Button();

        private string Pfad = @"C:\Users\nico_\Repositories\KniffelApp\Bilder\Wuerfel";
        private string FromFile = @"C:\Users\nico_\Repositories\KniffelApp\Bilder\Backpicture2.jpg";
        private string Spielregeln = @"C:\Users\nico_\Repositories\KniffelApp\Spielregeln.txt";
        private Bitmap[] Pictures;

        private Random random = new Random();

        SumOfSingleNumbers sumOfSingleNumbers;

        // Array für die gewürfelten Augen
        private int[] wurfelEyes;

        // speichert die Häufigkeit von 1er, 2er, 3er, ...
        private int[] number;

        private int resultAllPoints = 0;
        private int singleResult = 0;
        private int counter = 0;


        //////////////////////////////////////////////////////////////////////////////
        //                                                                          //
        //                            Konstruktoren                                 //
        //                                                                          //
        //////////////////////////////////////////////////////////////////////////////

        public Form1()
        {
            InitializeComponent();
        }


        //////////////////////////////////////////////////////////////////////////////
        //                                                                          //
        //                           Form1_Laod                                     //
        //                                                                          //
        //////////////////////////////////////////////////////////////////////////////

        #region Form1_Load
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(900, 560);
            this.Text = "Kniffel";

            CreatePlayButton();
            CreateWurfelButton();
            CreateKniffelButton();

            sumOfSingleNumbers = new SumOfSingleNumbers();
            wurfelEyes = new int[5];
            Pictures = new Bitmap[7];

            this.Controls.Add(Play);
            this.Controls.Add(WurfelBox1);
            this.Controls.Add(WurfelBox2);
            this.Controls.Add(WurfelBox3);
            this.Controls.Add(WurfelBox4);
            this.Controls.Add(WurfelBox5);
            this.Controls.Add(Kniffel1);
            this.Controls.Add(Kniffel2);
            this.Controls.Add(Kniffel3);
            this.Controls.Add(Kniffel4);
            this.Controls.Add(Kniffel5);
            this.Controls.Add(Kniffel6);
            this.Controls.Add(KniffelDreier);
            this.Controls.Add(KniffelVierer);
            this.Controls.Add(KniffelFull);
            this.Controls.Add(KniffelKleinStr);
            this.Controls.Add(KniffelGrosseStr);
            this.Controls.Add(Kniffel);
            this.Controls.Add(KniffelChance);
            this.Controls.Add(Neustart);
            this.Controls.Add(Regeln);
            this.Controls.Add(Highscore);

            CollectImages();
            WurfelBox1.Image = Pictures[1];
            WurfelBox2.Image = Pictures[1];
            WurfelBox3.Image = Pictures[1];
            WurfelBox4.Image = Pictures[1];
            WurfelBox5.Image = Pictures[1];

            this.BackgroundImage = Pictures[0];
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////
        //                                                                          //
        //                          Create-Button Funktionen                        //
        //                                                                          //
        //////////////////////////////////////////////////////////////////////////////

        #region Create Start Button
        private void CreatePlayButton()
        {
            Play.Location = new Point(520, 390);
            Play.Size = new Size(170, 40);
            Play.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Play.Text = "Würfeln";
            Play.Click += new EventHandler(PlayClick);
            Play.FlatStyle = FlatStyle.Flat;
            Play.Cursor = Cursors.Hand;

            Neustart.Location = new Point(410, 460);
            Neustart.Size = new Size(110, 30);
            Neustart.BackColor = Color.Transparent;
            Neustart.Font = new Font("Segoe UI", 12F);
            Neustart.Text = "Neustart";
            Neustart.Click += new EventHandler(NeustartClick);
            Neustart.FlatStyle = FlatStyle.Flat;
            Neustart.FlatAppearance.BorderSize = 0;

            Regeln.Location = new Point(550, 460);
            Regeln.Size = new Size(110, 30);
            Regeln.BackColor = Color.Transparent;
            Regeln.Font = new Font("Segoe UI", 12F);
            Regeln.Text = "Spielregeln";
            Regeln.Click += new EventHandler(RegelClickOne);
            Regeln.FlatStyle = FlatStyle.Flat;
            Regeln.FlatAppearance.BorderSize = 0;

            Highscore.Location = new Point(690, 460);
            Highscore.Size = new Size(110, 30);
            Highscore.BackColor = Color.Transparent;
            Highscore.Font = new Font("Segoe UI", 12F);
            Highscore.Text = "Highscore";
            Highscore.Click += new EventHandler(HighscoreClick);
            Highscore.FlatStyle = FlatStyle.Flat;
            Highscore.FlatAppearance.BorderSize = 0;
        }
        #endregion

        #region Create Würfel Button
        private void CreateWurfelButton()
        {
            WurfelBox1.Location = new Point(480,100);
            WurfelBox1.Size = new Size(110, 110);
            WurfelBox1.BackColor = Color.Transparent;
            WurfelBox1.Cursor = Cursors.Hand;
            WurfelBox1.FlatStyle = FlatStyle.Flat;
            WurfelBox1.FlatAppearance.BorderSize = 0;
            WurfelBox1.Click += new EventHandler(Wuerfel1Click);

            WurfelBox2.Location = new Point(620,100);
            WurfelBox2.Size = new Size(110, 110);
            WurfelBox2.BackColor = Color.Transparent;
            WurfelBox2.Cursor = Cursors.Hand;
            WurfelBox2.FlatStyle = FlatStyle.Flat;
            WurfelBox2.FlatAppearance.BorderSize = 0;
            WurfelBox2.Click += new EventHandler(Wuerfel2Click);

            WurfelBox3.Location = new Point(410,240);
            WurfelBox3.Size = new Size(110, 110);
            WurfelBox3.BackColor = Color.Transparent;
            WurfelBox3.Cursor = Cursors.Hand;
            WurfelBox3.FlatStyle = FlatStyle.Flat;
            WurfelBox3.FlatAppearance.BorderSize = 0;
            WurfelBox3.Click += new EventHandler(Wuerfel3Click);

            WurfelBox4.Location = new Point(550,240);
            WurfelBox4.Size = new Size(110, 110);
            WurfelBox4.BackColor = Color.Transparent;
            WurfelBox4.Cursor = Cursors.Hand;
            WurfelBox4.FlatStyle = FlatStyle.Flat;
            WurfelBox4.FlatAppearance.BorderSize = 0;
            WurfelBox4.Click += new EventHandler(Wuerfel4Click);

            WurfelBox5.Location = new Point(690,240);
            WurfelBox5.Size = new Size(110, 110);
            WurfelBox5.BackColor = Color.Transparent;
            WurfelBox5.Cursor = Cursors.Hand;
            WurfelBox5.FlatStyle = FlatStyle.Flat;
            WurfelBox5.FlatAppearance.BorderSize = 0;
            WurfelBox5.Click += new EventHandler(Wuerfel5Click);
        }
        #endregion

        #region Create Kniffel Button
        private void CreateKniffelButton()
        {
            Kniffel1.Location = new Point(35,35);
            Kniffel1.Size = new Size(200, 30);
            Kniffel1.Font = new Font("Consolas", 10F, FontStyle.Bold);
            Kniffel1.Text = "Einer";
            Kniffel1.TextAlign = ContentAlignment.MiddleLeft;
            Kniffel1.Click += new EventHandler(Kniffel1Click);
            Kniffel1.BackColor = Color.WhiteSmoke;
            Kniffel1.FlatStyle = FlatStyle.Flat;
            Kniffel1.FlatAppearance.BorderSize = 0;
            Kniffel1.Enabled = true;

            Kniffel2.Location = new Point(35, 65);
            Kniffel2.Size = new Size(200, 30);
            Kniffel2.Font = new Font("Consolas", 10F, FontStyle.Bold);
            Kniffel2.Text = "Zweier";
            Kniffel2.TextAlign = ContentAlignment.MiddleLeft;
            Kniffel2.Click += new EventHandler(Kniffel2Click);
            Kniffel2.BackColor = Color.WhiteSmoke;
            Kniffel2.FlatStyle = FlatStyle.Flat;
            Kniffel2.FlatAppearance.BorderSize = 0;
            Kniffel2.Enabled = true;

            Kniffel3.Location = new Point(35, 95);
            Kniffel3.Size = new Size(200, 30);
            Kniffel3.Font = new Font("Consolas", 10F, FontStyle.Bold);
            Kniffel3.Text = "Dreier";
            Kniffel3.TextAlign = ContentAlignment.MiddleLeft;
            Kniffel3.Click += new EventHandler(Kniffel3Click);
            Kniffel3.BackColor = Color.WhiteSmoke;
            Kniffel3.FlatStyle = FlatStyle.Flat;
            Kniffel3.FlatAppearance.BorderSize = 0;
            Kniffel3.Enabled = true;

            Kniffel4.Location = new Point(35, 125);
            Kniffel4.Size = new Size(200, 30);
            Kniffel4.Font = new Font("Consolas", 10F, FontStyle.Bold);
            Kniffel4.Text = "Vierer";
            Kniffel4.TextAlign = ContentAlignment.MiddleLeft;
            Kniffel4.Click += new EventHandler(Kniffel4Click);
            Kniffel4.BackColor = Color.WhiteSmoke;
            Kniffel4.FlatStyle = FlatStyle.Flat;
            Kniffel4.FlatAppearance.BorderSize = 0;
            Kniffel4.Enabled = true;

            Kniffel5.Location = new Point(35, 155);
            Kniffel5.Size = new Size(200, 30);
            Kniffel5.Font = new Font("Consolas", 10F, FontStyle.Bold);
            Kniffel5.Text = "Fünfer";
            Kniffel5.TextAlign = ContentAlignment.MiddleLeft;
            Kniffel5.Click += new EventHandler(Kniffel5Click);
            Kniffel5.BackColor = Color.WhiteSmoke;
            Kniffel5.FlatStyle = FlatStyle.Flat;
            Kniffel5.FlatAppearance.BorderSize = 0;
            Kniffel5.Enabled = true;

            Kniffel6.Location = new Point(35, 185);
            Kniffel6.Size = new Size(200, 30);
            Kniffel6.Font = new Font("Consolas", 10F, FontStyle.Bold);
            Kniffel6.Text = "Sechser";
            Kniffel6.TextAlign = ContentAlignment.MiddleLeft;
            Kniffel6.Click += new EventHandler(Kniffel6Click);
            Kniffel6.BackColor = Color.WhiteSmoke;
            Kniffel6.FlatStyle = FlatStyle.Flat;
            Kniffel6.FlatAppearance.BorderSize = 0;
            Kniffel6.Enabled = true;

            KniffelDreier.Location = new Point(35, 230);
            KniffelDreier.Size = new Size(200, 30);
            KniffelDreier.Font = new Font("Consolas", 10F, FontStyle.Bold);
            KniffelDreier.Text = "Dreierpasch";
            KniffelDreier.TextAlign = ContentAlignment.MiddleLeft;
            KniffelDreier.Click += new EventHandler(KniffelDreierClick);
            KniffelDreier.BackColor = Color.WhiteSmoke;
            KniffelDreier.FlatStyle = FlatStyle.Flat;
            KniffelDreier.FlatAppearance.BorderSize = 0;
            KniffelDreier.Enabled = true;

            KniffelVierer.Location = new Point(35, 260);
            KniffelVierer.Size = new Size(200, 30);
            KniffelVierer.Font = new Font("Consolas", 10F, FontStyle.Bold);
            KniffelVierer.Text = "Viererpasch";
            KniffelVierer.TextAlign = ContentAlignment.MiddleLeft;
            KniffelVierer.Click += new EventHandler(KniffelViererClick);
            KniffelVierer.BackColor = Color.WhiteSmoke;
            KniffelVierer.FlatStyle = FlatStyle.Flat;
            KniffelVierer.FlatAppearance.BorderSize = 0;
            KniffelVierer.Enabled = true;

            KniffelFull.Location = new Point(35, 290);
            KniffelFull.Size = new Size(200, 30);
            KniffelFull.Font = new Font("Consolas", 10F, FontStyle.Bold);
            KniffelFull.Text = "Fullhouse";
            KniffelFull.TextAlign = ContentAlignment.MiddleLeft;
            KniffelFull.Click += new EventHandler(KniffelFullClick);
            KniffelFull.BackColor = Color.WhiteSmoke;
            KniffelFull.FlatStyle = FlatStyle.Flat;
            KniffelFull.FlatAppearance.BorderSize = 0;
            KniffelFull.Enabled = true;

            KniffelKleinStr.Location = new Point(35, 320);
            KniffelKleinStr.Size = new Size(200, 30);
            KniffelKleinStr.Font = new Font("Consolas", 10F, FontStyle.Bold);
            KniffelKleinStr.Text = "Kleine Str";
            KniffelKleinStr.TextAlign = ContentAlignment.MiddleLeft;
            KniffelKleinStr.Click += new EventHandler(KniffelSmalStrClick);
            KniffelKleinStr.BackColor = Color.WhiteSmoke;
            KniffelKleinStr.FlatStyle = FlatStyle.Flat;
            KniffelKleinStr.FlatAppearance.BorderSize = 0;
            KniffelKleinStr.Enabled = true;

            KniffelGrosseStr.Location = new Point(35, 350);
            KniffelGrosseStr.Size = new Size(200, 30);
            KniffelGrosseStr.Font = new Font("Consolas", 10F, FontStyle.Bold);
            KniffelGrosseStr.Text = "Grosse Str";
            KniffelGrosseStr.TextAlign = ContentAlignment.MiddleLeft;
            KniffelGrosseStr.Click += new EventHandler(KniffelGreatStrClick);
            KniffelGrosseStr.BackColor = Color.WhiteSmoke;
            KniffelGrosseStr.FlatStyle = FlatStyle.Flat;
            KniffelGrosseStr.FlatAppearance.BorderSize = 0;
            KniffelGrosseStr.Enabled = true;

            Kniffel.Location = new Point(35, 380);
            Kniffel.Size = new Size(200, 30);
            Kniffel.Font = new Font("Consolas", 10F, FontStyle.Bold);
            Kniffel.Text = "Kniffel";
            Kniffel.TextAlign = ContentAlignment.MiddleLeft;
            Kniffel.Click += new EventHandler(KniffelClick);
            Kniffel.BackColor = Color.WhiteSmoke;
            Kniffel.FlatStyle = FlatStyle.Flat;
            Kniffel.FlatAppearance.BorderSize = 0;
            Kniffel.Enabled = true;

            KniffelChance.Location = new Point(35, 410);
            KniffelChance.Size = new Size(200, 30);
            KniffelChance.Font = new Font("Consolas", 10F, FontStyle.Bold);
            KniffelChance.Text = "Chance";
            KniffelChance.TextAlign = ContentAlignment.MiddleLeft;
            KniffelChance.Click += new EventHandler(KniffelChanceClick);
            KniffelChance.BackColor = Color.WhiteSmoke;
            KniffelChance.FlatStyle = FlatStyle.Flat;
            KniffelChance.FlatAppearance.BorderSize = 0;
            KniffelChance.Enabled = true;
        }
        #endregion



        //////////////////////////////////////////////////////////////////////////////
        //                                                                          //
        //            Methoden / Funktionen für den Ablauf des Spiels               //
        //                                                                          //
        //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Eine Funktion um die Bilder aus dem Ordner in ein Array zu speichern
        /// </summary>
        public void CollectImages()
        {
            string Datei = string.Empty;

            Pictures[0] = (Bitmap)Image.FromFile(FromFile);
            
            for (int i = 1; i <= 6; i++)
            {
                try
                {
                    Datei = Pfad + i.ToString() + ".png";
                    Pictures[i] = (Bitmap)Image.FromFile(Datei);
                }
                catch (Exception)
                {
                    MessageBox.Show("Kein Bild gefunden!");
                }
            }
        }

        /// <summary>
        /// Generiert Zufallszahlen in ein array und verbindet die Bilder in die Button zu laden
        /// </summary>
        public void ShowPictures()
        {
            if (WurfelBox1.Enabled)
            {
                // Zufallszahl für die Button werden ermittelt
                wurfelEyes[0] = random.Next(1, 7);
                // Das zur Zufallszahl passende Bild wird in den Button geladen
                WurfelBox1.Image = Pictures[wurfelEyes[0]];
            }

            if (WurfelBox2.Enabled)
            {
                wurfelEyes[1] = random.Next(1, 7);
                WurfelBox2.Image = Pictures[wurfelEyes[1]]; 
            }

            if (WurfelBox3.Enabled)
            {
                wurfelEyes[2] = random.Next(1, 7);
                WurfelBox3.Image = Pictures[wurfelEyes[2]]; 
            }

            if (WurfelBox4.Enabled)
            {
                wurfelEyes[3] = random.Next(1, 7);
                WurfelBox4.Image = Pictures[wurfelEyes[3]]; 
            }

            if (WurfelBox5.Enabled)
            {
                wurfelEyes[4] = random.Next(1, 7);
                WurfelBox5.Image = Pictures[wurfelEyes[4]]; 
            }
        }

        private void NewStartForNextPlay()
        {
            WurfelBox1.Image = Pictures[1];
            WurfelBox2.Image = Pictures[1];
            WurfelBox3.Image = Pictures[1];
            WurfelBox4.Image = Pictures[1];
            WurfelBox5.Image = Pictures[1];
            WurfelBox1.Enabled = true;
            WurfelBox2.Enabled = true;
            WurfelBox3.Enabled = true;
            WurfelBox4.Enabled = true;
            WurfelBox5.Enabled = true;
            Play.Enabled = true;
            Anweisung.Text = "Sie dürfen 3x Würfeln";
        }


        /// <summary>
        /// Zählt die Häufigkeit der gleichen Würfelaugen (z.B. zwei Würfel haben die 1, dann ist das
        /// Ergebnis 2 und wird in das Array gespeichert an erster Position, hat kein Würfel die 2 steht
        /// im array[1] eine 0)
        /// </summary>
        private void CountEyesOfPlayRound()
        {
            number = new int[6];

            for (int i = 0; i < number.Length; i++)
            {
                // wurfelEyes ist ein Array der gewürfelten Augen
                number[i] = wurfelEyes.Count(num => num == (i + 1));
            }
        }

        /// <summary>
        /// Funktion checkt ob das Ergebnis einem Dreier- oder Viererpasch entspricht
        /// </summary>
        /// <param name="value">Der Prüfwert für Dreierpasch(3) oder Viererpasch(4)</param>
        /// <returns>0 oder die Summe aller Würfel</returns>
        private int CheckForDreierOrViererPasch(int value)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] >= value)
                {
                    return wurfelEyes.Sum();
                }
            }
            return 0;
        }


        private int CheckForFullHouse()
        {
            var zero = number.Count(x => x == 0);

            for (int i = 0; i < number.Length; i++)
            {
                if (zero == 4)
                {
                    return 25;
                }
            }
            return 0;
        }

        private int CheckForSmalStr()
        {
            if ((wurfelEyes.Contains(1) && wurfelEyes.Contains(2) && wurfelEyes.Contains(3) && wurfelEyes.Contains(4))
                || (wurfelEyes.Contains(2) && wurfelEyes.Contains(3) && wurfelEyes.Contains(4) && wurfelEyes.Contains(5))
                || (wurfelEyes.Contains(3) && wurfelEyes.Contains(4) && wurfelEyes.Contains(5) && wurfelEyes.Contains(6)))
            {
                return 30;
            }
            return 0;
        }

        private int CheckForGreatStr()
        {
            var zero = number.Count(x => x == 0);

            for (int i = 0; i < number.Length; i++)
            {
                if (zero == 1 && (number[0] == 0 || number[5] == 0))
                {
                    return 40;
                }
            }
            return 0;
        }

        private int CheckForKniffel()
        {
            var zero = number.Count(x => x == 0);

            for (int i = 0; i < number.Length; i++)
            {
                if (zero == 5)
                {
                    return 50;
                }
            }
            return 0;
        }

        /// <summary>
        /// Zählt alle Ergebnisse zusammen und gibt das Ergebnis aus
        /// </summary>
        /// <param name="result">Ergebnis von einem Eintrag</param>
        private void GesamtErgebnis(int result)
        {
            resultAllPoints += result;
            gesamtPunkte.Text = $"Gesamtpunkte: {resultAllPoints.ToString().PadLeft(12)}";
        }



        //////////////////////////////////////////////////////////////////////////////
        //                                                                          //
        //                         Button-Click Events                              //
        //                                                                          //
        //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Eventfunktion 
        /// </summary>
        private void PlayClick(object? sender, EventArgs e)
        {
            if (counter < 3)
            {
                counter++;
                ShowPictures();
                Anweisung.Text = "Wählen Sie die Würfel, die Sie behalten wollen und würfeln Sie erneut";
            }
            if (counter == 3)
            {
                Play.Enabled = false;
                WurfelBox1.Enabled = false; 
                WurfelBox2.Enabled = false;
                WurfelBox3.Enabled = false;
                WurfelBox4.Enabled = false;
                WurfelBox5.Enabled = false;
                Anweisung.Text = "Ordnen Sie das Ergebnis einer Kombination zu";
                counter = 0;
            }
        }

        private void NeustartClick(object? sender, EventArgs e)
        {
            resultAllPoints = 0;
            singleResult = 0;
            counter = 0;
            CreateKniffelButton();
            NewStartForNextPlay();
            gesamtPunkte.Text = "Gesamtpunkte:";
            WurfelBox1.Enabled = true;
            WurfelBox2.Enabled = true;
            WurfelBox3.Enabled = true;
            WurfelBox4.Enabled = true;
            WurfelBox5.Enabled = true;
            Play.Enabled = true;
        }

        private void RegelClickOne(object? sender, EventArgs e)
        {
            try
            {
                string text = File.ReadAllText(Spielregeln);
                MessageBox.Show(text, "Kniffel - Die Spielregeln");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Datei wurde nicht gefunden!");
            }
        }

        private void HighscoreClick(object? sender, EventArgs e)
        {
            MessageBox.Show("In Bearbeitung", "Coming soon");
        }

        private void Wuerfel1Click(object? sender, EventArgs e)
        {
            WurfelBox1.Enabled = false;
        }

        private void Wuerfel2Click(object? sender, EventArgs e)
        {
            WurfelBox2.Enabled = false;
        }

        private void Wuerfel3Click(object? sender, EventArgs e)
        {
            WurfelBox3.Enabled = false;
        }

        private void Wuerfel4Click(object? sender, EventArgs e)
        {
            WurfelBox4.Enabled = false;
        }

        private void Wuerfel5Click(object? sender, EventArgs e)
        {
            WurfelBox5.Enabled = false;
        }


        private void Kniffel1Click(object? sender, EventArgs e)
        {
            singleResult = sumOfSingleNumbers.SumOfSameValues(1, wurfelEyes);
            Kniffel1.Text = $"Einer    {singleResult.ToString().PadLeft(12)}";
            GesamtErgebnis(singleResult);
            NewStartForNextPlay();
            Kniffel1.Enabled = false;
        }

        private void Kniffel2Click(object? sender, EventArgs e)
        {
            singleResult = sumOfSingleNumbers.SumOfSameValues(2, wurfelEyes);
            Kniffel2.Text = $"Zweier   {singleResult.ToString().PadLeft(12)}";
            GesamtErgebnis(singleResult);
            NewStartForNextPlay();
            Kniffel2.Enabled = false;
        }

        private void Kniffel3Click(object? sender, EventArgs e)
        {
            singleResult = sumOfSingleNumbers.SumOfSameValues(3, wurfelEyes);
            Kniffel3.Text = $"Dreier   {singleResult.ToString().PadLeft(12)}";
            GesamtErgebnis(singleResult);
            NewStartForNextPlay();
            Kniffel3.Enabled = false;
        }

        private void Kniffel4Click(object? sender, EventArgs e)
        {
            singleResult = sumOfSingleNumbers.SumOfSameValues(4, wurfelEyes);
            Kniffel4.Text = $"Vierer   {singleResult.ToString().PadLeft(12)}";
            GesamtErgebnis(singleResult);
            NewStartForNextPlay();
            Kniffel4.Enabled = false;
        }

        private void Kniffel5Click(object? sender, EventArgs e)
        {
            singleResult = sumOfSingleNumbers.SumOfSameValues(5, wurfelEyes);
            Kniffel5.Text = $"Fünfer   {singleResult.ToString().PadLeft(12)}";
            GesamtErgebnis(singleResult);
            NewStartForNextPlay();
            Kniffel5.Enabled = false;
        }

        private void Kniffel6Click(object? sender, EventArgs e)
        {
            singleResult = sumOfSingleNumbers.SumOfSameValues(6, wurfelEyes);
            Kniffel6.Text = $"Sechser  {singleResult.ToString().PadLeft(12)}";
            GesamtErgebnis(singleResult);
            NewStartForNextPlay();
            Kniffel6.Enabled = false;
        }

        private void KniffelDreierClick(object? sender, EventArgs e)
        {
            CountEyesOfPlayRound();
            int dreierpasch = CheckForDreierOrViererPasch(3);
            KniffelDreier.Text = $"Dreierpasch  {dreierpasch.ToString().PadLeft(8)}";
            GesamtErgebnis(dreierpasch);
            NewStartForNextPlay();
            KniffelDreier.Enabled = false;
        }

        private void KniffelViererClick(object? sender, EventArgs e)
        {
            CountEyesOfPlayRound();
            int viererpasch = CheckForDreierOrViererPasch(4);
            KniffelVierer.Text = $"Viererpasch  {viererpasch.ToString().PadLeft(8)}";
            GesamtErgebnis(viererpasch);
            NewStartForNextPlay();
            KniffelVierer.Enabled = false;
        }

        private void KniffelFullClick(object? sender, EventArgs e)
        {
            CountEyesOfPlayRound();
            int fullhouse = CheckForFullHouse();
            KniffelFull.Text = $"Fullhouse  {fullhouse.ToString().PadLeft(10)}";
            GesamtErgebnis(fullhouse);
            NewStartForNextPlay();
            KniffelFull.Enabled = false;
        }

        private void KniffelSmalStrClick(object? sender, EventArgs e)
        {
            CountEyesOfPlayRound();
            int kleineStr = CheckForSmalStr();
            KniffelKleinStr.Text = $"Kleine Str  {kleineStr.ToString().PadLeft(9)}";
            GesamtErgebnis(kleineStr);
            NewStartForNextPlay();
            KniffelKleinStr.Enabled = false;
        }

        private void KniffelGreatStrClick(object? sender, EventArgs e)
        {
            CountEyesOfPlayRound();
            int grosseStr = CheckForGreatStr();
            KniffelGrosseStr.Text = $"Grosse Str  {grosseStr.ToString().PadLeft(9)}";
            GesamtErgebnis(grosseStr);
            NewStartForNextPlay();
            KniffelGrosseStr.Enabled = false;
        }

        private void KniffelClick(object? sender, EventArgs e)
        {
            CountEyesOfPlayRound();
            int kniffel = CheckForKniffel();
            Kniffel.Text = $"Kniffel  {kniffel.ToString().PadLeft(12)}";
            GesamtErgebnis(kniffel);
            NewStartForNextPlay();
            Kniffel.Enabled = false;
        }

        private void KniffelChanceClick(object? sender, EventArgs e)
        {
            int chance = wurfelEyes.Sum();
            KniffelChance.Text = $"Chance  {chance.ToString().PadLeft(13)}";
            GesamtErgebnis(chance);
            NewStartForNextPlay();
            KniffelChance.Enabled = false;
        }
    }
}
