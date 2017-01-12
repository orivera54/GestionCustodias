Imports System.Web.Mvc

Namespace Controllers
    Public Class LlaveController
        Inherits System.Web.Mvc.Controller

        Private CtxSeguridad As Seguridad.SeguridadContext = New Seguridad.SeguridadContext
        Private CtxCaja As Custodia.Models.CajaModelsContext = New Custodia.Models.CajaModelsContext

        ' GET: Llave
        Function Index() As ActionResult
            Return View()
        End Function

        ' GET: Llave/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: Llave/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Llave/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Llave/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Llave/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: Llave/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: Llave/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace