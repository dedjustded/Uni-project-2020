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
    public partial class positions_edit : Form
    {
        public positions_edit()
        {
            InitializeComponent();
        }


        public void positions_edit_Load(object sender, EventArgs e)
        {
            try
            {
                positions_search positions_search = new positions_search();
                //positions_search.positionID = textBox1.Text;
                //MessageBox.Show(positions_search.positionID);
                textBox1.Text = positions_search.positionID;
                textBox3.Text = positions_search.positionName;
            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }
                
        }
        

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
