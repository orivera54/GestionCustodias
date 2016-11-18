<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of gestioncustodias.Custodia.Models.tbl_usuarios)" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
Ingresar
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">



     <section id="loginForm">
    <h2>Ingresar</h2>
    <% Using Html.BeginForm(New With { .ReturnUrl = ViewData("ReturnUrl") }) %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>
         

        <fieldset>
            <legend>Log in Form</legend>
            <ol>
                <li>
                    <%: Html.LabelFor(Function(m) m.ptx_login)%>
                    <%: Html.TextBoxFor(Function(m) m.ptx_login)%>
                    <%: Html.ValidationMessageFor(Function(m) m.ptx_login)%>
                </li>
                <li>
                    <%: Html.LabelFor(Function(m) m.ptx_Password)%>
                    <%: Html.PasswordFor(Function(m) m.ptx_Password)%>
                    <%: Html.ValidationMessageFor(Function(m) m.ptx_Password)%>
                </li>
               
            </ol>
            <input type="submit" value="Ingresar" />
        </fieldset>
        
    <% End Using %>
    </section>

    

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
