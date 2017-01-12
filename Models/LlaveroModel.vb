Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Data.Entity

Namespace Custodia.Models

    Public Class LlaveroModelContext
        Inherits DbContext
        Public Sub New()
            MyBase.New("Default")
        End Sub

        Public Property Llavero As DbSet(Of LlaveroModel)
    End Class

    <Table("llaveros")> _
    Public Class LlaveroModel
        <Key()> _
        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)> _
        Public Property Id As Integer

        <Required()> _
        <DataType(DataType.Text)> _
        <Display(Name:="Código")> _
        Public Property codigo As String

        <Required()> _
        <Display(Name:="Caja")> _
        Public Property Idcaja As Integer

        <Required()> _
        <Display(Name:="Oficina")> _
        Public Property cod_ofi As Integer

        <Required()> _
        <Display(Name:="Cliente")> _
        Public Property cod_cliente As Integer

        <Display(Name:="Usuario Creación")> _
        Public Property USUA_Crea As String

        <Display(Name:="Fecha de Creación")> _
        Public Property FechaCrea As DateTime

        <Display(Name:="Usuario que actualiza")> _
        <DisplayFormat(ConvertEmptyStringToNull:=False, NullDisplayText:="")> _
        Public Property USUA_Actualiza As String

        <Display(Name:="Fecha de Actualización")> _
        <DisplayFormat(ConvertEmptyStringToNull:=False, NullDisplayText:="")> _
        Public Property FechaActualiza As Nullable(Of DateTime)



    End Class
End Namespace

