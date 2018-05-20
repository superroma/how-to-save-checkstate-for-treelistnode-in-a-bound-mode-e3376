Namespace SaveCheckStateTreeListNode
    Partial Public Class frmMain
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
            Me.btnReset = New System.Windows.Forms.Button()
            CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' treeList1
            ' 
            Me.treeList1.Dock = System.Windows.Forms.DockStyle.Top
            Me.treeList1.Location = New System.Drawing.Point(0, 0)
            Me.treeList1.Name = "treeList1"
            Me.treeList1.OptionsView.ShowCheckBoxes = True
            Me.treeList1.Size = New System.Drawing.Size(643, 367)
            Me.treeList1.TabIndex = 0
            ' 
            ' btnReset
            ' 
            Me.btnReset.Location = New System.Drawing.Point(556, 373)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(75, 23)
            Me.btnReset.TabIndex = 1
            Me.btnReset.Text = "button1"
            Me.btnReset.UseVisualStyleBackColor = True
            ' 
            ' frmMain
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(643, 404)
            Me.Controls.Add(Me.btnReset)
            Me.Controls.Add(Me.treeList1)
            Me.Name = "frmMain"
            Me.Text = "Form1"
            CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private treeList1 As DevExpress.XtraTreeList.TreeList
        Private WithEvents btnReset As System.Windows.Forms.Button
    End Class
End Namespace

