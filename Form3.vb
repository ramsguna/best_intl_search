Public Class Form3
    Inherits System.Windows.Forms.Form
    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1 As New DataSet
    Dim DtView1 As DataView

    Dim strSQL As String
    Dim i As Integer

#Region " Windows フォーム デザイナで生成されたコード "

    Public Sub New()
        MyBase.New()

        ' この呼び出しは Windows フォーム デザイナで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後に初期化を追加します。

    End Sub

    ' Form は、コンポーネント一覧に後処理を実行するために dispose をオーバーライドします。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    ' メモ : 以下のプロシージャは、Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使って変更してください。  
    ' コード エディタを使って変更しないでください。
    Friend WithEvents Button98 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Edit1 As GrapeCity.Win.Input.Interop.Edit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button98 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Edit1 = New GrapeCity.Win.Input.Interop.Edit
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button98
        '
        Me.Button98.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button98.Location = New System.Drawing.Point(728, 280)
        Me.Button98.Name = "Button98"
        Me.Button98.Size = New System.Drawing.Size(104, 32)
        Me.Button98.TabIndex = 105
        Me.Button98.Text = "戻る"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(608, 280)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 106
        Me.Button1.Text = "更新"
        '
        'Edit1
        '
        Me.Edit1.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.Edit1.LengthAsByte = True
        Me.Edit1.Location = New System.Drawing.Point(16, 8)
        Me.Edit1.MaxLength = 1000
        Me.Edit1.Multiline = True
        Me.Edit1.Name = "Edit1"
        Me.Edit1.ScrollBarMode = GrapeCity.Win.Input.Interop.ScrollBarMode.Automatic
        Me.Edit1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Edit1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.Edit1.Size = New System.Drawing.Size(816, 264)
        Me.Edit1.TabIndex = 0
        Me.Edit1.Text = "Edit1"
        '
        'Form3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.ClientSize = New System.Drawing.Size(848, 319)
        Me.Controls.Add(Me.Edit1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button98)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "メモ"
        CType(Me.Edit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        strSQL = "SELECT * FROM Memo WHERE (ordr_no = '" & p_ordr_no & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        DB_OPEN()
        SqlCmd1.CommandTimeout = 600
        DaList1.Fill(DsList1, "Memo")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("Memo"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Edit1.Text = DtView1(i)("memo")
        Else
            Edit1.Text = Nothing
        End If

    End Sub

    '更新ボタン
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If DtView1.Count <> 0 Then
            If Trim(Edit1.Text) = Nothing Then
                strSQL = "DELETE FROM Memo WHERE (ordr_no = '" & p_ordr_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
                p_rtn = "0"
            Else
                strSQL = "UPDATE Memo"
                strSQL = strSQL & " SET memo = '" & Trim(Edit1.Text) & "'"
                strSQL = strSQL & " WHERE (ordr_no = '" & p_ordr_no & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
                p_rtn = "1"
            End If
        Else
            If Trim(Edit1.Text) = Nothing Then
                p_rtn = "0"
            Else
                strSQL = "INSERT INTO Memo (ordr_no, memo)"
                strSQL = strSQL & " VALUES ('" & p_ordr_no & "', '" & Trim(Edit1.Text) & "')"
                DB_OPEN()
                SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                SqlCmd1.CommandTimeout = 600
                SqlCmd1.ExecuteNonQuery()
                DB_CLOSE()
                p_rtn = "1"
            End If
        End If
        Me.Close()
    End Sub

    '戻るボタン
    Private Sub Button98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button98.Click
        Me.Close()
    End Sub
End Class
