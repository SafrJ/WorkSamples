using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace TicketToRide
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(@".\settings.txt"))
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "TicketToRide.Resources.settings.txt";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        Settings.NumOfPlayers(int.Parse(reader.ReadLine()));
                        for (int i = 0; i < 5; i++)
                        {
                            Settings.PlayerName(i, reader.ReadLine());
                        }
                    }
                }
            }
            else
            {
                string[] lines = File.ReadAllLines(@".\settings.txt");

                try
                {
                    Settings.NumOfPlayers(int.Parse(lines[0]));
                    for (int i = 0; i < 5; i++)
                    {
                        Settings.PlayerName(i, lines[i + 1]);
                    }
                }
                catch
                {
                    MessageBox.Show("Soubor s nastavením je ve špatném formátu. Odstraňte prosím soubor settings.txt ze složky se hrou a zkuste hru nastavit znovu.", "Poškozený soubor s nastavením", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            trackBar1.Value = Settings.NumOfPlayers();
            trackBar1_ValueChanged(sender, e);
            label2.Text = trackBar1.Value.ToString();
            textBox1.Text = Settings.PlayerName(0);
            textBox2.Text = Settings.PlayerName(1);
            textBox3.Text = Settings.PlayerName(2);
            textBox4.Text = Settings.PlayerName(2);
            textBox5.Text = Settings.PlayerName(4);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            Settings.NumOfPlayers(trackBar1.Value);
            label2.Text = trackBar1.Value.ToString();
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;



            if (trackBar1.Value > 1)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            if (trackBar1.Value > 2)
                textBox3.Enabled = true;
            if (trackBar1.Value > 3)
                textBox4.Enabled = true;
            if (trackBar1.Value > 4)
                textBox5.Enabled = true;



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] lines = new string[6];
            lines[0] = Settings.NumOfPlayers().ToString();
            lines[1] = Settings.PlayerName(0);
            lines[2] = Settings.PlayerName(1);
            lines[3] = Settings.PlayerName(2);
            lines[4] = Settings.PlayerName(3);
            lines[5] = Settings.PlayerName(4);

           File.WriteAllLines(@".\settings.txt", lines);

            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Settings.PlayerName(0, textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Settings.PlayerName(1, textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Settings.PlayerName(2, textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Settings.PlayerName(3, textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Settings.PlayerName(4, textBox5.Text);
        }
    }
}
