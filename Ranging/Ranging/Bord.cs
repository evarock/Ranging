using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranging
{
    public class Bord
    {
        public class altCompaper : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                BordAlt b1 = (BordAlt)x;
                BordAlt b2 = (BordAlt)y;
                if (b1.Grade <= b2.Grade)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }

        }

        public int Experts { get; set; }
        public int Count { get; set; } //количество альтернатив
        public Dictionary<int, ArrayList> Alternatives = new Dictionary<int,ArrayList>(); //ключ - n эксперта,
                                                                                  //значение - список его ранжирования
        public ArrayList RangAlt; //итоговое ранжирование

        public Bord() { }
        public Bord(int experts, int count)
        {
            this.Experts = experts;
            this.Count = count;  
            //!!!ввод с ui!!!
            for (int i = 0; i < Experts; i++)
            {
                ArrayList al = new ArrayList(Count);
                for (int j = 0; j < Count; j++)
                {
                    //!!ввод оценки альт юзером (больше, равна) = sign
                    int sign = 1; //например, больше
                    al.Add(new BordAlt(j, sign));                  
                }
                Alternatives.Add(i, al); //для каждого эксперта список его ранжирования
            }
            RangAlt = new ArrayList(Count); //итоговое ранжирование без знаков и оценок
            for (int i = 0; i < Count; i++)
            {
                RangAlt.Add(new BordAlt(i, 0));
            }
        }

        public ArrayList Do()
        {
            for (int i = 0; i < Experts; i++)
            {
                ArrayList al = new ArrayList();
                if (Alternatives.TryGetValue(i, out al)) //список этого эксперта
                {
                    al = Range(0, al);
                }
                Alternatives[i] = al;
                for (int j = 0; j < Count; j++) //накопление итоговых оценок
                {
                    BordAlt bh = (BordAlt)RangAlt[j];
                    BordAlt b = (BordAlt)al[j];
                    bh.Grade += b.Grade;
                    RangAlt[j] = bh;
                }
            }
            RangAlt.Sort(new altCompaper()); //итоговая сортировка альт
            return RangAlt;
        }

        private ArrayList Range(int k, ArrayList al)
        {
            while (k < al.Count)
            {
                BordAlt a = (BordAlt)al[k];
                if (a.Sign == 1 || a.Sign == 0)
                {
                    a.Grade = k + 1; //т.к. шкала оценки не с 0, а с 1                 
                    al[k] = a;
                    k++;
                }
                else
                {
                    bool eq = true;
                    int eqCount = 2; //два эквивалентных: k и k+1
                    int kk = k;
                    while (kk+1 < al.Count && eq)
                    {
                        BordAlt a2 = (BordAlt)al[kk+1];
                        if (a2.Sign == 2)
                        {
                            eqCount++; //найден ещё 1 эквивалентный
                        }
                        else
                        {
                            eq = false; //больше нет эквивалентных
                        }
                        kk++;
                    }
                    int sum = 0;
                    for (int i = k; i <= kk; i++)
                    {
                        sum = sum + i + 1; //т.к. шкала оценки не с 0, а с 1 
                    }
                    for (int i = k; i <= kk; i++)
                    {
                        BordAlt aa = (BordAlt)al[i];
                        aa.Grade = sum/(double)eqCount;
                        al[i] = aa;
                    }
                    k = kk + 1;
                }
            }
            return al;
        }
    }
}
