Imports System.Xml

Public Class Player

    Property Id As Integer
    Property Name As String
    Property Ranking As String

    Public Shared Function CreatePlayersList() As List(Of Player)

        Dim list As New List(Of Player)

        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(HttpContext.Current.Server.MapPath(String.Format("~/App_Data/Players.XML")))
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/TeamAR/Player")

        For Each node As XmlNode In nodes
            Dim player As New Player
            player.Id = node.SelectSingleNode("Id").InnerText
            player.Name = node.SelectSingleNode("Name").InnerText.ToLower()
            player.Ranking = Integer.Parse(node.SelectSingleNode("Ranking").InnerText)
            list.Add(player)
        Next

        Return list

    End Function

End Class
