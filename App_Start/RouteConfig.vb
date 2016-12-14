Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Class RouteConfig
    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute( _
            name:="Default", _
            url:="{controller}/{action}/{id}", _
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
          name:="Usuarios", _
          url:="{controller}/{action}/{login}", _
          defaults:=New With {.controller = "Usuarios", .action = "Ingresar", .login = UrlParameter.Optional} _
      )

        routes.MapRoute( _
             name:="Elemento", _
             url:="{controller}/{action}/{id}", _
             defaults:=New With {.controller = "Elemento", .action = "Index", .id = UrlParameter.Optional} _
         )

        routes.MapRoute( _
            name:="SubElemento", _
            url:="{controller}/{action}/{id}", _
            defaults:=New With {.controller = "SubElemento", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
           name:="Caja", _
           url:="{controller}/{action}/{id}", _
           defaults:=New With {.controller = "Caja", .action = "Index", .id = UrlParameter.Optional} _
       )
        routes.MapRoute( _
           name:="Llavero", _
           url:="{controller}/{action}/{id}", _
           defaults:=New With {.controller = "Llavero", .action = "Index", .id = UrlParameter.Optional} _
       )

    End Sub
End Class