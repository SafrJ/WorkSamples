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
    partial class TasksForm : Form
    {
        CardPile tasks;
        Game game;
        int index;
        int number;

        public TasksForm(CardPile tasks, Game game)
        {
            InitializeComponent();
            this.tasks = tasks;
            this.index = 0;
            this.number = tasks.GetCount();
            this.game = game;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index++;
            index = index % number;
            UpdateLabels();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            index = index + (number-1);
            index = index % number;
            UpdateLabels();

        }

        private void TasksForm_Load(object sender, EventArgs e)
        {
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            Task task = (Task)(tasks.GetCards()[index]);
            labelTo.Text = task.GetTo().ToString();
            labelFrom.Text = task.GetFrom().ToString();
            labelPoints.Text = task.GetPoints().ToString();

            if (game.IsConected(task.GetFrom(), task.GetTo(), game.GetActivePlayer().GetPlayerColor()))
                labelComp.Text = "ANO";
            else
                labelComp.Text = "NE";
        }
    }

}
