Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Порождается при запуске приложения
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Порождается при начале сеанса
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Порождается в начале каждого запроса
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Порождается при попытке выполнить проверку подлинности для запроса
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Порождается при возникновении ошибки
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Порождается при завершении сеанса
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Порождается при завершении приложения
    End Sub

End Class