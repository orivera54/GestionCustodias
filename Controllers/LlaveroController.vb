Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Transactions
Imports System.Web.Routing
Imports DotNetOpenAuth.AspNet
Imports Microsoft.Web.WebPages.OAuth
Imports WebMatrix.WebData
Imports System.Data.Entity
Imports System.Web.Mvc

Namespace Controllers
    Public Class LlaveroController
        Inherits System.Web.Mvc.Controller

        Private ctxLlavero As Custodia.Models.LlaveroModelContext = New Custodia.Models.LlaveroModelContext
        Private CtxSeguridad As Seguridad.SeguridadContext = New Seguridad.SeguridadContext
        Private CtxCaja As Custodia.Models.CajaModelsContext = New Custodia.Models.CajaModelsContext


        ' GET: Llavero
        Function Index() As ActionResult
            Dim usuario As New Custodia.Models.tbl_usuarios
            Dim llaveros As New List(Of Custodia.Models.LlaveroModel)

            If autenticado Then
                menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
                ViewData("menu") = menuapp
            End If


            Return View(ctxLlavero.Llavero.ToList())
        End Function

        ' GET: Llavero/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: Llavero/Create
        Function Create(ByVal returnurl As String) As ActionResult
            Dim usuario As New Custodia.Models.tbl_usuarios

            If autenticado Then
                menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
                ViewData("menu") = menuapp
            End If

            ViewBag.Idcaja = New SelectList(CtxCaja.Caja.ToList, "codigo", "descripcion")
            ViewBag.cod_ofi = New SelectList(CtxSeguridad.Oficinas.ToList, "cod_ofi", "tx_descrip")
            ViewBag.cod_cliente = New SelectList(CtxSeguridad.Clientes.ToList, "cod_cliente", "tx_descrip")


            ViewData("fechaCrea") = Now
            ViewData("USUCrea") = User.Identity.Name
            ViewData("ReturnUrl") = returnurl
            Return View()

        End Function

        ' POST: Llavero/Create
        <HttpPost()>
        Function Create(ByVal model As Custodia.Models.LlaveroModel, ByVal returnUrl As String) As ActionResult
            Try
                If (ModelState.IsValid) Then
                    Using DBLlavero As New Custodia.Models.LlaveroModelContext
                        model.USUA_Crea = User.Identity.Name
                        model.FechaCrea = Now

                        DBLlavero.Llavero.Add(New Custodia.Models.LlaveroModel With {.cod_ofi = model.cod_ofi, .Idcaja = model.Idcaja, .codigo = model.codigo, .USUA_Crea = model.USUA_Crea, .FechaCrea = model.FechaCrea})
                        DBLlavero.SaveChanges()

                        Return RedirectToLocal(returnUrl)

                    End Using
                Else
                    Dim errors = ModelState.Values.SelectMany(Function(v) v.Errors)
                    MsgBox(errors(0).ErrorMessage)
                End If

                ViewBag.cod_ofi = New SelectList(CtxSeguridad.Oficinas.ToList, "cod_ofi", "tx_descrip", model.cod_ofi)
                ViewBag.Idcaja = New SelectList(CtxCaja.Caja.ToList, "codigo", "descripcion", model.Idcaja)
                ViewBag.cod_cliente = New SelectList(CtxSeguridad.Clientes.ToList, "cod_cliente", "tx_descrip", model.cod_cliente)

                ViewData("fechaCrea") = Now
                ViewData("USUCrea") = User.Identity.Name
                ViewData("ReturnUrl") = returnUrl
                Return View(model)
            Catch
                Return View()
            End Try
        End Function

        ' GET: Llavero/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Dim Llaveros As Custodia.Models.LlaveroModel = ctxLlavero.Llavero.Find(id)
            If Llaveros Is Nothing Then
                Return HttpNotFound()
            End If

            Dim usuario As New Custodia.Models.tbl_usuarios

            If autenticado Then
                menuapp = usuario.menu_usu(SCL.PerfilUsr.login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
                ViewData("menu") = menuapp
            End If

            ViewData("fechaAct") = Now
            ViewData("USUAct") = User.Identity.Name
            ViewBag.cod_ofi = New SelectList(CtxSeguridad.Oficinas.ToList, "cod_ofi", "tx_descrip", Llaveros.cod_ofi)
            ViewBag.Idcaja = New SelectList(CtxCaja.Caja.ToList, "codigo", "descripcion", Llaveros.Idcaja)
            ViewBag.cod_cliente = New SelectList(CtxSeguridad.Clientes.ToList, "cod_cliente", "tx_descrip", Llaveros.cod_cliente)

            Return View(Llaveros)
        End Function

        ' POST: Llavero/Edit/5
        <HttpPost()>
        Function Edit(ByVal model As Custodia.Models.LlaveroModel) As ActionResult
            Try
                If ModelState.IsValid Then
                    model.USUA_Actualiza = User.Identity.Name
                    model.FechaActualiza = Now
                    ctxLlavero.Entry(model).State = EntityState.Modified
                    ctxLlavero.SaveChanges()
                    Return RedirectToAction("Index")
                Else
                    Dim errors = ModelState.Values.SelectMany(Function(v) v.Errors)
                    MsgBox(errors(0).ErrorMessage)
                End If

                ViewData("fechaAct") = Now
                ViewData("USUAct") = User.Identity.Name

                ViewBag.cod_ofi = New SelectList(CtxSeguridad.Oficinas.ToList, "cod_ofi", "tx_descrip", model.cod_ofi)
                ViewBag.Idcaja = New SelectList(CtxCaja.Caja.ToList, "codigo", "descripcion", model.Idcaja)
                ViewBag.cod_cliente = New SelectList(CtxSeguridad.Clientes.ToList, "cod_cliente", "tx_descrip", model.cod_cliente)

                Return View(model)
            Catch ex As Exception
                MsgBox(ex.InnerException.Message)
                Return View()
            End Try
        End Function

        ' GET: Llavero/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Llavero/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

      
        Public Function TraeOficina(ByVal id As Integer) As ActionResult

            ' TODO: Add TraeOficina  logic here
            Dim cod_cliente As Integer = id
            Dim dictOfi As IDictionary(Of String, String) = New Dictionary(Of String, String)()
            Dim Oficinas = CtxSeguridad.Oficinas.Where(Function(m) m.cod_cliente = cod_cliente)

            For Each Oficina In Oficinas
                dictOfi.Add(Oficina.cod_ofi.ToString(), Oficina.tx_descrip)
            Next

            Return Json(dictOfi, JsonRequestBehavior.AllowGet)

        End Function
     
#Region "Helpers"
        Private Function RedirectToLocal(ByVal returnUrl As String) As ActionResult
            If Url.IsLocalUrl(returnUrl) Then
                Return Redirect(returnUrl)
            Else
                Return RedirectToAction("Index", "Llavero")
            End If
        End Function

        
#End Region
    End Class
End Namespace