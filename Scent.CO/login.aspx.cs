using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scent.CO
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("signup.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String inputUsername = username.Text;
            String inputPassword = password.Text;
            conn = new SqlConnection(@"Data Source=DESKTOP-8807SS9\SQLEXPRESS;Initial Catalog=PerfumeProducts;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT UserID FROM Users WHERE Username = @Username AND Password = @Password", conn);
            cmd.Parameters.AddWithValue("@Username", inputUsername);
            cmd.Parameters.AddWithValue("@Password", inputPassword);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int userID = reader.GetInt32(reader.GetOrdinal("UserID"));
                conn.Close();
                Session["UserID"] = userID;
                if (Session["UserPreviousPage"] == null)
                {
                    Response.Redirect("home.aspx");
                    return;

                }
                Response.Redirect((String) Session["UserPreviousPage"]);
                return;
            }
            conn.Close();
            // matching username and password not found
            Response.Write("<script>alert('Wrong username or password');</script>");

        }
    }
}