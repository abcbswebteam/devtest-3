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

        If (String.IsNullOrEmpty(model.Name)) Then
            model.Message = "Please provide a player name to search."
            Return View(model)
        End If

        Dim data As List(Of Player) = Player.CreatePlayersList()
        Dim result As Player = New Player()

        If Not String.IsNullOrEmpty(model.Name) Then
            result = data.Where(Function(d) d.Name.ToLower().Contains(model.Name.ToLower())).FirstOrDefault()
        End If

        If (result Is Nothing) Then
            model.Message = "A player by that name was not found."
        Else
            model.Name = result.Name
            model.Ranking = result.Ranking
        End If

        Return View(model)

    End Function
End Class
