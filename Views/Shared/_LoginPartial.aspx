<%@ Page Language="VB" Inherits="System.Web.Mvc.ViewPage" %>
<% If (Request.IsAuthenticated) Then %>
    
    <% Using Html.BeginForm("LogOff", "Usuarios", FormMethod.Post, New With {.Id = "logoutForm"})%>
        <%: Html.AntiForgeryToken() %>
        <a href="javascript:document.getElementById('logoutForm').submit()">Salir</a>
    <% End Using %>
<% Else %>
    <ul>
       <li><%: Html.ActionLink("Ingreso", "Ingresar", "Usuarios", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink"})%></li>
    </ul>
<% End If %>