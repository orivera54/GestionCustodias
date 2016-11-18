Imports System.ComponentModel
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

    End Class

    <Table("tbl_oficinas")> _
    Public Class OficinaModel

        <Key()> _
        <DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)> _
        Public Property cod_ofi As Integer

        <Display(Name:="Nombre")> _
        Public Property tx_descrip As String


    End Class
End Namespace

