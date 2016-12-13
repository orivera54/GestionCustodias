<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of gestioncustodias.Custodia.Models.CajaModel))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
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
                <h2>Cajas</h2>
            </hgroup>
 
        </div>
    </section>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

<p>
     <a href="<%: Url.Action("Create", "Caja")%>"><img src="../../Images/ic_add_box_black_24dp_2x.png" /> </a> 
</p>
<table class="display" id="IDXLista"  cellspacing="0" width="100%">
    <thead>
      <tr>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.codcaja)%>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.cod_ciu)%>
        </th>
          <th>
            <%: Html.DisplayNameFor(Function(model) model.direccion)%>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.descripcion) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.USUA_Crea) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.FechaCrea)%>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.USUA_Actualiza) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.FechaActualiza) %>
        </th>
        <th></th>
    </tr>
    </thead>
    <tfoot>
      <tr>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.codcaja)%>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.cod_ciu)%>
        </th>
           <th>
            <%: Html.DisplayNameFor(Function(model) model.direccion)%>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.descripcion) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.USUA_Crea) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.FechaCrea)%>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.USUA_Actualiza) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.FechaActualiza) %>
        </th>
        <th></th>
    </tr>
    </tfoot>

    <tbody>

    

<% If Not IsNothing(Model) Then%>
 <% For Each item In Model %>
    <% Dim currentItem = item
               
        Dim fechaCrea As String = ""
        Dim fechaAct As String = ""
        Dim Ciudades As New gestioncustodias.Seguridad.SeguridadContext
        Dim Ciudad As gestioncustodias.Seguridad.CiudadModel
        Ciudad = Ciudades.Ciudades.Find(currentItem.cod_ciu)
        
        
        If IsNothing(currentItem.FechaCrea) Then
            fechaCrea = ""
        Else
            fechaCrea = currentItem.FechaCrea.ToShortDateString()
        End If
        
        If IsNothing(currentItem.FechaActualiza) Then
            fechaAct = ""
        Else
            fechaAct = currentItem.FechaActualiza.ToString.AsDateTime.ToShortDateString
        End If
        
        %>
    <tr>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.codcaja)%>" style="width: 5%" >
            <%: Html.DisplayFor(Function(modelItem) currentItem.codcaja)%>
        </td>
        <td data-th="Ciudad" style="width: 25%">
            <%: Html.DisplayFor(Function(modelItem) Ciudad.tx_descrip)%>
        </td>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.direccion)%>" style="width: 25%">
            <%: Html.DisplayFor(Function(modelItem) currentItem.direccion)%>
        </td>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.descripcion) %>" style="width: 20%">
            <%: Html.DisplayFor(Function(modelItem) currentItem.descripcion) %>
        </td>
         <td data-th="<%: Html.DisplayNameFor(Function(model) model.USUA_Crea) %>" style="width: 10%">
            <%: Html.DisplayFor(Function(modelItem) currentItem.USUA_Crea) %>
        </td>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.FechaCrea)%>" style="width: 10%">
            <%: Html.Raw(fechaCrea)%>
        </td>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.USUA_Actualiza) %>" style="width: 10%">
            <%: Html.DisplayFor(Function(modelItem) currentItem.USUA_Actualiza) %>
        </td>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.FechaActualiza) %>" style="width: 10%">
            <%: Html.Raw(fechaAct)%>
        </td>
        <td style="width: 10%">
              <a href="<%: Url.Action("Edit", "Caja", New With {.id = currentItem.Codigo})%>"><img src="../../Images/ic_edit_black_24dp_1x.png" /> </a> 
          <%--   <%: Html.ActionLink(".", "Edit", New With {.id = currentItem.Codigo}, New With {.class = "btn_edit"})%> --%> <%-- 
            <%: Html.ActionLink("Details", "Details", New With {.id = currentItem.PrimaryKey}) %> |
            <%: Html.ActionLink("Delete", "Delete", New With {.id = currentItem.PrimaryKey}) %>--%>
        </td>
    </tr>
 <% Next %>
<% End If%>
</tbody>
</table>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
