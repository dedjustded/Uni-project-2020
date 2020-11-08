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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //Login button
        private void button2_Click(object sender, EventArgs e)
        {
            if (usernameTextbox.Text == "" || passwordTextbox.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");




                return;
            }
            else
            {


                SqlConnection con = new SqlConnection("Data Source=BG-5CG6205LSG\\SQLEXPRESS; Initial Catalog=HR; User Id=sa;Password=TI3bEiDtezJ85ryWszds;");


                try
                {
                    con.Open();


                    string qry1 = "Select * from Login where Password=@Password and Username=@Username";
                    SqlCommand com = new SqlCommand(qry1, con);
                    com.Parameters.AddWithValue("@Username", this.usernameTextbox.Text);
                    com.Parameters.AddWithValue("@Password", this.passwordTextbox.Text);
                    SqlDataReader dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr.HasRows == true)
                        {
                            var home = new homeScreen();
                            this.Hide();
                            home.Show();

                            //  MessageBox.Show("Login Successfull", "Login Information");
                        }
                    }
                    if (dr.HasRows == false)
                    {

                        MessageBox.Show("Access Denied", "Login Information");
                        passwordTextbox.Clear();
                        //this.Close();

                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Error with the databse connection");
                }
                finally {
                    con.Close();
                }
              
                
            }
        
                   
            
        }

        //Sets Login to the default button
        private void SetDefault(Button myDefaultBtn)
        {
            this.AcceptButton = button2;
        }

        //Exit button
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
