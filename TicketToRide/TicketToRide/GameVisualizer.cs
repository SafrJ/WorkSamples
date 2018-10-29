using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TicketToRide
{
    class GameVisualizer
    {
        GameForm mainForm;
        Game game;
        List<PictureBox> pictureBoxes;
        List<Label> bottomLabels;

        public GameVisualizer(GameForm form, Game game)
        {
            this.mainForm = form;
            this.game = game;
            this.pictureBoxes = mainForm.GetPictureBoxes();
            this.bottomLabels = mainForm.GetBottomLabels();
        }

        public void UpdateTable()
        {
            Player player = game.GetActivePlayer();
            List<ICard> cardsOnTable = game.GetCardsOnTable();


            mainForm.SetPlayerStats(player.GetName(), player.GetWagonsCount(), player.GetPlayerColor());
            for (int i = 0; i < 5; i++)
            {
                if (cardsOnTable[i] != null)
                {
                    switch (cardsOnTable[i].GetCardColor())
                    {
                        case CardColor.All:
                            pictureBoxes[i + 1].Image = Properties.Resources.locoSmall2;
                            pictureBoxes[i + 1].Visible = true;
                            break;
                        case CardColor.Pink:
                            pictureBoxes[i + 1].Image = Properties.Resources.pinkSmall2;
                            pictureBoxes[i + 1].Visible = true;
                            break;
                        case CardColor.Orange:
                            pictureBoxes[i + 1].Image = Properties.Resources.orangeSmall2;
                            pictureBoxes[i + 1].Visible = true;
                            break;
                        case CardColor.Red:
                            pictureBoxes[i + 1].Image = Properties.Resources.redSmall2;
                            pictureBoxes[i + 1].Visible = true;
                            break;
                        case CardColor.Black:
                            pictureBoxes[i + 1].Image = Properties.Resources.blackSmall2;
                            pictureBoxes[i + 1].Visible = true;
                            break;
                        case CardColor.Green:
                            pictureBoxes[i + 1].Image = Properties.Resources.greenSmall2;
                            pictureBoxes[i + 1].Visible = true;
                            break;
                        case CardColor.White:
                            pictureBoxes[i + 1].Image = Properties.Resources.whiteSmall2;
                            pictureBoxes[i + 1].Visible = true;
                            break;
                        case CardColor.Yellow:
                            pictureBoxes[i + 1].Image = Properties.Resources.yellowSmall2;
                            pictureBoxes[i + 1].Visible = true;
                            break;
                        case CardColor.Blue:
                            pictureBoxes[i + 1].Image = Properties.Resources.blueSmall2;
                            pictureBoxes[i + 1].Visible = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                    pictureBoxes[i + 1].Visible = false;

            }

            bottomLabels[0].Text = player.GetCardCount(CardColor.Black).ToString();
            bottomLabels[1].Text = player.GetCardCount(CardColor.Pink).ToString();
            bottomLabels[2].Text = player.GetCardCount(CardColor.White).ToString();
            bottomLabels[3].Text = player.GetCardCount(CardColor.Blue).ToString();
            bottomLabels[4].Text = player.GetCardCount(CardColor.Yellow).ToString();
            bottomLabels[5].Text = player.GetCardCount(CardColor.Orange).ToString();
            bottomLabels[6].Text = player.GetCardCount(CardColor.Green).ToString();
            bottomLabels[7].Text = player.GetCardCount(CardColor.All).ToString();
            bottomLabels[8].Text = player.GetCardCount(CardColor.Red).ToString();

            DrawGameMap();
        }
        
        public void NextPlayer()
        {
            mainForm.ShowPanelNextPlayer(game.GetActivePlayer().GetName());
            UpdateTable();
        }

        public void DrawGameMap()
        {
            Bitmap bitMap = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            Graphics g = Graphics.FromImage(bitMap);
            

            foreach (Link link in game.GetGameMap().GetLinks())
            {
                Tuple<int, int> coordsFrom = link.GetFrom().GetCoords();
                Tuple<int, int> coordsTo = link.GetTo().GetCoords();

                switch (link.GetLinkType())
                {
                    case LinkType.Rail:
                        break;
                    case LinkType.Ship:
                        g.DrawLine(new Pen(Brushes.LightBlue, (bitMap.Width / 100)), new Point(((bitMap.Width / 100) * coordsFrom.Item1) + 10, ((bitMap.Height / 50) * coordsFrom.Item2) + 10), new Point(((bitMap.Width / 100) * coordsTo.Item1) + 10, ((bitMap.Height / 50) * coordsTo.Item2) + 10));
                        break;
                    case LinkType.Tunnel:
                        g.DrawLine(new Pen(Brushes.Black, (bitMap.Width / 100)), new Point(((bitMap.Width / 100) * coordsFrom.Item1) + 10, ((bitMap.Height / 50) * coordsFrom.Item2) + 10), new Point(((bitMap.Width / 100) * coordsTo.Item1) + 10, ((bitMap.Height / 50) * coordsTo.Item2) + 10));
                        break;
                    default:
                        break;
                }
            }
            foreach (Link link in game.GetGameMap().GetLinks())
            {
                    Tuple<int, int> coordsFrom = link.GetFrom().GetCoords();
                    Tuple<int, int> coordsTo = link.GetTo().GetCoords();
                    Point startPoint = new Point(((bitMap.Width / 100) * coordsFrom.Item1) + 10, ((bitMap.Height / 50) * coordsFrom.Item2) + 10);
                    Point endPoint = new Point(((bitMap.Width / 100) * coordsTo.Item1) + 10, ((bitMap.Height / 50) * coordsTo.Item2) + 10);

                if (link.GetPlayerColor() == 5)
                {
                    g.DrawLine(new Pen(link.GetBrushColor(), bitMap.Width / 200), startPoint, endPoint);
                }
                else
                {
                    g.DrawLine(new Pen(link.GetBrushColor(), bitMap.Width / 200), startPoint, endPoint);
                    g.DrawLine(new Pen(Brushes.DarkGray, bitMap.Width / 400), startPoint, endPoint);
                }
                    Point center = new Point(((startPoint.X + endPoint.X) / 2), ((endPoint.Y + startPoint.Y) / 2));
                    g.DrawString(link.GetLength().ToString(), new Font("Arial", 16), Brushes.OrangeRed, center);
            }

            foreach (City city in game.GetGameMap().GetCities())
            {
                Tuple<int, int> coords = city.GetCoords();
                g.FillEllipse(Brushes.Red, new Rectangle(new Point((bitMap.Width / 100) * coords.Item1, (bitMap.Height / 50) * coords.Item2), new Size((bitMap.Width / 100), (bitMap.Height / 50))));
                g.DrawEllipse(new Pen(Brushes.Black), new Rectangle(new Point((bitMap.Width / 100) * coords.Item1, (bitMap.Height / 50) * coords.Item2), new Size((bitMap.Width / 100), (bitMap.Height / 50))));
                g.DrawString(city.ToString(), new Font("Arial", 12), Brushes.Black, new Point(((bitMap.Width / 100) * coords.Item1) - 25, ((bitMap.Height / 50) * coords.Item2) - 20));
            }
            pictureBoxes[0].Image = bitMap;
            pictureBoxes[0].SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void ShowPoints(int[,] points)
        {
            mainForm.ShowPoints(points);
        }

        public void FirstTurn()
        {
            mainForm.ShowPlayerStartingTask();
            mainForm.ShowPanelNextPlayer(game.GetActivePlayer().GetName());
            UpdateTable();
        }
    }
}
