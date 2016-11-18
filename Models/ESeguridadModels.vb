Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Data.Entity
Imports MySql.Data.MySqlClient

Namespace Custodia.Models
    Public Class ElementosSeguridadContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("Default")
        End Sub

        Public Property ElementoSeguridad As DbSet(Of elementosseguridadModel)

    End Class


    <Table("elementosseguridad")> _
    Public Class elementosseguridadModel

        <Key()> _
        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)> _
        Public Property Codigo As Integer

        <Required()> _
        <DataType(DataType.Text)> _
        <Display(Name:="Abreviatura")> _
        Public Property abreviatura As String

        <Required()> _
        <DataType(DataType.Text)> _
        <Display(Name:="Nombre del elemento")> _
        Public Property nombre As String

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


