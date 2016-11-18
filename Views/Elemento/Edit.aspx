<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of gestioncustodias.Custodia.Models.elementosseguridadModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
Editar Elemento
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
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
                <h2>Elementos de Seguridad</h2>
            </hgroup>
 
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Editar Elemento</h2>

<%-- The following line works around an ASP.NET compiler warning --%>
<%: "" %>

<% Using Html.BeginForm() %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(True) %>

    <fieldset>
        <legend>elementosseguridadModel</legend>

        <%: Html.HiddenFor(Function(model) model.Codigo) %>

        <table>
           <tr>
               <td>
                    <div class="editor-label">
                         <%: Html.LabelFor(Function(model) model.abreviatura) %>
                    </div>
               </td>
               <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(Function(model) model.nombre) %>
                    </div>
               </td>
           </tr>
           <tr>
               <td>
                    <div class="editor-field">
                        <%: Html.EditorFor(Function(model) model.abreviatura) %>
                        <%: Html.ValidationMessageFor(Function(model) model.abreviatura) %>
                    </div>
               </td>
               <td>
                    <div class="editor-field">
                         <%: Html.EditorFor(Function(model) model.nombre) %>
                        <%: Html.ValidationMessageFor(Function(model) model.nombre) %>
                    </div>
               </td>
           </tr>
           <tr>
               <td colspan="2">
                    <div class="editor-label">
                        <%: Html.LabelFor(Function(model) model.descripcion) %>
                    </div>
               </td>
           </tr>
            <tr>
                <td colspan="2">
                         <div class="editor-field">
                                <%: Html.EditorFor(Function(model) model.descripcion)%>
                                <%: Html.ValidationMessageFor(Function(model) model.descripcion) %>
                        </div>
                </td>
            </tr>


        </table>
       
        <div class="Hidden-field"> 
            <%: Html.HiddenFor(Function(model) model.USUA_Crea)%>
        </div>
      
        <div class="Hidden-field"> 
            <%: Html.HiddenFor(Function(model) model.FechaCrea)%>
        </div>

        <p>
            <input type="submit" value="Grabar" />
        </p>
    </fieldset>
<% End Using %>

<div>
   <p title="Regresar"> <a href="<%: Url.Action("Index", "Elemento")%>" ><img src="../../Images/ic_reply_black_24dp_2x.png" /> </a></p>
</div>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
