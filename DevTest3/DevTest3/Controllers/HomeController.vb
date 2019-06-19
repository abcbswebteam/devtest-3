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
        Dim result As Player = New Player()

        'If Not String.IsNullOrEmpty(model.Name) Then
        '    result = data.Where(Function(d) d.Name.Contains(model.Name)).FirstOrDefault()
        'End If

        If Not String.IsNullOrEmpty(model.Name) Then
            result = data.Where(Function(d) d.Name.ToLower.Contains(model.Name.Trim().ToLower)).FirstOrDefault()
            If (result Is Nothing) Then
                model.Name = "Player not found"
                model.Ranking = 0
            Else
                model.Name = result.Name
                model.Ranking = result.Ranking
            End If
        Else
            model.Name = "Please Enter valid player name to look up"
            model.Ranking = -1
        End If



        Return View(model)

    End Function
End Class
