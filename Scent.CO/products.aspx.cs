using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scent.CO
{
    public partial class products : System.Web.UI.Page
    {
        private SqlConnection conn;
        public List<Product> allProductList;
        public List<Product> displayingProductList;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-8807SS9\SQLEXPRESS;Initial Catalog=PerfumeProducts;Integrated Security=True");
            allProductList = new List<Product>();
            displayingProductList = new List<Product>();

            string selectQuery = "SELECT Image, Name, Volume, Description, Price, Quantity FROM Perfume";
            conn.Open();
            SqlCommand cmd = new SqlCommand(selectQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String image = reader["Image"].ToString();
                String name = reader["Name"].ToString();
                int vol = reader.GetInt32(reader.GetOrdinal("Volume"));
                String desc = reader["Description"].ToString();
                float price = (float)reader.GetDouble(reader.GetOrdinal("Price"));
                int qty = reader.GetInt32(reader.GetOrdinal("Quantity"));
                allProductList.Add(new Product(image, name, vol, desc, price, qty));
            }
            conn.Close();

            // Concatenate product with same name but different volume
            foreach (Product eachProduct in allProductList) 
            {
                if (displayingProductList.Count == 0)
                {
                    displayingProductList.Add(eachProduct);
                    displayingProductList[0].addVariant(eachProduct.Volume, eachProduct.Price);
                } 
                else
                {
                    for (int i = 0; i < displayingProductList.Count; i++)
                    {
                        if (displayingProductList[i].Name == eachProduct.Name)
                        {
                            displayingProductList[i].addVariant(eachProduct.Volume, eachProduct.Price);
                            break;
                        }
                        if (i == displayingProductList.Count - 1)
                        {
                            displayingProductList.Add(eachProduct);
                        }
                    }
                }
                
            }
            if (!IsPostBack) 
            { 
                ProductList.DataSource = displayingProductList;
                ProductList.DataBind(); 
            }
            

            // Set volume for drop down list for each displaying product
            for (int i = 0; i < ProductList.Items.Count; i++)
            {
                DropDownList ddl = (DropDownList) ProductList.Items[i].FindControl("SelectVolume");
                if (ddl != null)
                {
                    for(int j = 0; j < displayingProductList[i].VolumeVariant.Count; j++)
                    {
                        String volumeToAdd = displayingProductList[i].VolumeVariant[j].ToString() + "mL";
                        ddl.Items.Add(new ListItem(volumeToAdd, volumeToAdd));
                    }
                }
            }
        }

        protected void ToCartButton_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < displayingProductList.Count; i++)
            {
                RepeaterItem productItem = ProductList.Items[i];
                CheckBox productCheck = (CheckBox)productItem.FindControl("TheCheckBox");
                if (!productCheck.Checked)
                {
                    continue;
                }
                // Get product name and volume from client side
                String productNameString = displayingProductList[i].Name;
                DropDownList productVolume = (DropDownList)productItem.FindControl("SelectVolume");
                String productVolumeString = (String) productVolume.SelectedValue;
                productVolumeString = productVolumeString.Substring(0, productVolumeString.Length - 2);
                int productVolumeInt = Convert.ToInt32(productVolumeString);
                
                // Query product id from database with matching product anem and volume
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT ProductID FROM Perfume WHERE Name = @Name AND Volume = @Volume", conn);
                cmd.Parameters.AddWithValue("@Name", productNameString);
                cmd.Parameters.AddWithValue("@Volume", productVolumeInt);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    Response.Write($"Product not found: {productNameString} with volume = {productVolumeString}");
                    continue;
                }
                int productID = reader.GetInt32(reader.GetOrdinal("ProductID"));
                conn.Close();
                // Add product id into session
                if (Session["Cart"] == null)
                {
                    List<int> currentCart = new List<int> { productID };
                    Session["Cart"] = currentCart;
                }
                else
                {
                    List<int> currentCart = (List<int>)Session["Cart"];
                    currentCart.Add(productID);
                    Session["Cart"] = currentCart;
                }


            } //  end for loop for repeater item
            if (Session["UserID"] == null)
            {
                Session["UserPreviousPage"] = "cart.aspx";
                Response.Redirect("login.aspx");
                return;
            }
            Response.Redirect("cart.aspx");
        }


    }
}