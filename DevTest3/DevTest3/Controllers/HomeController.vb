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
		Try


            Dim data As List(Of Player) = Player.CreatePlayersList()
            Dim result As Player = Nothing

            If Not String.IsNullOrEmpty(model.Name) Then
                'result = data.Where(Function(d) d.Name.Contains(model.Name)).FirstOrDefault()

                ' Replaced where with Single to fix the search. Changed the value to lower case to prevent case sensitive search.
                result = data.Single(Function(x) x.Name.ToLower().Contains(model.Name.ToLower()))

            End If

            If result Is Nothing Then
                model.Name = ""
            Else
                model.Name = result.Name
            End If

            If result Is Nothing Then
                model.Ranking = 9999999
            Else
                model.Ranking = result.Ranking
            End If
        Catch ex As Exception
            model.Ranking = 9999999
            model.Name = "Player name not found"
            Return View(model)
        End Try
        Return View(model)

    End Function
End Class
