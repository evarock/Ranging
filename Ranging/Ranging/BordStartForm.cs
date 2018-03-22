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
    public partial class BordStartForm : Form
    {
        public BordStartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<int, ArrayList> Alts = new Dictionary<int, ArrayList>();
            //передаётся число АЛЬТЕРНАТИВ и ЭКСПЕРТОВ
            BordInputForm f = new BordInputForm(Convert.ToInt32(numAlt.Value), Convert.ToInt32(numExp.Value), 0);            
            f.ShowDialog();
            this.Close();
        }
    }
}
