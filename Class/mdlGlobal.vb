
Imports MySql.Data.MySqlClient
Imports System.Convert

Module mdlGlobal
    Public SCL As New libapp
    Public menuapp As String = ""
    Public autenticado As Boolean = False

    Private Function conexion(ByVal StringConnName As String) As String

        Dim webconf As System.Configuration.Configuration
        Dim connString As System.Configuration.ConnectionStringSettings
        Dim strconex As String

        webconf = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~")
        connString = webconf.ConnectionStrings.ConnectionStrings(StringConnName)
        strconex = connString.ConnectionString


        Return strconex

    End Function

    Private Function quita_marca(ByVal cadena As String, ByVal marca As String) As String


        'Recorre la cadena e ignora los caracteres iniciales y finales según el parametro marca 

        Dim longcad As Integer = cadena.Length - 1
        Dim resultado As String = ""

        For i = 0 To longcad
            If i = 0 Or i = longcad Then
                If Not cadena.Substring(i, 1) = marca Then
                    resultado &= cadena.Substring(i, 1)
                End If
            Else
                resultado &= cadena.Substring(i, 1)
            End If
        Next

        Return resultado


    End Function

    Public Function Consulta(ByVal campos As String, ByVal tabla As String, ByVal conexionstr As String, Optional ByVal condicion As String = "") As MySql.Data.MySqlClient.MySqlDataReader

        'La condición debera venir de la forma "valor1:='xxx',valor2:=#dd/mm/yyyy#,valor3:=00000,valor4:=$00000.00$" para de esta forma usar parametros y no construir manualmente el sql por problemas de seguridad 
        'Para identificar el tipo de dato verifica el primer caracter si es numero el tipo es integer, si es ' es texto, si es # es fecha 


        Dim str_sql As String = ""    'Cadena SQL
        Dim str_cond As String = " "  'Condicion SQL
        Dim scm_consulta As MySqlCommand
        Dim scc_conn As MySqlConnection
        Dim dr_reader As MySqlDataReader
        Dim str_conn As String

        Try
            str_sql &= "SELECT " & campos & " FROM " & tabla


            str_conn = conexion(conexionstr)
            scc_conn = New MySqlConnection(str_conn)

            'Construye la parte de la condicion del SQL

            If Not Trim(condicion) = "" Then   'Verifica si se envia condicion 
                Dim arr_param = Split(condicion, ",")   'Almacenamos los parametros en un arreglo 
                Dim int_and As Integer = 0

                str_cond &= "WHERE "

                For Each cond In arr_param

                    Dim param_cond = Split(cond, ":=", , CompareMethod.Text)

                    If int_and > 0 Then
                        str_cond &= " AND "
                    End If

                    'Crea la condicion para el  SQL 
                    str_cond &= " " & param_cond(0) & "=@" & param_cond(0)
                    int_and = 1
                Next

                str_sql &= " " & str_cond

            End If

            scm_consulta = New MySqlCommand(str_sql, scc_conn)
            scc_conn.Open()

            'Construye los parametros en el caso de que venga el parametro de condicion   

            If Not Trim(condicion) = "" Then   'Verifica si se envia condicion 
                Dim arr_param = Split(condicion, ",")   'Almacenamos los parametros en un arreglo 

                For Each cond In arr_param

                    Dim param_cond = Split(cond, ":=", , CompareMethod.Text)
                    Dim parametro As String = "@" & param_cond(0).ToString


                    'Identifica el tipo de dato 

                    Select Case param_cond(1).Substring(0, 1)
                        Case Chr(39)
                            'Es una cadena de texto
                            scm_consulta.Parameters.Add(parametro, MySqlDbType.VarChar)
                            scm_consulta.Parameters(parametro).Value = quita_marca(param_cond(1), Chr(39))
                        Case Chr(34)
                            'Es una cadena de texto
                            scm_consulta.Parameters.Add(parametro, MySqlDbType.VarChar)
                            scm_consulta.Parameters(parametro).Value = quita_marca(param_cond(1), Chr(39))
                        Case "#"
                            'Verifica si el caracter final tambien es #
                            If param_cond(1).Substring(param_cond(1).Length - 1, 1) = "#" Then
                                'Es una fecha 
                                scm_consulta.Parameters.Add(parametro, MySqlDbType.DateTime)
                                scm_consulta.Parameters(parametro).Value = DateTime.Parse(quita_marca(param_cond(1), "#"))
                            End If
                        Case "$"
                            'Verifica si el caracter final tambien es #
                            If param_cond(1).Substring(param_cond(1).Length - 1, 1) = "$" Then
                                'Es un decimal 
                                scm_consulta.Parameters.Add(parametro, MySqlDbType.Decimal)
                                scm_consulta.Parameters(parametro).Value = ToDecimal(quita_marca(param_cond(1), "$"))
                            End If
                        Case Else
                            scm_consulta.Parameters.Add(parametro, MySqlDbType.Int32)
                            scm_consulta.Parameters(parametro).Value = ToInt32(param_cond(1))
                    End Select

                Next
            End If

            'Crea el reader para enviarlo como respuesta 
            dr_reader = scm_consulta.ExecuteReader


            'scc_conn.Close()

            Return dr_reader
        Catch ex As Exception
            MsgBox("Error al ejecutar la consulta. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "SCL - Error ")
            dr_reader = Nothing

            ' scc_conn.Close()

            Return dr_reader
        End Try


    End Function

   

End Module
