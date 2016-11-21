<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of gestioncustodias.Custodia.Models.SubElementosModel))" %>

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
                <h2>SubElementos de Seguridad</h2>
            </hgroup>
 
        </div>
    </section>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <p>
   <a href="<%: Url.Action("Create", "SubElemento")%>"><img src="../../Images/ic_add_box_black_24dp_2x.png" /> </a> 
</p>
<table  class="display" id="IDXLista"  cellspacing="0" width="100%">
    <thead>
        <tr>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.abreviatura) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.nombre) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.descripcion) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.TieneClave) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.TieneLlave) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.USUA_Crea) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.FechaCrea) %>
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
            <%: Html.DisplayNameFor(Function(model) model.abreviatura) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.nombre) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.descripcion) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.TieneClave) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.TieneLlave) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.USUA_Crea) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(Function(model) model.FechaCrea) %>
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



<% For Each item In Model %>
    <% Dim currentItem = item
        
        Dim fechaCrea As String = ""
        Dim fechaAct As String = ""
        Dim tiene_clave As String = ""
        Dim tiene_llave As String = ""
        
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
        
        If currentItem.TieneClave = 0 Then
            tiene_clave = "No"
        Else
            tiene_clave = "Si"
        End If
        
        If currentItem.TieneLlave = 0 Then
            tiene_llave = "No"
        Else
            tiene_llave = "Si"
        End If
        
        %>
    <tr>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.abreviatura) %>" style="width: 5%" >
            <%: Html.DisplayFor(Function(modelItem) currentItem.abreviatura) %>
        </td>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.nombre) %>" style="width: 25%">
            <%: Html.DisplayFor(Function(modelItem) currentItem.nombre) %>
        </td>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.descripcion) %>" style="width: 20%">
          <%: Html.DisplayFor(Function(modelItem) currentItem.descripcion) %>
        </td>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.TieneClave)%>" style="width: 5%">
           <%: Html.Raw(tiene_clave)%>
        </td>
        <td data-th="<%: Html.DisplayNameFor(Function(model) model.TieneLlave)%>" style="width: 5%">
            <%: Html.Raw(tiene_llave)%>
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
        <td  data-th="<%: Html.DisplayNameFor(Function(model) model.FechaActualiza) %>" style="width: 10%">
           <%: Html.Raw(fechaAct)%>
        </td>
        <td>
            <a href="<%: Url.Action("Edit", "SubElemento", New With {.id = currentItem.Codigo})%>"><img src="../../Images/ic_edit_black_24dp_1x.png" /> </a> 
            <%--<%: Html.ActionLink("Edit", "Edit", New With {.id = currentItem.PrimaryKey}) %> |
            <%: Html.ActionLink("Details", "Details", New With {.id = currentItem.PrimaryKey}) %> |
            <%: Html.ActionLink("Delete", "Delete", New With {.id = currentItem.PrimaryKey}) %>--%>
        </td>
    </tr>
<% Next %>

    </tbody>
</table>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
