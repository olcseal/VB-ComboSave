Imports System.Text
Imports Newtonsoft.Json



Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FILE_NAME As String = "hash.dat"
        If IO.File.Exists(FILE_NAME) Then
            Using sr As New IO.StreamReader(FILE_NAME)
                While Not sr.EndOfStream
                    cmbHash.Items.Add(sr.ReadLine)
                End While
            End Using
        Else
            MsgBox("Error loading combobox.")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmbHash.Items.Add(cmbHash.Text)

        Dim sb As New StringBuilder()

        For Each item As Object In cmbHash.Items
            sb.AppendFormat("{0}{1}", item, Environment.NewLine)
        Next

        Dim FILE_NAME As String = "hash.dat"
        If System.IO.File.Exists(FILE_NAME) = True Then
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
            'Need to add logic to check if combobox item already exists, and if so, don't add
            objWriter.Write(sb.ToString())
            objWriter.Close()
        Else
            MsgBox("Error writing combobox data.")
        End If
    End Sub
End Class
