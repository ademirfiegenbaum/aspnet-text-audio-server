<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Código que é executado quando a aplicação é iniciada
        System.Web.Mvc.AreaRegistration.RegisterAllAreas();
        System.Web.Routing.RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        
        System.Web.Routing.RouteTable.Routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }

    void Application_End(object sender, EventArgs e)
    {
        // Código que é executado quando a aplicação é encerrada
    }

</script>