namespace _STUDENTU_ZURNALAS_C__
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    throw new Exception("Laukeliai yra tušti! Įveskite reikšmes į visus laukelius!");
                }
                else
                {
                    string[] vardasPavarde = textBox1.Text.Split(' ');
                    string vardas = vardasPavarde[0]; 
                    string pavardė = vardasPavarde.Length > 1 ? vardasPavarde[1] : ""; 

                    string[] pazymiaiString = textBox2.Text.Split(' ');
                    List<int> pazymiai = new List<int>();

                    foreach (string pazymys in pazymiaiString)
                    {
                        if (int.TryParse(pazymys, out int pazymysInt))
                        {
                            pazymiai.Add(pazymysInt);
                        }
                        else
                        {
                            throw new Exception("Neteisingai įvesti pažymiai!");
                        }
                    }

                    int egzaminoBalas;
                    if (int.TryParse(textBox3.Text, out egzaminoBalas))
                    {
                        double rezultatas = 0;
                        string rezultatoPavadinimas = "";

                        if (radioButton1.Checked)
                        {
                            rezultatas = pazymiai.Average(); // Vidurkio skaičiavimas
                            rezultatoPavadinimas = "Vidurkis: ";
                        }
                        else if (radioButton2.Checked)
                        {
                            pazymiai.Sort();
                            int count = pazymiai.Count;
                            if (count % 2 == 0)
                            {
                                rezultatas = (double)(pazymiai[count / 2 - 1] + pazymiai[count / 2]) / 2; // Medianos skaičiavimas
                            }
                            else
                            {
                                rezultatas = (double)pazymiai[count / 2];
                            }
                            rezultatoPavadinimas = "Mediana: ";
                        }

                        string studentInfo = vardas + " " + pavardė + " " + string.Join(" ", pazymiai) + " Egzamino balas: " + egzaminoBalas + " " + rezultatoPavadinimas + rezultatas.ToString();
                        listBox1.Items.Add(studentInfo);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        throw new Exception("Neteisingai įvestas egzamino balas!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KLAIDA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button3_Click(object sender, EventArgs e) // [KOPIJUOTI VISUS]
        {
            textBox4.Text = "";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                textBox4.Text += listBox1.Items[i].ToString() + "\r\n";
            }
        }

        private void button4_Click(object sender, EventArgs e) // [KOPIJUOTI PAŽYMĖTA]
        {
            if (listBox1.SelectedIndex != -1)
            {
                textBox4.Text = listBox1.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Nepasirinktas joks studentas!", "KLAIDA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e) // [ATIDARYTI]
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Teksto failai (*.txt)|*.txt|Visi failai (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog1.FileName);

                    listBox1.Items.Clear();

                    foreach (string line in lines)
                    {
                        listBox1.Items.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Klaida: Nepavyko atidaryti failo. " + ex.Message);
                }
            }
        }


        private void button6_Click(object sender, EventArgs e) // [IŠSAUGOTI KAIP]
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Teksto failai (*.txt)|*.txt|Visi failai (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<string> linesToSave = new List<string>();

                    foreach (var item in listBox1.Items)
                    {
                        linesToSave.Add(item.ToString());
                    }

                    File.WriteAllLines(saveFileDialog1.FileName, linesToSave);

                    MessageBox.Show("Failas išsaugotas sėkmingai!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Klaida: Nepavyko išsaugoti failo. " + ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e) // [SPAUSDINTI]
        {
            MessageBox.Show("Funkcija dar nebaigta!", "Klaida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button8_Click(object sender, EventArgs e) // [VALYTI]
        {
            listBox1.Items.Clear();
            textBox4.Text = "";
        }

        private void atidarytiToolStripMenuItem_Click(object sender, EventArgs e) // [ATIDARYTI MENU]
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Teksto failai (*.txt)|*.txt|Visi failai (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog1.FileName);

                    listBox1.Items.Clear();

                    foreach (string line in lines)
                    {
                        listBox1.Items.Add(line);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Klaida: Nepavyko atidaryti failo. " + ex.Message);
                }
            }
        }

        private void išsaugotiKaipToolStripMenuItem_Click(object sender, EventArgs e) // [IŠSAUGOTI KAIP MENU]
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Teksto failai (*.txt)|*.txt|Visi failai (*.*)|*.*";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<string> linesToSave = new List<string>();

                    foreach (var item in listBox1.Items)
                    {
                        linesToSave.Add(item.ToString());
                    }

                    File.WriteAllLines(saveFileDialog1.FileName, linesToSave);

                    MessageBox.Show("Failas issaugotas sekmingai!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Klaida: Nepavyko issaugoti failo. " + ex.Message);
                }
            }
        }

        private void uždarytiToolStripMenuItem_Click(object sender, EventArgs e) // [UŽDARYTI MENU]
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) // [USLESS]
        {

        }

        private void failasToolStripMenuItem2_Click(object sender, EventArgs e) // [USLESS]
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pagalbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Įrašykite studento vardą, pavardę visus pažymius, atskirtus tarpais, ir egzamino balą. Jeigu norite galite kopijuoti visą informaciją i antrą laukelį išsaugojimui ir/arba komentarų pridėjimui.", "Pagalba", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void apieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Antras praktinis darbas v0.1", "Apie", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
