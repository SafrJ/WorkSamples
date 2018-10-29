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

namespace TicketToRide
{
    public partial class GameForm : Form
    {
        private Game game;
        
        //Location Ratios
        private Dictionary<Control, double> XRatio = new Dictionary<Control, double>();
        private Dictionary<Control, double> YRatio = new Dictionary<Control, double>();
        //Size Ratios
        private Dictionary<Control, double> XSizeRatio = new Dictionary<Control, double>();
        private Dictionary<Control, double> YSizeRatio = new Dictionary<Control, double>();

        public GameForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size((int)(Screen.PrimaryScreen.WorkingArea.Width * 0.6), (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.75));

            panelMainMenu.Visible = true;
            panelGame.Visible = false;
            panelStartTasks.Visible = false;
            panelPoints.Visible = false;

            #region Nastaveni co cemu veli

            this.Controls.Add(panelGame);
            this.Controls.Add(panelMainMenu);
            this.Controls.Add(panelNextPlayer);
            this.Controls.Add(panelPoints);

            panelPoints.Controls.Add(tablePoints);
            panelPoints.Controls.Add(buttonMainMenu);

            panelNextPlayer.Controls.Add(btnNextPlayer);
            panelNextPlayer.Controls.Add(labelTxtNxtPlr);

            panelGame.Controls.Add(panelGameRight);
            panelGame.Controls.Add(panelGameBottom);
            panelGame.Controls.Add(panelGameCorner);
            panelGame.Controls.Add(pictureBoxMap);

            panelMainMenu.Controls.Add(btnSettings);
            panelMainMenu.Controls.Add(btnNewGame);

            panelGameRight.Controls.Add(pictureBoxUpper1);
            panelGameRight.Controls.Add(pictureBoxUpper2);
            panelGameRight.Controls.Add(pictureBoxUpper3);
            panelGameRight.Controls.Add(pictureBoxUpper4);
            panelGameRight.Controls.Add(pictureBoxUpper5);
            panelGameRight.Controls.Add(pictureBoxUpper6);

            #endregion

            #region Poloha tlacitek main menu
            btnNewGame.Left = ((panelMainMenu.Size.Width - btnNewGame.Size.Width) / 2);
            btnSettings.Left = btnNewGame.Left;
            btnNewGame.Top = (((panelMainMenu.Size.Height - btnNewGame.Size.Height) / 2) - btnNewGame.Size.Height);
            btnSettings.Top = btnNewGame.Top + btnNewGame.Size.Height + 30;
            #endregion

            foreach (Control thisControl in panelGame.Controls)
            {
                if (thisControl is PictureBox)
                {
                    
                    XRatio.Add(thisControl, Convert.ToDouble(thisControl.Left) / panelGame.Width);
                    YRatio.Add(thisControl, Convert.ToDouble(thisControl.Top) / panelGame.Height);
                    

                    XSizeRatio.Add(thisControl, Convert.ToDouble(thisControl.Width) / panelGame.Width);
                    YSizeRatio.Add(thisControl, Convert.ToDouble(thisControl.Height) / panelGame.Height);
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().Show();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@".\settings.txt"))
            {
                if( new SettingsForm().ShowDialog() == DialogResult.OK)
                {
                    panelMainMenu.Visible = false;
                    panelGame.Visible = true;
                    StartGame();
                }
            }
            else
            {
                Settings.LoadSettings();
                panelMainMenu.Visible = false;
                panelGame.Visible = true;
                StartGame();
            }
        }

