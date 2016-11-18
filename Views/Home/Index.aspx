<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Sistema de Custodia de Claves y Llaves
</asp:Content>

<asp:Content ID="indexFeatured" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="menuapp">
        <div class="content-wrapper">
          <div class="menuprincipal">
            <%: Html.Raw(ViewData("menu"))%>
          </div>
        </div>
    </section>
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>&nbsp;</h1>
                <h2><%: ViewData("Message") %></h2>
            </hgroup>
            <p>
                &nbsp;</p>
        </div>
    </section>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
   
</asp:Content>
