Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraTreeList
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.XtraTreeList.Columns

Namespace SaveCheckStateTreeListNode
    Friend Class SaveCheckHelper
        Private ReadOnly _treeList As TreeList
        Private ReadOnly _source As DataTable
        Private ReadOnly _indexCheckColumn As Integer

        Public Sub New(ByVal treeList As TreeList, ByVal field As String)
            _treeList = treeList
            Dim column As TreeListColumn = _treeList.Columns.ColumnByFieldName(field)
            If column Is Nothing Then
                Throw New Exception(String.Format("TreeList doesn't contain the {0} field", field))
            End If
            _source = TryCast(_treeList.DataSource, DataTable)
            _indexCheckColumn = column.ColumnHandle
            column.Visible = False
            SubscribeEvents()
        End Sub

        Private Sub SubscribeEvents()
            AddHandler _treeList.AfterCheckNode, AddressOf _treeList_AfterCheckNode
            AddHandler _treeList.NodesReloaded, AddressOf _treeList_NodesReloaded
        End Sub

        Private Sub _treeList_NodesReloaded(ByVal sender As Object, ByVal e As EventArgs)
            If _treeList.DataSource Is Nothing Then
                Return
            End If
            For i As Integer = 0 To _source.Rows.Count - 1
                _treeList.FindNodeByID(i).CheckState = CType(_source.Rows(i)(_indexCheckColumn), CheckState)
            Next i
        End Sub

        Private Sub _treeList_AfterCheckNode(ByVal sender As Object, ByVal e As NodeEventArgs)
            If _treeList.DataSource Is Nothing Then
                Return
            End If
            _treeList.BeginUpdate()
            _source.Rows(e.Node.Id)(_indexCheckColumn) = _treeList.FindNodeByID(e.Node.Id).CheckState
            _treeList.EndUpdate()
        End Sub
    End Class
End Namespace
