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

        If Not String.IsNullOrEmpty(model.Name) Then
            result = data.Where(Function(d) d.Name.ToUpper().Contains(model.Name.ToUpper())).FirstOrDefault()
        End If

        If (IsNothing(result) = False) Then
            model.Name = result.Name
            model.Ranking = result.Ranking
        End If


        Return View(model)

    End Function
End Class
