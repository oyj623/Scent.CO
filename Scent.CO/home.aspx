<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Scent.CO.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/home.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="navbrand">
        <ul class="navbrand-items">
            <li class="navbrand-item">
                <a href="#dior">Dior</a>
            </li>
            <li class="navbrand-item">
                <a href="#ysl">YSL</a>
            </li>
            <li class="navbrand-item">
                <a href="#chanel">Chanel</a>
            </li>
            <li class="navbrand-item">
                <a href="#gucci">Gucci</a>
            </li>
            <li class="navbrand-item">
                <a href="#lv">Louis Vuitton</a>
            </li>
            <li class="navbrand-item">
                <a href="#bvlgari">Bvlgari</a>
            </li>
            <li class="navbrand-item">
                <a href="#jomalone">Jo Malone</a>
            </li>
        </ul>
    </div>

    <div class="home-perfume" id="dior">
        <div class="home-perfume-video">
            <video autoplay loop muted>
                <source src="https://cdn.shopify.com/videos/c/o/v/7ccb23b90e624299ac2c9919ac223093.mp4" type="video/mp4" /> 
            </video>
        </div>
        <div class="home-perfume-content home-perfume-title">
            <h2 class="brand">DIOR</h2>
        </div>
        <div class="home-perfume-content home-perfume-description">
            <h4 class="slogan">Real elegance is everywhere, especially in the things that don't show.</h4>
        </div>
        <div class="home-perfume-content home-perfume-button">
            <asp:Button ID="Button1" runat="server" Text="View More" BackColor="#666699" ForeColor="#f1f0e1" Font-Names="Elephant" Font-Size="Medium" Width="130" Height="50" BorderStyle="Outset" CssClass="btn1" BorderColor="#666699" OnClick="Button1_Click" />
        </div>
    </div>

     <div class="home-perfume" id="ysl">
        <div class="home-perfume-video">
            <video autoplay loop muted>
                <source src="Video/ysl.mp4" type="video/mp4" /> 
            </video>
        </div>
         <div class="home-perfume-content home-perfume-title">
            <h2 class="brand">YSL</h2>
        </div>
        <div class="home-perfume-content home-perfume-description">
            <h4 class="slogan">For me, perfume, must be adapted to fashion, not the other way around.</h4>
        </div>
         <div class="home-perfume-content home-perfume-button">
            <asp:Button ID="Button2" runat="server" Text="View More" BackColor="#666699" ForeColor="#f1f0e1" Font-Names="Elephant" Font-Size="Medium" Width="130" Height="50" BorderStyle="Outset" CssClass="btn1" BorderColor="#666699" OnClick="Button2_Click" />
        </div>
    </div>

    <div class="home-perfume" id="chanel">
        <div class="home-perfume-video">
            <video autoplay loop muted>
                <source src="Video/chanel.mp4" type="video/mp4" /> 
            </video>
        </div>
         <div class="home-perfume-content home-perfume-title">
            <h2 class="brand">Chanel</h2>
        </div>
        <div class="home-perfume-content home-perfume-description">
            <h4 class="slogan">No elegance is possible without perfume. It is unseen, unforgettable, ultimate accessory.</h4>
        </div>
         <div class="home-perfume-content home-perfume-button">
            <asp:Button ID="Button3" runat="server" Text="View More" BackColor="#666699" ForeColor="#f1f0e1" Font-Names="Elephant" Font-Size="Medium" Width="130" Height="50" BorderStyle="Outset" CssClass="btn1" BorderColor="#666699" OnClick="Button3_Click" />
        </div>
    </div>


    <div class="home-perfume" id="gucci">
        <div class="home-perfume-video">
            <video autoplay loop muted>
                <source src="Video/gucci.mp4" type="video/mp4" /> 
            </video>
        </div>
         <div class="home-perfume-content home-perfume-title">
            <h2 class="brand">Gucci</h2>
        </div>
        <div class="home-perfume-content home-perfume-description">
            <h4 class="slogan">Quality is remembered long after price is forgotten.</h4>
        </div>
         <div class="home-perfume-content home-perfume-button">
            <asp:Button ID="Button4" runat="server" Text="View More" BackColor="#666699" ForeColor="#f1f0e1" Font-Names="Elephant" Font-Size="Medium" Width="130" Height="50" BorderStyle="Outset" CssClass="btn1" BorderColor="#666699" OnClick="Button4_Click" />
        </div>
    </div>

    <div class="home-perfume" id="lv">
        <div class="home-perfume-video">
            <video autoplay loop muted>
                <source src="Video/louis-vuitton.mp4" type="video/mp4" /> 
            </video>
        </div>
         <div class="home-perfume-content home-perfume-title">
            <h2 class="brand">Louis Vuitton</h2>
        </div>
        <div class="home-perfume-content home-perfume-description">
            <h4 class="slogan">Letting imigination take over. Escape into the olfactory palette of Les Parfum.</h4>
        </div>
         <div class="home-perfume-content home-perfume-button">
            <asp:Button ID="Button5" runat="server" Text="View More" BackColor="#666699" ForeColor="#f1f0e1" Font-Names="Elephant" Font-Size="Medium" Width="130" Height="50" BorderStyle="Outset" CssClass="btn1" BorderColor="#666699" OnClick="Button5_Click" />
        </div>
    </div>
    
    <div class="home-perfume" id="bvlgari">
        <div class="home-perfume-video">
            <video autoplay loop muted>
                <source src="Video/bvlgari.mp4" type="video/mp4" /> 
            </video>
        </div>
         <div class="home-perfume-content home-perfume-title">
            <h2 class="brand">Bvlgari</h2>
        </div>
        <div class="home-perfume-content home-perfume-description">
            <h4 class="slogan">Real elegance is everywhere, especially in the things that don't show</h4>
        </div>
         <div class="home-perfume-content home-perfume-button">
            <asp:Button ID="Button6" runat="server" Text="View More" BackColor="#666699" ForeColor="#f1f0e1" Font-Names="Elephant" Font-Size="Medium" Width="130" Height="50" BorderStyle="Outset" CssClass="btn1" BorderColor="#666699" OnClick="Button6_Click" />
        </div>
    </div>
    
    <div class="home-perfume" id="jomalone">
        <div class="home-perfume-video">
            <video autoplay loop muted>
                <source src="Video/jo-malone.mp4" type="video/mp4" /> 
            </video>
        </div>
         <div class="home-perfume-content home-perfume-title">
            <h2 class="brand">Jo Malone</h2>
        </div>
        <div class="home-perfume-content home-perfume-description">
            <h4 class="slogan">Destiny semlls of dust and the libraries of the night.</h4>
        </div>
         <div class="home-perfume-content home-perfume-button">
            <asp:Button ID="Button7" runat="server" Text="View More" BackColor="#666699" ForeColor="#f1f0e1" Font-Names="Elephant" Font-Size="Medium" Width="130" Height="50" BorderStyle="Outset" CssClass="btn1" BorderColor="#666699" OnClick="Button7_Click" />
        </div>
    </div>
    <%--<div class="team" style="background-color: #12031c; color: #f1f0e1;">
        <img src="Image/perfume.png" alt="Logo" width="200" height="120" style="padding-bottom: 10px" id="img2"/>
        <h4>A unique fragrance is often impressive and more representative of personality. Unique personality is always one of the conditions of real elegance.</h4>
        <br/>
        <h3 style="font-weight: bold; font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;">  Welcome to SCENT.CO</h3>
        <h4>Pick a perfume and create your own scent. Enjoy your journey and hope you have a great day.</h4>
    </div>--%>
</asp:Content>
