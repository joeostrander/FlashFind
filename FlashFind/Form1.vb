Imports System.IO
Imports System.ComponentModel
Imports System.Threading
Imports System.Text.RegularExpressions
Imports Microsoft.Win32
Imports System.Runtime.InteropServices

Public Class Form1

#Region "ICONSTUFF"
    Private Structure SHFILEINFO
        Public hIcon As IntPtr            ' : icon
        Public iIcon As Integer           ' : icondex
        Public dwAttributes As Integer    ' : SFGAO_ flags
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    <DllImport("user32.dll", SetLastError:=True)> _
Private Shared Function DestroyIcon(ByVal hIcon As IntPtr) As Boolean
    End Function

    Private Declare Auto Function SHGetFileInfo Lib "shell32.dll" _
            (ByVal pszPath As String, _
             ByVal dwFileAttributes As Integer, _
             ByRef psfi As SHFILEINFO, _
             ByVal cbFileInfo As Integer, _
             ByVal uFlags As Integer) As IntPtr

    Private Const SHGFI_ICON = &H100
    Private Const SHGFI_SMALLICON = &H1
    Private Const SHGFI_LARGEICON = &H0    ' Large icon



#End Region


    'TODO
    'icons still a bit glitchy

    Private Const MOD_CONTROL As Integer = &H2 'Control key
    Private Const MOD_SHIFT As Integer = &H4 'Shift key
    Private Const WM_HOTKEY As Integer = &H312

    Dim MaxDepth As Integer
    Dim intFoldersScanned As Integer
    Dim intFoldersMatched As Integer
    Dim strSearchString As String
    Dim strSearchString_ESCAPED As String
    Dim strWindowTitle As String = "Flash Find"
    Dim RootFolder As String
    Dim dtStartTime As DateTime
    Dim ElapsedTime As TimeSpan
    Dim SearchMode As String = "Folder"

    Private UPD As New Updater
    Private strUpdateURL As String = "http://pcsupp.msp.graco.com/apps/"

    Private dictExtensions As New Dictionary(Of String, String)

    ' This delegate enables asynchronous calls for setting
    ' the properties on the main form controls
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Delegate Sub AddListViewItemCallback(ByVal lvi As ListViewItem)

    Private demoThread As Thread = Nothing

    Private Declare Function RegisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    Private Declare Function UnregisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer) As Integer
    Public boolTrayExit As Boolean = False
    Private boolStartup As Boolean = False

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_HOTKEY Then ShowMe()
        MyBase.WndProc(m) 'Never Forget This
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim ret As Integer = MsgBox("Are you sure you want to exit?" & vbCrLf & vbCrLf & _
        '                            "(Click No to minimize to the Notification area)", _
        '                            MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Exit " & Application.ProductName & "?")
        If boolTrayExit = False Then
            'If ret <> vbYes Then
            e.Cancel = True
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        UPD.DeleteOldFiles()
        UPD.CheckForUpdates(strUpdateURL, True)

        Me.Text = strWindowTitle
        NotifyIcon1.Text = strWindowTitle

        ComboBox1.Text = "3"
        Dim args() As String = Environment.GetCommandLineArgs

        LabelStatus.Text = ""

        ClearToolStrip()

        If args.Length > 1 Then
            Dim strPath As String = args(1)
            If IO.Directory.Exists(strPath) Then
                TextBoxRootFolder.Text = strPath
            End If
        End If

        RegisterHotKey(Me.Handle, 9, MOD_CONTROL + MOD_SHIFT, Keys.F) 'Ctrl + Shift + F
        CheckForStartup()
    End Sub


    Private Sub CheckForStartup()
        On Error Resume Next

        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

        Dim appRegKey As RegistryKey
        appRegKey = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, True)

        If IsNothing(appRegKey) Then
            'Create the key
            Registry.CurrentUser.CreateSubKey("Software\" & Application.ProductName)
            appRegKey = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, True)
            If IsNothing(appRegKey) Then
                regKey.Close()
                Exit Sub
            End If

            'Ask user if they want it to launch auto...
            If MsgBox("Launch " & Application.ProductName & " at Startup?", _
                            MsgBoxStyle.Question + MsgBoxStyle.YesNo, _
                            Application.ProductName) = MsgBoxResult.Yes Then
                boolStartup = True
            Else
                boolStartup = False
            End If

        Else
            'Get Current Value and set it in the interface
            boolStartup = appRegKey.GetValue("RunAtStartup", False)
        End If

        regKey.Close()
        appRegKey.Close()

        SaveRegistrySettings()

    End Sub

    Private Sub SaveRegistrySettings()
        On Error Resume Next

        Dim regKey As RegistryKey
        regKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

        Dim appRegKey As RegistryKey
        appRegKey = Registry.CurrentUser.OpenSubKey("Software\" & Application.ProductName, True)

        'Save the response
        appRegKey.SetValue("RunAtStartup", boolStartup, RegistryValueKind.DWord)

        'If boolStartup=true, set to run at startup
        If boolStartup = True Then
            regKey.SetValue(Application.ProductName, Application.ExecutablePath)
        Else
            regKey.DeleteValue(Application.ProductName)
        End If

        RunAtStartupToolStripMenuItemTRAY.Checked = boolStartup
        RunAtStartupToolStripMenuItem1.Checked = boolStartup

        regKey.Close()
        appRegKey.Close()

    End Sub


    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click
        StartSearch()
    End Sub


    Private Sub StartSearch()

        'File Name
        'Location
        'Size
        'Type
        'Modified
        'Created
        'Last Accessed



        'On Error Resume Next

        If TextBoxRootFolder.Text = "" Then
            MsgBox("Please enter a valid Root Folder.", MsgBoxStyle.Exclamation, strWindowTitle)
            TextBoxRootFolder.Focus()
            Exit Sub
        End If

        RootFolder = TextBoxRootFolder.Text
        Dim DI As DirectoryInfo = New DirectoryInfo(RootFolder)
        If Not DI.Exists Then
            MsgBox("Please enter a valid Root Folder.", MsgBoxStyle.Exclamation, strWindowTitle)
            TextBoxRootFolder.Focus()
            Exit Sub
        End If


        If TextBoxSearchString.Text = "" Then
            'MsgBox("Please enter a " & SearchMode & " Name.", MsgBoxStyle.Exclamation, strWindowTitle)
            'TextBoxSearchString.Focus()
            'Exit Sub
            TextBoxSearchString.Text = "*"
        End If

        Dim strComboMaxDepth As String = ComboBox1.Text

        If InStr(strComboMaxDepth, "+") Or IsNumeric(strComboMaxDepth) = False Then
            MaxDepth = 9999
        Else
            MaxDepth = CInt(strComboMaxDepth)
        End If

        'nIndex = 0
        'ImageListSmall.Images.Clear()
        ListView1.Items.Clear()
        TextBoxErrors.Clear()
        intFoldersScanned = 0
        intFoldersMatched = 0
        ClearToolStrip()
        ButtonStart.Enabled = False
        ButtonStop.Enabled = True
        Timer1.Start()


        'background thread
        Me.demoThread = New Thread( _
            New ThreadStart(AddressOf Me.ThreadProcSafe))
        Me.demoThread.Start()



    End Sub

    Private Sub UpdateStatusStrip()
        ElapsedTime = Now.Subtract(dtStartTime)

        Dim NewText As String

        ' It's on a different thread, so use Invoke.
        Dim d As New SetTextCallback(AddressOf SetTextTSStatusLabel1)
        NewText = "Folders Scanned:  " & intFoldersScanned
        Me.Invoke(d, New Object() {[NewText]})

        Dim e As New SetTextCallback(AddressOf SetTextTSStatusLabel2)
        NewText = SearchMode & "s Matched:  " & intFoldersMatched
        Me.Invoke(e, New Object() {[NewText]})

        Dim f As New SetTextCallback(AddressOf SetTextTSStatusLabel3)
        NewText = "Elapsed Time:  " & FormatTimeSpan(ElapsedTime)
        Me.Invoke(f, New Object() {[NewText]})


    End Sub



    Private Sub FindFolders(ByVal DirInfo As DirectoryInfo)

        If demoThread.IsAlive = False Then Exit Sub
        Try

            Dim strCurrentDir As String = DirInfo.FullName

            Debug.WriteLine(strCurrentDir)

            If Me.LabelStatus.InvokeRequired Then
                ' It's on a different thread, so use Invoke.
                Dim d As New SetTextCallback(AddressOf SetText)
                Dim NewText As String = "Scanning:  " & strCurrentDir
                Me.Invoke(d, New Object() {[NewText]})
            End If


            'Debug.WriteLine(Mid(strCurrentDir, Len(RootFolder) + 1))
            Dim arrPath As Array = Split(Mid(strCurrentDir, Len(RootFolder) + 1), "\")

            intFoldersScanned += 1
            UpdateStatusStrip()


            If SearchMode = "File" Then
                ' SEARCH FOR FILE
                For Each myFile As FileInfo In DirInfo.GetFiles
                    Try
                        Dim boolAddMe As Boolean = False
                        If InStr(strSearchString, "*") Then
                            boolAddMe = Regex.IsMatch(myFile.Name, "^" & strSearchString_ESCAPED & "$", RegexOptions.IgnoreCase)
                        Else
                            If myFile.Name.ToLower = strSearchString.ToLower Then boolAddMe = True
                        End If

                        

            If boolAddMe = True Then
                If TextBoxContainingText.Text <> "" Then
                    'Read the file
                    boolAddMe = FileContainsText(myFile.FullName, TextBoxContainingText.Text)
                End If
            End If


            If boolAddMe = True Then
                intFoldersMatched += 1
                If Me.ListView1.InvokeRequired Then


                    ''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim hImgSmall As IntPtr  'The handle to the system image list.
                    Dim shinfo As SHFILEINFO
                    shinfo = New SHFILEINFO()


                    shinfo.szDisplayName = New String(Chr(0), 260)
                    shinfo.szTypeName = New String(Chr(0), 80)

                    Dim strFileExtension As String = myFile.Extension.ToLower
                    If strFileExtension = "" Then strFileExtension = "???"

                                Dim imageKey As String = strFileExtension
                                If imageKey = ".exe" Then
                                    imageKey = myFile.FullName
                                End If


                                If Not ImageListSmall.Images.ContainsKey(imageKey) Then
                                    'Use this to get the small icon.
                                    hImgSmall = SHGetFileInfo(myFile.FullName, FileAttribute.Normal, shinfo, _
                                                Marshal.SizeOf(shinfo), _
                                                SHGFI_ICON Or SHGFI_SMALLICON)
                                    Dim myIcon As System.Drawing.Icon
                                    myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon)
                                    ImageListSmall.Images.Add(imageKey, myIcon)
                                    Debug.WriteLine(imageKey)
                                    DestroyIcon(shinfo.hIcon)
                                    DestroyIcon(shinfo.iIcon)
                                End If



                    ' It's on a different thread, so use Invoke.

                                Dim e As New AddListViewItemCallback(AddressOf ListViewAdd)
                    Dim lvi As ListViewItem
                    Try
                                    lvi = New ListViewItem(myFile.Name, ImageListSmall.Images.IndexOfKey(imageKey))
                    Catch ex As Exception
                                    lvi = New ListViewItem(myFile.Name)
                                    Debug.WriteLine(ex.Message)
                    End Try


                    lvi.SubItems.Add(myFile.DirectoryName)
                    'lvi.SubItems.Add(StrFormatByteSize(myFile.Length))
                    lvi.SubItems.Add(StrFormatKiloBytes(myFile.Length))

                    Dim strFileType As String
                    If dictExtensions.ContainsKey(myFile.Extension) Then
                        strFileType = dictExtensions.Item(myFile.Extension)
                    Else
                        strFileType = GetFileType(myFile.Extension)
                        dictExtensions.Add(myFile.Extension, strFileType)
                    End If

                    lvi.SubItems.Add(strFileType)


                    lvi.SubItems.Add(myFile.LastWriteTime)
                    lvi.SubItems.Add(myFile.CreationTime)
                    lvi.SubItems.Add(myFile.LastAccessTime)
                    'Size
                    'Type
                    'Modified
                    'Created
                    'Accessed

                    Me.Invoke(e, New Object() {lvi})
                End If
                UpdateStatusStrip()
            End If
        Catch ex As Exception
            Debug.WriteLine(myFile.Name & "..." & ex.Message)
        End Try

                Next
            Else
                Try
                    ' SEARCH FOR FOLDER
                    Dim boolAddMe As Boolean = False
                    If InStr(strSearchString, "*") Then
                        boolAddMe = Regex.IsMatch(DirInfo.Name, "^" & strSearchString_ESCAPED & "$", RegexOptions.IgnoreCase)
                    Else
                        If DirInfo.Name.ToLower = strSearchString.ToLower Then boolAddMe = True
                    End If


                    If boolAddMe = True Then
                        intFoldersMatched += 1
                        If Me.ListView1.InvokeRequired Then
                            Dim hImgSmall As IntPtr  'The handle to the system image list.
                            Dim shinfo As SHFILEINFO
                            shinfo = New SHFILEINFO()


                            shinfo.szDisplayName = New String(Chr(0), 260)
                            shinfo.szTypeName = New String(Chr(0), 80)

                            If Not ImageListSmall.Images.ContainsKey("FILE_FOLDER_ICON") Then
                                'Use this to get the small icon.
                                hImgSmall = SHGetFileInfo("", FileAttribute.Directory, shinfo, _
                                            Marshal.SizeOf(shinfo), _
                                            SHGFI_ICON Or SHGFI_SMALLICON)
                                Dim myIcon As System.Drawing.Icon
                                myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon)
                                ImageListSmall.Images.Add("FILE_FOLDER_ICON", myIcon)
                                DestroyIcon(shinfo.hIcon)
                                DestroyIcon(shinfo.iIcon)
                            End If

							'???? is this needed
                            ImageListSmall.Images.Add(GetIcon(DirInfo.FullName))

                            'Dim lvi As New ListViewItem
                            'lvi.Text = DirInfo.Name
                            Dim lvi As ListViewItem = New ListViewItem(DirInfo.Name, ImageListSmall.Images.IndexOfKey("FILE_FOLDER_ICON"))
                            lvi.SubItems.Add(DirInfo.Parent.FullName)
                            lvi.SubItems.Add("")
                            lvi.SubItems.Add("File Folder")
                            lvi.SubItems.Add(DirInfo.LastWriteTime)
                            lvi.SubItems.Add(DirInfo.CreationTime)
                            lvi.SubItems.Add(DirInfo.LastAccessTime)


                            ' It's on a different thread, so use Invoke.
                            Dim e As New AddListViewItemCallback(AddressOf ListViewAdd)
                            Me.Invoke(e, New Object() {lvi})
                        End If
                        UpdateStatusStrip()
                    End If
                Catch ex As Exception
                    Debug.WriteLine(DirInfo.Name)
                End Try

            End If




            If UBound(arrPath) + 1 < MaxDepth Then
                ' search each subdirectory
                For Each di As DirectoryInfo In DirInfo.GetDirectories
                    FindFolders(di)
                Next
            End If


        Catch ex As Exception

            Debug.WriteLine("Access Denied:  " & DirInfo.FullName)
            'Debug.WriteLine(ex.Message)
            If Me.TextBoxErrors.InvokeRequired Then
                ' It's on a different thread, so use Invoke.
                Dim f As New SetTextCallback(AddressOf SetTextErrors)
                Dim NewText As String = TextBoxErrors.Text
                Me.Invoke(f, New Object() {[NewText]})
            End If
        End Try

    End Sub
    ' This method is passed in to the SetTextCallBack delegate
    ' to set the Text property of textBox1.
    Private Sub SetText(ByVal [text] As String)
        Me.LabelStatus.Text = [text]
    End Sub
    Private Sub SetTextErrors(ByVal [text] As String)
        If InStr(LCase(text), "aborted") = False Then Me.TextBoxErrors.Text = [text] & vbCrLf & TextBoxErrors.Text
    End Sub

    Private Sub ListViewAdd(ByVal lvi As ListViewItem)
        ListView1.Items.Add(lvi)
        'ListView1.Refresh()
        ListView1.Items(ListView1.Items.Count - 1).EnsureVisible()
    End Sub

    Private Sub SetTextTSStatusLabel1(ByVal [text] As String)
        ToolStripStatusLabel1.Text = text
    End Sub
    Private Sub SetTextTSStatusLabel2(ByVal [text] As String)
        ToolStripStatusLabelMatches.Text = text
    End Sub

    Private Sub SetTextTSStatusLabel3(ByVal [text] As String)
        ToolStripStatusLabel3.Text = text
    End Sub


    Private Sub ButtonBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBrowse.Click
        BrowseForFolder()
    End Sub

    Private Sub BrowseForFolder()
        FolderBrowserDialog1.Description = "Please select a folder to search in:"
        FolderBrowserDialog1.ShowDialog()
        If FolderBrowserDialog1.SelectedPath <> "" Then TextBoxRootFolder.Text = FolderBrowserDialog1.SelectedPath
    End Sub



    Private Sub ExploreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExploreToolStripMenuItem.Click
        ExploreFolder()
    End Sub

    Private Sub ListBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ExploreFolder()
    End Sub

    Private Sub ExploreFolder()
        If ListView1.SelectedItems.Count = 0 Then Exit Sub

        Dim strPath As String

        strPath = GetSelectedPath()

        If IO.File.Exists(strPath) = False Then
            If IO.Directory.Exists(strPath) = False Then
                MsgBox("The path:" & vbCrLf & vbCrLf & strPath & vbCrLf & vbCrLf & "Could not be found!", MsgBoxStyle.Exclamation, Application.ProductName)
                Exit Sub
            End If
        End If

        Try
            'If SearchMode = "File" Then
            Shell("explorer.exe /e,/select," & Chr(34) & strPath & Chr(34), AppWinStyle.NormalFocus)
            'Else
            'Shell("explorer.exe /e," & Chr(34) & strFolder & Chr(34), AppWinStyle.NormalFocus)
            'End If


        Catch ex As Exception
            'Do Nothing
        End Try

    End Sub


    Private Function FormatTimeSpan(ByVal time_span As  _
    TimeSpan, Optional ByVal whole_seconds As Boolean = _
    True) As String
        Dim txt As String = ""

        If time_span.Days > 0 Then
            txt &= ", " & time_span.Days.ToString() & " days"
            time_span = time_span.Subtract(New  _
                TimeSpan(time_span.Days, 0, 0, 0))
        End If
        If time_span.Hours > 0 Then
            txt &= ", " & time_span.Hours.ToString() & " hours"
            time_span = time_span.Subtract(New TimeSpan(0, _
                time_span.Hours, 0, 0))
        End If
        If time_span.Minutes > 0 Then
            txt &= ", " & time_span.Minutes.ToString() & " " & _
                "minutes"
            time_span = time_span.Subtract(New TimeSpan(0, 0, _
                time_span.Minutes, 0))
        End If

        If whole_seconds Then
            ' Display only whole seconds.
            If time_span.Seconds > 0 Then
                txt &= ", " & time_span.Seconds.ToString() & " " & _
                    "seconds"
            End If
        Else
            ' Display fractional seconds.
            txt &= ", " & time_span.TotalSeconds.ToString() & " " & _
                "seconds"
        End If

        ' Remove the leading ", ".
        If txt.Length > 0 Then txt = txt.Substring(2)

        ' Return the result.
        Return txt
    End Function

    Private Sub ClearToolStrip()
        ToolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.None
        ToolStripStatusLabelMatches.BorderSides = ToolStripStatusLabelBorderSides.None
        ToolStripStatusLabel1.Text = ""
        ToolStripStatusLabelMatches.Text = ""
        ToolStripStatusLabel3.Text = ""
        StatusStrip1.Refresh()
    End Sub


    Private Sub TextBoxRootFolder_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxRootFolder.KeyDown
        If e.KeyCode = Keys.Enter Then
            BrowseForFolder()
        End If
    End Sub


    Private Sub ButtonStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStop.Click
        demoThread.Abort()
        LabelStatus.Text = "Scanning stopped."
    End Sub

    Private Sub ThreadProcSafe()

        strSearchString = TextBoxSearchString.Text
        strSearchString_ESCAPED = strSearchString
        If CheckBoxRegEx.CheckState = CheckState.Unchecked Then
            strSearchString_ESCAPED = strSearchString.Replace(".", "\.")
            strSearchString_ESCAPED = strSearchString_ESCAPED.Replace("*", "(.*?)")
        End If

        dtStartTime = Now

        RootFolder = TextBoxRootFolder.Text
        Dim DI As DirectoryInfo = New DirectoryInfo(RootFolder)

        FindFolders(DI)

        If Me.TextBoxErrors.InvokeRequired Then
            ' It's on a different thread, so use Invoke.
            Dim f As New SetTextCallback(AddressOf SetText)
            Dim NewText As String = "Operation Complete."
            Me.Invoke(f, New Object() {[NewText]})
        End If
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If demoThread.IsAlive Then
            ButtonStart.Enabled = False
            ButtonStop.Enabled = True

            RadioButtonFileMode.Enabled = False
            RadioButtonFolderMode.Enabled = False
            TextBoxRootFolder.Enabled = False
            TextBoxSearchString.Enabled = False
            ComboBox1.Enabled = False
            TextBoxContainingText.Enabled = False
            ButtonBrowse.Enabled = False
            CheckBoxRegEx.Enabled = False
        Else
            ButtonStart.Enabled = True
            ButtonStop.Enabled = False

            RadioButtonFileMode.Enabled = True
            RadioButtonFolderMode.Enabled = True
            TextBoxRootFolder.Enabled = True
            TextBoxSearchString.Enabled = True
            ComboBox1.Enabled = True
            TextBoxContainingText.Enabled = True
            ButtonBrowse.Enabled = True
            CheckBoxRegEx.Enabled = True

            Timer1.Stop()
        End If
    End Sub


    Private Sub RadioButtonFileMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonFileMode.CheckedChanged
        If RadioButtonFileMode.Checked Then
            LabelContainingText.Visible = True
            TextBoxContainingText.Visible = True
            LabelOptional.Visible = True
            RadioButtonFolderMode.Checked = False
            LabelSearchString.Text = "File &Name"
            SearchMode = "File"

            'ListView1.Columns(0).Text = "File Name"    'bombs out!
            For Each col As ColumnHeader In ListView1.Columns
                col.Text = "File Name"
                Exit For
            Next
        End If
    End Sub

    Private Sub RadioButtonFolderMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonFolderMode.CheckedChanged
        If RadioButtonFolderMode.Checked Then
            LabelContainingText.Visible = False
            TextBoxContainingText.Visible = False
            LabelOptional.Visible = False
            RadioButtonFileMode.Checked = False
            LabelSearchString.Text = "Folder &Name"
            SearchMode = "Folder"

            'ListView1.Columns(0).Text = "Folder Name"  'bombs out
            For Each col As ColumnHeader In ListView1.Columns
                col.Text = "Folder Name"
                Exit For
            Next
        End If
    End Sub

    Private Sub LaunchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaunchToolStripMenuItem.Click
        If ListView1.SelectedItems.Count = 0 Then Exit Sub

        Dim strPath As String

        strPath = GetSelectedPath()

        Try
            If IO.Directory.Exists(strPath) Then
                ExploreFolder()
            ElseIf IO.File.Exists(strPath) Then
                Shell("cmd /c " & Chr(34) & strPath & Chr(34), AppWinStyle.MinimizedNoFocus)
            Else
                MsgBox("The path:" & vbCrLf & vbCrLf & strPath & vbCrLf & vbCrLf & "Could not be found!", MsgBoxStyle.Exclamation, Application.ProductName)
            End If


        Catch ex As Exception
            'Do Nothing
        End Try
    End Sub

    Private Sub ContextMenuStrip_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripListView.Opening
        If SearchMode = "Folder" Then
            LaunchToolStripMenuItem.Visible = False
            ExploreToolStripMenuItem.Text = "&Explore"
        Else
            LaunchToolStripMenuItem.Visible = True
            ExploreToolStripMenuItem.Text = "&Show in Explorer"
        End If

    End Sub

    Private Function FileContainsText(ByVal strFilePath As String, ByVal strText As String) As Boolean

        Dim reader As StreamReader = New StreamReader(strFilePath)

        While reader.Peek <> -1
            If Regex.IsMatch(reader.ReadLine, strText, RegexOptions.IgnoreCase) Then
                reader.Close()
                Return True
            End If
        End While
        reader.Close()
        Return False

    End Function




    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        boolTrayExit = True
        Application.Exit()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        ReadMe.ShowDialog()
    End Sub

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click
        ShowMe()
    End Sub

    Private Sub RunAtStartupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunAtStartupToolStripMenuItemTRAY.Click
        boolStartup = RunAtStartupToolStripMenuItemTRAY.Checked
        RunAtStartupToolStripMenuItem1.Checked = RunAtStartupToolStripMenuItemTRAY.Checked
        SaveRegistrySettings()
    End Sub



    Private Sub NotifyIcon1_BalloonTipClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.BalloonTipClicked
        ShowMe()
    End Sub

    Private Sub ShowMe()
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.Activate()
    End Sub

    Private Sub NotifyIcon1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        If e.Button = MouseButtons.Right Then
            'NotifyIcon1.ContextMenu = ContextMenuIcon
        End If
        If e.Button = MouseButtons.Left Then
            ShowMe()
        End If

    End Sub

    Private Sub Form1_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move

        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.ShowBalloonTip(600, Application.ProductName, """Ctrl+Shift+F"" to activate", ToolTipIcon.Info)
            Me.Hide()
        Else
            Me.Show()
        End If
    End Sub


    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.WindowState = FormWindowState.Minimized Then Me.Hide()
        Me.Text = strWindowTitle
    End Sub

    

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Dim ret As MsgBoxResult = MsgBox("Are you sure you want to exit?" & vbCrLf & vbCrLf & _
                                    "(Click No to minimize to the Notification area)", _
                                    MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Exit " & Application.ProductName & "?")
        If ret = MsgBoxResult.Yes Then
            boolTrayExit = True
            Application.Exit()
        Else
            Me.WindowState = FormWindowState.Minimized
        End If



    End Sub

    Private Sub RunAtStartupToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunAtStartupToolStripMenuItem1.Click
        boolStartup = RunAtStartupToolStripMenuItem1.Checked
        RunAtStartupToolStripMenuItemTRAY.Checked = RunAtStartupToolStripMenuItem1.Checked
        SaveRegistrySettings()
    End Sub

    Private Function StrFormatByteSize(ByVal lngBytes As Long) As String
        Dim suf As String() = {"B", "KB", "MB", "GB", "TB", "PB"}
        Dim place As Integer = Convert.ToInt32(Math.Floor(Math.Log(lngBytes, 1024)))
        Dim num As Double = Math.Round(lngBytes / Math.Pow(1024, place), 1)
        Dim readable As String = num.ToString() & " " & suf(place)

        StrFormatByteSize = readable
    End Function

    Private Function StrFormatKiloBytes(ByVal lngBytes As Long) As String
        Dim num As Double = Math.Round(lngBytes / 1024, 1)

        Dim readable As String = FormatNumber(num, 1) & " KB"
        StrFormatKiloBytes = readable
    End Function


    Public Shared Function GetFileType(ByVal fileExtension As String) As String
        If fileExtension = "" Then
            Return ""
        End If
        Dim fileType As String = ""
        'Search all keys under HKEY_CLASSES_ROOT
        For Each subKey As String In Registry.ClassesRoot.GetSubKeyNames()
            If String.IsNullOrEmpty(subKey) Then
                Continue For
            End If

            If subKey.CompareTo(fileExtension) = 0 Then
                'File extension found. Get Default Value

                Dim defaultValue As String = Registry.ClassesRoot.OpenSubKey(subKey).GetValue("", "").ToString()
                If defaultValue.Length = 0 Then
                    'No File Type specified
                    Exit For
                End If
                If fileType.Length = 0 Then
                    'Get Initial File Type and search for the full File Type Description
                    fileType = defaultValue
                    fileExtension = fileType
                Else
                    'File Type Description found
                    If defaultValue.Length > 0 Then
                        fileType = defaultValue
                    End If
                    Exit For
                End If
            End If

        Next
        Return fileType
    End Function

    Friend Sub SortMyListView(ByVal ListViewToSort As ListView, ByVal ColumnNumber As Integer, Optional ByVal Resort As Boolean = False, Optional ByVal ForceSort As Boolean = False)
        ' Sorts a list view column by string, number, or date.  The three types of sorts must be specified within the listview columns "tag" property unless the ForceSort option is enabled.
        ' ListViewToSort - The listview to sort
        ' ColumnNumber - The column number to sort by
        ' Resort - Resorts a listview in the same direction as the last sort
        ' ForceSort - Forces a sort even if no listview tag data exists and assumes a string sort.  If this is false (default) and no tag is specified the procedure will exit
        Dim SortOrder As SortOrder
        Static LastSortColumn As Integer = -1
        Static LastSortOrder As SortOrder = SortOrder.Ascending
        If Resort = True Then
            SortOrder = LastSortOrder
        Else
            If LastSortColumn = ColumnNumber Then
                If LastSortOrder = SortOrder.Ascending Then
                    SortOrder = SortOrder.Descending
                Else
                    SortOrder = SortOrder.Ascending
                End If
            Else
                SortOrder = SortOrder.Ascending
            End If
        End If

        ' In case a tag wasn't specified check if we should force a string sort
        If String.IsNullOrEmpty(CStr(ListViewToSort.Columns(ColumnNumber).Tag)) Then
            If ForceSort = True Then
                ListViewToSort.Columns(ColumnNumber).Tag = "String"
            Else
                ' don't sort since no tag was specified.
                Exit Sub
            End If
        End If

        Select Case ListViewToSort.Columns(ColumnNumber).Tag.ToString
            Case "Numeric"
                ListViewToSort.ListViewItemSorter = New ListViewNumericSort(ColumnNumber, SortOrder)
            Case "Date"
                ListViewToSort.ListViewItemSorter = New ListViewDateSort(ColumnNumber, SortOrder)
            Case "String"
                ListViewToSort.ListViewItemSorter = New ListViewStringSort(ColumnNumber, SortOrder)
            Case "IP"
                ListViewToSort.ListViewItemSorter = New ListViewIPSort(ColumnNumber, SortOrder)
        End Select
        LastSortColumn = ColumnNumber
        LastSortOrder = SortOrder
        ListViewToSort.ListViewItemSorter = Nothing
    End Sub

    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        SortMyListView(sender, e.Column, , True)

        'If e.Column = 0 Then
        '    ColorLines(False)
        'Else
        '   ColorLines(True)
        'End If
    End Sub

    Private Function GetIcon(ByVal strFileName As String) As System.Drawing.Icon

        Dim hImgSmall As IntPtr  'The handle to the system image list.
        Dim shinfo As SHFILEINFO
        shinfo = New SHFILEINFO()


        shinfo.szDisplayName = New String(Chr(0), 260)
        shinfo.szTypeName = New String(Chr(0), 80)


        'Use this to get the small icon.
        hImgSmall = SHGetFileInfo(strFileName, 0, shinfo, _
                    Marshal.SizeOf(shinfo), _
                    SHGFI_ICON Or SHGFI_SMALLICON)


        Dim myIcon As System.Drawing.Icon
        myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon)

        Return myIcon

    End Function

 
    Private Sub CopyFileNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyFileNameToolStripMenuItem.Click
        If ListView1.SelectedItems.Count = 0 Then Exit Sub
        Dim strPath As String = GetSelectedPath()
        If strPath <> "" Then
            Clipboard.SetText(GetSelectedPath)
            NotifyIcon1.ShowBalloonTip(5, "Flash Find", "Path copied to clipboard.", ToolTipIcon.Info)
        Else
            NotifyIcon1.ShowBalloonTip(5, "Flash Find", "Failed to copy path.", ToolTipIcon.Error)
        End If
    End Sub

    Private Function GetSelectedPath() As String
        If ListView1.SelectedItems.Count = 0 Then
            Return ""
        End If

        Dim strName As String
        Dim strParentFolder As String
        Dim strPath As String

        strName = ListView1.SelectedItems(0).SubItems(0).Text
        strParentFolder = ListView1.SelectedItems(0).SubItems(1).Text
        strPath = strParentFolder & "\" & strName
        'strPath = strPath.Replace("\\", "\")

        Return strPath
    End Function


    Private Sub ExportToCSVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToCSVToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub

        Dim strFilename As String = SaveFileDialog1.FileName
        Dim writer As New StreamWriter(strFilename)

        Dim strHeaders As String = ""

        For Each colTitle As ColumnHeader In ListView1.Columns
            strHeaders += Chr(34) & colTitle.Text & Chr(34) & ","
        Next

        If strHeaders.EndsWith(",") Then strHeaders = strHeaders.Remove(strHeaders.Length - 1)
        writer.WriteLine(strHeaders)


        For Each row As ListViewItem In ListView1.Items
            Dim strRowText As String = ""
            For Each itm As ListViewItem.ListViewSubItem In row.SubItems
                strRowText = strRowText & Chr(34) & itm.Text & Chr(34) & ","
            Next
            If strRowText.EndsWith(",") Then strRowText = strRowText.Remove(strRowText.Length - 1)
            writer.WriteLine(strRowText)
        Next

        writer.Close()
        MsgBox("See file:  " & strFilename, MsgBoxStyle.Information)
    End Sub

    Private Sub AboutToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem2.Click
        ReadMe.ShowDialog()
    End Sub


    Private Sub CheckForUpdatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        UPD.CheckForUpdates(strUpdateURL, False)
    End Sub

    Private Sub CheckForUpdatesToolStripMenuItemTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItemTray.Click
        UPD.CheckForUpdates(strUpdateURL, False)
    End Sub
End Class
