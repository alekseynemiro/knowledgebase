'(c) Aleksey Nemiro, 2011
'http://aleksey.nemiro.ru
'http://kbyte.ru
Public Class Form1

  Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
    Process.Start("http://kbyte.ru")
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    'куски текста
    Dim part1() As String = {"Товарищи!", "С другой стороны", "Раным образом", "Не следует, однако, забывать что", "Таким образом", "Повседневная практика показывает, что"}
    Dim part2() As String = {"реализация намеченных плановых заданий", "рамки и место обучение кадров", "постоянный количественный рост и сфера нашей активности", "сложившаяся структура организации", "новая модель организационной деятельности", "дальнейшее развитие различных форм деятельности"}
    Dim part3() As String = {"играет важную роль в формировании", "требуют от нас анализа", "требуют определения и уточнения", "способствует подготовке и реализации", "обеспечивает широкому кругу (специалистов) участие в формировании", "позволяет выполнять важные задания по разработке"}
    Dim part4() As String = {"существенных финансовых и административных условий", "дальнейших направлений развития", "системы массового участия", "позиций, занимаемых участниками в отношении поставленных задач", "новых предложений", "направлений прогрессивного развития"}
    'включаем генератор случайных чисел
    Randomize()
    'формируем случайную речь депутата коммунистической партии :)
    TextBox1.Text = ""
    TextBox1.Text = part1(Int(Rnd() * (part1.Length - 1)))
    TextBox1.Text &= " "
    TextBox1.Text &= part2(Int(Rnd() * (part2.Length - 1)))
    TextBox1.Text &= " "
    TextBox1.Text &= part3(Int(Rnd() * (part3.Length - 1)))
    TextBox1.Text &= " "
    TextBox1.Text &= part4(Int(Rnd() * (part4.Length - 1)))
  End Sub

End Class