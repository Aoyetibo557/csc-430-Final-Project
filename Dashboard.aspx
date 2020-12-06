<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="BMI_Web_API__ASP.NET_FRAMEWORK_.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="dashboardStyles.css" rel="stylesheet" />
    <title>Dashboard</title>
</head>
<body>
        <form runat="server">

    <section class="_dashboard_section">
        <div id="sideBar" class="_side_bar">
            <div id="topSideBar" class="_top_side_bar">
                <h3 class="_current_username"><asp:Label ID="usernameTextBox" Text="" runat="server" /></h3>
                <%--<img src="www.placeholder/200/200" alt="Avatar"/>--%>
                <%-- <form runat="server"> --%>
                    <asp:Label ID="fullnameTextBox" Text="" runat="server" CssClass="_username" />
                    <%--<div>
                       <asp:Button ID="logoutBtn" Text="LOGOUT" runat="server" OnClick="logoutMethod" CssClass="_inner_links" />
                    </div>--%>
               <%-- </form> --%>
               
            </div>
            <div id="bottom_sidebar" class="_bottom_side_bar">
                <p><a href="#" class="_inner_links active" onclick="addActive()">OVERVIEW</a></p>
                <p><a id="buds" href="#sect2" class="_inner_links" onclick="addActive()">BUDDIES</a></p>
                <p><a id="alerts" href="#" class="_inner_links" onclick="addActive()" >ALERTS</a></p>
                <p><a id="awards" href="#" class="_inner_links" onclick="addActive()" >AWARDS</a></p>
                <p><a id="setts" href="#" class="_inner_links " onclick="addActive()" >SETTINGS</a></p>
                <p><asp:Button ID="Button1" Text="LOGOUT" runat="server" OnClick="logoutMethod" CssClass="_logout_btn" /></p>
            </div>
        </div>




        <div id="mainScreen" class="_main_screen">
            <div id="topScreen" class="_top_screen">
                <div>
                    <p>Your Goal BMI</p>
                    <asp:Label ID="goalBmiTextBox" Text="" runat="server" CssClass="_icon_values" />
                    <p>REDUCE WEIGHT TO GET TO GOAL BMI</p>
                </div>

                <div>
                    <p>Date & Time</p>
                    <asp:Label ID="dateTimeLabel" Text="" runat="server" />
                    <p class="_date_time"><span><asp:Label ID="dayTextBox" Text="" runat="server" /></span>, <span><asp:Label ID="monthTextBox" Text="" runat="server" /></span> <span><asp:Label ID="yearTextBox" Text="" runat="server" /></span> 

                        <asp:Label ID="timeTextBox" Text="" runat="server" />
                    </p>
                    
                </div>

                <div>
                    <p>Show Me</p>
                    <div class="_show_me">
                        <img class="_top_icons" src="stairs.png" width="40" height="40"  alt="Stairs Pic"/><span><asp:Label ID="stepsTextBox" Text="" runat="server" /></span>
                        <img class="_top_icons" src="award1.png" width="40" height="40"  alt="Awards Pic"/><span> Performance Award</span>
                        <img class="_top_icons" src="level.png" width="40" height="40"  alt="Leve Pic"/><span><asp:Label ID="levelTextBox" Text="" runat="server" /></span>

                    </div>
                </div>
            </div>

            <div id="middleScreen" class="_middle_screen">
                <img src="img3.png" alt="Running Image" />
            </div>

            <div id="bottomScreen" class="_bottom_screen" >
                <div>
                    <img class="_icons" src="apple.png" alt="Stack Picture" />
                     <asp:Label ID="heightTextBox" Text ="" runat="server" CssClass="_icon_values" />
                    <p class="_icon_values_p">Height</p>
                </div>
                 <div>
                     <img class="_icons" src="weight.png" alt="Apple Icon" />
                     <asp:Label ID="weightTextBox" Text ="" runat="server" CssClass="_icon_values" />
                    <p class="_icon_values_p">Weight</p>
                </div>
                 <div>
                    <img class="_icons" src="scale.png" alt="Apple Icon" />
                     <asp:Label ID="bmiTextBox" Text ="" runat="server" CssClass="_icon_values" />
                    <p class="_icon_values_p">Current Bmi</p>
                </div>
            </div>
        </div>

       
    </section>

    <section id="sect2" class="_buddies_section">
        <div>
            <div id="_bud_head">
                <h4 class="_buddies_h4">FriendList</h4>
                <p class="_buddies_p">Add Friends With Username</p>
                <asp:Label ID="alertLabel" Text="" runat="server" />
            </div>

            <div id="outputField">
                <asp:GridView ID="test1GridView" runat="server" CssClass="friendlist_girdView" Width="950px"></asp:GridView>

            </div>

            <div id="hidden_fields" class="_friend_add_div">
                <asp:TextBox ID="friendUsernameTextBox" Text="" runat="server" CssClass="_friend_textBox"  ></asp:TextBox>
                <asp:Button ID="addfriendButton" Text="Add Friend" runat="server" OnClick="findFriendMethod" CssClass="_friend_button"  />
            </div>

        </div>
    </section>
       </form>
    <script type="text/javascript">
        //To prevent page from going back to dashboard after logout
        window.history.forward(-1);
    </script>
    <script src="script.js"></script>
</body>
</html>
