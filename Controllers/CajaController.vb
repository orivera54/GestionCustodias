Imports System.Web.Mvc
Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Transactions
Imports System.Web.Routing
Imports DotNetOpenAuth.AspNet
Imports Microsoft.Web.WebPages.OAuth
Imports WebMatrix.WebData
Imports System.Data.Entity

Namespace Controllers
    Public Class CajaController
        Inherits System.Web.Mvc.Controller


        Private ctxCaja As Custodia.Models.CajaModelsContext = New Custodia.Models.CajaModelsContext
        Private CtxSeguridad As Seguridad.SeguridadContext = New Seguridad.SeguridadContext

        ' GET: Caja
        Function Index() As ActionResult

            Dim usuario As New Custodia.Models.tbl_usuarios
            Dim cajas As New List(Of Custodia.Models.CajaModel)

            If autenticado Then
                menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
                ViewData("menu") = menuapp
            End If


            Return View(ctxCaja.Caja.ToList())
        End Function

        ' GET: Caja/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: Caja/Create
        Function Create(ByVal returnurl As String) As ActionResult

            Dim usuario As New Custodia.Models.tbl_usuarios

            If autenticado Then
                menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
                ViewData("menu") = menuapp
            End If

            ViewBag.cod_ciu = New SelectList(CtxSeguridad.Ciudades.ToList, "cod_ciu", "tx_descrip")


            ViewData("fechaCrea") = Now
            ViewData("USUCrea") = User.Identity.Name
            ViewData("ReturnUrl") = returnurl
            Return View()


        End Function

        ' POST: Caja/Create
        <HttpPost()>
        Function Create(ByVal model As Custodia.Models.CajaModel, ByVal returnUrl As String) As ActionResult
            Try

                If (ModelState.IsValid) Then
                    Using DBCaja As New Custodia.Models.CajaModelsContext
                        model.USUA_Crea = User.Identity.Name
                        model.FechaCrea = Now

                        DBCaja.Caja.Add(New Custodia.Models.CajaModel With {.cod_ciu = model.cod_ciu, .codcaja = model.codcaja, .descripcion = model.descripcion, .Codigo = model.Codigo, .direccion = model.direccion, .USUA_Crea = model.USUA_Crea, .FechaCrea = model.FechaCrea})
                        DBCaja.SaveChanges()

                        Return RedirectToLocal(returnUrl)

                    End Using
                Else
                    Dim errors = ModelState.Values.SelectMany(Function(v) v.Errors)
                    MsgBox(errors(0).ErrorMessage)
                End If

                ViewBag.cod_ciu = New SelectList(CtxSeguridad.Ciudades.ToList, "cod_ciu", "tx_descrip", model.cod_ciu)

                ViewData("fechaCrea") = Now
                ViewData("USUCrea") = User.Identity.Name
                ViewData("ReturnUrl") = returnUrl
                Return View(model)
            Catch
                Return View()
            End Try
        End Function

        ' GET: Caja/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult

            Dim Cajas As Custodia.Models.CajaModel = ctxCaja.Caja.Find(id)
            If Cajas Is Nothing Then
                Return HttpNotFound()
            End If

            Dim usuario As New Custodia.Models.tbl_usuarios
            ViewBag.cod_ciu = New SelectList(CtxSeguridad.Ciudades.ToList, "cod_ciu", "tx_descrip", Cajas.cod_ciu)

            If autenticado Then
                menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
                ViewData("menu") = menuapp
            End If

            ViewData("fechaAct") = Now
            ViewData("USUAct") = User.Identity.Name

            Return View(Cajas)


        End Function

        ' POST: Caja/Edit/5
        <HttpPost()>
        Function Edit(ByVal model As Custodia.Models.CajaModel) As ActionResult
            Try
                If ModelState.IsValid Then
                    model.USUA_Actualiza = User.Identity.Name
                    model.FechaActualiza = Now
                    ctxCaja.Entry(model).State = EntityState.Modified
                    ctxCaja.SaveChanges()
                    Return RedirectToAction("Index")
                Else
                    Dim errors = ModelState.Values.SelectMany(Function(v) v.Errors)
                    MsgBox(errors(0).ErrorMessage)
                End If

                ViewData("fechaAct") = Now
                ViewData("USUAct") = User.Identity.Name

                ViewBag.cod_ciu = New SelectList(CtxSeguridad.Ciudades.ToList, "cod_ciu", "tx_descrip", model.cod_ciu)
                Return View(model)
            Catch ex As Exception
                MsgBox(ex.InnerException.Message)
                Return View()
            End Try
        End Function

        ' GET: Caja/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Caja/Delete/5
        <HttpPost()>
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
                Return RedirectToAction("Index", "Caja")
            End If
        End Function
#End Region
    End Class
End Namespace