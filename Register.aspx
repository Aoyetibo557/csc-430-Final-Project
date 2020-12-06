<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BMI_Web_API__ASP.NET_FRAMEWORK_.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="main.css" rel="stylesheet" />
    <title>Register Account</title>
</head>
<body>
     <header class="_main_header">
        <h3>BMI App</h3>
        <nav class="_main_nav">
            <ul>
                <li><a href="Login.aspx">Login</a></li>
                <li><a href="#">Register</a></li>
            </ul>
        </nav>
    </header>

    <div id="alertBox">
         <asp:Label ID="alertLabel" Text="" runat="server" />
    </div>

    <section class="_register_section">
        <form id="form1" runat="server">
            <h4 class="_register_h4">Create New Account</h4>
            <div>
                <asp:Label Text="Firstname" runat="server" CssClass="_register_label" />
                <asp:TextBox ID="firstnameTextBox" Text="" runat="server" CssClass="_register_input" />

                 <asp:Label Text="Lastname" runat="server" CssClass="_register_label" />
                <asp:TextBox ID="lastnameTextBox" Text="" runat="server" CssClass="_register_input"  />
            </div>

            <div>
                <asp:Label Text="Email-Address" runat="server" CssClass="_register_label" />
                <asp:TextBox ID="emailAddressTextBox" Text="" runat="server" CssClass="_register_input"  />

                <asp:Label Text="Gender" runat="server" CssClass="_register_label" />
                <asp:TextBox ID="genderTextBox" Text="" runat="server" CssClass="_register_input"  />
            </div>

            <div>
                <asp:Label Text="Username" runat="server" CssClass="_register_label" />
                <asp:TextBox ID="usernameTextBox" Text="" runat="server" CssClass="_register_input" />

                <asp:Label Text="Password" runat="server" CssClass="_register_label" />
                <asp:TextBox ID="passwordTextBox" Text="" runat="server" CssClass="_register_input"  />
            </div>
            
            <h5>Enter BMI Information Below</h5>

            <div>
                <asp:Label Text="Height" runat="server" CssClass="_register_label" />
                <asp:TextBox ID="heightTextBox" Text="" runat="server" CssClass="_register_input"  />

                <asp:Label Text="Weight" runat="server" CssClass="_register_label"/>
                <asp:TextBox ID="weightTextBox" Text="" runat="server" CssClass="_register_input"  />

                <asp:Label Text="Bmi_Goal" runat="server" CssClass="_register_label" />
                <asp:TextBox ID="bmiGoalTextBox" Text="" runat="server" CssClass="_register_input"  />
            </div>

            <div>
                <asp:Button ID="registerButton" Text="REGISTER" runat="server" OnClick="createNewAccount" CssClass="_primary_btn" />
            </div>
        </form>

        <div>
            <%-- Hold Image --%>
        </div>
    </section>
</body>
</html>
