Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Data.Entity
Imports MySql.Data.MySqlClient

Namespace Custodia.Models
    Public Class UsuariosModels
        Inherits DbContext

        Public Sub New()
            MyBase.New("segurinet")
        End Sub

        Public Property Usuarios As DbSet(Of tbl_usuarios)

    End Class

    Public Class PerfilUsuario
        Public Property login As String
        Public Property nombre As String
        Public Property rol As String
    End Class

    Public Class tbl_usuarios

        <Required()> _
        <Display(Name:="Usuario")> _
        Public Property ptx_login As String

        <Required()> _
        <DataType(DataType.Password)> _
        <Display(Name:="Password")> _
        Public Property ptx_Password As String

        Public Function valida(ByVal user As String, ByVal pass As String) As Boolean

            Dim drsel As MySqlDataReader
            Dim drapp As MySqlDataReader
            Dim int_usr As Integer
            Dim parametros As String

            Dim passcyph As String = ""
            passcyph = Data_layer.encriptar(pass)


            parametros = "tx_login:='" & user & "',tx_passwd:='" & passcyph & "',tx_estado:=1"

            drsel = consulta("count(tx_login) as existe", "tbl_usuarios", "segurinet", parametros)


            drsel.Read()

            int_usr = drsel.Item(0)


            If int_usr > 0 Then
                drsel.Dispose()

                Dim int_app As Integer = 0
                valida = True

                'Valida si tiene acceso a al applicación 

                parametros = "tx_login:='" & user & "',cod_apli:=  " & libapp.CODEAPP

                drapp = consulta("count(cod_apli) as existe", "tbl_apliusu", "segurinet", parametros)

                drapp.Read()

                int_app = drapp.Item(0)

                If int_app > 0 Then 'Tiene permisos para usar la app

                    valida = True
                Else
                    valida = False

                End If
                drapp.Dispose()


            Else
                drsel.Dispose()


                valida = False
            End If


        End Function

        Public Function menu_usu(ByVal user As String, ByRef perfil As PerfilUsuario) As String

            Dim webconf As System.Configuration.Configuration
            Dim connString As System.Configuration.ConnectionStringSettings
            Dim strconex As String
            Dim HTMLlist As String
            Dim str_sql As String


            webconf = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
            connString = webconf.ConnectionStrings.ConnectionStrings("segurinet")
            strconex = connString.ConnectionString

            Dim cnex As New MySqlConnection(strconex)
            Dim cmdsel As MySqlCommand
            Dim drsel As MySqlDataReader

            Dim mnumantenimiento As String = ""
            Dim mnuregistro As String = ""
            Dim mnuconsultas As String = ""

            HTMLlist = "<nav id=""nav"" class=""ry"">" & vbCrLf & "<ul id=""main-menu"">" & vbCrLf    'comienza a crear el menú
            perfil = New PerfilUsuario
            str_sql = "select v.Nombrerol,v.codigoMenu, v.NombreMenu, concat(tu.tx_nombres,' ' ,tu.tx_apellidos) as nombres from tbl_apliusu au inner join v_aplicacion_menu_rol v on au.cod_apli = v.codigoAplicacion and v.CodigoRol = au.cod_rol inner join tbl_usuarios tu on tu.tx_login = au.tx_login  where au.cod_apli = " & libapp.CODEAPP & " and au.tx_login  = '" & user & "' and tu.tx_estado = 1"
            cmdsel = New MySqlCommand(str_sql, cnex)

            cnex.Open()
            drsel = cmdsel.ExecuteReader()

            'Recorre las opciones y empieza a costruir el html del menú

            While drsel.Read()
                perfil.login = user
                perfil.nombre = drsel.Item("nombres")
                perfil.rol = drsel.Item("Nombrerol")

                Dim lstmant = New List(Of Integer) From {1, 2, 3, 4, 5, 6, 8}    'Opciones que pertenecen al menu de mantenimiento
                Dim lstreg = New List(Of Integer) From {7, 10, 11, 12, 13, 14}   'Opciones que pertenecen al menu de registro 
                Dim lstcons = New List(Of Integer) From {15, 16, 17, 18, 19, 20} 'Opciones que pertenecen al menu de consultas 
                Dim link_menu As String = ""

                If lstmant.Contains(drsel.Item("codigomenu")) Then   'Si el codigo esta en el listado de opciones de mantimiento 
                    Select Case drsel.Item("codigomenu")
                        Case 1
                            link_menu = "/Elemento"
                        Case 2
                            link_menu = "/SubElemento"
                    End Select
                    mnumantenimiento &= "<li><a href=""" & link_menu & """>" & drsel.Item("NombreMenu") & "</a></li>" & vbCrLf
                ElseIf lstreg.Contains(drsel.Item("codigomenu")) Then
                    mnuregistro &= "<li><a href=# >" & drsel.Item("NombreMenu") & "</a></li>" & vbCrLf
                Else
                    mnuconsultas &= "<li><a href=# >" & drsel.Item("NombreMenu") & "</a></li>" & vbCrLf
                End If

            End While

            'Termina de construir el HTML

            HTMLlist &= "<li>" & vbCrLf
            HTMLlist &= "<a href=#>Mantenimiento</a> <ul  class=""submenu"">" & mnumantenimiento & "</ul>" & vbCrLf      'Construye menu de mantenimiento 
            HTMLlist &= "</li>" & vbCrLf
            HTMLlist &= "<li>" & vbCrLf
            HTMLlist &= "<a href=#>Registro</a> <ul  class=""submenu"">" & mnuregistro & "</ul>" & vbCrLf      'Construye menu de Registro 
            HTMLlist &= "</li>" & vbCrLf
            HTMLlist &= "<li>" & vbCrLf
            HTMLlist &= "<a href=#>Consultas</a> <ul  class=""submenu"">" & mnuconsultas & "</ul>" & vbCrLf      'Construye menu de Consultas 
            HTMLlist &= "</li>" & vbCrLf


            HTMLlist &= "</nav>" & vbCrLf & "</ul>" & vbCrLf    'cierra el menú

            Return HTMLlist


        End Function

     

    End Class
End Namespace

