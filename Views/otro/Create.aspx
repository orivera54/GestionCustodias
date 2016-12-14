<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of gestioncustodias.Custodia.Models.LlaveroModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Crear Caja/Cofre
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
                <h2>Llaveros</h2>
            </hgroup>
 
        </div>
    </section>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Crear Llavero</h2>

<%-- The following line works around an ASP.NET compiler warning --%>
<%: "" %>

<% Using Html.BeginForm() %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(True) %>

    <fieldset>
        <legend>CajaModel</legend>

    <table>
        <tr>
            <td>
                 <div class="editor-label">
                     <%: Html.LabelFor(Function(model) model.codigo)%>
                </div>
            </td>
           
            <td>
                 <div class="editor-label">
                     <%: Html.LabelFor(Function(model) model.cod_ofi)%>
                </div>
            </td>
           <td>
                <div class="editor-label">
                    <%: Html.LabelFor(Function(model) model.Idcaja)%>
                </div>
           </td>
        </tr>
       <tr>
           <td>
              <div class="editor-field">
                    <%: Html.EditorFor(Function(model) model.codigo)%>
                    <%: Html.ValidationMessageFor(Function(model) model.Idcaja)%>
              </div>
           </td>
             <td>
                  <div class="editor-field">
                        <%: Html.DropDownList("cod_ofi", "Seleccione Oficina")%>
                        <%: Html.ValidationMessageFor(Function(model) model.cod_ofi)%>
                   </div>
            </td>
           <td>
                    <div class="editor-field">
                         <%: Html.DropDownList("IDCaja", "Seleccione Caja")%>
                         <%: Html.ValidationMessageFor(Function(model) model.Idcaja)%>
                    </div>
         </td>
       </tr>
              
        
    </table>
        

        <p>
            <input type="submit" value="Grabar" />
        </p>
    </fieldset>
<% End Using %>

<div>
   <p title="Regresar"> <a href="<%: Url.Action("Index", "Llavero")%>" ><img src="../../Images/ic_reply_black_24dp_2x.png" /> </a></p>
</div>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
