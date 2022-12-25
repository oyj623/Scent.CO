using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scent.CO
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                if (Session["addressIDToBeUpdated"] == null)
                {
                    return;
                }
                title.InnerText = "Edit Address";
                int addressID = (int)Session["addressIDToBeUpdated"];
                conn = new SqlConnection(@"Data Source=DESKTOP-8807SS9\SQLEXPRESS;Initial Catalog=PerfumeProducts;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("SELECT RecipientName, RecipientPhone, State, Postcode, City, Address FROM Address WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", addressID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    name.Text = reader["RecipientName"].ToString();
                    phone.Text = reader["RecipientPhone"].ToString();
                    state.Text = reader["State"].ToString();
                    postcode.Text = reader.GetInt32(reader.GetOrdinal("Postcode")).ToString();
                    city.Text = reader["City"].ToString();
                    unit.Text = reader["Address"].ToString();
                }
                else
                {
                    Response.Write("Unexpected Address ID received");
                }
                conn.Close();
                AddressButton.Text = "Update and Choose";
            }
        }
        protected void AddressButton_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-8807SS9\SQLEXPRESS;Initial Catalog=PerfumeProducts;Integrated Security=True");

            // get info from client
            String newRecipientName = name.Text;
            String newRecipientPhone = phone.Text;
            String newState = state.Text;
            String newPostcode = postcode.Text;
            String newCity = city.Text;
            String newAddress = unit.Text;

            if (Session["addressIDToBeUpdated"] == null)
            {
                // add new address
                SqlCommand insertCommane = new SqlCommand("INSERT INTO Address OUTPUT INSERTED.ID VALUES (@State, @City, @Postcode, @Address, @UserID, @RecipientName, @RecipientPhone)", conn);
                insertCommane.Parameters.AddWithValue("@State", newState);
                insertCommane.Parameters.AddWithValue("@City", newCity);
                insertCommane.Parameters.AddWithValue("@Postcode", newPostcode);
                insertCommane.Parameters.AddWithValue("@Address", newAddress);
                insertCommane.Parameters.AddWithValue("@UserID", (int)Session["UserID"]);
                insertCommane.Parameters.AddWithValue("@RecipientName", newRecipientName);
                insertCommane.Parameters.AddWithValue("@RecipientPhone", newRecipientPhone);
                conn.Open();
                int newAddressID = Convert.ToInt32(insertCommane.ExecuteScalar());
                conn.Close();
                Session["DefaultAddressID"] = newAddressID;
            }
            else
            {
                int addressID = (int)Session["addressIDToBeUpdated"];
                SqlCommand cmd = new SqlCommand("UPDATE Address SET State = @State, City = @City, Postcode = @Postcode, Address = @Address, UserID = @UserID, RecipientName = @RecipientName, RecipientPhone = @RecipientPhone WHERE ID = @AddressID", conn);
                cmd.Parameters.AddWithValue("@State", newState);
                cmd.Parameters.AddWithValue("@City", newCity);
                cmd.Parameters.AddWithValue("@Postcode", newPostcode);
                cmd.Parameters.AddWithValue("@Address", newAddress);
                cmd.Parameters.AddWithValue("@UserID", (int)Session["UserID"]);
                cmd.Parameters.AddWithValue("@RecipientName", newRecipientName);
                cmd.Parameters.AddWithValue("@RecipientPhone", newRecipientPhone);
                cmd.Parameters.AddWithValue("@AddressID", addressID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Session["DefaultAddressID"] = addressID;
            }
            Response.Write("Address modified");
            if (Session["UserPreviousPage"] == null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                String newPage = (String)Session["UserPreviousPage"];
                Session["addressIDToBeUpdated"] = null;
                Response.Redirect(newPage);
            }
        }




    }
}