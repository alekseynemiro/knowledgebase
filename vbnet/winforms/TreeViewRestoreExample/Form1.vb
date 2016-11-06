Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

''' <summary>
''' http://kbyte.ru/ru/Forums/Show.aspx?id=15143
''' </summary>
Public Class Form1

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    If TreeView1.SelectedNode IsNot Nothing Then
      TreeView1.SelectedNode.Nodes.Add(Now.Ticks)
    Else
      TreeView1.Nodes.Add(Now.Ticks)
    End If

    TreeView1.SelectedNode = TreeView1.Nodes(TreeView1.Nodes.Count - 1)
  End Sub

  Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
    If Not SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then Return

    'save nodes to file
    Using s As Stream = File.Open(SaveFileDialog1.FileName, FileMode.Create)
      Dim bf As New BinaryFormatter()
      bf.Serialize(s, TreeView1.Nodes.Cast(Of TreeNode)().ToList())
    End Using
  End Sub

  Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
    If Not OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then Return

    'load nodes from file
    Using s As Stream = File.Open(OpenFileDialog1.FileName, FileMode.Open)
      Dim bf As New BinaryFormatter()
      Dim obj As Object = bf.Deserialize(s)
      Dim nodeList As TreeNode() = (TryCast(obj, IEnumerable(Of TreeNode))).ToArray()
      TreeView1.Nodes.AddRange(nodeList)
    End Using
  End Sub

End Class