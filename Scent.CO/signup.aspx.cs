using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scent.CO
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String inputUsername = username.Text;
            String inputPassword = password.Text;
            String inputEmail = email.Text;
            String inputPhone = phone.Text;
            String inputState = state.Text;
            String inputPostcode = postcode.Text;
            String inputCity = city.Text;
            String inputAddress = unit.Text;

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8807SS9\SQLEXPRESS;Initial Catalog=PerfumeProducts;Integrated Security=True");
            SqlCommand cmd;
            conn.Open();

            // check if has existing username or email
            cmd = new SqlCommand("SELECT UserID FROM Users WHERE Username = @Username", conn);
            cmd.Parameters.AddWithValue("@Username", inputUsername);
            SqlDataReader duplicateUsernameReader = cmd.ExecuteReader();
            if (duplicateUsernameReader.Read())
            {
                Response.Write(@"<script>
                    alert('Username has been used');
                </script>");
                return;
            }
            duplicateUsernameReader.Close();
            cmd.Dispose();

            // Check duplicate email
            cmd = new SqlCommand("SELECT UserID FROM Users WHERE Email = @Email", conn);
            cmd.Parameters.AddWithValue("@Email", inputEmail);
            SqlDataReader duplicateEmailReader = cmd.ExecuteReader();
            if (duplicateEmailReader.Read())
            {
                Response.Write(@"<script>
                    alert('Email has been used');
                </script>");
                return;
            }
            duplicateEmailReader.Close();
            cmd.Dispose();

            // Insert new account into database
            cmd = new SqlCommand("INSERT INTO Users(Username, Password, Email, Phone) VALUES(@Username, @Password, @Email, @Phone)", conn);
            cmd.Parameters.AddWithValue("@Username", inputUsername);
            cmd.Parameters.AddWithValue("@Password", inputPassword);
            cmd.Parameters.AddWithValue("@Email", inputEmail);
            cmd.Parameters.AddWithValue("@Phone", inputPhone);
            SqlDataAdapter insertUserAdapter = new SqlDataAdapter();
            insertUserAdapter.InsertCommand = cmd;
            insertUserAdapter.InsertCommand.ExecuteNonQuery();
            cmd.Dispose();

            // Get user id
            cmd = new SqlCommand("SELECT UserID FROM Users WHERE Username = @Username AND Password = @Password", conn);
            cmd.Parameters.AddWithValue("@Username", inputUsername);
            cmd.Parameters.AddWithValue("@Password", inputPassword);
            SqlDataReader readUserID = cmd.ExecuteReader();
            if (readUserID.Read())
            {
                Session["UserID"] = readUserID.GetInt32(readUserID.GetOrdinal("UserID"));
            }
            readUserID.Close();
            cmd.Dispose();

            // Insert new address into database
            cmd = new SqlCommand("INSERT INTO Address(State, City, Postcode, Address, UserID, RecipientName, RecipientPhone) VALUES(@State, @City, @Postcode, @Address, @UserID, @RecipientName, @RecipientPhone)", conn);
            cmd.Parameters.AddWithValue("@State", inputState);
            cmd.Parameters.AddWithValue("@City", inputCity);
            cmd.Parameters.AddWithValue("@Postcode", inputPostcode);
            cmd.Parameters.AddWithValue("@Address", inputAddress);
            cmd.Parameters.AddWithValue("@UserID", (int) Session["UserID"]);
            cmd.Parameters.AddWithValue("@RecipientName", inputUsername);
            cmd.Parameters.AddWithValue("@RecipientPhone", inputPhone);
            SqlDataAdapter insertAddressAdapter = new SqlDataAdapter();
            insertAddressAdapter.InsertCommand = cmd;
            insertAddressAdapter.InsertCommand.ExecuteNonQuery();
            cmd.Dispose();

            conn.Close();

            //back to previous page
            if (Session["UserPreviousPage"] == null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                Response.Redirect((String)Session["UserPreviousPage"]);
            }
            
        }


    }
}