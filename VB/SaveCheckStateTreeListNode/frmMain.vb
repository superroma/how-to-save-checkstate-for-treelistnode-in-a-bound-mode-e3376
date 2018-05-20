Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms

Namespace SaveCheckStateTreeListNode
    Partial Public Class frmMain
        Inherits Form

        Private ReadOnly source As New DataTable()
        Private Const resetTxt As String = "Reset"
        Private Const setupTxt As String = "Setup"
        Private Const nameCheckColumn As String = "Check"

        Public Sub New()
            InitializeComponent()
            FillTable()
            treeList1.DataSource = source
            treeList1.KeyFieldName = "ID"
            treeList1.ParentFieldName = "ParentID"
            If treeList1.DataSource IsNot Nothing Then
                btnReset.Text = resetTxt
            Else
                btnReset.Text = setupTxt
            End If
            treeList1.ExpandAll()
            Dim tempVar As New SaveCheckHelper(treeList1, nameCheckColumn)
        End Sub

        Private Sub FillTable()
            source.Columns.Add("ID")
            source.Columns.Add("ParentID")
            source.Columns.Add("FirstName")
            source.Columns.Add("LastName")
            source.Columns.Add("Age")
            source.Columns.Add("Address")
            source.Columns.Add(nameCheckColumn, GetType(CheckState))
            Dim rnd As New Random()
            Const countRows As Integer = 20
            For i As Integer = 0 To countRows - 1
                source.Rows.Add(New Object() { i, rnd.Next(countRows - 1), "FirstName" & i, "LastName" & i, i + 20, "Address" & i, CheckState.Unchecked })
            Next i
        End Sub

        Private Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReset.Click
            If btnReset.Text = resetTxt Then
                treeList1.DataSource = Nothing
                btnReset.Text = setupTxt
            Else
                treeList1.DataSource = source
                btnReset.Text = resetTxt
            End If
            treeList1.ExpandAll()
        End Sub
    End Class
End Namespace
