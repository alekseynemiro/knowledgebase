<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomControl1
    Inherits System.Windows.Forms.Control

    'Элемент управления переопределяет метод Dispose для очистки списка компонентов.
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

    'Требуется для конструктора элементов управления
    Private components As System.ComponentModel.IContainer

    ' Примечание: следующая процедура является обязательной для конструктора компонентов
    ' Для ее изменения используйте конструктор компонентов. Не изменяйте ее
    ' в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

End Class

