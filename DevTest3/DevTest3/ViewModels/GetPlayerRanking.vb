Imports System.ComponentModel.DataAnnotations

Public Class GetPlayerRanking
    <Required(ErrorMessage:="Please enter player name")>
    Property Name As String
    Property Ranking As Integer

End Class
