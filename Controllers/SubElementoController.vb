Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Transactions
Imports System.Web.Routing
Imports System.Web.Mvc
Imports DotNetOpenAuth.AspNet
Imports Microsoft.Web.WebPages.OAuth
Imports WebMatrix.WebData
Imports System.Data.Entity


Public Class SubElementoController
    Inherits System.Web.Mvc.Controller

    Private ctxSubElemento As Custodia.Models.SubElementoContext = New Custodia.Models.SubElementoContext
    Private CtxSeguridad As Seguridad.SeguridadContext = New Seguridad.SeguridadContext

    '
    ' GET: /SubElemento

    Function Index() As ActionResult
        Dim usuario As New Custodia.Models.tbl_usuarios
        Dim subelementos As New List(Of Custodia.Models.SubElementosModel)


        If autenticado Then
            menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
            ViewData("menu") = menuapp
        End If


        Return View(ctxSubElemento.SubElementoSeguridad.ToList())
    End Function

    '
    ' GET: /SubElemento/Details/5

    Function Details(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    '
    ' GET: /SubElemento/Create

    Function Create(ByVal returnUrl As String) As ActionResult

        Dim TieneLlave As New List(Of SelectListItem)
        TieneLlave.Add(New SelectListItem With {.Text = "Si", .Value = 1})
        TieneLlave.Add(New SelectListItem With {.Text = "No", .Value = 0, .Selected = True})

        Dim TieneClave As New List(Of SelectListItem)
        TieneClave.Add(New SelectListItem With {.Text = "Si", .Value = 1})
        TieneClave.Add(New SelectListItem With {.Text = "No", .Value = 0, .Selected = True})


        Dim usuario As New Custodia.Models.tbl_usuarios

        If autenticado Then
            menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
            ViewData("menu") = menuapp
        End If

        ViewData("TieneClave") = TieneClave
        ViewData("TieneLlave") = TieneLlave

        ViewData("ReturnUrl") = returnUrl
       

        Return View()
    End Function

    '
    ' POST: /SubElemento/Create

    <HttpPost()> _
    Function Create(ByVal model As Custodia.Models.SubElementosModel, ByVal returnUrl As String) As ActionResult
        Try


            Dim TieneLlave As New List(Of SelectListItem)
            TieneLlave.Add(New SelectListItem With {.Text = "Si", .Value = 1})
            TieneLlave.Add(New SelectListItem With {.Text = "No", .Value = 0})

            Dim TieneClave As New List(Of SelectListItem)
            TieneClave.Add(New SelectListItem With {.Text = "Si", .Value = 1})
            TieneClave.Add(New SelectListItem With {.Text = "No", .Value = 0})


            ViewData("TieneClave") = TieneClave
            ViewData("TieneLlave") = TieneLlave
            ViewData("fechaCrea") = Now
            ViewData("USUCrea") = User.Identity.Name

            If (ModelState.IsValid) Then
                Using DBElemento As New Custodia.Models.SubElementoContext
                    model.USUA_Crea = User.Identity.Name
                    model.FechaCrea = Now
                    DBElemento.SubElementoSeguridad.Add(New Custodia.Models.SubElementosModel With {.abreviatura = model.abreviatura, .nombre = model.nombre, .descripcion = model.descripcion, .USUA_Crea = model.USUA_Crea, .FechaCrea = model.FechaCrea, .TieneClave = model.TieneClave, .TieneLlave = model.TieneLlave, .FechaActualiza = model.FechaActualiza})
                    DBElemento.SaveChanges()

                    Return RedirectToLocal(returnUrl)

                End Using
            End If



            ViewData("ReturnUrl") = returnUrl
            Return View(model)
        Catch ex As Exception
            MsgBox(ex.Message & " " & ex.Source)
            Return View()
        End Try
    End Function

    '
    ' GET: /SubElemento/Edit/5

    Function Edit(ByVal id As Integer) As ActionResult

        Dim TieneLlave As New List(Of SelectListItem)
        TieneLlave.Add(New SelectListItem With {.Text = "Si", .Value = 1})
        TieneLlave.Add(New SelectListItem With {.Text = "No", .Value = 0, .Selected = True})

        Dim TieneClave As New List(Of SelectListItem)
        TieneClave.Add(New SelectListItem With {.Text = "Si", .Value = 1})
        TieneClave.Add(New SelectListItem With {.Text = "No", .Value = 0, .Selected = True})

        Dim Subelementos As Custodia.Models.SubElementosModel = ctxSubElemento.SubElementoSeguridad.Find(id)
        If Subelementos Is Nothing Then
            Return HttpNotFound()
        End If

        Dim usuario As New Custodia.Models.tbl_usuarios

        If autenticado Then
            menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
            ViewData("menu") = menuapp
        End If

        ViewBag.TieneLlave = TieneLlave
        ViewBag.TieneClave = TieneClave


        Return View(Subelementos)
    End Function

    '
    ' POST: /SubElemento/Edit/5

    <HttpPost()> _
    Function Edit(ByVal model As Custodia.Models.SubElementosModel) As ActionResult
        Try

            Dim TieneLlave As New List(Of SelectListItem)
            TieneLlave.Add(New SelectListItem With {.Text = "Si", .Value = 1})
            TieneLlave.Add(New SelectListItem With {.Text = "No", .Value = 0})

            Dim TieneClave As New List(Of SelectListItem)
            TieneClave.Add(New SelectListItem With {.Text = "Si", .Value = 1})
            TieneClave.Add(New SelectListItem With {.Text = "No", .Value = 0})

            If ModelState.IsValid Then
                model.USUA_Actualiza = User.Identity.Name
                model.FechaActualiza = Now
                ctxSubElemento.Entry(model).State = EntityState.Modified
                ctxSubElemento.SaveChanges()
                Return RedirectToAction("Index")
            End If

            ViewData("fechaAct") = Now
            ViewData("USUAct") = User.Identity.Name
            ViewData("TieneLlave") = TieneLlave
            ViewData("TieneClave") = TieneClave

            Return View(model)
        Catch
            Return View()
        End Try
    End Function

    '
    ' GET: /SubElemento/Delete/5

    Function Delete(ByVal id As Integer) As ActionResult
        Return View()
    End Function

    '
    ' POST: /SubElemento/Delete/5

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