        private void StartGame()
        {
            game = new Game(this);
            game.StartGame();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void GameForm_ResizeEnd(object sender, EventArgs e)
        {

            foreach (Control thisControl in panelGame.Controls)
            {
                if (thisControl is PictureBox)
                {
                    //*********************Re-Position the PictureBox********************
                    double localXRatio = 0;
                    double localYRatio = 0;
                    //Grab the Location Ratios for this particular PictureBox
                    localXRatio = XRatio.FirstOrDefault(ratio => ratio.Key == thisControl).Value;
                    localYRatio = YRatio.FirstOrDefault(ratio => ratio.Key == thisControl).Value;
                    //Calculate the new Location by using the ratios
                    int newX = Convert.ToInt32(panelGame.Width * localXRatio);
                    int newY = Convert.ToInt32(panelGame.Height * localYRatio);
                    //Set the new Location
                    thisControl.Location = new Point(newX, newY);
                    //*********************Re-Size the PictureBox********************
                    double localXSizeRatio = 0;
                    double localYSizeRatio = 0;
                    //Grab the Size Ratios for this particular PictureBox
                    localXSizeRatio = XSizeRatio.FirstOrDefault(ratio => ratio.Key == thisControl).Value;
                    localYSizeRatio = YSizeRatio.FirstOrDefault(ratio => ratio.Key == thisControl).Value;
                    //Calculate the new sizes by using the set ratio
                    int newWidth = Convert.ToInt32(panelGame.Width * localXSizeRatio);
                    int newHeight = Convert.ToInt32(panelGame.Height * localYSizeRatio);
                    //Set the new Size
                    thisControl.Width = newWidth;
                    thisControl.Height = newHeight;
                }
            }
        }

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {

        }

        public List<PictureBox> GetPictureBoxes()
        {
            List<PictureBox> boxes = new List<PictureBox>
            {
                pictureBoxMap,
                pictureBoxUpper1,
                pictureBoxUpper2,
                pictureBoxUpper3,
                pictureBoxUpper4,
                pictureBoxUpper5,
                pictureBoxUpper6,
                pictureBoxBottom1,
                pictureBoxBottom2,
                pictureBoxBottom3,
                pictureBoxBottom4,
                pictureBoxBottom5,
                pictureBoxBottom6,
                pictureBoxBottom7,
                pictureBoxBottom8,
                pictureBoxBottom9
            };
            return boxes;
        }

        public List<Label> GetBottomLabels()
        {
            List<Label> labels = new List<Label>
            {
                labelBlack,
                labelPink,
                labelWhite,
                labelBlue,
                labelYellow,
                labelOrange,
                labelGreen,
                labelLoco,
                labelRed,
            };
            return labels;
        }

        private void pictureBoxUpper1_Click(object sender, EventArgs e)
        {
            game.PlayerDrawsCard(0);
        }

        private void pictureBoxUpper2_Click(object sender, EventArgs e)
        {
            game.PlayerDrawsCard(1);
        }

        private void pictureBoxUpper3_Click(object sender, EventArgs e)
        {
            game.PlayerDrawsCard(2);
        }

        private void pictureBoxUpper4_Click(object sender, EventArgs e)
        {
            game.PlayerDrawsCard(3);
        }

        private void pictureBoxUpper6_Click(object sender, EventArgs e)
        {
            game.PlayerDrawsCardBlind();
        }

        private void pictureBoxUpper5_Click(object sender, EventArgs e)
        {
            game.PlayerDrawsCard(4);
        }

        private void pictureBoxUpper1_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pB = sender as PictureBox;
            pB.BorderStyle = BorderStyle.Fixed3D;

        }

