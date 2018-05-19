using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SaveCheckStateTreeListNode
{
    public partial class frmMain : Form
    {
        readonly DataTable source = new DataTable();
        const string resetTxt = "Reset";
        const string setupTxt = "Setup";
        const string nameCheckColumn = "Check";

        public frmMain()
        {
            InitializeComponent();
            FillTable();
            treeList1.DataSource = source;
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "ParentID";
            if (treeList1.DataSource != null)
                btnReset.Text = resetTxt;
            else
                btnReset.Text = setupTxt;
            treeList1.ExpandAll();
            new SaveCheckHelper(treeList1, nameCheckColumn);
        }

        void FillTable()
        {
            source.Columns.Add("ID");
            source.Columns.Add("ParentID");
            source.Columns.Add("FirstName");
            source.Columns.Add("LastName");
            source.Columns.Add("Age");
            source.Columns.Add("Address");
            source.Columns.Add(nameCheckColumn, typeof(CheckState));
            Random rnd = new Random();
            const int countRows = 20;
            for (int i = 0; i < countRows; i++)
            {
                source.Rows.Add(new object[] { i, rnd.Next(countRows - 1), "FirstName" + i, "LastName" + i, i + 20, "Address" + i, CheckState.Unchecked });
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (btnReset.Text == resetTxt)
            {
                treeList1.DataSource = null;
                btnReset.Text = setupTxt;
            }
            else
            {
                treeList1.DataSource = source;
                btnReset.Text = resetTxt;
            }
            treeList1.ExpandAll();
        }
    }
}
