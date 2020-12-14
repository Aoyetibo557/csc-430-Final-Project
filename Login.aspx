<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BMI_Web_API__ASP.NET_FRAMEWORK_.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="main.css" rel="stylesheet" />
    <title>Login Page</title>
</head>
<body>
    <header class="_main_header">
        <h3>BMI App</h3>
        <nav class="_main_nav">
            <ul>
                <li><a href="#">Login</a></li>
                <li><a href="Register.aspx">Register</a></li>
            </ul>
        </nav>
    </header>

        <asp:Label ID="loginalertBox" Text="" runat="server" />

    <section class="_login_section">
         <form id="form1" runat="server">
              <h4>LOGIN</h4>

            <div>
                <asp:Label Text="Username" runat="server" CssClass="_login_form_label" />
                <asp:TextBox ID="usernameTextBox" Text="" runat="server" CssClass="_login_input"/>
            </div>

             <div>
                <asp:Label Text="Password" runat="server" CssClass="_login_form_label" />
                <asp:TextBox ID="passwordTextBox" Text="" runat="server" CssClass="_login_input" />
            </div>

             <div>
                <asp:Button ID="loginButton" Text="LOGIN" runat="server" OnClick="loginMethod" CssClass="_secondary_btn" />
            </div>

             <div>
                 <a href="Register.aspx" class="_primary_btn">CREATE ACCOUNT</a>
                <%--<asp:Button ID="createAccount" Text="CREATE ACCOUNT" runat="server" CssClass="_primary_btn" />--%>
             </div>
        </form>
        <div class="_section_img_div">
            <%-- Hold The Image by the side --%>
            <img src="img1.jpg" class="_section_img" />
        </div>

    </section>
</body>
</html>