        private void pictureBoxUpper1_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pB = sender as PictureBox;
            pB.BorderStyle = BorderStyle.FixedSingle;
        }

        public void SetPlayerStats(string name, int wagons, PlayerColor color)
        {
            labelPlayerName.Text = name;
            labelColor.Text = color.ToString();
            labelNumWagons.Text = wagons.ToString();
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            game.NextPlayer();
        }

        private void btnNextPlayer_Click(object sender, EventArgs e)
        {
            if (game.FirstRound())
            {
                panelStartTasks.Visible = true;
                panelNextPlayer.Visible = false;
                panelGame.Visible = false;
            }
            else
            {
                panelStartTasks.Visible = false;
                panelNextPlayer.Visible = false;
                panelGame.Visible = true;
            }
        }

        public void ShowPanelNextPlayer (string playerName)
        {
            panelGame.Visible = false;
            labelTxtNxtPlr.Text = "Na řadě je " + playerName;
            if (game.IsLastRound())
            {
                labelTxtNxtPlr.Text = "PROBÍHÁ POSLEDNÍ KOLO! - Na řadě je " + playerName;
            }
            panelNextPlayer.Visible = true;
            
        }

        private void panelNextPlayer_VisibleChanged(object sender, EventArgs e)
        {
            panelNextPlayer.Size = panelGame.Size;
            labelTxtNxtPlr.Top = ((panelNextPlayer.Size.Height - labelTxtNxtPlr.Size.Height) / 3);
            labelTxtNxtPlr.Left = ((panelNextPlayer.Size.Width / 2) - (labelTxtNxtPlr.Size.Width / 2 ));

            btnNextPlayer.Top = ((panelNextPlayer.Size.Height - btnNextPlayer.Size.Height) / 3) + 40;
            btnNextPlayer.Left = ((panelNextPlayer.Size.Width - btnNextPlayer.Size.Width) / 2);
        }

        private void btnActiveTasks_Click(object sender, EventArgs e)
        {
            new TasksForm(game.GetActivePlayer().GetTasks(), game).Show();
        }

        public void ShowPlayerStartingTask ()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;


            List<Task> tasksList = new List<Task>();

            foreach (ICard card in game.GetActivePlayer().GetTasks().GetCards())
            {
                tasksList.Add((Task)card);
            }

            labelCityFrom1.Text = tasksList[0].GetFrom().ToString();
            labelCityFrom2.Text = tasksList[1].GetFrom().ToString();
            labelCityFrom3.Text = tasksList[2].GetFrom().ToString();
            labelCityFrom4.Text = tasksList[3].GetFrom().ToString();

            labelCityTo1.Text = tasksList[0].GetTo().ToString();
            labelCityTo2.Text = tasksList[1].GetTo().ToString();
            labelCityTo3.Text = tasksList[2].GetTo().ToString();
            labelCityTo4.Text = tasksList[3].GetTo().ToString();

            labelPoints1.Text = tasksList[0].GetPoints().ToString();
            labelPoints2.Text = tasksList[1].GetPoints().ToString();
            labelPoints3.Text = tasksList[2].GetPoints().ToString();
            labelPoints4.Text = tasksList[3].GetPoints().ToString();
        }

        private void btnTasksAccept_Click(object sender, EventArgs e)
        {
            List<Task> tasksList = new List<Task>();
            foreach (ICard card in game.GetActivePlayer().GetTasks().GetCards())
            {
                tasksList.Add((Task)card);
            }

            int count = 0;
            if (checkBox1.Checked)
                count++;
            if (checkBox2.Checked)
                count++;
            if (checkBox3.Checked)
                count++;
            if (checkBox4.Checked)
                count++;

            if (count > 1)
            {
                if (!checkBox1.Checked)
                    game.GetActivePlayer().DiscardCard(tasksList[0]);
                if (!checkBox2.Checked)
                    game.GetActivePlayer().DiscardCard(tasksList[1]);
                if (!checkBox3.Checked)
                    game.GetActivePlayer().DiscardCard(tasksList[2]);
                if (!checkBox4.Checked)
                    game.GetActivePlayer().DiscardCard(tasksList[3]);

                game.NextPlayer();
                panelStartTasks.Visible = false;
            }
            else
            {
                MessageBox.Show("Nemáš vybraný dostatečný počet úkolů. Vyber alespoň 2", "Vyber více úkolů", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuildRail_Click(object sender, EventArgs e)
        {
            if (game.GetAP() == 2)
            {
                new BuildRailForm(game).Show();
            }
            else
            {
                MessageBox.Show("Tuto akci už nemůžeš provést, počkej do dalšího kola", "Cestu již nelze postavit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            if (game.GetAP() < 2)
            {
                MessageBox.Show("V tomto kole už nemůžeš lízat nové úkoly. Počkej do dalšího kola.", "Úkoly nelze líznout",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                new DrawTaskForm(game).Show();
            }
        }

        public void ShowPoints(int[,] points)
        {
            int i = points.GetLength(0);
            List<Player> players = game.GetPlayers();

            panelPoints.Visible = true;

            labelPlayer1.Text = players[0].GetName();
            labelPlayer2.Text = players[1].GetName();

            labelPointsRail1.Text = points[0, 0].ToString();
            labelPointsRail2.Text = points[1, 0].ToString();

            labelPointsTasks1.Text = points[0, 1].ToString();
            labelPointsTasks2.Text = points[1, 1].ToString();

            labelPointsLong1.Text = points[0, 2].ToString();
            labelPointsLong2.Text = points[1, 2].ToString();

            labelPointsSum1.Text = (points[0, 0] + points[0, 1] + points[0, 2]).ToString();
            labelPointsSum2.Text = (points[1, 0] + points[1, 1] + points[1, 2]).ToString();



            if (i > 2)
            {
                labelPointsRail3.Visible = true;
                labelPointsTasks3.Visible = true;
                labelPointsLong3.Visible = true;
                labelPointsSum3.Visible = true;
                labelPlayer3.Visible = true;

                labelPlayer3.Text = players[2].GetName();
                labelPointsRail3.Text = points[2, 0].ToString();
                labelPointsTasks3.Text = points[2, 1].ToString();
                labelPointsLong3.Text = points[2, 2].ToString();
                labelPointsSum3.Text = (points[2, 0] + points[2, 1] + points[2, 2]).ToString();
            }
            if (i > 3)
            {
                labelPointsRail4.Visible = true;
                labelPointsTasks4.Visible = true;
                labelPointsLong4.Visible = true;
                labelPointsSum4.Visible = true;
                labelPlayer4.Visible = true;

                labelPlayer4.Text = players[3].GetName();
                labelPointsRail4.Text = points[3, 0].ToString();
                labelPointsTasks4.Text = points[3, 1].ToString();
                labelPointsLong4.Text = points[3, 2].ToString();
                labelPointsSum4.Text = (points[3, 0] + points[3, 1] + points[3, 2]).ToString();
            }
            if (i > 4)
            {
                labelPointsRail5.Visible = true;
                labelPointsTasks5.Visible = true;
                labelPointsLong5.Visible = true;
                labelPointsSum5.Visible = true;
                labelPlayer5.Visible = true;

                labelPlayer5.Text = players[4].GetName();
                labelPointsRail5.Text = points[4, 0].ToString();
                labelPointsTasks5.Text = points[4, 1].ToString();
                labelPointsLong5.Text = points[4, 2].ToString();
                labelPointsSum5.Text = (points[4, 0] + points[4, 1] + points[4, 2]).ToString();
            }
        }

        private void buttonMainMenu_Click(object sender, EventArgs e)
        {
            panelGame.Visible = false;
            panelMainMenu.Visible = true;
            panelPoints.Visible = false;
            panelNextPlayer.Visible = false;
        }
    }
}
