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
        'when compairing string, it is better to match the case as well and trim it for avoid any blankspace
        If Not String.IsNullOrEmpty(model.Name) Then
            result = data.Where(Function(d) d.Name.ToLower().Trim() == model.Name.ToLower().Trim()).FirstOrDefault()
        End If
            'If no data found then result would be NULL and so it can throw null object reference exception
            if Not result Is NULL THEN    
                model.Name = result.Name
                model.Ranking = result.Ranking
            END IF

        Return View(model)

    End Function
End Class
