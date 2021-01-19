Public Class Form2
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL As String
    Dim i As Integer

#Region " Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h "

    Public Sub New()
        MyBase.New()

        ' ���̌Ăяo���� Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
        InitializeComponent()

        ' InitializeComponent() �Ăяo���̌�ɏ�������ǉ����܂��B

    End Sub

    ' Form �́A�R���|�[�l���g�ꗗ�Ɍ㏈�������s���邽�߂� dispose ���I�[�o�[���C�h���܂��B
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    Private components As System.ComponentModel.IContainer

    ' ���� : �ȉ��̃v���V�[�W���́AWindows �t�H�[�� �f�U�C�i�ŕK�v�ł��B
    'Windows �t�H�[�� �f�U�C�i���g���ĕύX���Ă��������B  
    ' �R�[�h �G�f�B�^���g���ĕύX���Ȃ��ł��������B
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button98 = New System.Windows.Forms.Button
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button98.Location = New System.Drawing.Point(1056, 472)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(104, 32)
        Me.Button98.TabIndex = 104
        Me.Button98.Text = "�߂�"
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionBackColor = System.Drawing.Color.DarkBlue
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.LinkColor = System.Drawing.Color.DarkBlue
        Me.DataGrid1.Location = New System.Drawing.Point(8, 24)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.SelectionBackColor = System.Drawing.Color.DarkBlue
        Me.DataGrid1.Size = New System.Drawing.Size(1160, 440)
        Me.DataGrid1.TabIndex = 105
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(1178, 509)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("�l�r �o�S�V�b�N", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "���̗���"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        strSQL = "SELECT Wrn_ivc.ordr_no, Wrn_ivc.line_no, Wrn_ivc.seq, Wrn_ivc.close_date, Wrn_ivc.seq_sub, Wrn_ivc.FLD007"
        strSQL = strSQL & ", xa.CLS_CODE_NAME, Wrn_ivc.FLD011, Wrn_ivc.FLD012, Wrn_ivc.FLD014, Wrn_ivc.FLD028, Wrn_ivc.FLD031"
        strSQL = strSQL & ", Wrn_ivc.FLD005, Wrn_ivc.FLD020, Wrn_ivc.FLD021, Wrn_ivc.Cancel_date, '' AS close_date_2, '' AS FLD028_2"
        strSQL = strSQL & " FROM Wrn_ivc LEFT OUTER JOIN"
        strSQL = strSQL & " (SELECT CLS_CODE, RTRIM(CLS_CODE_NAME) AS CLS_CODE_NAME FROM CLS_CODE WHERE (CLS_NO = '002')) xa"
        strSQL = strSQL & "  ON Wrn_ivc.FLD007 = xa.CLS_CODE COLLATE Japanese_CI_AS"
        strSQL = strSQL & " WHERE (Wrn_ivc.ordr_no = '" & p_ordr_no & "')"
        strSQL = strSQL & " AND (Wrn_ivc.line_no = '" & p_line_no & "')"
        strSQL = strSQL & " AND (Wrn_ivc.seq = " & p_seq & ")"
        strSQL = strSQL & " ORDER BY Wrn_ivc.close_date, Wrn_ivc.seq_sub"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "Wrn_ivc")

        DtView1 = New DataView(DsList1.Tables("Wrn_ivc"), "", "close_date,seq_sub", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            For i = 0 To DtView1.Count - 1
                DtView1(i)("close_date_2") = Format(DtView1(i)("close_date"), "yyyy/MM")
                DtView1(i)("FLD028_2") = Format(DtView1(i)("FLD028"), "###,##0.00")
            Next
        End If

        '�e�[�u���X�^�C�����쐬���ăf�[�^�O���b�h�ɒǉ�����
        Dim ts As DataGridTableStyle
        ts = New DataGridTableStyle
        ts.MappingName = "Wrn_ivc"

        DataGrid1.TableStyles.Clear()

        Dim clmStyle1, clmStyle2, clmStyle3, clmStyle4, clmStyle5, clmStyle6, clmStyle7, clmStyle8, clmStyle9, clmStyle10, clmStyle11 As DataGridColumnStyle
        ts.GridColumnStyles.Clear()
        '��X�^�C�����쐬���ăe�[�u���X�^�C���ɒǉ�����

        clmStyle1 = New DataGridTextBoxColumn
        With clmStyle1
            .MappingName = "close_date_2"
            .HeaderText = "���ߌ�"
            .Alignment = HorizontalAlignment.Center
            .Width = 70
        End With
        ts.GridColumnStyles.Add(clmStyle1)

        clmStyle2 = New DataGridTextBoxColumn
        With clmStyle2
            .MappingName = "FLD005"
            .NullText = ""
            .HeaderText = "���̓�"
            .Alignment = HorizontalAlignment.Center
            .Width = 100
        End With
        ts.GridColumnStyles.Add(clmStyle2)

        clmStyle3 = New DataGridTextBoxColumn
        With clmStyle3
            .MappingName = "CLS_CODE_NAME"
            .NullText = ""
            .HeaderText = "���̏�"
            .Width = 100
        End With
        ts.GridColumnStyles.Add(clmStyle3)

        clmStyle4 = New DataGridTextBoxColumn
        With clmStyle4
            .MappingName = "FLD011"
            .NullText = ""
            .HeaderText = "�C����t�X"
            .Alignment = HorizontalAlignment.Center
            .Width = 100
        End With
        ts.GridColumnStyles.Add(clmStyle4)

        clmStyle5 = New DataGridTextBoxColumn
        With clmStyle5
            .MappingName = "FLD012"
            .NullText = ""
            .HeaderText = "�C�������X"
            .Alignment = HorizontalAlignment.Center
            .Width = 100
        End With
        ts.GridColumnStyles.Add(clmStyle5)

        clmStyle6 = New DataGridTextBoxColumn
        With clmStyle6
            .MappingName = "FLD014"
            .NullText = ""
            .HeaderText = "�C���`�[�ԍ�"
            .Width = 120
        End With
        ts.GridColumnStyles.Add(clmStyle6)

        clmStyle11 = New DataGridTextBoxColumn
        With clmStyle11
            .MappingName = "FLD020"
            .NullText = ""
            .HeaderText = "�����ԍ�"
            .Width = 120
        End With
        ts.GridColumnStyles.Add(clmStyle11)

        clmStyle7 = New DataGridTextBoxColumn
        With clmStyle7
            .MappingName = "FLD021"
            .NullText = ""
            .HeaderText = "�C����t��"
            .Alignment = HorizontalAlignment.Center
            .Width = 100
        End With
        ts.GridColumnStyles.Add(clmStyle7)

        clmStyle8 = New DataGridTextBoxColumn
        With clmStyle8
            .MappingName = "FLD028_2"
            .NullText = ""
            .HeaderText = "�����z"
            .Alignment = HorizontalAlignment.Right
            .Width = 80
        End With
        ts.GridColumnStyles.Add(clmStyle8)

        clmStyle9 = New DataGridTextBoxColumn
        With clmStyle9
            .MappingName = "FLD031"
            .NullText = ""
            .HeaderText = "������"
            .Alignment = HorizontalAlignment.Center
            .Width = 100
        End With
        ts.GridColumnStyles.Add(clmStyle9)

        clmStyle10 = New DataGridTextBoxColumn
        With clmStyle10
            .MappingName = "Cancel_date"
            .NullText = ""
            .HeaderText = "�����"
            .Alignment = HorizontalAlignment.Center
            .Width = 100
        End With
        ts.GridColumnStyles.Add(clmStyle10)

        ts.ReadOnly = True
        DataGrid1.TableStyles.Add(ts)
        DataGrid1.SetDataBinding(DsList1, "Wrn_ivc")

    End Sub

    '�߂�{�^��
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        Me.Close()
    End Sub
End Class
