Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Transactions
Imports System.Web.Routing
Imports DotNetOpenAuth.AspNet
Imports Microsoft.Web.WebPages.OAuth
Imports WebMatrix.WebData
Imports System.Data.Entity


Public Class ElementoController
    Inherits System.Web.Mvc.Controller

    Private ctxElemento As Custodia.Models.ElementosSeguridadContext = New Custodia.Models.ElementosSeguridadContext
    Private CtxSeguridad As Seguridad.SeguridadContext = New Seguridad.SeguridadContext


    '
    ' GET: /Elemento

    Function Index() As ActionResult

        Dim usuario As New Custodia.Models.tbl_usuarios
        Dim elementos As New List(Of Custodia.Models.elementosseguridadModel)

        If autenticado Then
            menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
            ViewData("menu") = menuapp
        End If
       

        Return View(ctxElemento.ElementoSeguridad.ToList())
    End Function

    '
    ' GET: /Elemento/Details/5

    Function Details(ByVal id As Integer) As ActionResult


        Return View()
    End Function

    '
    ' GET: /Elemento/Create

    Function Create(ByVal returnUrl As String) As ActionResult

        Dim usuario As New Custodia.Models.tbl_usuarios

        If autenticado Then
            menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
            ViewData("menu") = menuapp
        End If
        ViewData("fechaCrea") = Now
        ViewData("USUCrea") = User.Identity.Name
        ViewData("ReturnUrl") = returnUrl
        Return View()
    End Function

    '
    ' POST: /Elemento/Create

    <HttpPost()> _
    Function Create(ByVal model As Custodia.Models.elementosseguridadModel, ByVal returnUrl As String) As ActionResult
        Try

            If (ModelState.IsValid) Then
                Using DBElemento As New Custodia.Models.ElementosSeguridadContext
                    model.USUA_Crea = User.Identity.Name
                    model.FechaCrea = Now

                    DBElemento.ElementoSeguridad.Add(New Custodia.Models.elementosseguridadModel With {.abreviatura = model.abreviatura, .nombre = model.nombre, .descripcion = model.descripcion, .USUA_Crea = model.USUA_Crea, .FechaCrea = model.FechaCrea})
                    DBElemento.SaveChanges()

                    Return RedirectToLocal(returnUrl)

                End Using
            End If
            ViewData("fechaCrea") = Now
            ViewData("USUCrea") = User.Identity.Name
            ViewData("ReturnUrl") = returnUrl
            Return View(model)
        Catch
            Return View()
        End Try
    End Function

    '
    ' GET: /Elemento/Edit/5

    Function Edit(ByVal id As Integer) As ActionResult

        Dim elementos As Custodia.Models.elementosseguridadModel = ctxElemento.ElementoSeguridad.Find(id)
        If elementos Is Nothing Then
            Return HttpNotFound()
        End If

        Dim usuario As New Custodia.Models.tbl_usuarios

        If autenticado Then
            menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
            ViewData("menu") = menuapp
        End If

        ViewData("fechaAct") = Now
        ViewData("USUAct") = User.Identity.Name

        Return View(elementos)
    End Function

    '
    ' POST: /Elemento/Edit/5

    <HttpPost()> _
    Function Edit(ByVal model As Custodia.Models.elementosseguridadModel) As ActionResult
        Try
            If ModelState.IsValid Then
                model.USUA_Actualiza = User.Identity.Name
                model.FechaActualiza = Now
                ctxElemento.Entry(model).State = EntityState.Modified
                ctxElemento.SaveChanges()
                Return RedirectToAction("Index")
            End If

            ViewData("fechaAct") = Now
            ViewData("USUAct") = User.Identity.Name


            Return View(model)
        Catch ex As Exception
            MsgBox(ex.InnerException.Message)
            Return View()
        End Try
    End Function

    '
    ' GET: /Elemento/Delete/5

    Function Delete(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    '
    ' POST: /Elemento/Delete/5

    <HttpPost()> _
    Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
        Try
            ' TODO: Add delete logic here

            Return RedirectToAction("Index")
        Catch
            Return View()
        End Try
    End Function

#Region "Helpers"
    Private Function RedirectToLocal(ByVal returnUrl As String) As ActionResult
        If Url.IsLocalUrl(returnUrl) Then
            Return Redirect(returnUrl)
        Else
            Return RedirectToAction("Index", "Elemento")
        End If
    End Function
#End Region
End Class