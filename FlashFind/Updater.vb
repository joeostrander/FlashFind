Imports System.Net
Imports System.IO
Imports System.Net.Cache

Public Class Updater
    Public Sub CheckForUpdates(ByVal strUpdateURL As String, ByVal IsStartupCheck As Boolean)
        Dim strTitle As String = "Update Check"
        Dim strAppPath As String = Application.ExecutablePath
        Dim strExeName As String = Path.GetFileName(strAppPath)
        Dim strRemoteURL As String = strUpdateURL & strExeName

        Try
            Dim request As HttpWebRequest = HttpWebRequest.Create(strUpdateURL & Application.ProductName & ".txt")
            request.CachePolicy = New HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore)

            Using response As HttpWebResponse = request.GetResponse
                If response.StatusCode = HttpStatusCode.OK Then
                    Dim sr As StreamReader = New StreamReader(response.GetResponseStream)
                    Dim strLatestVersion As String = sr.ReadLine
                    sr.Close()
                    Try
                        Dim ver_latest As New Version(strLatestVersion)
                        Dim ver_current As New Version(Application.ProductVersion)

                        If ver_latest > ver_current Then
                            If MsgBox("An update is available!" & vbCrLf & vbCrLf & _
                                      "Current Version:" & vbTab & ver_current.ToString & vbCrLf & "Latest Version:" & vbTab & ver_latest.ToString & vbCrLf & vbCrLf & _
                                      "Would you like to update now?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, strTitle) = MsgBoxResult.Yes Then
                                UpdateNow(strAppPath, strRemoteURL)
                            End If
                        Else
                            If IsStartupCheck = False Then MsgBox("No updates are available.", MsgBoxStyle.Information, strTitle)
                        End If

                    Catch ex As Exception
                        If IsStartupCheck = False Then MsgBox("Error checking versions." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, strTitle)
                    End Try
                End If
                response.Close()
            End Using
        Catch wex As WebException
            Dim resp As HttpWebResponse = DirectCast(wex.Response, HttpWebResponse)
            If wex.Status = WebExceptionStatus.NameResolutionFailure Then
                If IsStartupCheck = False Then MsgBox("Could not connect to update server.", MsgBoxStyle.Exclamation, strTitle)
            ElseIf wex.Status = WebExceptionStatus.ProtocolError And resp IsNot Nothing Then
                If resp.StatusCode = HttpStatusCode.NotFound Then
                    If IsStartupCheck = False Then MsgBox("Could not find version information on update server.", MsgBoxStyle.Exclamation, strTitle)
                Else
                    If IsStartupCheck = False Then MsgBox(wex.Message, MsgBoxStyle.Exclamation, strTitle)
                End If
            Else
                If IsStartupCheck = False Then MsgBox(wex.Message, MsgBoxStyle.Exclamation, strTitle)
            End If

        Catch ex As Exception
            If IsStartupCheck = False Then MsgBox("An error occurred:  " & ex.Message, MsgBoxStyle.Exclamation, strTitle)
        End Try





    End Sub

    Public Sub UpdateNow(ByVal strLocalFile As String, ByVal strRemoteURL As String)

        If IO.File.Exists(strLocalFile & ".OLD") Then IO.File.Delete(strLocalFile & ".OLD")
        IO.File.Move(strLocalFile, strLocalFile & ".OLD")

        Dim myURI As Uri = New Uri(strRemoteURL)
        Dim wc As WebClient = New WebClient
        wc.DownloadFile(myURI, strLocalFile)

        Form1.boolTrayExit = True

        Application.Restart()


    End Sub

    Public Sub DeleteOldFiles()
        Try
            Dim strOldFile As String = Application.ExecutablePath & ".OLD"
            If IO.File.Exists(strOldFile) Then IO.File.Delete(strOldFile)
        Catch ex As Exception
            'Do nothing
        End Try
    End Sub
End Class
