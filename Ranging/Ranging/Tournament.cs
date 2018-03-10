using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranging
{
    public class Tournament
    {
        public int Count { get; set; } //количество альтернатив
        public ArrayList Alternatives; //альт, удаляются по мере ранжирования (переход в RangAlt)
        public int[,] CompAlt { get; set; }  //экспертные сравнения альт между собой 
                                              //(0 - не было, 1 - лучше 1, 2 - лучше 2)
        public ArrayList RangAlt { get; set; } //альт в порядке ранжирования (ответ)
        public int Comparisons { get; set; } //количество сравнений для ранжирования

        public Tournament() { }
        public Tournament(int count)
        {
            this.Count = count;
            Alternatives = new ArrayList();
            RangAlt = new ArrayList();
            for (int i = 0; i < Count; i++)
            {
                Alternatives.Add(i); //порядковые номера с 0
            }
            CompAlt = new int[count, count]; //пустая таблица сравнений
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

        //выбор между двумя альт (результат - порядковый номер)
        private Object Choice(Object first, Object second)
        {
            int o1 = (int)first;
            int o2 = (int)second;
            int rating = CompAlt[o1, o2]; //значение из табл сравнений
            if (rating == 0)
            {
                //1) спросить у юзера, что лучше
                //2) занести в CompAlt[o1, o2] и CompAlt[o2, o1] 1 или 2
                Comparisons++; //было сравнение
                return first; //вернуть лучшую
            }
            else if (rating == 1)
            {
                return first;
            }
            else
            {
                return second;
            }
        }

    }
}
