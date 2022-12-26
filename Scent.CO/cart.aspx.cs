using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scent.CO
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection conn;
        List<int> productIndices;
        List<Product> cartProducts;
        List<Address> addresses;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //  If no this, will result in error
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("login.aspx");
                }
                Initialize();
                CartItem.DataSource = cartProducts;
                CartItem.DataBind();
                AddressList.DataSource = addresses;
                AddressList.DataBind();
                int indexToBeChecked = 0;
                if (Session["DefaultAddressID"] != null)
                {
                    int addressIDToBeChecked = (int)Session["DefaultAddressID"];
                    for(int i = 0; i < addresses.Count; i++)
                    {
                        if(addressIDToBeChecked == addresses[i].ID)
                        {
                            indexToBeChecked = i;
                            break;
                        }
                    }
                }
                if (AddressList.Items.Count > 0)
                {
                    RadioButton thisRadio = (RadioButton)AddressList.Items[indexToBeChecked].FindControl("AddressSelect");
                    thisRadio.Checked = true;
                }
                
            }
        }

        protected void CartItem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeleteItem")
            {
                // Reinitialize
                Initialize();

                // Start deleting
                String productToBeDeleted = e.CommandArgument.ToString();
                int productIndex = -1;
                for(int i = 0; i < cartProducts.Count; i++)
                {
                    if (productToBeDeleted.Equals(cartProducts[i].Name))
                    {
                        productIndex = i;
                        break;
                    }
                }
                List<int> temp = (List<int>)Session["Cart"];
                temp.RemoveAt(productIndex);
                Session["Cart"] = temp;
                cartProducts.RemoveAt(productIndex);
                CartItem.DataSource = cartProducts;
                CartItem.DataBind();
                cartItemAmount.InnerText = cartProducts.Count.ToString();
            }
        }

        protected void Address_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Initialize();

            if (e.CommandName == "UpdateAddress")
            {
                String index = e.CommandArgument.ToString();
                int addressIndexToBeUpdated = Convert.ToInt32(index);
                int addressIDToBeUpdated = addresses[addressIndexToBeUpdated].ID;
                Session["addressIDToBeUpdated"] = addressIDToBeUpdated;
                Session["UserPreviousPage"] = "cart.aspx";
                Response.Redirect("address.aspx");
            }
            else if (e.CommandName == "DeleteAddress")
            {
                String index = e.CommandArgument.ToString();
                int addressIndexToBeDeleted = Convert.ToInt32(index);
                int addressIDToBeDeleted = addresses[addressIndexToBeDeleted].ID;
                SqlCommand deleteCommand = new SqlCommand("DELETE Address WHERE ID = @AddressID", conn);
                deleteCommand.Parameters.AddWithValue("@AddressID", addressIDToBeDeleted);
                conn.Open();
                deleteCommand.ExecuteNonQuery();
                conn.Close();
                addresses.RemoveAt(addressIndexToBeDeleted);
            }
            Initialize();
            AddressList.DataSource = addresses;
            AddressList.DataBind();
            int indexToBeChecked = 0;
            if (Session["DefaultAddressID"] != null)
            {
                int addressIDToBeChecked = (int)Session["DefaultAddressID"];
                for (int i = 0; i < addresses.Count; i++)
                {
                    if (addressIDToBeChecked == addresses[i].ID)
                    {
                        indexToBeChecked = i;
                        break;
                    }
                }
            }
            if (AddressList.Items.Count > 0)
            {
                RadioButton thisRadio = (RadioButton)AddressList.Items[indexToBeChecked].FindControl("AddressSelect");
                thisRadio.Checked = true;
            }
        }
        protected void AddAddress_Click(object source, EventArgs e)
        {
            Session["UserPreviousPage"] = "cart.aspx";
            Response.Redirect("address.aspx");

        }

        protected void CheckoutButton_Click(object source, EventArgs e)
        {
            Initialize();
            int currentTransactionID = CreateTransaction();
            float totalPrice = 0.0f;
            for (int i = 0; i < cartProducts.Count;i++)
            {
                // get quantity
                RepeaterItem cartItem = CartItem.Items[i];
                TextBox quantityTB = (TextBox)cartItem.FindControl("QuantityInput");
                int quantity = Convert.ToInt32(quantityTB.Text);
                totalPrice += quantity * cartProducts[i].Price;
                // create order
                SqlCommand cmd = new SqlCommand("INSERT INTO [Order] (ProductID, Quantity, TransactionID) VALUES(@ProductID, @Quantity, @TransactionID)", conn);
                cmd.Parameters.AddWithValue("@ProductID", productIndices[i]);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@TransactionID", currentTransactionID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            int selectedAddressIndex = -1;
            for (int i = 0; i < AddressList.Items.Count; i++)
            {
                RadioButton thisRadioButton = (RadioButton)AddressList.Items[i].FindControl("AddressSelect");
                if (thisRadioButton.Checked)
                {
                    selectedAddressIndex = i;
                    break;
                }
            }
            int selectedAddressID = addresses[selectedAddressIndex].ID;
            UpdateTransaction(selectedAddressID, totalPrice, currentTransactionID);

            Session["Cart"] = null;
            if (productIndices != null)
            {
                productIndices.Clear();
            }
            cartProducts.Clear();
            Session["PurchaseSuccessful"] = "PurchaseSuccessful";
            Response.Redirect("home.aspx");
        }
        private int CreateTransaction()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [Transaction] OUTPUT INSERTED.TransactionID VALUES(NULL, @UserID, NULL)", conn);
            cmd.Parameters.AddWithValue("@UserID", (int)Session["UserID"]);
            conn.Open(); 
            int tID = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();

            return tID;
        }
        private void UpdateTransaction(int addressID, float price, int tID)
        {
            SqlCommand cmd = new SqlCommand("UPDATE [Transaction] SET TotalPrice = @Price, AddressID = @AddressID WHERE TransactionID = @TransactionID", conn);
            cmd.Parameters.AddWithValue("@AddressID", addressID);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@TransactionID", tID);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void Initialize()
        {
            productIndices = (List<int>)Session["Cart"];
            cartProducts = new List<Product>();
            addresses = new List<Address>();
            conn = new SqlConnection(@"Data Source=DESKTOP-8807SS9\SQLEXPRESS;Initial Catalog=PerfumeProducts;Integrated Security=True");

            // initialize cart item
            if (productIndices != null)
            {
                foreach (int i in productIndices)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Perfume WHERE ProductID = @ProductID", conn);
                    cmd.Parameters.AddWithValue("@ProductID", i);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            String image = reader["Image"].ToString();
                            String name = reader["Name"].ToString();
                            int vol = reader.GetInt32(reader.GetOrdinal("Volume"));
                            String desc = reader["Description"].ToString();
                            float price = (float)reader.GetDouble(reader.GetOrdinal("Price"));
                            int qty = reader.GetInt32(reader.GetOrdinal("Quantity"));
                            cartProducts.Add(new Product(image, name, vol, desc, price, qty));
                        }
                    }
                    cmd.Dispose();
                    conn.Close();

                }
            }

            // initialize address
            SqlCommand addressCmd = new SqlCommand("SELECT ID, State, City, Postcode, Address, RecipientName, RecipientPhone FROM Address WHERE UserID = @UserID", conn);
            addressCmd.Parameters.AddWithValue("@UserID", (int)Session["UserID"]);
            conn.Open();
            SqlDataReader addressReader = addressCmd.ExecuteReader();
            while(addressReader.Read())
            {
                int addressID = addressReader.GetInt32(addressReader.GetOrdinal("ID"));
                String state = addressReader["State"].ToString();
                String city = addressReader["City"].ToString();
                int postcode = addressReader.GetInt32(addressReader.GetOrdinal("Postcode"));
                String addressDetails = addressReader["Address"].ToString();
                String recipientName = addressReader["RecipientName"].ToString();
                String recipientPhone = addressReader["RecipientPhone"].ToString();
                addresses.Add(new Address(addressID, state, city, postcode, addressDetails, recipientName, recipientPhone));
            }
            conn.Close();

            cartItemAmount.InnerText = cartProducts.Count.ToString();

        }



    }
}