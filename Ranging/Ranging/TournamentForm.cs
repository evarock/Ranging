using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranging
{    

    public partial class TournamentForm : Form
    {
        public int ButtonClicked;

        public TournamentForm(int first, int second)
        {
            InitializeComponent();
            ButtonClicked = -1;
            button1.Text = first.ToString();
            button2.Text = second.ToString();
        }

        //если выбрали 1 кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClicked = Convert.ToInt32(button1.Text); //запомнить номер альтернативы
            this.DialogResult = DialogResult.OK;
        }

        //если выбрали 2 кнопку
        private void button2_Click(object sender, EventArgs e)
        {
            ButtonClicked = Convert.ToInt32(button2.Text); //запомнить номер альтернативы
            this.DialogResult = DialogResult.OK;
        }
    }
}
