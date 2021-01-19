Module Module2
    Public cnsqlclient As New System.Data.SqlClient.SqlConnection

    Public Function DB_OPEN() As Boolean
        Dim sr As System.io.StreamReader = New System.IO.StreamReader("best_wrn_intl.ini")
        Dim line As String
        Dim source As String
        Dim catalog As String
        Dim line_len As Integer
        Dim eq_pos As Integer
        Dim line_key As String
        ' Read and display the lines from the file until the end 
        ' of the file is reached.
        Do
            line = sr.ReadLine()
            line_len = Len(line)
            If line_len = 0 Then
            Else
                eq_pos = InStr(1, line, "=", 1)
                line_key = Mid(line, 1, eq_pos - 1)
                If line_key = "source" Then
                    source = Mid(line, eq_pos + 1, line_len - eq_pos)
                Else
                End If
                If line_key = "catalog" Then
                    catalog = Mid(line, eq_pos + 1, line_len - eq_pos)
                Else
                End If
            End If
        Loop Until line Is Nothing
        sr.Close()
        DB_OPEN = False
        '*****  �ڑ���������쐬���Đڑ����J�n����  *****
        cnsqlclient.ConnectionString = "integrated security=SSPI;data source=" & source & ";" & _
                                       "persist security info=False;initial catalog=" & catalog
        Try
            '*****  Connection���ڑ�����Ă��邩�`�F�b�N  *****
            If cnsqlclient.State = ConnectionState.Closed Then
                cnsqlclient.Open()
            End If
        Catch
            MsgBox(Err.Description, 16, "�ڑ��G���[")
            DB_OPEN = False
            Exit Function
        End Try

        DB_OPEN = True

    End Function

    Public Sub DB_CLOSE()
        '�ڑ����I������
        cnsqlclient.Close()
    End Sub
End Module
