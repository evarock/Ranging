using System;
using System.Collections;
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
    public partial class BordInputForm : Form
    {
        Button first = null;
        Button second = null;

        int altern; //кол-во альтернатив
        int exp; //сколько всего экспертов
        int n; //номер нынешнего эксперта

        public List<Button> AllTheButtons = new List<Button>();

        public BordInputForm(int alt, int s, int num)
        {
            InitializeComponent();

            altern = alt;
            exp = s;
            n = num;

            this.Text = "Эксперт " + (n+1).ToString();

            BtnsToArray();

            for (int i = 0; i < alt+alt-1; i++)
            {
                AllTheButtons[i].Show();
            }

        }

        private void InitAll()
        {
            first = null;
            second = null;
            nullArrayButton();
        }

        //заполнить массив кнопок
        private void BtnsToArray()
        {
            AllTheButtons.Add(alt1);
            AllTheButtons.Add(btnSymb1);
            AllTheButtons.Add(alt2);
            AllTheButtons.Add(btnSymb2);
            AllTheButtons.Add(alt3);
            AllTheButtons.Add(btnSymb3);
            AllTheButtons.Add(alt4);
            AllTheButtons.Add(btnSymb4);
            AllTheButtons.Add(alt5);
            AllTheButtons.Add(btnSymb5);
            AllTheButtons.Add(alt6);
            AllTheButtons.Add(btnSymb6);
            AllTheButtons.Add(alt7);
            AllTheButtons.Add(btnSymb7);
            AllTheButtons.Add(alt8);
            AllTheButtons.Add(btnSymb8);
            AllTheButtons.Add(alt9);
            AllTheButtons.Add(btnSymb9);
            AllTheButtons.Add(alt10);
            AllTheButtons.Add(btnSymb10);


            nullArrayButton();
        }
        
        //обNULLить))) массив кнопок
        private void nullArrayButton()
        {
            int i = 1;
            foreach (Button b in AllTheButtons)
            {
                b.BackColor = Color.White;
                if (!(b.Text == "=") && !(b.Text == ">"))
                {
                    b.Text = i.ToString();
                    i++;
                }else
                {
                    b.Text = "=";
                }
            }

        }


        //взять кнопку в first или в second
        private void gotVal(ref Button b)
        {
            if (first == null)
            {
                first = b;
                b.BackColor = Color.PaleGreen;
            }
            else
            {
                if (first.Equals(b))
                {
                    b.BackColor = Color.White;
                    first = null;
                    btnChange.Enabled = false;
                }
                else
                {
                    if (second == null)
                    {
                        second = b;
                        b.BackColor = Color.AliceBlue;
                        btnChange.Enabled = true;
                    }
                    else
                    {
                        b.BackColor = Color.White;
                        second = null;
                        btnChange.Enabled = false;
                    }
                }
              
            }
        }

       
        //ивенты KNOPO4EK))))
        private void alt1_Click(object sender, EventArgs e)
        {
            gotVal(ref alt1);
            
        }

        private void alt2_Click(object sender, EventArgs e)
        {
            gotVal(ref alt2);
        }

        private void alt3_Click(object sender, EventArgs e)
        {
            gotVal(ref alt3);
        }

        private void alt4_Click(object sender, EventArgs e)
        {
            gotVal(ref alt4);
        }

        private void alt5_Click(object sender, EventArgs e)
        {
            gotVal(ref alt5);
        }

        private void alt6_Click(object sender, EventArgs e)
        {
            gotVal(ref alt6);
        }

        private void alt7_Click(object sender, EventArgs e)
        {
            gotVal(ref alt7);
        }

        private void alt8_Click(object sender, EventArgs e)
        {
            gotVal(ref alt8);
        }

        private void alt9_Click(object sender, EventArgs e)
        {
            gotVal(ref alt9);
        }

        private void alt10_Click(object sender, EventArgs e)
        {
            gotVal(ref alt10);
        }

        //поменять местами
        private void btnChange_Click(object sender, EventArgs e)
        {
            if((first != null) & (second != null)) 
            {
                string temp = first.Text;
                first.Text = second.Text;
                second.Text = temp;
                first.BackColor = Color.White;
                second.BackColor = Color.White;
                first = null;
                second = null;
                btnChange.Enabled = false;
            }

        }

        //сбросить всё нафиг
        private void button2_Click(object sender, EventArgs e)
        {
            InitAll();
        }

        private void changeButtonSymbol(ref Button b)
        {
            if (b.Text == "=")
            {
                b.Text = ">";
            }
            else
            {
                b.Text = "=";
            }
        }

        private void btnSymb1_Click(object sender, EventArgs e)
        {
            changeButtonSymbol(ref btnSymb1);
        }

        private void btnSymb2_Click(object sender, EventArgs e)
        {
            changeButtonSymbol(ref btnSymb2);
        }

        private void btnSymb3_Click(object sender, EventArgs e)
        {
            changeButtonSymbol(ref btnSymb3);
        }

        private void btnSymb4_Click(object sender, EventArgs e)
        {
            changeButtonSymbol(ref btnSymb4);
        }

        private void btnSymb5_Click(object sender, EventArgs e)
        {
            changeButtonSymbol(ref btnSymb5);
        }

        private void btnSymb6_Click(object sender, EventArgs e)
        {
            changeButtonSymbol(ref btnSymb6);
        }

        private void btnSymb7_Click(object sender, EventArgs e)
        {
            changeButtonSymbol(ref btnSymb7);
        }

        private void btnSymb8_Click(object sender, EventArgs e)
        {
            changeButtonSymbol(ref btnSymb8);
        }

        private void btnSymb9_Click(object sender, EventArgs e)
        {
            changeButtonSymbol(ref btnSymb9);
        }

        
        private int convertToMark(string s, int i)
        {
            int res = 0;

            if (i != (altern * 2-1))
            {
                if (s == ">")
                {
                    res = 1;
                }

                if (s == "=")
                {
                    res = 2;
                }
            }
            


            return res;
            
        }

        ////временный для проверки
        public string arrtostr(ArrayList ar)
        {
            string arrr = "";

            foreach (BordAlt ba in ar)
            {
                arrr = arrr + ba.Value.ToString() + " " + ba.Sign.ToString();
            }


            return arrr;
        }

        //ок!
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;

            ArrayList al = new ArrayList();
            while(i<altern*2)
            {
                al.Add(new BordAlt(Convert.ToInt32(AllTheButtons[i].Text), convertToMark(AllTheButtons[i+1].Text, i+1)));

                i += 2;
            }

            StatsArray.Alterns.Add(n,al); //добавить в Dictionary

            if (n < exp-1) //если это не последний эксперт...
            {
                BordInputForm f = new BordInputForm(altern, exp, n + 1); //создать новую форму, закрыть нынешнюю
                f.ShowDialog();
            }
            else
            {
                TotalForm tf = new TotalForm(altern, exp);
                tf.ShowDialog();
            }
            this.Close();
            //MessageBox.Show(arrtostr(al)); //проверка что всё норм
        }
    }
}
