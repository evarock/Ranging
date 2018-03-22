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


        ////выбор между двумя альт (результат - порядковый номер)
        //private Object Choice(Object first, Object second)
        //{
        //    Object result = new object(); //для результата

        //    //получить номера альтернатив
        //    int o1 = (int)first;
        //    int o2 = (int)second;

        //    int rating = StatsArray.tourn.CompAlt[o1, o2]; //значение из таблицы сравнений

        //    //если значения ещё нет, то
        //    if (rating == 0)
        //    {
        //        //1) спросить у юзера, что лучше
        //        //2) занести в CompAlt[o1, o2] и CompAlt[o2, o1] 1 (если о1) или 2 (если о2)

        //        //если кнопку кликнули, то
        //        if (ButtonClicked != -1)
        //            if (ButtonClicked == o1) //если кликнули на первую, то занести данные, что первая лучше
        //            {
        //                StatsArray.tourn.CompAlt[o1, o2] = 1;
        //                StatsArray.tourn.CompAlt[o2, o1] = 1;
        //                result = first;
        //            }
        //            else //иначе занести в CompAlt, что лучше вторая
        //            {
        //                StatsArray.tourn.CompAlt[o1, o2] = 2;
        //                StatsArray.tourn.CompAlt[o2, o1] = 2;
        //                result = second;
        //            }

        //        StatsArray.tourn.Comparisons++; //было сравнение
        //        return first; //вернуть лучшую
        //    }
        //    else if (rating == 1) //если в CompAlt есть значение, то вернуть соответствующее 
        //    {
        //        result = first;
        //    }
        //    else
        //    {
        //        result = second;
        //    }

        //    return result;
        //}
    }
}
