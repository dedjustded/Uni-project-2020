using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicantTracking2
{
    public partial class homeScreen : Form
    {
        public homeScreen()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        // this form will open only once
        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                
                if (f.Name == "positions_search")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }

            }
            if(isOpen == false)
            {
                positions_search f2 = new positions_search();
                f2.MdiParent = this;
                f2.Show();
            }
            else
            {

            }

        }


        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var login = new Login();
            this.Close();
            login.Show();
        }

        private void newPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "positions_newPosition")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                positions_newPosition f2 = new positions_newPosition();
                f2.MdiParent = this;
                f2.Show();
            }

        }
    }
}
