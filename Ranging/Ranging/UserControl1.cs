using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranging
{
    public partial class UserControl1 : UserControl
    {
        Button first = null;
        Button second = null;

        public List<Button> buttons = new List<Button>();
        public List<ComboBox> combos = new List<ComboBox>();

        public UserControl1(int alt, int s)
        {
            InitializeComponent();

            BtnsToArray();
            CombosToArray();

            for (int i = 0; i < alt; i++)
            {
                buttons[i].Show();
            }

            for (int i = 0; i < alt - 1; i++)
            {
                combos[i].Show();
            }
        }

        private void InitAll()
        {
            BtnsToArray();
            CombosToArray();
        }

        //заполнить массив кнопок
        private void BtnsToArray()
        {
            alt1.Text = "1";
            alt2.Text = "2";
            alt3.Text = "3";
            alt4.Text = "4";
            alt5.Text = "5";
            alt6.Text = "6";
            alt7.Text = "7";
            alt8.Text = "8";
            alt9.Text = "9";
            alt10.Text = "10";


            buttons.Add(alt1);
            buttons.Add(alt2);
            buttons.Add(alt3);
            buttons.Add(alt4);
            buttons.Add(alt5);
            buttons.Add(alt6);
            buttons.Add(alt7);
            buttons.Add(alt8);
            buttons.Add(alt9);
            buttons.Add(alt10);
        }

        private void CombosToArray()
        {
            combos.Add(comboBox1);
            combos.Add(comboBox2);
            combos.Add(comboBox3);
            combos.Add(comboBox4);
            combos.Add(comboBox5);
            combos.Add(comboBox6);
            combos.Add(comboBox7);
            combos.Add(comboBox8);
            combos.Add(comboBox9);
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
            if ((first != null) & (second != null))
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
    }
}
