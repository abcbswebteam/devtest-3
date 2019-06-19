@ModelType GetPlayerRanking
@Code
    ViewData("Title") = "Get Player Ranking"
End Code

<div class="Index">
    <h1>Player Ranking Lookup</h1>

</div>


@Using Html.BeginForm()

    @<div class="row">
        <div class="col-md-6">
            <div class="form-group">
                @Html.LabelFor(Function(m) m.Name, "Player Name")
                @Html.TextBoxFor(Function(m) m.Name, New With {.class = "form-control"})
            </div>
            <button class="btn btn-primary" type="submit" value="Submit">Submit</button>

            
                <div class="row">
                    <div class="col-md-4">
                        <h2>@Model.Name</h2>


                        @*@If Model.Ranking = -1 Then
                            @<p>
                                <strong>Ranking :  </strong> "Please provide valid name to search"
                            </p>
                        ElseIf Model.Ranking = 0 Then
                            @<p>
                                <strong>Ranking :  </strong> "Player not found""
                            </p>
                        End if*@


                        @IF Model.Ranking > 0 THEN
                        @<p>
                            <strong>Ranking :  </strong> @Model.Ranking
                        </p>
                        End IF

                    </div>

                </div>
          

        </div>
    </div>

End Using 