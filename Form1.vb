Public Class Form1
    Inherits System.Windows.Forms.Form

    Dim SqlCmd1 As SqlClient.SqlCommand
    Dim DaList1 = New SqlClient.SqlDataAdapter
    Dim DsList1, WK_DsList1 As New DataSet
    Dim DtView1, WK_DtView1 As DataView

    Dim strSQL, strWH As String
    Dim Line_No, x, i, j, k, r, ln As Integer

    Dim label(99, 9) As label
    Dim cmbbox(99, 9) As ComboBox
    Dim edit(99, 9) As GrapeCity.Win.Input.Interop.Edit
    Dim num(99, 9) As GrapeCity.Win.Input.Interop.Number
    Dim datBox(99, 9) As GrapeCity.Win.Input.Interop.Date
    Dim btn(99, 9) As Button

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_city As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents txt_adrs1 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents txt_adrs2 As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents cust_lname As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents cust_fname As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Date_ent As GrapeCity.Win.Input.Interop.Date
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_phone As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents txt_shop_code As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lbl_shop As System.Windows.Forms.Label
    Friend WithEvents lbl_wrnttl As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pos As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txt_no As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents country As System.Windows.Forms.Label
    Friend WithEvents slct As GrapeCity.Win.Input.Interop.Edit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Date_ent = New GrapeCity.Win.Input.Interop.Date
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txt_city = New GrapeCity.Win.Input.Interop.Edit
        Me.txt_adrs1 = New GrapeCity.Win.Input.Interop.Edit
        Me.txt_adrs2 = New GrapeCity.Win.Input.Interop.Edit
        Me.cust_lname = New GrapeCity.Win.Input.Interop.Edit
        Me.cust_fname = New GrapeCity.Win.Input.Interop.Edit
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txt_phone = New GrapeCity.Win.Input.Interop.Edit
        Me.txt_shop_code = New GrapeCity.Win.Input.Interop.Edit
        Me.Label22 = New System.Windows.Forms.Label
        Me.lbl_shop = New System.Windows.Forms.Label
        Me.lbl_wrnttl = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pos = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.country = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.txt_no = New GrapeCity.Win.Input.Interop.Edit
        Me.Button4 = New System.Windows.Forms.Button
        Me.slct = New GrapeCity.Win.Input.Interop.Edit
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.Date_ent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_city, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_adrs1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_adrs2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cust_lname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cust_fname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_phone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_shop_code, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txt_no, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Date_ent
        '
        Me.Date_ent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Date_ent.DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
        Me.Date_ent.DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
        Me.Date_ent.DropDownCalendar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_ent.DropDownCalendar.Size = New System.Drawing.Size(186, 207)
        Me.Date_ent.ExitOnLastChar = True
        Me.Date_ent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_ent.Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
        Me.Date_ent.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Date_ent.Location = New System.Drawing.Point(792, 48)
        Me.Date_ent.MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2100, 12, 31, 23, 59, 59, 0))
        Me.Date_ent.MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
        Me.Date_ent.Name = "Date_ent"
        Me.Date_ent.ReadOnly = True
        Me.Date_ent.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
        Me.Date_ent.Size = New System.Drawing.Size(120, 25)
        Me.Date_ent.TabIndex = 2
        Me.Date_ent.TabStop = False
        Me.Date_ent.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.Date_ent.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        Me.Date_ent.Value = Nothing
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkBlue
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(704, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 24)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "申込日"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 32)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "商品名"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(128, 216)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 32)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "メーカー"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DarkBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(248, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 32)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "型  式"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DarkBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(416, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "品種コード"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkBlue
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(416, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "（部門）（品種）"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(504, 216)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 32)
        Me.Label9.TabIndex = 28
        Me.Label9.Text = "POSコード"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DarkBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(576, 216)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 32)
        Me.Label10.TabIndex = 29
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DarkBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(688, 216)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 32)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "購入日"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.DarkBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(776, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 32)
        Me.Label12.TabIndex = 32
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(672, 480)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 32)
        Me.Button2.TabIndex = 101
        Me.Button2.Text = "クリア"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkBlue
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(16, 144)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 24)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "電話番号"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.DarkBlue
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(16, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 48)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "使用者"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DarkBlue
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(72, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 24)
        Me.Label15.TabIndex = 70
        Me.Label15.Text = "（姓）"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.DarkBlue
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(72, 112)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 24)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "（名）"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DarkBlue
        Me.Label17.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(704, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 24)
        Me.Label17.TabIndex = 73
        Me.Label17.Text = "No."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_city
        '
        Me.txt_city.AllowSpace = False
        Me.txt_city.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_city.ExitOnLastChar = True
        Me.txt_city.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_city.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_city.LengthAsByte = True
        Me.txt_city.Location = New System.Drawing.Point(424, 96)
        Me.txt_city.MaxLength = 24
        Me.txt_city.Name = "txt_city"
        Me.txt_city.ReadOnly = True
        Me.txt_city.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_city.Size = New System.Drawing.Size(368, 25)
        Me.txt_city.TabIndex = 16
        Me.txt_city.TabStop = False
        Me.txt_city.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_city.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'txt_adrs1
        '
        Me.txt_adrs1.AllowSpace = False
        Me.txt_adrs1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_adrs1.ExitOnLastChar = True
        Me.txt_adrs1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_adrs1.Format = "AaK#@"
        Me.txt_adrs1.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_adrs1.LengthAsByte = True
        Me.txt_adrs1.Location = New System.Drawing.Point(424, 120)
        Me.txt_adrs1.MaxLength = 36
        Me.txt_adrs1.Name = "txt_adrs1"
        Me.txt_adrs1.ReadOnly = True
        Me.txt_adrs1.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_adrs1.Size = New System.Drawing.Size(368, 25)
        Me.txt_adrs1.TabIndex = 17
        Me.txt_adrs1.TabStop = False
        Me.txt_adrs1.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_adrs1.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'txt_adrs2
        '
        Me.txt_adrs2.AllowSpace = False
        Me.txt_adrs2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_adrs2.ExitOnLastChar = True
        Me.txt_adrs2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_adrs2.Format = "AaK#@"
        Me.txt_adrs2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txt_adrs2.LengthAsByte = True
        Me.txt_adrs2.Location = New System.Drawing.Point(424, 144)
        Me.txt_adrs2.MaxLength = 36
        Me.txt_adrs2.Name = "txt_adrs2"
        Me.txt_adrs2.ReadOnly = True
        Me.txt_adrs2.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_adrs2.Size = New System.Drawing.Size(368, 25)
        Me.txt_adrs2.TabIndex = 18
        Me.txt_adrs2.TabStop = False
        Me.txt_adrs2.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.txt_adrs2.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'cust_lname
        '
        Me.cust_lname.AllowSpace = False
        Me.cust_lname.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.cust_lname.ExitOnLastChar = True
        Me.cust_lname.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cust_lname.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.cust_lname.LengthAsByte = True
        Me.cust_lname.Location = New System.Drawing.Point(128, 88)
        Me.cust_lname.MaxLength = 15
        Me.cust_lname.Name = "cust_lname"
        Me.cust_lname.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.cust_lname.Size = New System.Drawing.Size(176, 25)
        Me.cust_lname.TabIndex = 11
        Me.cust_lname.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.cust_lname.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'cust_fname
        '
        Me.cust_fname.AllowSpace = False
        Me.cust_fname.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.cust_fname.ExitOnLastChar = True
        Me.cust_fname.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cust_fname.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.cust_fname.LengthAsByte = True
        Me.cust_fname.Location = New System.Drawing.Point(128, 112)
        Me.cust_fname.MaxLength = 15
        Me.cust_fname.Name = "cust_fname"
        Me.cust_fname.ReadOnly = True
        Me.cust_fname.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.cust_fname.Size = New System.Drawing.Size(176, 25)
        Me.cust_fname.TabIndex = 12
        Me.cust_fname.TabStop = False
        Me.cust_fname.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
        Me.cust_fname.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(776, 480)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 32)
        Me.Button3.TabIndex = 103
        Me.Button3.Text = "終 了"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DarkBlue
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(328, 96)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 24)
        Me.Label18.TabIndex = 105
        Me.Label18.Text = "市区町村名"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.DarkBlue
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(328, 120)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(96, 24)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "住所1"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.DarkBlue
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(328, 144)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(96, 24)
        Me.Label20.TabIndex = 107
        Me.Label20.Text = "住所2"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_phone
        '
        Me.txt_phone.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.txt_phone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_phone.Format = "9#"
        Me.txt_phone.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_phone.Location = New System.Drawing.Point(128, 144)
        Me.txt_phone.MaxLength = 15
        Me.txt_phone.Name = "txt_phone"
        Me.txt_phone.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_phone.Size = New System.Drawing.Size(176, 25)
        Me.txt_phone.TabIndex = 13
        '
        'txt_shop_code
        '
        Me.txt_shop_code.AllowSpace = False
        Me.txt_shop_code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_shop_code.ExitOnLastChar = True
        Me.txt_shop_code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_shop_code.Format = "9"
        Me.txt_shop_code.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_shop_code.LengthAsByte = True
        Me.txt_shop_code.Location = New System.Drawing.Point(88, 456)
        Me.txt_shop_code.MaxLength = 4
        Me.txt_shop_code.Name = "txt_shop_code"
        Me.txt_shop_code.ReadOnly = True
        Me.txt_shop_code.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_shop_code.Size = New System.Drawing.Size(64, 32)
        Me.txt_shop_code.TabIndex = 31
        Me.txt_shop_code.TabStop = False
        Me.txt_shop_code.TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
        Me.txt_shop_code.TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkBlue
        Me.Label22.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(16, 456)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 32)
        Me.Label22.TabIndex = 125
        Me.Label22.Text = "店コード"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_shop
        '
        Me.lbl_shop.BackColor = System.Drawing.Color.White
        Me.lbl_shop.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_shop.ForeColor = System.Drawing.Color.Black
        Me.lbl_shop.Location = New System.Drawing.Point(224, 456)
        Me.lbl_shop.Name = "lbl_shop"
        Me.lbl_shop.Size = New System.Drawing.Size(248, 32)
        Me.lbl_shop.TabIndex = 126
        Me.lbl_shop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_wrnttl
        '
        Me.lbl_wrnttl.BackColor = System.Drawing.Color.White
        Me.lbl_wrnttl.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wrnttl.ForeColor = System.Drawing.Color.Black
        Me.lbl_wrnttl.Location = New System.Drawing.Point(752, 432)
        Me.lbl_wrnttl.Name = "lbl_wrnttl"
        Me.lbl_wrnttl.Size = New System.Drawing.Size(104, 32)
        Me.lbl_wrnttl.TabIndex = 129
        Me.lbl_wrnttl.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.DarkBlue
        Me.Label24.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(640, 432)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 32)
        Me.Label24.TabIndex = 130
        Me.Label24.Text = "保証料合計"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.pos)
        Me.Panel1.Location = New System.Drawing.Point(8, 248)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(980, 176)
        Me.Panel1.TabIndex = 10000
        '
        'pos
        '
        Me.pos.Location = New System.Drawing.Point(0, 0)
        Me.pos.Name = "pos"
        Me.pos.Size = New System.Drawing.Size(1, 1)
        Me.pos.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkBlue
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(152, 456)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 32)
        Me.Label1.TabIndex = 10001
        Me.Label1.Text = "店舗名"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.Button1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Button1.Location = New System.Drawing.Point(552, 480)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 10002
        Me.Button1.Text = "検 索"
        '
        'country
        '
        Me.country.BackColor = System.Drawing.SystemColors.Control
        Me.country.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.country.Location = New System.Drawing.Point(224, 8)
        Me.country.Name = "country"
        Me.country.Size = New System.Drawing.Size(192, 32)
        Me.country.TabIndex = 10004
        Me.country.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.DarkBlue
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(880, 216)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(20, 32)
        Me.Label25.TabIndex = 10005
        Me.Label25.Text = "契約"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.DarkBlue
        Me.Label26.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(16, 8)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(192, 32)
        Me.Label26.TabIndex = 10006
        Me.Label26.Text = "海外データ検索"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txt_no
        '
        Me.txt_no.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.txt_no.DisabledBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.txt_no.DisabledForeColor = System.Drawing.Color.Black
        Me.txt_no.Font = New System.Drawing.Font("Arial", 11.25!)
        Me.txt_no.Format = "9A"
        Me.txt_no.HighlightText = True
        Me.txt_no.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txt_no.LengthAsByte = True
        Me.txt_no.Location = New System.Drawing.Point(752, 16)
        Me.txt_no.MaxLength = 16
        Me.txt_no.Name = "txt_no"
        Me.txt_no.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.txt_no.Size = New System.Drawing.Size(160, 24)
        Me.txt_no.TabIndex = 1
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.Enabled = False
        Me.Button4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(808, 88)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 32)
        Me.Button4.TabIndex = 10008
        Me.Button4.Text = "メモ"
        '
        'slct
        '
        Me.slct.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.slct.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.slct.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.slct.Location = New System.Drawing.Point(920, 16)
        Me.slct.MaxLength = 15
        Me.slct.Name = "slct"
        Me.slct.Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
        Me.slct.Size = New System.Drawing.Size(24, 25)
        Me.slct.TabIndex = 10012
        Me.slct.TabStop = False
        Me.slct.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(896, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 32)
        Me.Label3.TabIndex = 10013
        Me.Label3.Text = "保証期間"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 12)
        Me.ClientSize = New System.Drawing.Size(994, 525)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.slct)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txt_no)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.country)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lbl_wrnttl)
        Me.Controls.Add(Me.lbl_shop)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txt_shop_code)
        Me.Controls.Add(Me.txt_phone)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cust_fname)
        Me.Controls.Add(Me.cust_lname)
        Me.Controls.Add(Me.txt_adrs2)
        Me.Controls.Add(Me.txt_adrs1)
        Me.Controls.Add(Me.txt_city)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Date_ent)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "セーフティ5 海外データ検索"
        CType(Me.Date_ent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_city, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_adrs1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_adrs2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cust_lname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cust_fname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_phone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_shop_code, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txt_no, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Label10.Text = "購入価格" & vbCrLf & "（税込）"
        Label12.Text = "保証料" & vbCrLf & "（税抜）"

    End Sub

    '検索
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txt_no.Text = Trim(txt_no.Text)
        cust_lname.Text = Trim(cust_lname.Text)
        txt_phone.Text = Trim(txt_phone.Text)

        If txt_no.Text = Nothing And cust_lname.Text = Nothing And txt_phone.Text = Nothing Then
            MessageBox.Show("検索キーを指定してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txt_no.Focus()
        Else

re_scn:
            '保証データ_マスタ
            DsList1.Clear()
            strSQL = "SELECT Wrn_mtr.ordr_no, Wrn_mtr.cust_fname, Wrn_mtr.cust_lname, Wrn_mtr.adrs1"
            strSQL = strSQL & ", Wrn_mtr.adrs2, Wrn_mtr.city_name, Wrn_mtr.pref_code, Wrn_mtr.zip_code"
            strSQL = strSQL & ", Wrn_mtr.srch_phn, Wrn_mtr.shop_code, Wrn_mtr.entry_date, Wrn_mtr.corp_flg"
            strSQL = strSQL & ", Wrn_mtr.entry_flg, '' AS pref_name, Wrn_mtr.country"
            strSQL = strSQL & ", Shop_mtr.[店舗名(漢字)] AS shop_name"
            strSQL = strSQL & " FROM Wrn_mtr INNER JOIN"
            strSQL = strSQL & " Shop_mtr ON Wrn_mtr.shop_code = Shop_mtr.shop_code"
            strWH = " WHERE"

            If slct.Text = "1" Then
                strWH = strWH & " (Wrn_mtr.ordr_no = '" & txt_no.Text & "')"
            Else
                Dim and_F As String = "0"
                If txt_no.Text <> Nothing Then
                    strWH = strWH & " (Wrn_mtr.ordr_no LIKE '" & txt_no.Text & "%')"
                    and_F = "1"
                End If
                If cust_lname.Text <> Nothing Then
                    If and_F = "1" Then strWH = strWH & " AND"
                    strWH = strWH & " (Wrn_mtr.cust_lname LIKE '" & cust_lname.Text & "%')"
                    and_F = "1"
                End If
                If txt_phone.Text <> Nothing Then
                    If and_F = "1" Then strWH = strWH & " AND"
                    strWH = strWH & " (Wrn_mtr.srch_phn LIKE '" & txt_phone.Text & "%')"
                End If
            End If
            strSQL = strSQL & strWH
            SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
            DaList1.SelectCommand = SqlCmd1
            SqlCmd1.CommandTimeout = 600
            DB_OPEN()
            r = DaList1.Fill(DsList1, "wrn_mtr")
            DB_CLOSE()

            Select Case r
                Case Is = 0
                    MessageBox.Show("該当するデータはありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case Is = 1
                    DtView1 = New DataView(DsList1.Tables("wrn_mtr"), "", "", DataViewRowState.CurrentRows)
                    Call disp_main()
                Case Is <= 100
                    P_DsList1.Clear()
                    strSQL = "SELECT Wrn_mtr.ordr_no, RTRIM(Wrn_mtr.cust_lname) + ' ' + RTRIM(Wrn_mtr.cust_fname) AS cust_name"
                    strSQL = strSQL & ", RTRIM(Wrn_mtr.srch_phn) AS srch_phn, Wrn_sub.prch_date, Wrn_sub.cont_flg"
                    strSQL = strSQL & ", Shop_mtr.[店舗名(漢字)] AS shop_name, RTRIM(Wrn_mtr.country) AS country"
                    strSQL = strSQL & " FROM Wrn_mtr INNER JOIN"
                    strSQL = strSQL & " Wrn_sub ON Wrn_mtr.ordr_no = Wrn_sub.ordr_no INNER JOIN"
                    strSQL = strSQL & " Shop_mtr ON Wrn_mtr.shop_code = Shop_mtr.shop_code"
                    strSQL = strSQL & strWH
                    SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
                    DaList1.SelectCommand = SqlCmd1
                    SqlCmd1.CommandTimeout = 600
                    DB_OPEN()
                    DaList1.Fill(P_DsList1, "List")
                    DB_CLOSE()

                    p_ordr_no = Nothing
                    Me.Enabled = False

                    Dim List As New List
                    List.ShowDialog()

                    Me.Enabled = True
                    txt_no.Text = p_ordr_no
                    slct.Text = "1"

                    GoTo re_scn
                Case Else
                    MessageBox.Show("検索結果が100件を超えています。条件を再度設定してください。", "検索結果", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Select

        End If
    End Sub

    'クリア
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'CANCEL
        Call initial()
        txt_no.Focus()
    End Sub

    '終了
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Application.Exit()
    End Sub

    'メインデータ表示
    Sub disp_main()

        country.Text = DtView1(0)("country")
        txt_no.Text = Trim(DtView1(0)("ordr_no"))
        Date_ent.Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(Year(DtView1(0)("entry_date")), Month(DtView1(0)("entry_date")), Format(DtView1(0)("entry_date"), "dd"), 0, 0, 0))
        cust_lname.Text = Trim(DtView1(0)("cust_lname"))
        cust_fname.Text = Trim(DtView1(0)("cust_fname"))
        txt_phone.Text = RTrim(DtView1(0)("srch_phn"))
        txt_city.Text = Trim(DtView1(0)("city_name"))
        txt_adrs1.Text = Trim(DtView1(0)("adrs1"))
        If Not IsDBNull(DtView1(0)("adrs2")) Then
            txt_adrs2.Text = Trim(DtView1(0)("adrs2"))
        Else
            txt_adrs2.Text = Nothing
        End If
        txt_shop_code.Text = DtView1(0)("shop_code")
        lbl_shop.Text = Trim(DtView1(0)("shop_name"))

        'memo
        Button4.Enabled = True
        strSQL = "SELECT * FROM Memo WHERE (ordr_no = '" & txt_no.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN()
        DaList1.Fill(DsList1, "Memo")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("Memo"), "", "", DataViewRowState.CurrentRows)
        If DtView1.Count <> 0 Then
            Button4.BackColor = System.Drawing.Color.Yellow
            p_rtn = "1"
        Else
            Button4.BackColor = System.Drawing.SystemColors.Control
            p_rtn = "0"
        End If

        Call disp_sub()

    End Sub

    'サブデータ表示
    Sub disp_sub()
        Panel1.Controls.Clear()

        '保証データ_サブ
        strSQL = "SELECT Wrn_sub.ordr_no, Wrn_sub.line_no, Wrn_sub.seq, Wrn_sub.prch_price, Wrn_sub.prch_tax"
        strSQL = strSQL & ", Wrn_sub.prch_date, Wrn_sub.item_cat_code, V_Cat_mtr.[品種名(漢字)] AS cat_name"
        strSQL = strSQL & ", Wrn_sub.bend_code, Wrn_sub.brnd_name, Wrn_sub.model_name, Wrn_sub.pos_code"
        strSQL = strSQL & ", Wrn_sub.wrn_fee, Wrn_sub.cont_flg, Wrn_sub.cxl_date, Wrn_sub.total_loss_flg"
        strSQL = strSQL & ", total_loss.total_loss_date, xa.ordr_no AS ivc, Wrn_sub.wrn_prod"
        strSQL = strSQL & " FROM Wrn_sub LEFT OUTER JOIN"
        strSQL = strSQL & " V_Cat_mtr ON Wrn_sub.item_cat_code = V_Cat_mtr.cd12 LEFT OUTER JOIN"
        strSQL = strSQL & " (SELECT ordr_no, line_no, seq FROM Wrn_ivc GROUP BY ordr_no, line_no, seq HAVING (ordr_no = '" & txt_no.Text & "')) xa ON"
        strSQL = strSQL & " Wrn_sub.ordr_no = xa.ordr_no AND"
        strSQL = strSQL & " Wrn_sub.line_no = xa.line_no AND Wrn_sub.seq = xa.seq LEFT OUTER JOIN"
        strSQL = strSQL & " total_loss ON Wrn_sub.ordr_no = total_loss.ordr_no AND Wrn_sub.line_no = total_loss.line_no"
        strSQL = strSQL & " WHERE (Wrn_sub.ordr_no = '" & txt_no.Text & "')"
        SqlCmd1 = New SqlClient.SqlCommand(strSQL, cnsqlclient)
        DaList1.SelectCommand = SqlCmd1
        SqlCmd1.CommandTimeout = 600
        DB_OPEN()
        DaList1.Fill(DsList1, "Wrn_sub")
        DB_CLOSE()

        DtView1 = New DataView(DsList1.Tables("Wrn_sub"), "", "line_no", DataViewRowState.CurrentRows)
        For Line_No = 0 To DtView1.Count - 1

            '商品名
            x = 0
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(0, 25 * Line_No + pos.Location.Y)
            label(Line_No, x).Name = "lbl_item1"
            label(Line_No, x).Size = New System.Drawing.Size(120, 24)
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(Line_No, x).Tag = Line_No
            If Not IsDBNull(DtView1(Line_No)("cat_name")) Then label(Line_No, x).Text = Trim(DtView1(Line_No)("cat_name"))
            Panel1.Controls.Add(label(Line_No, x))

            'メーカー
            x = 3
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(120, 25 * Line_No + pos.Location.Y)
            label(Line_No, x).Name = "lbl_vdr"
            label(Line_No, x).Size = New System.Drawing.Size(120, 24)
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            label(Line_No, x).Text = RTrim(DtView1(Line_No)("brnd_name"))
            Panel1.Controls.Add(label(Line_No, x))

            '型式
            x = 0
            edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
            edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
            edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            edit(Line_No, x).Format = "AaK#@"
            edit(Line_No, x).MaxLength = 20
            edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Off
            edit(Line_No, x).Location = New System.Drawing.Point(240, 25 * Line_No + pos.Location.Y)
            edit(Line_No, x).Tag = Line_No
            edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
            edit(Line_No, x).Size = New System.Drawing.Size(168, 24)
            edit(Line_No, x).TabIndex = 102
            edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Left
            edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
            edit(Line_No, x).Text = RTrim(DtView1(Line_No)("model_name"))
            Panel1.Controls.Add(edit(Line_No, x))

            '品種コード(部門)
            x = 1
            edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
            edit(Line_No, x).AllowSpace = False
            edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
            edit(Line_No, x).ExitOnLastChar = True
            edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            edit(Line_No, x).Format = "9"
            edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
            edit(Line_No, x).LengthAsByte = True
            edit(Line_No, x).Location = New System.Drawing.Point(408, 25 * Line_No + pos.Location.Y)
            edit(Line_No, x).MaxLength = 2
            edit(Line_No, x).Tag = Line_No
            edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
            edit(Line_No, x).Size = New System.Drawing.Size(44, 24)
            edit(Line_No, x).TabIndex = 103
            edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
            edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
            edit(Line_No, x).Text = Mid(DtView1(Line_No)("item_cat_code"), 1, 2)
            Panel1.Controls.Add(edit(Line_No, x))

            '品種コード(品種)
            x = 2
            edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
            edit(Line_No, x).AllowSpace = False
            edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
            edit(Line_No, x).ExitOnLastChar = True
            edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            edit(Line_No, x).Format = "9"
            edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
            edit(Line_No, x).LengthAsByte = True
            edit(Line_No, x).Location = New System.Drawing.Point(452, 25 * Line_No + pos.Location.Y)
            edit(Line_No, x).MaxLength = 2
            edit(Line_No, x).Tag = Line_No
            edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
            edit(Line_No, x).Size = New System.Drawing.Size(44, 24)
            edit(Line_No, x).TabIndex = 104
            edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
            edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
            edit(Line_No, x).Text = Mid(DtView1(Line_No)("item_cat_code"), 3, 2)
            Panel1.Controls.Add(edit(Line_No, x))

            'POSコード
            x = 3
            edit(Line_No, x) = New GrapeCity.Win.Input.Interop.Edit
            edit(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
            edit(Line_No, x).ExitOnLastChar = True
            edit(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            edit(Line_No, x).Format = "9"
            edit(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
            edit(Line_No, x).LengthAsByte = True
            edit(Line_No, x).Location = New System.Drawing.Point(496, 25 * Line_No + pos.Location.Y)
            edit(Line_No, x).MaxLength = 8
            edit(Line_No, x).Tag = Line_No
            edit(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
            edit(Line_No, x).Size = New System.Drawing.Size(72, 24)
            edit(Line_No, x).TabIndex = 105
            edit(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
            edit(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
            edit(Line_No, x).Text = DtView1(Line_No)("pos_code")
            Panel1.Controls.Add(edit(Line_No, x))

            '購入金額
            x = 0
            num(Line_No, x) = New GrapeCity.Win.Input.Interop.Number
            num(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
            num(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0.000", "", "", "-", "", "", "")
            num(Line_No, x).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
            num(Line_No, x).DropDownCalculator.Size = New System.Drawing.Size(216, 214)
            num(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            num(Line_No, x).Format = New GrapeCity.Win.Input.Interop.NumberDisplayFormat("##,###,##0.000", "", "", "-", "", "", "")
            num(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
            num(Line_No, x).Location = New System.Drawing.Point(568, 25 * Line_No + pos.Location.Y)
            num(Line_No, x).MaxValue = New Decimal(New Integer() {99999999.0, 0, 0, 0})
            num(Line_No, x).MinValue = New Decimal(New Integer() {99999999.0, 0, 0, -2147483648})
            num(Line_No, x).Tag = Line_No
            num(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear})
            num(Line_No, x).Size = New System.Drawing.Size(112, 24)
            num(Line_No, x).TabIndex = 106
            num(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
            num(Line_No, x).Value = DtView1(Line_No)("prch_price") + DtView1(Line_No)("prch_tax")
            Panel1.Controls.Add(num(Line_No, x))

            '購入日
            x = 0
            datBox(Line_No, x) = New GrapeCity.Win.Input.Interop.Date
            datBox(Line_No, x).BorderStyle = System.Windows.Forms.BorderStyle.None
            datBox(Line_No, x).DisplayFormat = New GrapeCity.Win.Input.Interop.DateDisplayFormat("yyyy/MM/dd", "", "")
            datBox(Line_No, x).DropDown = New GrapeCity.Win.Input.Interop.DropDown(GrapeCity.Win.Input.Interop.ButtonPosition.Inside, True, GrapeCity.Win.Input.Interop.Visibility.NotShown, System.Windows.Forms.FlatStyle.System)
            datBox(Line_No, x).ExitOnLastChar = True
            datBox(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            datBox(Line_No, x).Format = New GrapeCity.Win.Input.Interop.DateFormat("yyyy/MM/dd", "", "")
            datBox(Line_No, x).ImeMode = System.Windows.Forms.ImeMode.Disable
            datBox(Line_No, x).Location = New System.Drawing.Point(680, 25 * Line_No + pos.Location.Y)
            datBox(Line_No, x).MaxDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(2100, 12, 31, 23, 59, 59, 0))
            datBox(Line_No, x).MinDate = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(1900, 1, 1, 0, 0, 0, 0))
            datBox(Line_No, x).Shortcuts = New GrapeCity.Win.Input.Interop.ShortcutCollection(New String() {"F2", "F5"}, New GrapeCity.Win.Input.Interop.KeyActions() {GrapeCity.Win.Input.Interop.KeyActions.Clear, GrapeCity.Win.Input.Interop.KeyActions.Now})
            datBox(Line_No, x).Size = New System.Drawing.Size(88, 24)
            datBox(Line_No, x).TabIndex = 107
            datBox(Line_No, x).TextHAlign = GrapeCity.Win.Input.Interop.AlignHorizontal.Center
            datBox(Line_No, x).TextVAlign = GrapeCity.Win.Input.Interop.AlignVertical.Middle
            datBox(Line_No, x).Tag = Line_No
            'datBox(Line_No, x).Value = New GrapeCity.Win.Input.Interop.DateTimeEx(New Date(Year(DtView1(Line_No)("prch_date")), Month(DtView1(Line_No)("prch_date")), Format(DtView1(Line_No)("prch_date"), "dd"), 0, 0, 0, 0))
            Panel1.Controls.Add(datBox(Line_No, x))

            '保証料
            x = 1
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(768, 25 * Line_No + pos.Location.Y)
            label(Line_No, x).Tag = Line_No
            label(Line_No, x).Size = New System.Drawing.Size(104, 24)
            label(Line_No, x).TabIndex = 108
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleRight
            label(Line_No, x).Text = Format(DtView1(Line_No)("wrn_fee"), "##,##0.000")
            If DtView1(Line_No)("wrn_fee") > 0 Then
                label(Line_No, x).ForeColor = System.Drawing.SystemColors.WindowText
            Else
                label(Line_No, x).ForeColor = System.Drawing.Color.Red
            End If
            Panel1.Controls.Add(label(Line_No, x))

            '契約状況
            x = 3
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(872, 25 * Line_No + pos.Location.Y)
            label(Line_No, x).Tag = Line_No
            label(Line_No, x).Size = New System.Drawing.Size(20, 24)
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            label(Line_No, x).Text = DtView1(Line_No)("cont_flg")
            If Not IsDBNull(DtView1(Line_No)("total_loss_flg")) Then
                If DtView1(Line_No)("total_loss_flg") = "1" Then
                    label(Line_No, x).Text = "Z"
                End If
            End If
            Panel1.Controls.Add(label(Line_No, x))

            '2014/06/11 保証期間表示追加 ADD START
            '保証期間
            x = 3
            label(Line_No, x) = New Label
            label(Line_No, x).BackColor = System.Drawing.Color.White
            label(Line_No, x).Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            label(Line_No, x).ForeColor = System.Drawing.Color.Black
            label(Line_No, x).Location = New System.Drawing.Point(892, 25 * Line_No + pos.Location.Y)
            label(Line_No, x).Tag = Line_No
            label(Line_No, x).Size = New System.Drawing.Size(40, 24)
            label(Line_No, x).TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            label(Line_No, x).Text = DtView1(Line_No)("wrn_prod")
            Panel1.Controls.Add(label(Line_No, x))
            '2014/06/11 保証期間表示追加 ADD END

            '事故ボタン
            If Not IsDBNull(DtView1(Line_No)("ivc")) Then
                x = 0
                btn(Line_No, x) = New Button
                btn(Line_No, x).Enabled = True
                btn(Line_No, x).BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
                '2014/06/11 保証期間表示追加 MOD START
                '                btn(Line_No, x).Location = New System.Drawing.Point(892, 25 * Line_No + pos.Location.Y)
                btn(Line_No, x).Location = New System.Drawing.Point(932, 25 * Line_No + pos.Location.Y)
                '2014/06/11 保証期間表示追加 MOD END
                btn(Line_No, x).Size = New System.Drawing.Size(40, 26)
                btn(Line_No, x).Text = "事故"
                btn(Line_No, x).Tag = Line_No
                Panel1.Controls.Add(btn(Line_No, x))
                AddHandler btn(Line_No, x).Click, AddressOf Button_Click
            End If

            '行番号
            x = 2
            label(Line_No, x) = New Label
            label(Line_No, x).Text = DtView1(Line_No)("line_no")

            'SEQ
            x = 5
            label(Line_No, x) = New Label
            label(Line_No, x).Text = DtView1(Line_No)("seq")
        Next

        lbl_wrnttl.Text = Format(0, "##,##0.000")

        For i = 0 To Line_No - 1
            lbl_wrnttl.Text = Format(CDec(lbl_wrnttl.Text) + CDec(label(i, 1).Text), "##,##0.000")
        Next

        Line_No = DtView1.Count - 1

    End Sub

    '**********************************
    '選択ボタン
    '**********************************
    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim btn As Button
        btn = DirectCast(sender, Button)

        p_ordr_no = txt_no.Text
        p_line_no = label(btn.Tag, 2).Text
        p_seq = label(btn.Tag, 5).Text

        Dim frmform2 As New Form2
        frmform2.ShowDialog()

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '**********************************
    'メモボタン
    '**********************************
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        p_ordr_no = txt_no.Text

        Dim frmform3 As New Form3
        frmform3.ShowDialog()

        If p_rtn = "1" Then
            Button4.BackColor = System.Drawing.Color.Yellow
        Else
            Button4.BackColor = System.Drawing.SystemColors.Control
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    '画面の初期化
    Sub initial()

        country.Text = Nothing
        txt_no.Text = Nothing
        slct.Text = Nothing
        Date_ent.Text = "____/__/__"
        cust_lname.Text = Nothing
        cust_fname.Text = Nothing
        txt_phone.Text = Nothing
        txt_city.Text = Nothing
        txt_adrs1.Text = Nothing
        txt_adrs2.Text = Nothing
        txt_shop_code.Text = Nothing
        lbl_shop.Text = Nothing
        lbl_wrnttl.Text = Format(0, "##,##0.000")

        Panel1.Controls.Clear()
        Button4.Enabled = False        'memo
        Button4.BackColor = System.Drawing.SystemColors.Control
    End Sub
End Class
