﻿Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Globalization
Imports System.Data.Entity

Namespace Seguridad
    Public Class SeguridadContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("segurinet")
        End Sub

        Public Property Oficinas As DbSet(Of OficinaModel)
        Public Property Ciudades As DbSet(Of CiudadModel)
        Public Property Clientes As DbSet(Of ClientesModel)

    End Class

    <Table("tbl_oficinas")> _
    Public Class OficinaModel

        <Key()> _
        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)> _
        Public Property cod_ofi As Integer

        <Display(Name:="Nombre")> _
        Public Property tx_descrip As String

        <Display(Name:="Cliente")> _
        Public Property cod_cliente As String


    End Class

    <Table("tbl_ciudades")> _
    Public Class CiudadModel

        <Key()> _
       <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)> _
        Public Property cod_ciu As Integer

        <Display(Name:="Ciudad")> _
        Public Property tx_descrip As String

        <Display(Name:="Pais")>
        Public Property cod_pai As Integer

    End Class

    <Table("tbl_clientes")> _
    Public Class ClientesModel

        <Key()> _
        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)> _
        Public Property cod_cliente As Integer

        <Display(Name:="Cliente")> _
        Public Property tx_descrip As String

        <Display(Name:="Estado")>
        Public Property tx_estado As Integer

    End Class
End Namespace

