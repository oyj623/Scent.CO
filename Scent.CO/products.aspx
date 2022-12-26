<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="Scent.CO.products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/product.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="searchbox">
        <asp:TextBox ID="filterInput" runat="server" CssClass="search" ForeColor="Black" onKeyPress="javascript:filterProduct();"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Image/searchButton.png" OnClientClick="filterProduct(); return false;" CssClass="search-icon"/>
    </div>
    <div class="product-list">
        <asp:Repeater ID="ProductList" runat="server">
            <ItemTemplate>
                <div class="product">
                    <center>
                        <asp:CheckBox ID="TheCheckBox" runat="server" CssClass="checkbox-1"></asp:CheckBox>
                        <div class="details">
                            <img width="150" height="150" src="Image/<%#Eval("ImagePath") %>" alt="Perfume Image" id="img3"/>
                            <br /><br />
                            <h8><%# Eval("Name") %></h8>
                            <p style="font-family:'Cambria Math'; font-size: small;" class="text-justify">
                                <%# Eval("DescribeVolumeVariant") %> 
                                <br />
                                <%# Eval("DescribePriceVariant") %> 
                            </p>
                        </div>
                        <asp:DropDownList ID="SelectVolume" runat="server" Font-Names="Cambria Math" Font-Size="Small" CssClass="volume" >
                        </asp:DropDownList><br />
                    </center>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <center><asp:Button ID="ToCartButton" runat="server" Text="Add to cart" CssClass="add-to-cart" OnClick="ToCartButton_Click" /></center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" runat="server">
    <script>
        // TODO: check if any checked product, if no, display alert

        function filterProduct() {
            // Declare variables
            var input, filter;
            input = document.getElementById('<%=filterInput.ClientID%>');
            filter = input.value.toUpperCase();
            var products = document.getElementsByClassName('product');

            // Loop through all list items, and hide those who don't match the search query
            for (let i = 0; i < products.length; i++) {
                let productName = products[i].getElementsByTagName("h8")[0].innerText;
                if (productName.toUpperCase().includes(filter)) {
                    products[i].style.display = "";
                } else {
                    products[i].style.display = "none";
                }
            }
            return false;
        }
    </script>
</asp:Content>
