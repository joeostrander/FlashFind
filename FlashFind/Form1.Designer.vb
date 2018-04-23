<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.LabelStatus = New System.Windows.Forms.Label
        Me.ContextMenuStripListView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExploreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LaunchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CopyFileNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportToCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LabelMaxDepth = New System.Windows.Forms.Label
        Me.LabelSearchString = New System.Windows.Forms.Label
        Me.TextBoxSearchString = New System.Windows.Forms.TextBox
        Me.LabelRootFolder = New System.Windows.Forms.Label
        Me.TextBoxRootFolder = New System.Windows.Forms.TextBox
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ButtonBrowse = New System.Windows.Forms.Button
        Me.TextBoxErrors = New System.Windows.Forms.TextBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabelMatches = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ButtonStop = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LabelMode = New System.Windows.Forms.Label
        Me.RadioButtonFolderMode = New System.Windows.Forms.RadioButton
        Me.RadioButtonFileMode = New System.Windows.Forms.RadioButton
        Me.LabelContainingText = New System.Windows.Forms.Label
        Me.TextBoxContainingText = New System.Windows.Forms.TextBox
        Me.LabelOptional = New System.Windows.Forms.Label
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStripTRAY = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RunAtStartupToolStripMenuItemTRAY = New System.Windows.Forms.ToolStripMenuItem
        Me.CheckForUpdatesToolStripMenuItemTray = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RunAtStartupToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.CheckForUpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ColumnHeaderName = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderLocation = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderSize = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderType = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderModified = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderCreated = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderLastAccessed = New System.Windows.Forms.ColumnHeader
        Me.ImageListSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.CheckBoxRegEx = New System.Windows.Forms.CheckBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStripListView.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStripTRAY.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(9, 165)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStart.TabIndex = 16
        Me.ButtonStart.Text = "&Start"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'LabelStatus
        '
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Location = New System.Drawing.Point(171, 170)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(63, 13)
        Me.LabelStatus.TabIndex = 18
        Me.LabelStatus.Text = "LabelStatus"
        '
        'ContextMenuStripListView
        '
        Me.ContextMenuStripListView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExploreToolStripMenuItem, Me.LaunchToolStripMenuItem, Me.CopyFileNameToolStripMenuItem, Me.ExportToCSVToolStripMenuItem})
        Me.ContextMenuStripListView.Name = "ContextMenuStrip1"
        Me.ContextMenuStripListView.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStripListView.ShowImageMargin = False
        Me.ContextMenuStripListView.Size = New System.Drawing.Size(130, 92)
        '
        'ExploreToolStripMenuItem
        '
        Me.ExploreToolStripMenuItem.Name = "ExploreToolStripMenuItem"
        Me.ExploreToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.ExploreToolStripMenuItem.Text = "&Explore"
        '
        'LaunchToolStripMenuItem
        '
        Me.LaunchToolStripMenuItem.Name = "LaunchToolStripMenuItem"
        Me.LaunchToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.LaunchToolStripMenuItem.Text = "&Launch"
        '
        'CopyFileNameToolStripMenuItem
        '
        Me.CopyFileNameToolStripMenuItem.Name = "CopyFileNameToolStripMenuItem"
        Me.CopyFileNameToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.CopyFileNameToolStripMenuItem.Text = "&Copy Full Path"
        '
        'ExportToCSVToolStripMenuItem
        '
        Me.ExportToCSVToolStripMenuItem.Name = "ExportToCSVToolStripMenuItem"
        Me.ExportToCSVToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.ExportToCSVToolStripMenuItem.Text = "E&xport to CSV"
        '
        'LabelMaxDepth
        '
        Me.LabelMaxDepth.AutoSize = True
        Me.LabelMaxDepth.Location = New System.Drawing.Point(6, 113)
        Me.LabelMaxDepth.Name = "LabelMaxDepth"
        Me.LabelMaxDepth.Size = New System.Drawing.Size(59, 13)
        Me.LabelMaxDepth.TabIndex = 11
        Me.LabelMaxDepth.Text = "Max &Depth"
        '
        'LabelSearchString
        '
        Me.LabelSearchString.AutoSize = True
        Me.LabelSearchString.Location = New System.Drawing.Point(6, 87)
        Me.LabelSearchString.Name = "LabelSearchString"
        Me.LabelSearchString.Size = New System.Drawing.Size(67, 13)
        Me.LabelSearchString.TabIndex = 7
        Me.LabelSearchString.Text = "Folder &Name"
        '
        'TextBoxSearchString
        '
        Me.TextBoxSearchString.Location = New System.Drawing.Point(89, 84)
        Me.TextBoxSearchString.Name = "TextBoxSearchString"
        Me.TextBoxSearchString.Size = New System.Drawing.Size(210, 20)
        Me.TextBoxSearchString.TabIndex = 8
        '
        'LabelRootFolder
        '
        Me.LabelRootFolder.AutoSize = True
        Me.LabelRootFolder.Location = New System.Drawing.Point(6, 61)
        Me.LabelRootFolder.Name = "LabelRootFolder"
        Me.LabelRootFolder.Size = New System.Drawing.Size(62, 13)
        Me.LabelRootFolder.TabIndex = 4
        Me.LabelRootFolder.Text = "&Root Folder"
        '
        'TextBoxRootFolder
        '
        Me.TextBoxRootFolder.Location = New System.Drawing.Point(89, 58)
        Me.TextBoxRootFolder.Name = "TextBoxRootFolder"
        Me.TextBoxRootFolder.Size = New System.Drawing.Size(415, 20)
        Me.TextBoxRootFolder.TabIndex = 5
        Me.TextBoxRootFolder.Text = "C:\"
        '
        'ButtonBrowse
        '
        Me.ButtonBrowse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonBrowse.FlatAppearance.BorderSize = 0
        Me.ButtonBrowse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ButtonBrowse.Location = New System.Drawing.Point(507, 56)
        Me.ButtonBrowse.Name = "ButtonBrowse"
        Me.ButtonBrowse.Size = New System.Drawing.Size(64, 23)
        Me.ButtonBrowse.TabIndex = 6
        Me.ButtonBrowse.Text = "&Browse"
        Me.ButtonBrowse.UseVisualStyleBackColor = True
        '
        'TextBoxErrors
        '
        Me.TextBoxErrors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxErrors.Location = New System.Drawing.Point(9, 539)
        Me.TextBoxErrors.Multiline = True
        Me.TextBoxErrors.Name = "TextBoxErrors"
        Me.TextBoxErrors.ReadOnly = True
        Me.TextBoxErrors.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxErrors.Size = New System.Drawing.Size(965, 46)
        Me.TextBoxErrors.TabIndex = 20
        Me.TextBoxErrors.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabelMatches, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 591)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(983, 22)
        Me.StatusStrip1.TabIndex = 21
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(94, 17)
        Me.ToolStripStatusLabel1.Text = "Folders Scanned:"
        '
        'ToolStripStatusLabelMatches
        '
        Me.ToolStripStatusLabelMatches.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabelMatches.Name = "ToolStripStatusLabelMatches"
        Me.ToolStripStatusLabelMatches.Size = New System.Drawing.Size(94, 17)
        Me.ToolStripStatusLabelMatches.Text = "Folders Matched:"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(73, 17)
        Me.ToolStripStatusLabel3.Text = "Elapsed Time:"
        '
        'ButtonStop
        '
        Me.ButtonStop.Enabled = False
        Me.ButtonStop.Location = New System.Drawing.Point(90, 165)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStop.TabIndex = 17
        Me.ButtonStop.Text = "Sto&p"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'LabelMode
        '
        Me.LabelMode.AutoSize = True
        Me.LabelMode.Location = New System.Drawing.Point(6, 37)
        Me.LabelMode.Name = "LabelMode"
        Me.LabelMode.Size = New System.Drawing.Size(34, 13)
        Me.LabelMode.TabIndex = 1
        Me.LabelMode.Text = "&Mode"
        '
        'RadioButtonFolderMode
        '
        Me.RadioButtonFolderMode.AutoSize = True
        Me.RadioButtonFolderMode.Location = New System.Drawing.Point(89, 35)
        Me.RadioButtonFolderMode.Name = "RadioButtonFolderMode"
        Me.RadioButtonFolderMode.Size = New System.Drawing.Size(54, 17)
        Me.RadioButtonFolderMode.TabIndex = 2
        Me.RadioButtonFolderMode.Text = "F&older"
        Me.RadioButtonFolderMode.UseVisualStyleBackColor = True
        '
        'RadioButtonFileMode
        '
        Me.RadioButtonFileMode.AutoSize = True
        Me.RadioButtonFileMode.Checked = True
        Me.RadioButtonFileMode.Location = New System.Drawing.Point(149, 35)
        Me.RadioButtonFileMode.Name = "RadioButtonFileMode"
        Me.RadioButtonFileMode.Size = New System.Drawing.Size(41, 17)
        Me.RadioButtonFileMode.TabIndex = 3
        Me.RadioButtonFileMode.TabStop = True
        Me.RadioButtonFileMode.Text = "F&ile"
        Me.RadioButtonFileMode.UseVisualStyleBackColor = True
        '
        'LabelContainingText
        '
        Me.LabelContainingText.AutoSize = True
        Me.LabelContainingText.Location = New System.Drawing.Point(6, 139)
        Me.LabelContainingText.Name = "LabelContainingText"
        Me.LabelContainingText.Size = New System.Drawing.Size(81, 13)
        Me.LabelContainingText.TabIndex = 13
        Me.LabelContainingText.Text = "Containing &Text"
        '
        'TextBoxContainingText
        '
        Me.TextBoxContainingText.Location = New System.Drawing.Point(89, 136)
        Me.TextBoxContainingText.Name = "TextBoxContainingText"
        Me.TextBoxContainingText.Size = New System.Drawing.Size(218, 20)
        Me.TextBoxContainingText.TabIndex = 14
        '
        'LabelOptional
        '
        Me.LabelOptional.AutoSize = True
        Me.LabelOptional.Location = New System.Drawing.Point(313, 139)
        Me.LabelOptional.Name = "LabelOptional"
        Me.LabelOptional.Size = New System.Drawing.Size(50, 13)
        Me.LabelOptional.TabIndex = 15
        Me.LabelOptional.Text = "(optional)"
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStripTRAY
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStripTRAY
        '
        Me.ContextMenuStripTRAY.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowToolStripMenuItem, Me.RunAtStartupToolStripMenuItemTRAY, Me.CheckForUpdatesToolStripMenuItemTray, Me.AboutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.ContextMenuStripTRAY.Name = "ContextMenuStripTRAY"
        Me.ContextMenuStripTRAY.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStripTRAY.ShowCheckMargin = True
        Me.ContextMenuStripTRAY.ShowImageMargin = False
        Me.ContextMenuStripTRAY.Size = New System.Drawing.Size(175, 136)
        '
        'ShowToolStripMenuItem
        '
        Me.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem"
        Me.ShowToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ShowToolStripMenuItem.Text = "&Show"
        '
        'RunAtStartupToolStripMenuItemTRAY
        '
        Me.RunAtStartupToolStripMenuItemTRAY.CheckOnClick = True
        Me.RunAtStartupToolStripMenuItemTRAY.Name = "RunAtStartupToolStripMenuItemTRAY"
        Me.RunAtStartupToolStripMenuItemTRAY.Size = New System.Drawing.Size(174, 22)
        Me.RunAtStartupToolStripMenuItemTRAY.Text = "&Run at Startup"
        '
        'CheckForUpdatesToolStripMenuItemTray
        '
        Me.CheckForUpdatesToolStripMenuItemTray.Name = "CheckForUpdatesToolStripMenuItemTray"
        Me.CheckForUpdatesToolStripMenuItemTray.Size = New System.Drawing.Size(174, 22)
        Me.CheckForUpdatesToolStripMenuItemTray.Text = "&Check for Updates"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10+"})
        Me.ComboBox1.Location = New System.Drawing.Point(89, 109)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(54, 21)
        Me.ComboBox1.TabIndex = 12
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.AboutToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(983, 24)
        Me.MenuStrip1.TabIndex = 23
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunAtStartupToolStripMenuItem1, Me.ExitToolStripMenuItem1})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'RunAtStartupToolStripMenuItem1
        '
        Me.RunAtStartupToolStripMenuItem1.CheckOnClick = True
        Me.RunAtStartupToolStripMenuItem1.Name = "RunAtStartupToolStripMenuItem1"
        Me.RunAtStartupToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.RunAtStartupToolStripMenuItem1.Text = "&Run at Startup"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.ExitToolStripMenuItem1.Text = "E&xit"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem2, Me.CheckForUpdatesToolStripMenuItem})
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(40, 20)
        Me.AboutToolStripMenuItem1.Text = "&Help"
        '
        'AboutToolStripMenuItem2
        '
        Me.AboutToolStripMenuItem2.Name = "AboutToolStripMenuItem2"
        Me.AboutToolStripMenuItem2.Size = New System.Drawing.Size(174, 22)
        Me.AboutToolStripMenuItem2.Text = "&About"
        '
        'CheckForUpdatesToolStripMenuItem
        '
        Me.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem"
        Me.CheckForUpdatesToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.CheckForUpdatesToolStripMenuItem.Text = "&Check for Updates"
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderName, Me.ColumnHeaderLocation, Me.ColumnHeaderSize, Me.ColumnHeaderType, Me.ColumnHeaderModified, Me.ColumnHeaderCreated, Me.ColumnHeaderLastAccessed})
        Me.ListView1.ContextMenuStrip = Me.ContextMenuStripListView
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(9, 194)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(962, 339)
        Me.ListView1.SmallImageList = Me.ImageListSmall
        Me.ListView1.TabIndex = 24
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderName
        '
        Me.ColumnHeaderName.Tag = "String"
        Me.ColumnHeaderName.Text = "File Name"
        Me.ColumnHeaderName.Width = 120
        '
        'ColumnHeaderLocation
        '
        Me.ColumnHeaderLocation.Tag = "String"
        Me.ColumnHeaderLocation.Text = "Location"
        Me.ColumnHeaderLocation.Width = 240
        '
        'ColumnHeaderSize
        '
        Me.ColumnHeaderSize.Tag = "Numeric"
        Me.ColumnHeaderSize.Text = "Size"
        Me.ColumnHeaderSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeaderSize.Width = 80
        '
        'ColumnHeaderType
        '
        Me.ColumnHeaderType.Tag = "String"
        Me.ColumnHeaderType.Text = "Type"
        Me.ColumnHeaderType.Width = 120
        '
        'ColumnHeaderModified
        '
        Me.ColumnHeaderModified.Tag = "Date"
        Me.ColumnHeaderModified.Text = "Modified"
        Me.ColumnHeaderModified.Width = 135
        '
        'ColumnHeaderCreated
        '
        Me.ColumnHeaderCreated.Tag = "Date"
        Me.ColumnHeaderCreated.Text = "Created"
        Me.ColumnHeaderCreated.Width = 135
        '
        'ColumnHeaderLastAccessed
        '
        Me.ColumnHeaderLastAccessed.Tag = "Date"
        Me.ColumnHeaderLastAccessed.Text = "Last Accessed"
        Me.ColumnHeaderLastAccessed.Width = 135
        '
        'ImageListSmall
        '
        Me.ImageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageListSmall.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListSmall.TransparentColor = System.Drawing.Color.Transparent
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "CSV Files|*.csv"
        '
        'CheckBoxRegEx
        '
        Me.CheckBoxRegEx.AutoSize = True
        Me.CheckBoxRegEx.Location = New System.Drawing.Point(305, 86)
        Me.CheckBoxRegEx.Name = "CheckBoxRegEx"
        Me.CheckBoxRegEx.Size = New System.Drawing.Size(69, 17)
        Me.CheckBoxRegEx.TabIndex = 25
        Me.CheckBoxRegEx.Text = "Is RegEx"
        Me.ToolTip1.SetToolTip(Me.CheckBoxRegEx, "If your search string is in regular expression format, click this.")
        Me.CheckBoxRegEx.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 613)
        Me.Controls.Add(Me.CheckBoxRegEx)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TextBoxErrors)
        Me.Controls.Add(Me.LabelOptional)
        Me.Controls.Add(Me.TextBoxContainingText)
        Me.Controls.Add(Me.LabelContainingText)
        Me.Controls.Add(Me.RadioButtonFileMode)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.RadioButtonFolderMode)
        Me.Controls.Add(Me.LabelMode)
        Me.Controls.Add(Me.LabelRootFolder)
        Me.Controls.Add(Me.LabelStatus)
        Me.Controls.Add(Me.ButtonStop)
        Me.Controls.Add(Me.TextBoxRootFolder)
        Me.Controls.Add(Me.LabelSearchString)
        Me.Controls.Add(Me.ButtonBrowse)
        Me.Controls.Add(Me.TextBoxSearchString)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.LabelMaxDepth)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(600, 400)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ContextMenuStripListView.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStripTRAY.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    Friend WithEvents LabelMaxDepth As System.Windows.Forms.Label
    Friend WithEvents LabelSearchString As System.Windows.Forms.Label
    Friend WithEvents TextBoxSearchString As System.Windows.Forms.TextBox
    Friend WithEvents LabelRootFolder As System.Windows.Forms.Label
    Friend WithEvents TextBoxRootFolder As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ButtonBrowse As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStripListView As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExploreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBoxErrors As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelMatches As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ButtonStop As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LabelMode As System.Windows.Forms.Label
    Friend WithEvents RadioButtonFolderMode As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonFileMode As System.Windows.Forms.RadioButton
    Friend WithEvents LaunchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelContainingText As System.Windows.Forms.Label
    Friend WithEvents TextBoxContainingText As System.Windows.Forms.TextBox
    Friend WithEvents LabelOptional As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStripTRAY As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RunAtStartupToolStripMenuItemTRAY As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunAtStartupToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeaderName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderLocation As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderModified As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderCreated As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderLastAccessed As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageListSmall As System.Windows.Forms.ImageList
    Friend WithEvents CopyFileNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents AboutToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckForUpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckForUpdatesToolStripMenuItemTray As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBoxRegEx As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
