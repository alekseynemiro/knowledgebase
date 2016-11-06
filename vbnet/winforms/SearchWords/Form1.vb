Imports System.IO
Imports System.Text.RegularExpressions

'Пример к теме: http://kbyte.ru/ru/Forums/Show.aspx?id=15419

Public Class Form1

  Private _Words() As String 'массив слов словаря поиска слов :)

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    If Not OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then Return
    _Words = File.ReadAllLines(OpenFileDialog1.FileName, System.Text.Encoding.GetEncoding(1251)) 'грузим слова из файла в переменную
    tbFileName.Text = OpenFileDialog1.FileName
  End Sub

  Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
    If _Words.Length <= 0 Then
      MessageBox.Show("Выберите словарь! В словаре должно быть хотя бы одно слово, но лучше конечно два, или больше ;)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Return
    End If

    'создаем шаблон на основе введеных в форму данных
    Dim pattern As String = String.Format("^([{0}-[{1}]]{{{2}}})$", Regex.Escape(tbInclude.Text), Regex.Escape(tbExclude.Text), tbMax.Text) 'Regex.Escape- экранирует управляющие символы
    'При формировании шаблона, при желании, можно сделать автоматическое указание включаемых/исключаемых симолов,
    'чтобы пользователю не пришлось их самому вводить. Но мне лень это делать :)

    ListBox1.Items.Clear() 'очищаем список с результатами поиска (если там что-то есть)

    'листаем слова
    For Each word As String In _Words
      If Regex.IsMatch(word, pattern, RegexOptions.IgnoreCase Or RegexOptions.Singleline) Then
        ListBox1.Items.Add(word) 'слово подходящее, добавляем в результат
      End If
    Next

    MessageBox.Show("Поиск завершен!", "Ура!", MessageBoxButtons.OK, MessageBoxIcon.Information)
  End Sub

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    OpenFileDialog1.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "zdf-win.txt")
  End Sub

End Class