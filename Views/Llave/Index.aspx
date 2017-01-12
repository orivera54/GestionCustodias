<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of gestioncustodias.Custodia.Models.LlaveroModel))" %>

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
                <h2>Llaveros</h2>
            </hgroup>
 
        </div>
    </section>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

<p>
     <a href="<%: Url.Action("Create", "Llavero")%>"><img src="../../Images/ic_add_box_black_24dp_2x.png" /> </a> 
</p>
<table class="display" id="IDXLista"  cellspacing="0" width="100%">
    <thead>
      <tr>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.codigo)%>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.cod_ofi)%>
        </th>
          <th>
            <%: Html.DisplayNameFor(Function(model) model.Idcaja)%>
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
            <%: Html.DisplayNameFor(Function(model) model.codigo)%>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.cod_ofi)%>
        </th>
           <th>
            <%: Html.DisplayNameFor(Function(model) model.Idcaja)%>
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
        Dim Oficinas As New gestioncustodias.Seguridad.SeguridadContext
        Dim Oficina As gestioncustodias.Seguridad.OficinaModel
        Dim Cajas As New gestioncustodias.Custodia.Models.CajaModelsContext
        Dim caja As gestioncustodias.Custodia.Models.CajaModel
        Oficina = Oficinas.Oficinas.Find(currentItem.cod_ofi)
        caja = Cajas.Caja.Find(currentItem.Idcaja)
        
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
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.codigo)%>" style="width: 5%" >
            <%: Html.DisplayFor(Function(modelItem) currentItem.codigo)%>
        </td>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.cod_ofi)%>" style="width: 25%">
            <%: Html.DisplayFor(Function(modelItem) Oficina.tx_descrip)%>
        </td>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.Idcaja)%>" style="width: 5%" >
            <%: Html.DisplayFor(Function(modelItem) caja.descripcion)%>
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
              <a href="<%: Url.Action("Edit", "Llavero", New With {.id = currentItem.Id})%>"><img src="../../Images/ic_edit_black_24dp_1x.png" /> </a> 
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
