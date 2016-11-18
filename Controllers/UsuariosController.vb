Imports System.Diagnostics.CodeAnalysis
Imports System.Security.Principal
Imports System.Transactions
Imports System.Web.Routing
Imports DotNetOpenAuth.AspNet
Imports Microsoft.Web.WebPages.OAuth
Imports WebMatrix.WebData


Public Class UsuariosController
    Inherits System.Web.Mvc.Controller

    '
    ' GET: /Usuarios/Ingresar

    Function Ingresar() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Usuarios/Ingresar

    <HttpPost()>
    Public Function Ingresar(ByVal login As Custodia.Models.tbl_usuarios, ByVal returnUrl As String) As ActionResult

        If ModelState.IsValid Then
            If login.valida(login.ptx_login, login.ptx_Password) Then
                FormsAuthentication.SetAuthCookie(login.ptx_login, False)
                menuapp = login.menu_usu(login.ptx_login, SCL.PerfilUsr)   'Extrae el menu para dibujarlo 
                autenticado = True
                Return RedirectToAction("Index", "Home")
            Else
                ModelState.AddModelError("", "Usuario o contraseña incorrecta")
            End If
        End If

        Return View(login)

    End Function

    '
    ' POST: /Usuarios/LogOff

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Public Function LogOff() As ActionResult
        FormsAuthentication.SignOut()
        autenticado = False
        menuapp = ""

        Return RedirectToAction("Index", "Home")
    End Function

End Class