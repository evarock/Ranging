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

namespace Ranging
{
    public partial class TotalForm : Form
    {
        public TotalForm(int alt, int s)
        {
            InitializeComponent();

            Bord b = new Bord();
            b.Alternatives = StatsArray.Alterns;
            b.Count = alt;
            b.Experts = s;

            b.Do();

            resultTB.Text = arrtostrRangeAlt(b.RangAlt);

            for(int i = 0; i < alt; i++)
            {
                
                dataGridView1.Columns.Add("", "");
                dataGridView1.Columns[i+1].HeaderCell.Value = "a" + (i+1).ToString();
                DataGridViewColumn column = dataGridView1.Columns[i+1];
                column.Width = 40;
            }

            for (int i = 0; i < s; i++)
            {
                dataGridView1.Rows.Add("", "");
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();

                for (int j = 0; j < alt; j++)
                {                    
                    dataGridView1[0, i].Value = arrtostr(b.Alternatives[i]);
                    dataGridView1[j+1, i].Value = GetGrade(b.Alternatives[i], j);                    
                }

            }

            dataGridView1.Rows.Add("", "");
            dataGridView1[0, s].Value = arrtostrRangeAlt(b.RangAlt);
            dataGridView1.Rows[s].HeaderCell.Value = "~";
            for (int j = 1; j < alt+1; j++)
            {
                dataGridView1[j, s].Value = GetGrade(b.RangAlt, j - 1);
            }
                
        }

        public string arrtostr(ArrayList ar)
        {
            string arrr = "";

            foreach (BordAlt ba in ar)
            {
                arrr = arrr +"a" +(ba.Value).ToString()+" "+MarkToStr(ba.Sign)+" ";
            }

            return arrr;
        }

        public string arrtostrRangeAlt(ArrayList ar)
        {
            string arrr = "";

            foreach (BordAlt ba in ar)
            {
                arrr = arrr + "a" + (ba.Value+1).ToString() + " " + MarkToStr(ba.Sign) + " ";
            }

            return arrr;
        }

        public string GetGrade(ArrayList a, int i)
        {
            string res = "";

            BordAlt ba = (BordAlt)a[i];
            res = ba.Grade.ToString();
            return res;
        }

        public string arrtostrNoMark(ArrayList ar)
        {
            string arrr = "";

            foreach (BordAlt ba in ar)
            {
                arrr = arrr + (ba.Value + 1).ToString() + " ";
            }

            return arrr;
        }

        //1 больше, 2 равно, 0 конец
        public string MarkToStr(int i)
        {
            string res = "";

            if (i == 2)
            {
                res = "=";
            }

            if (i == 1)
            {
                res = ">";
            }

            return res;
        }

    }
}