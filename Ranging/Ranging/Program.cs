﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ranging
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());

            //Tournament t = new Tournament(5);
            //ArrayList result = t.Do();
            //int comp = t.Comparisons; //сравнений

            //Bord b = new Bord(2, 3);
            //b.Do();
        }
    }
}
