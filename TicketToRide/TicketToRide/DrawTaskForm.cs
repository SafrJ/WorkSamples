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
    partial class DrawTaskForm : Form
    {
        Task taskOne;
        Task taskTwo;
        Task taskThree;
        Game game;

        public DrawTaskForm(Game game)
        {
            this.game = game;
            InitializeComponent();
            taskOne = game.DrawTask();
            taskTwo = game.DrawTask();
            taskThree = game.DrawTask();
            this.ControlBox = false;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                game.GetActivePlayer().GiveCard(taskOne);
            }
            if (checkBox2.Checked)
            {
                game.GetActivePlayer().GiveCard(taskTwo);
            }
            if (checkBox3.Checked)
            {
                game.GetActivePlayer().GiveCard(taskThree);
            }

            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
            {
                MessageBox.Show("Musíš si líznout alespoň jeden úkol", "Zvoleno málo úkolů", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Close();
            }

        }

        private void DrawTaskForm_Load(object sender, EventArgs e)
        {
            label1.Text = taskOne.ToString();
            label2.Text = taskTwo.ToString();
            label3.Text = taskThree.ToString();
        }
    }
}
