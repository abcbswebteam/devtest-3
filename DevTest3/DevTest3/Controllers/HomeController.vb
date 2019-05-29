Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult

        Return View()

    End Function

    Function GetPlayerRanking() As ActionResult
        Dim model As New GetPlayerRanking With {
            .ErrorMessage = "Name cannot be empty"
        }
        Return View(model)

    End Function

    <HttpPost>
    Public Function GetPlayerRanking(model As GetPlayerRanking) As ActionResult

        Dim data As List(Of Player) = Player.CreatePlayersList()
        'Dim result As Player = Nothing
        If model Is Nothing Or String.IsNullOrEmpty(model.Name) Then
            model.ErrorMessage = "Name cannot be empty."
        Else
            Dim result As Player = data.FirstOrDefault(Function(p) p.Name.ToLower().Contains(model.Name.ToLower()))
            If result Is Nothing Then
                model.ErrorMessage = $"No player found with Name conatining {model.Name}"
            Else
                model.ErrorMessage = String.Empty
                model.Name = result.Name
                model.Ranking = result.Ranking
            End If
        End If

        'If Not String.IsNullOrEmpty(model.Name) Then
        '    result = data.Where(Function(d) d.Name.Contains(model.Name)).FirstOrDefault()
        'End If

        'model.Name = result.Name
        'model.Ranking = result.Ranking

        Return View(model)

    End Function
End Class
