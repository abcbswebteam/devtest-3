Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult

        Return View()

    End Function

    Function GetPlayerRanking() As ActionResult

        Dim model As New GetPlayerRanking()
        Return View(model)

    End Function

    <HttpPost>
    Public Function GetPlayerRanking(model As GetPlayerRanking) As ActionResult

        Dim data As List(Of Player) = Player.CreatePlayersList()
        Dim result As Player = Nothing
        Dim attemptedFetch As Boolean = False

        If Not String.IsNullOrEmpty(model.Name) Then
            attemptedFetch = True
            result = data.Where(Function(d) d.Name.IndexOf(model.Name, 0, StringComparison.CurrentCultureIgnoreCase) > -1).FirstOrDefault()
        End If

        If result IsNot Nothing Then
            model.Name = result.Name
            model.Ranking = result.Ranking
        ElseIf attemptedFetch Then
            model.Name = "Not Found"
            model.Ranking = 0
        Else
            model.Name = Nothing
            model.Ranking = -1
        End If
        Return View(model)

    End Function
End Class
