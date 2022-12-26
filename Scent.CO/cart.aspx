<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Scent.CO.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/cart.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="shopping-cart">
    <div class="title"> Shopping Cart </div>
    <asp:Repeater ID="CartItem" runat="server" OnItemCommand="CartItem_ItemCommand">
        <ItemTemplate>
            <div class="item">
                <div>
                    <asp:ImageButton ID="DeleteItemFromCart" runat="server" CommandName="DeleteItem" CommandArgument='<%# Eval("Name") %>' CssClass="btn-del" ImageUrl="~/Image/deleteButton.png"/>
                </div>
 
                <div class="image">
                    <img src="Image/<%# Eval("ImagePath")%>" alt="perfume image"/>
                </div>
 
                <div class="description">
                    <span><%# Eval("Name")  %></span>
                    <span><%# Eval("Volume")  %>mL</span>
                </div>
 
                <div class="quantity">
                    <button type="button" id="minusButton" onclick="modifyQuantity(<%#Container.ItemIndex %>, -1)">-</button>
                    <!--<div class="quantity-number" runat="server">1</div>-->
                    <asp:TextBox ID="QuantityInput" runat="server" CssClass="quantity-number" Text="1"></asp:TextBox>
                    
                    <!--<asp:Label ID="Quantity" runat="server" Text="1" CssClass="quantity-number"></asp:Label>
                    <asp:HiddenField ID="HiddenQuantity" runat="server" />-->
                    <button type="button" id="plusButton" onclick="modifyQuantity(<%#Container.ItemIndex %>, 1)">+</button>
                </div>
 
                <div class="total-price">RM<%# Eval("Price") %></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="checkout">
        <div class="total">
            <div>
                <div class="Subtotal">Sub-Total</div>
                <div class="items"><p class="cart-item-amount" id="cartItemAmount" runat="server">0</p> products</div>
            </div>
            <div class="total-amount" id="totalAmount">RM0</div>
        </div>
    </div>
</div>

<hr /> 

    

    <div class="add-box">
        <asp:Label ID="Label5" runat="server" Text="Choose Address" CssClass="topics"></asp:Label>
        <section>
            <asp:Repeater ID="AddressList" runat="server" OnItemCommand="Address_ItemCommand">
                <ItemTemplate>
                    <div class="address">
                        <asp:RadioButton ID="AddressSelect" runat="server" GroupName="address" Checked="False" CssClass="radio" OnClick="javascript:radioButtonSingleSelection(this.id)"/>
                        <label for="RadioButton1">
                        <center><h2>Default Address <%# Container.ItemIndex + 1 %></h2>
                        <asp:Label ID="RecipientName" runat="server" Text='<%# Eval("RecipientName") %>' CssClass="newaddr"></asp:Label><br />
                        <asp:Label ID="RecipientPhone" runat="server" Text='<%# Eval("RecipientPhone") %>' CssClass="newaddr"></asp:Label><br />
                        <asp:Label ID="State" runat="server" Text='<%# Eval("State") %>' CssClass="newaddr"></asp:Label><br />
                        <asp:Label ID="Postcode" runat="server" Text='<%# Eval("Postcode") %>' CssClass="newaddr"></asp:Label><br />
                        <asp:Label ID="City" runat="server" Text='<%# Eval("City") %>' CssClass="newaddr"></asp:Label><br />
                        <asp:Label ID="AddressDetails" runat="server" Text='<%# Eval("AddressDetails") %>' CssClass="newaddr"></asp:Label>
                        <div class="up-del">
                            <asp:Button ID="UpdateAddress" runat="server" Text="Update" CssClass="crud-btn" CommandName="UpdateAddress" CommandArgument="<%# Container.ItemIndex %>"/>
                            <asp:Button ID="DeleteAddress" runat="server" Text="Delete" CssClass="crud-btn" CommandName="DeleteAddress" CommandArgument="<%# Container.ItemIndex %>"/>
                        </div>
                        </center>
                        </label>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </section>

        <asp:Button ID="AddAddress" runat="server" Text="Add New Address" CssClass="new-btn" OnClick="AddAddress_Click"/>

        <hr /> 
    <div class="checkout">
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="payment">
                <asp:ListItem>Bank Transfer</asp:ListItem>
                <asp:ListItem>Credit or Debit Card</asp:ListItem>
                <asp:ListItem>COD</asp:ListItem>
            </asp:DropDownList>
        </div>

        <asp:Button ID="CheckoutButton" runat="server" Text="Checkout" CssClass="button" OnClick="CheckoutButton_Click"/>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" runat="server">
    <script>
        window.onload = function() {
            calculateTotalPrice();
        }

        function modifyQuantity(index, modify) {
            let QuantityInput = document.getElementsByClassName("quantity-number");

            if (isNaN(QuantityInput[index].value)) {
                alert("Quantity should be a number");
                return;
            }
            let currentQuantity = parseInt(QuantityInput[index].value);
            currentQuantity += modify;
            if (currentQuantity <= 0) {
                currentQuantity = 1;
                alert("Product quantity cannot be less than 1, please delete the product if you wish so");
            }
            QuantityInput[index].value = currentQuantity;
            calculateTotalPrice();
        }

        function calculateTotalPrice() {
            var QuantityInput = document.getElementsByClassName("quantity-number");
            var Prices = document.getElementsByClassName("total-price");
            var totalActualPrice = 0.0;
            for (let i = 0; i < QuantityInput.length; i++) {
                let thisQuantity = parseInt(QuantityInput[i].value);
                let thisPrice = parseFloat(Prices[i].innerText.substring(2));
                totalActualPrice += thisQuantity * thisPrice;
            }
            var TotalPrice = document.getElementById("totalAmount");
            TotalPrice.innerText = "RM" + totalActualPrice;
        }

        function radioButtonSingleSelection(thisID) {
            var radioButton = document.getElementById(thisID);
            var radioButtonList = document.getElementsByTagName("input");
            for (let i = 0; i < radioButtonList.length; i++) {
                if (radioButtonList[i].id != radioButton.id && radioButtonList[i].type == "radio") {
                    radioButtonList[i].checked = false;
                }
            }
        }
    </script>
</asp:Content>
