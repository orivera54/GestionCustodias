Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Data.Entity


Namespace Custodia.Models
    Public Class CajaModelsContext
        Inherits DbContext
        Public Sub New()
            MyBase.New("Default")
        End Sub

        Public Property Caja As DbSet(Of CajaModel)

    End Class

    <Table("Cajas")> _
    Public Class CajaModel

        <Key()> _
        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)> _
        Public Property Codigo As Integer

        <Required()> _
        <DataType(DataType.Text)> _
        <Display(Name:="Código de Caja")> _
        Public Property codcaja As String

        <Required()> _
        <Display(Name:="Ciudad")> _
        Public Property cod_ciu As Integer

        <Required()> _
        <DataType(DataType.Text)> _
        <Display(Name:="Dirección")> _
        Public Property direccion As String

        <DataType(DataType.MultilineText)> _
        <Display(Name:="Descripción")> _
        Public Property descripcion As String

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
