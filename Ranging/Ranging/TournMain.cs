﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//я перенесла сюда всё содержимое класса Tournament, потому что так проще и лучше

namespace Ranging
{
    public partial class TournMain : Form
    {
        public int Count { get; set; } //количество альтернатив

        public ArrayList Alternatives; //альт, удаляются по мере ранжирования (переход в RangAlt)

        public int[,] CompAlt { get; set; }  //экспертные сравнения альт между собой 
                                             //(0 - не было, 1 - лучше 1, 2 - лучше 2)

        public ArrayList RangAlt { get; set; } //альт в порядке ранжирования (ответ)

        public int Comparisons { get; set; } //количество сравнений для ранжирования

        //инициализация Tournament теперь инициализация этой формы
        public TournMain(int count)
        {
            InitializeComponent();

            Count = count;
            Alternatives = new ArrayList();
            RangAlt = new ArrayList();
            for (int i = 0; i < Count; i++)
            {
                Alternatives.Add(i); //порядковые номера с 0
            }
            CompAlt = new int[Count, Count]; //пустая таблица сравнений


            //действия
            ArrayList result = Do();

            int comp = Comparisons;

            //просто проверка что всё работает
            label1.Text = ArrToStr();
            label2.Text = comp.ToString();

        }



        //выбор лучшей альт из оставшихся
        private Object BestAlt(ArrayList alts)
        {
            ArrayList helpArr = new ArrayList();
            int pair = alts.Count / 2;
            for (int i = 0; i <= pair; i += 2)
            {
                Object best = Choice(alts[i], alts[i + 1]);
                helpArr.Add(best);
            }
            //непарная альт всегда проходит дальше
            if (alts.Count % 2 != 0)
            {
                helpArr.Add(alts[alts.Count - 1]);
            }
            if (helpArr.Count == 1) //осталась лучшая альт
            {
                return helpArr[0];
            }
            else
            {
                return BestAlt(helpArr); //искать лучшую из сокращённого списка
            }
        }

        public ArrayList Do()
        {
            while (Count > 1)
            {
                Object o = BestAlt(Alternatives);
                Alternatives.Remove(o);
                RangAlt.Add(o);
                --Count;
            }
            RangAlt.Add(Alternatives[0]); //добавление последнего
            Alternatives.Clear();
            return RangAlt;
        }


        //выбор между двумя альт (результат - порядковый номер)
        private Object Choice(Object first, Object second)
        {
            Object result = new object(); //для результата

            //получить номера альтернатив
            int o1 = (int)first;
            int o2 = (int)second;

            int rating = CompAlt[o1, o2]; //значение из таблицы сравнений

            //если значения ещё нет, то
            if (rating == 0)
            {
                //1) спросить у юзера, что лучше
                //2) занести в CompAlt[o1, o2] и CompAlt[o2, o1] 1 (если о1) или 2 (если о2)
                

                // !!!!  1) У ЮЗЕРА СПРАШИВАЮТ КТО ЛУЧШЕ

                //создаётся форма сравнения
                TournamentForm tf = new TournamentForm(o1, o2);

                //показывается диалог, где пользователь щёлкает на нужное
                if(tf.ShowDialog() == DialogResult.OK)
                {

                    //заносится в массив
                    if(tf.ButtonClicked != -1)
                    {
                        if (tf.ButtonClicked == o1) //если кликнули на первую, то занести данные, что первая лучше
                        {
                            CompAlt[o1, o2] = 1;
                            CompAlt[o2, o1] = 1;
                            result = first;
                        }
                        else //иначе занести в CompAlt, что лучше вторая
                        {
                            CompAlt[o1, o2] = 2;
                            CompAlt[o2, o1] = 2;
                            result = second;
                        }
                    }

                    Comparisons++; //было сравнение
                }
                return first; //вернуть лучшую
            }
            else if (rating == 1) //если в CompAlt есть значение, то вернуть соответствующее 
            {
                result = first;
            }
            else
            {
                result = second;
            }

            return result;
        }

        private void TournMain_Load(object sender, EventArgs e)
        {

        }

        public string ArrToStr()
        {
            string arrr = "";

            for (int i = 0; i<Count; i++)
            {
                arrr = arrr + RangAlt[i].ToString();
            }

            return arrr;
        }


    }

}