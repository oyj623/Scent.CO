<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Scent.CO.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href ="css/signup.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Sign Up form code goes here -->
    <center>
        <div class="signup-box">
            <center><h1>Sign Up As Member</h1>
                <asp:Label ID="Label1" runat="server" Text="Register Here" CssClass="info"></asp:Label><br />
                <asp:TextBox ID="username" runat="server" placeholder="Username" CssClass="signin"></asp:TextBox><br />
                <asp:TextBox ID="password" runat="server" placeholder="Password" TextMode="Password" CssClass="signin"></asp:TextBox><br />
                <asp:TextBox ID="email" runat="server" placeholder="Email" TextMode="Email" CssClass="signin"></asp:TextBox><br />
                <asp:TextBox ID="phone" runat="server" placeholder="Phone Number" CssClass="signin"></asp:TextBox><br />
                <asp:TextBox ID="state" runat="server" placeholder="State" CssClass="signin"></asp:TextBox><br />
                <asp:TextBox ID="postcode" runat="server" placeholder="Postcode" CssClass="signin"></asp:TextBox><br />
                <asp:TextBox ID="city" runat="server" placeholder="City" CssClass="signin"></asp:TextBox><br />
                <asp:TextBox ID="unit" runat="server" placeholder="Address Details" TextMode="MultiLine" CssClass="signin"></asp:TextBox><br />
                <asp:Button ID="Button1" runat="server" Text="Sign Up" CssClass="btnlogin" OnClick="Button1_Click" /><br />
            </center>
        </div>
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JavaScript" runat="server">
    <script>
        // check is not empty
        function validateForm() {

        }

    </script>
</asp:Content>
