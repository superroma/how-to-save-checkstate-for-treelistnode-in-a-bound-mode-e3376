using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;

namespace SaveCheckStateTreeListNode
{
    class SaveCheckHelper
    {
        readonly TreeList _treeList;
        readonly DataTable _source;
        readonly int _indexCheckColumn;

        public SaveCheckHelper(TreeList treeList, string field)
        {
            _treeList = treeList;
            TreeListColumn column = _treeList.Columns.ColumnByFieldName(field);
            if (column == null)
                throw new Exception(String.Format("TreeList doesn't contain the {0} field", field));
            _source = _treeList.DataSource as DataTable;
            _indexCheckColumn = column.ColumnHandle;
            column.Visible = false;
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _treeList.AfterCheckNode += _treeList_AfterCheckNode;
            _treeList.NodesReloaded += _treeList_NodesReloaded;
        }

        void _treeList_NodesReloaded(object sender, EventArgs e)
        {
            if (_treeList.DataSource == null)
                return;
            for (int i = 0; i < _source.Rows.Count; i++)
            {
                _treeList.FindNodeByID(i).CheckState = (CheckState)_source.Rows[i][_indexCheckColumn];
            }
        }

        void _treeList_AfterCheckNode(object sender, NodeEventArgs e)
        {
            if (_treeList.DataSource == null)
                return;
            _treeList.BeginUpdate();
            _source.Rows[e.Node.Id][_indexCheckColumn] = _treeList.FindNodeByID(e.Node.Id).CheckState;
            _treeList.EndUpdate();
        }
    }
}
