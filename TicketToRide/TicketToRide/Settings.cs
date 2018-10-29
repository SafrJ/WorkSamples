using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TicketToRide
{
    static class Settings
    {
        static int numPlayers = 2;
        static string[] playersNames = new string[5];        
        
        public static void LoadSettings()
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


        public static void PlayerName(int number, string name)
        {
            playersNames[number] = name;
        }

        public static void NumOfPlayers(int number)
        {
            numPlayers = number;
        }

        public static int NumOfPlayers()
        {
            return numPlayers;
        }

        public static string PlayerName(int number)
        {
            return playersNames[number];
        }
    }
}
