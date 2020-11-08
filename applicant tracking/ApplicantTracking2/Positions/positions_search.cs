using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicantTracking2
{
    public partial class positions_search : Form
    {
        int ID = 0;

        SqlConnection con = new SqlConnection("Data Source=BG-5CG6205LSG\\SQLEXPRESS; Initial Catalog=HR; User Id=sa;Password=TI3bEiDtezJ85ryWszds;");
        public static string positionID;
        public static string positionName;
        public positions_search()
        {
            InitializeComponent();
        }


        public void positions_newPositions_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsPositions.POSITIONS' table. You can move, or remove it, as needed.
            this.pOSITIONSTableAdapter.Fill(this.dsPositions.POSITIONS);
           

            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from POSITIONS", con);

                //fill the DataTable with records from Table
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                //Loop through the DataTable
                //Add Item to ListView.
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["POSITION_ID"].ToString());
                    listitem.SubItems.Add(dr["POSITION_NAME"].ToString());
                    listView1.Items.Add(listitem);
                }

                listView1.View = View.Details;
                
                //DataSet ds = new DataSet();
                //SqlDataAdapter adapter = new SqlDataAdapter(
                //"SELECT * from SKILS", con);
                //adapter.Fill(ds);
                //this.listView1.DataSource = ds.Tables[0];
                //this.listBox.DisplayMember = "part_num";

            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //int SelectedIndices
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "positions_edit")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }
            if (isOpen == false)
            {
                //change public static string variables to the corresponding selected items in listview

                if(listView1.SelectedItems.Count > 0)
                {
                    var item = listView1.SelectedItems[0];
                    positionID = item.ToString();
                    positionName= item.SubItems[1].ToString();
                }
                else
                {
                    return;
                }

                
                //positionName = listView1.SelectedItems[1].ToString();
                //positionMinSkillPoints = listView1.SelectedItems[2].ToString();



                //open new Edit form
                positions_edit newpositions_edit = new positions_edit();
                newpositions_edit.MdiParent = this.MdiParent;
                newpositions_edit.Show();

                
                



            }

            //    //var tmpValue = listView1.Items[SelectedIndices].ToString();
            //    //MessageBox.Show(tmpValue);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var tostr = listView1.SelectedItems[0].SubItems[0];
            //MessageBox.Show(tostr);
        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
           txtSearch.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //txt_State.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtSearch.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (ID != 0)
            {
                
                SqlCommand cmd = new SqlCommand("update  POSITIONS  set POSITION_NAME = @POSITION_NAME where POSITION_ID=@ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@POSITION_NAME", txtSearch.Text.ToString());

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully!");
               position
                // DisplayData();
               // ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
    }
}
