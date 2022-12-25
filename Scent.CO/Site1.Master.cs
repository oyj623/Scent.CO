using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scent.CO
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                LoginButton.Visible = true;
                WelcomeText.Visible = false;
            }
            else
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8807SS9\SQLEXPRESS;Initial Catalog=PerfumeProducts;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("SELECT Username FROM Users WHERE UserID = @UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", (int)Session["UserID"]);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    WelcomeText.Text = "Welcome, " + reader["Username"].ToString();
                    WelcomeText.Visible = true;
                }
                else
                {
                    Response.Write("Unexpected user id in session");
                }
                LoginButton.Visible = false;
                conn.Close();
            }
            
        }

    }
}