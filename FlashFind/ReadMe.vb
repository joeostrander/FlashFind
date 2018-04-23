

Public Class ReadMe


    Private IsLoading As Boolean = True
    Private IsVisible As Boolean = False
    Private IsClosing As Boolean = False

    Private Sub ReadMe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName

        TextBox1.Text = "Finding files/folders can take forever when " & _
               "the folders go many levels deep.  More often than not, " & _
               "the item you need is only down a few levels.  Searching ALL " & _
               "subdirectories would take way too long." & vbCrLf & vbCrLf & _
               "Start by searching with a small depth... maybe 3 folders " & _
               "deep.  If you don't find the item you're looking for, increase " & _
               "to 4,5,etc." & vbCrLf & vbCrLf & _
               "Match Case:  Minimize the results returned.  If you know " & _
               "the exact name of the file/folder, enable this." & vbCrLf & vbCrLf & _
               "Fuzzy Search:  search for variants of a name.  ""desk"" would " & _
               "return ""desktop"",""Desktop"",""Front Desk"",etc." & vbCrLf & vbCrLf & _
               "Tip:  To find a renamed folder, search for a file that " & _
               "was in the folder.  For best results, pick one with a unique name."

        FadeIn()
        


    End Sub

    Private Sub ReadMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click
        FadeOut()
        Me.Close()
    End Sub


    Private Sub FadeIn()
        Dim iCount As Integer

        For iCount = 10 To 100 Step 10
            Me.Opacity = iCount / 100
            Me.Refresh()
            Threading.Thread.Sleep(50)
        Next
    End Sub

    Private Sub FadeOut()
        Dim iCount As Integer

        For iCount = 90 To 10 Step -10
            Me.Opacity = iCount / 100
            Me.Refresh()
            Threading.Thread.Sleep(50)
        Next

        Me.Close()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub ReadMe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.Close()
    End Sub
End Class