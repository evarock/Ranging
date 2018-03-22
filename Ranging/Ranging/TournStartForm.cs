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
    public partial class TournStartForm : Form
    {
        public TournStartForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TournMain tm = new TournMain((int)nudAltern.Value);
            tm.ShowDialog(this);
            Close();
        }
    }
}
