<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="BMI_Web_API__ASP.NET_FRAMEWORK_.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CalculatorStyles.css" rel="stylesheet" />
   
    <title>Calculator Page</title>


</head>
<body>

    <form id="form1" runat="server">
       
        
    <section id="calc_sect" class="_calc_section">

        
    <div class="_cal_header">
        <h4>BMI Calculator Pro</h4>
        <a href="Dashboard.aspx">Dashboard</a>
    </div>



        <div id="clac_div" class="_calcMainDiv">
            <div id="calcTop">
                <div class="box _box_hover">
                    <p><asp:ImageButton ID="maleButton" AlternateText="Male" runat="server" OnClick="maleBtn_sub" ImageUrl="~/maleGenderIcon.png" CssClass="gender_icons" OnClientClick="return false;"/></p>
                    <p>Male</p>
                </div>
                <div class="box _box_hover">
                    <p><asp:ImageButton ID="femaleButton" AlternateText="Female" runat="server" OnClick="femaleBtn_sub"  ImageUrl="~/femaleGenderIcon.png" CssClass="gender_icons" OnClientClick="return false;"/></p>
                    <p>Female</p>
                </div>
            </div>

        <div id="calcMiddle">
            <div class="_height_box">
                <h5>Height</h5>
                <asp:Label ID="heightLabel" Text="" runat="server" CssClass="_height_label"  />
                <input type="range" id="heightRange" value="0" min="1" max="300" oninput="move();"/>
                    

                <asp:ScriptManager ID="asm" runat="server" />
                <div id="slider"></div>
            </div>

        </div>

        <div id="calcBottom">
            <div id="calcWeight" class="box">
                <p>Weight</p>  
                <asp:Label ID="weightLabel" Text="0 lb" runat="server" CssClass="_text" />
                <input type="range" id="weightSlider" min="1" max="300" value="0" oninput="theSlide('weightSlider', 'weightLabel');" />
                <%--<p>
                    <span>
                        <asp:Button ID="subBtn" Text="-" runat="server" CssClass="alt_btn" OnClick="subweightBtnMethod"  />
                   </span>
                   <span>
                       <asp:Button ID="addBtn" Text="+" runat="server" CssClass="alt_btn" OnClick="addweightBtnMethod"/>
                   </span>
                </p>--%>
            </div>
            <div id="calcAge" class="box">
                <p>Age</p>  
                <asp:Label ID="ageLabel" Text="0" runat="server" CssClass="_text" />
                <input type="range" id="ageSlider" min="1" max="100" value="0" oninput="theSlide('ageSlider', 'ageLabel');" />

               <%-- <p>
                    <span>
                        <asp:Button ID="ageBtn1" Text="-" runat="server" CssClass="alt_btn" OnClick="subageBtnMethod"  />
                   </span>
                   <span>
                       <asp:Button ID="ageBtn2" Text="+" runat="server" CssClass="alt_btn"  OnClick="addageBtnMethod" />
                   </span>
                </p>--%>
            </div>
        </div>
        </div>
        <%-- Output Begining --%>
        <div class="_output_div">
             <div id="outputHeader" >
                <h4>SOLUTION</h4>
            </div>
            <div >
                <asp:Label ID="outputGenderLabel" Text="" runat="server" CssClass="_height_label" />
            </div>
        </div>

    </section>
    </form>
      <script src="script.js" lang="javascript" type="text/javascript"></script>

</body>
</html>
