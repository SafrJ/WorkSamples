using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketToRide
{
    partial class BuildRailForm : Form
    {
        Game game;

        public BuildRailForm(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void BuildRailForm_Load(object sender, EventArgs e)
        {
            Link[] linkArray = new Link[game.GetAvailibleLinks().Count];
            int i = 0;

            foreach (Link link in game.GetAvailibleLinks())
            {
                linkArray[i] = link;
                i++;
            }

            listBox1.Items.AddRange(linkArray);
        }

        //Zkontroluje jestli uživatel vybral vhodný počet karet a pokud ano tak sebere hráči karty a nechá ho postavit cestu
        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (panelCardChoose.Visible == false && listBox1.SelectedItem != null)
            {
                panelCardChoose.Visible = true;
                btnBack.Visible = true;
            }
            else
            {
                Link selectedLink = (Link)listBox1.SelectedItem;
                if (CanBeBuild(selectedLink))
                {
                    game.BuildRail(selectedLink);
                    listBox1.ClearSelected();
                    DiscardSelectedCards();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("S vybranými kartami nelze cestu postavit", "Špatně vybrané karty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        //Zavře okno
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panelCardChoose.Visible = false;
            btnBack.Visible = false;
        }

        private void panelCardChoose_VisibleChanged(object sender, EventArgs e)
        {
            Link selectedLink = (Link)listBox1.SelectedItem;
            numericLoco.Maximum = 0;
            numericBlack.Maximum = 0;
            numericPink.Maximum = 0;
            numericOrange.Maximum = 0;
            numericRed.Maximum = 0;
            numericYellow.Maximum = 0;
            numericBlue.Maximum = 0;
            numericGreen.Maximum = 0;
            numericWhite.Maximum = 0;


            switch (selectedLink.GetLinkColor())
            {
                case CardColor.All:
                    labelMaxLoco.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.All).ToString() + ")";
                    labelMaxPink.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Pink).ToString() + ")";
                    labelMaxRed.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Red).ToString() + ")";
                    labelMaxOrange.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Orange).ToString() + ")";
                    labelMaxBlack.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Black).ToString() + ")";
                    labelMaxYellow.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Yellow).ToString() + ")";
                    labelMaxBlue.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Blue).ToString() + ")";
                    labelMaxGreen.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Green).ToString() + ")";
                    labelMaxWhite.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.White).ToString() + ")";
                    numericLoco.Maximum = game.GetActivePlayer().GetCardCount(CardColor.All);
                    numericBlack.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Black);
                    numericPink.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Pink);
                    numericOrange.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Orange);
                    numericRed.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Red);
                    numericYellow.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Yellow);
                    numericBlue.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Blue);
                    numericGreen.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Green);
                    numericWhite.Maximum = game.GetActivePlayer().GetCardCount(CardColor.White);
                    break;

                case CardColor.Pink:
                    labelMaxLoco.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.All).ToString() + ")";
                    labelMaxPink.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Pink).ToString() + ")";
                    numericLoco.Maximum = game.GetActivePlayer().GetCardCount(CardColor.All);
                    numericPink.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Pink);
                    break;

                case CardColor.Orange:
                    labelMaxLoco.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.All).ToString() + ")";
                    labelMaxOrange.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Orange).ToString() + ")";
                    numericLoco.Maximum = game.GetActivePlayer().GetCardCount(CardColor.All);
                    numericOrange.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Orange);
                    break;

                case CardColor.Red:
                    labelMaxLoco.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.All).ToString() + ")";
                    labelMaxRed.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Red).ToString() + ")";
                    numericLoco.Maximum = game.GetActivePlayer().GetCardCount(CardColor.All);
                    numericRed.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Red);
                    break;
                case CardColor.Black:
                    labelMaxLoco.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.All).ToString() + ")";
                    labelMaxBlack.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Black).ToString() + ")";
                    numericLoco.Maximum = game.GetActivePlayer().GetCardCount(CardColor.All);
                    numericBlack.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Black);
                    break;
                case CardColor.Green:
                    labelMaxLoco.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.All).ToString() + ")";
                    labelMaxGreen.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Green).ToString() + ")";
                    numericLoco.Maximum = game.GetActivePlayer().GetCardCount(CardColor.All);
                    numericGreen.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Green);
                    break;
                case CardColor.White:
                    labelMaxLoco.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.All).ToString() + ")";
                    labelMaxWhite.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.White).ToString() + ")";
                    numericLoco.Maximum = game.GetActivePlayer().GetCardCount(CardColor.All);
                    numericWhite.Maximum = game.GetActivePlayer().GetCardCount(CardColor.White);
                    break;
                case CardColor.Yellow:
                    labelMaxYellow.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Yellow).ToString() + ")";
                    labelMaxLoco.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.All).ToString() + ")";
                    numericLoco.Maximum = game.GetActivePlayer().GetCardCount(CardColor.All);
                    numericYellow.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Yellow);
                    break;
                case CardColor.Blue:
                    labelMaxBlue.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.Blue).ToString() + ")";
                    labelMaxLoco.Text = "(max." + game.GetActivePlayer().GetCardCount(CardColor.All).ToString() + ")";
                    numericLoco.Maximum = game.GetActivePlayer().GetCardCount(CardColor.All);
                    numericBlue.Maximum = game.GetActivePlayer().GetCardCount(CardColor.Blue);
                    break;
                default:
                    break;
            }
        }

        private bool CanBeBuild(Link link)
        {
            int price = link.GetLength();
            if (price > game.GetActivePlayer().GetWagonsCount())
            {
                MessageBox.Show("Nemáš dostatečný počet vagonků. Cesta nelze postavit.", "Nedostatečný počet vagonků", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                price = price - (int)(numericBlack.Value);
                price = price - (int)(numericPink.Value);
                price = price - (int)(numericYellow.Value);
                price = price - (int)(numericRed.Value);
                price = price - (int)(numericOrange.Value);
                price = price - (int)(numericWhite.Value);
                price = price - (int)(numericBlue.Value);
                price = price - (int)(numericGreen.Value);
                price = price - (int)(numericLoco.Value);
            }

            if (price <= 0)
                return true;
            else
                return false;
        }

        private void DiscardSelectedCards()
        {
            for (int i = 0; i < numericLoco.Value; i++)
            {
                game.PlayerDiscardsCard(CardColor.All);
            }
            for (int i = 0; i < numericPink.Value; i++)
            {
                game.PlayerDiscardsCard(CardColor.Pink);
            }
            for (int i = 0; i < numericOrange.Value; i++)
            {
                game.PlayerDiscardsCard(CardColor.Orange);
            }
            for (int i = 0; i < numericRed.Value; i++)
            {
                game.PlayerDiscardsCard(CardColor.Red);
            }
            for (int i = 0; i < numericBlack.Value; i++)
            {
                game.PlayerDiscardsCard(CardColor.Black);
            }
            for (int i = 0; i < numericBlue.Value; i++)
            {
                game.PlayerDiscardsCard(CardColor.Blue);
            }
            for (int i = 0; i < numericGreen.Value; i++)
            {
                game.PlayerDiscardsCard(CardColor.Green);
            }
            for (int i = 0; i < numericYellow.Value; i++)
            {
                game.PlayerDiscardsCard(CardColor.Yellow);
            }
            for (int i = 0; i < numericWhite.Value; i++)
            {
                game.PlayerDiscardsCard(CardColor.White);
            }
        }

        #region Kontrola počtu barev

        private void numericPink_ValueChanged(object sender, EventArgs e)
        {
            if (
                numericBlack.Value != 0 ||
                numericOrange.Value != 0 ||
                numericRed.Value != 0 ||
                numericBlue.Value != 0 ||
                numericWhite.Value != 0 ||
                numericYellow.Value != 0 ||
                numericGreen.Value != 0
                )
                numericPink.Value = 0;
        }
       

        private void numericLoco_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericOrange_ValueChanged(object sender, EventArgs e)
        {
            if (
                numericBlack.Value != 0 ||
                numericPink.Value != 0 ||
                numericRed.Value != 0 ||
                numericBlue.Value != 0 ||
                numericWhite.Value != 0 ||
                numericYellow.Value != 0 ||
                numericGreen.Value != 0
                )
            {
                numericOrange.Value = 0;
                MessageBox.Show("Kromě lokomotiv můžeš vybrat karty jen jedné barvy. Nejprve odstraň karty jiné barvy a pak až naklikej jinou.", "Zvoleno více barev", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numericRed_ValueChanged(object sender, EventArgs e)
        {
            if (
                numericBlack.Value != 0 ||
                numericOrange.Value != 0 ||
                numericPink.Value != 0 ||
                numericBlue.Value != 0 ||
                numericWhite.Value != 0 ||
                numericYellow.Value != 0 ||
                numericGreen.Value != 0
                )
            {
                numericRed.Value = 0;
                MessageBox.Show("Kromě lokomotiv můžeš vybrat karty jen jedné barvy. Nejprve odstraň karty jiné barvy a pak až naklikej jinou.", "Zvoleno více barev", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        private void numericBlack_ValueChanged(object sender, EventArgs e)
        {
            if (
                numericPink.Value != 0 ||
                numericOrange.Value != 0 ||
                numericRed.Value != 0 ||
                numericBlue.Value != 0 ||
                numericWhite.Value != 0 ||
                numericYellow.Value != 0 ||
                numericGreen.Value != 0    
                )
            {
                numericBlack.Value = 0;
                MessageBox.Show("Kromě lokomotiv můžeš vybrat karty jen jedné barvy. Nejprve odstraň karty jiné barvy a pak až naklikej jinou.", "Zvoleno více barev", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numericGreen_ValueChanged(object sender, EventArgs e)
        {
            if (
                numericBlack.Value != 0 ||
                numericOrange.Value != 0 ||
                numericRed.Value != 0 ||
                numericBlue.Value != 0 ||
                numericWhite.Value != 0 ||
                numericYellow.Value != 0 ||
                numericPink.Value != 0
                )
            {
                numericGreen.Value = 0;
                MessageBox.Show("Kromě lokomotiv můžeš vybrat karty jen jedné barvy. Nejprve odstraň karty jiné barvy a pak až naklikej jinou.", "Zvoleno více barev", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numericWhite_ValueChanged(object sender, EventArgs e)
        {
            if (
                numericBlack.Value != 0 ||
                numericOrange.Value != 0 ||
                numericRed.Value != 0 ||
                numericBlue.Value != 0 ||
                numericPink.Value != 0 ||
                numericYellow.Value != 0 ||
                numericGreen.Value != 0
                )
            {
                numericWhite.Value = 0;
                MessageBox.Show("Kromě lokomotiv můžeš vybrat karty jen jedné barvy. Nejprve odstraň karty jiné barvy a pak až naklikej jinou.", "Zvoleno více barev", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void numericYellow_ValueChanged(object sender, EventArgs e)
        {
            if (
                numericBlack.Value != 0 ||
                numericOrange.Value != 0 ||
                numericRed.Value != 0 ||
                numericBlue.Value != 0 ||
                numericWhite.Value != 0 ||
                numericPink.Value != 0 ||
                numericGreen.Value != 0
                )
            { 
                numericYellow.Value = 0;
            MessageBox.Show("Kromě lokomotiv můžeš vybrat karty jen jedné barvy. Nejprve odstraň karty jiné barvy a pak až naklikej jinou.", "Zvoleno více barev", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        }

        private void numericBlue_ValueChanged(object sender, EventArgs e)
        {
            if (
                numericBlack.Value != 0 ||
                numericOrange.Value != 0 ||
                numericRed.Value != 0 ||
                numericPink.Value != 0 ||
                numericWhite.Value != 0 ||
                numericYellow.Value != 0 ||
                numericGreen.Value != 0
                )
            {
                numericBlue.Value = 0;
                MessageBox.Show("Kromě lokomotiv můžeš vybrat karty jen jedné barvy. Nejprve odstraň karty jiné barvy a pak až naklikej jinou.", "Zvoleno více barev", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
