<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e){
        RegisterCustomRoutes(RouteTable.Routes);
    }

     void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "RegisterRoute",
                "Register",
                "~/Register.aspx"
                );

            routes.MapPageRoute(
                "LoginRoute",
                "Login",
                "~/Login.aspx"
                );

            routes.MapPageRoute(
                 "DashboardRoute",
                 "Dashboard/{UsernameValue}",
                 "~/Dashboard.aspx"               
                );
        }
</script>