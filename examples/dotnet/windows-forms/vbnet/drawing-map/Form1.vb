Imports System.IO

Public Class Form1

  Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Dim pic As New PictureBox()
    pic.Width = Me.Width
    pic.Height = Me.Height
    pic.Dock = DockStyle.Fill
    Me.Controls.Add(pic)

    Dim m As New MemoryStream(Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAA4AAAAOCAIAAACQKrqGAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAJbSURBVChTDU/bT9pwGO3fsNc9LAuOaKzgAJFLp8imbLrpw0xm1M1oQki8RURRyoACLQV6oQVKy1WMVmGIzuiKGJa4TePLkmV7X/av7Jd8D+c7Oec734F+/0u27tYb7cVjZe7iu+v8xqncLdda843rhZry4eyrU76YP+24bn5i0NHlApFBPOGeFfSRl+imi0PCoSNfm4gJpriIoAkNnrbwe+OfOxvQaccZyyIR3hhk+smcOchoEpI5J78EK54xbYS6IpyJqzhK9VlIuV3z4rA/qXVjKk9EFRdNfHUEDAAJyRrm9MDAlkbrigtq3a1tRbvZso0qWKkSksxbgA7cJrIDAVqLZ4xu7MkO0Xd9vw2BHoCiy8+SRSvK9sakga2YCs/pCUG/5H4Q5XW7RI8HU9dbS1D96j1IwfinPgaOioZgWruCPUTpHuDBWK0oj/El2y7RK5/PQV9+rBTqk+zeiIdU+1PwR65vM6by03BMHGQKQ2xxuHA4gZJa8WAKSFfzx1OyMps+cmRrDn9KExYMiYIlnrfGBTOIzh+Mk1mk2XZC5ca0jwS/juxQ8Cr2GGW1ZBFJVe10eZiShtxBda76ii28aLZd0Mm1k8rbMwfjflbnJtRhwYhLZlKyUCUbVx4NUvowZfBGNMq3TWivObMdhcO8KZpDqIqdkJAAZwiwOjxrTYrDyZxtA+1aR7ubV8vQ7Z9AiDEFmAE/a/DRulDa6E30+RL9GDcYTZmF/QlvCI5n7Z17H/Trb7xy8k6Q3xy1F5jqmPhpcv9yhi49F+TX5frbRmuxcjzdaDk7977/bpkW2o1ktfgAAAAASUVORK5CYII="))

    Dim canvas As New Bitmap(pic.Width, pic.Height)
    Dim sprite As Image = Image.FromStream(m)

    Dim g As Graphics = Graphics.FromImage(canvas)

    For x As Integer = 0 To Me.Width Step sprite.Width
      For y As Integer = 0 To Me.Height Step sprite.Height
        g.DrawImage(sprite, x, y, sprite.Width, sprite.Height)
      Next
    Next

    pic.Image = canvas
  End Sub

End Class