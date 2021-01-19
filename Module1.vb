Module Module1

    Public P_DsList1 As New DataSet

    Public p_ordr_no, p_line_no As String
    Public p_seq As Integer
    Public p_rtn As String

    Public Function Round(ByVal pdblX As Double, ByVal keta As Integer) As Double
        Dim wkn1 As Integer
        Dim wkn2 As Double
        wkn1 = Fix(pdblX * 10 ^ keta)
        wkn2 = Fix(pdblX * 10 ^ keta * 10) / 10
        If wkn2 - wkn1 >= 0.5 Then
            Return (wkn1 + 1) / 10 ^ keta
        Else
            Return wkn1 / 10 ^ keta
        End If
    End Function

End Module
