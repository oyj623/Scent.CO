using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Scent.CO
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PurchaseSuccessful"] != null)
            {
                Response.Write(@"<script>
                    alert('Purchase Successful');
                </script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.dior.com/en_my");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.ysl.com/en-my");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.chanel.com/");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.gucci.com/us/en/");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://eu.louisvuitton.com/eng-e1/homepage");
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.bulgari.com/en-int/");
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.jomalone.com.my/");
        }
    }
}