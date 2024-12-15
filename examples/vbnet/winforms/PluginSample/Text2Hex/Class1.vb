Imports PluginSample
Imports System.Windows.Forms

''' <summary>
''' Простой пример плагина
''' </summary>
''' <remarks>
''' Aleksey Nemiro, 28.11.2007
''' http://kbyte.ru - лучший в рунете портал для программиство и разработчиков!
''' http://aleksey.nemiro.ru
''' </remarks>
Public Class Class1
  Implements IPlugin

  'в этой переменной мы будем хранить ссылку на текстовое поле формы
  Private _textBox As TextBox

  Public ReadOnly Property AuthorName() As String Implements PluginSample.IPlugin.AuthorName
    Get
      Return "Aleksey Nemiro"
    End Get
  End Property

  Public ReadOnly Property Description() As String Implements PluginSample.IPlugin.Description
    Get
      Return "Converts text to hexadecimal and back"
      'Return "Плагин преобразует текст в шестнадцатеричный код и обратно"
    End Get
  End Property

  Public ReadOnly Property Name() As String Implements PluginSample.IPlugin.Name
    Get
      Return "Text2Hex"
    End Get
  End Property

  Public ReadOnly Property Version() As System.Version Implements PluginSample.IPlugin.Version
    Get
      Return New Version(1, 0, 0, 0)
    End Get
  End Property

  Public Sub Initialize(ByVal MainContainer As Object) Implements PluginSample.IPlugin.Initialize
    If MainContainer Is Nothing Then Throw New Exception("Container not found!")
    'If MainContainer Is Nothing Then Throw New Exception("Контейнер не найден!")

    'get a reference to the form
    'получаем ссылку на форму
    Dim frm As Form = CType(MainContainer, Form)
    Dim mnu As MenuStrip = Nothing

    'get menu of the form
    'получаем меню формы
    If frm.Controls.Find("MenuStrip1", False) IsNot Nothing AndAlso frm.Controls.Find("MenuStrip1", False).Length > 0 Then
      mnu = frm.Controls.Find("MenuStrip1", False)(0)
    End If

    'get TextBox
    'получаем текстовое поле
    If frm.Controls.Find("TextBox1", False) IsNot Nothing AndAlso frm.Controls.Find("TextBox1", False).Length > 0 Then
      _textBox = frm.Controls.Find("TextBox1", False)(0)
    End If

    If mnu Is Nothing Then Throw New Exception("Menu not found.")
    If _textBox Is Nothing Then Throw New Exception("Text field not found.")
    'If mnu Is Nothing Then Throw New Exception("Меню не найдено")
    'If _textBox Is Nothing Then Throw New Exception("Текстовое поле не найдено")

    'create elements of the plugin
    'создаем новые элементы меню
    Dim myText2HexMenu As New ToolStripMenuItem
    myText2HexMenu.Text = "Text2Hex"
    Dim myConvertText2HexMenu As New ToolStripMenuItem
    Dim myConvertHex2TextMenu As New ToolStripMenuItem
    Dim myAboutMenu As New ToolStripMenuItem
    AddHandler myConvertText2HexMenu.Click, AddressOf ConvertText2HexMenu_Click
    AddHandler myConvertHex2TextMenu.Click, AddressOf ConvertHex2TextMenu_Click
    AddHandler myAboutMenu.Click, AddressOf AboutMenu_Click
    myConvertText2HexMenu.Text = "Text => HEX"
    myConvertHex2TextMenu.Text = "HEX => Text"
    myAboutMenu.Text = "About Text2Hex..."
    'myConvertText2HexMenu.Text = "Конвертировать текст в hex"
    'myConvertHex2TextMenu.Text = "Конвертировать hex в текст"
    'myAboutMenu.Text = "О Text2Hex..."
    myText2HexMenu.DropDownItems.Add(myConvertText2HexMenu)
    myText2HexMenu.DropDownItems.Add(myConvertHex2TextMenu)
    myText2HexMenu.DropDownItems.Add(New ToolStripSeparator())
    myText2HexMenu.DropDownItems.Add(myAboutMenu)
    'добавляем новые элементы меню на форму
    mnu.Items.Add(myText2HexMenu)
  End Sub

  'обработка события нажания на меню ConvertText2Hex (Конвертировать Текст в Шестнадцатеричный код)
  Public Sub ConvertText2HexMenu_Click(ByVal sender As Object, ByVal e As EventArgs)
    If String.IsNullOrEmpty(_textBox.Text) Then Return 'нет текста, выходим
    Dim sResult As String = ""
    For Each s As Char In _textBox.Text
      sResult += IIf(Hex(Asc(s)).Length < 2, "0" & Hex(Asc(s)), Hex(Asc(s)))
    Next
    _textBox.Text = sResult
  End Sub

  'обработка события нажания на меню ConvertHex2TextMenu (Конвертировать Шестнадцатеричный код в Текст)
  Public Sub ConvertHex2TextMenu_Click(ByVal sender As Object, ByVal e As EventArgs)
    If String.IsNullOrEmpty(_textBox.Text) Then Return 'нет текста, выходим
    Dim sResult As String = ""
    'удаляем все символы, которые нельзя преобразовать в hex
    Dim myRegEx As New System.Text.RegularExpressions.Regex("[^0-9ABCDEF]*")
    _textBox.Text = myRegEx.Replace(_textBox.Text, "")
    If String.IsNullOrEmpty(_textBox.Text) Then Return 'нет текста, выходим
    For i As Integer = 1 To _textBox.Text.Length Step 2
      If CType("&H" & Mid(_textBox.Text, i, 2), Integer) <= 255 Then
        sResult += Chr(CType("&H" & Mid(_textBox.Text, i, 2), Integer))
      End If
    Next
    _textBox.Text = sResult
  End Sub

  'обработка события нажания на меню AboutMenu (О программе)
  Public Sub AboutMenu_Click(ByVal sender As Object, ByVal e As EventArgs)
    MsgBox("Simple example of plugin.", MsgBoxStyle.Information)
    'MsgBox("Простой пример плагина", MsgBoxStyle.Information)
  End Sub

  Public Sub Dispose() Implements PluginSample.IPlugin.Dispose

  End Sub

End Class