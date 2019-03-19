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

            @If Model.Message <> "" Then
                @<div class="row">
                    <div class="col-md-6 alert-warning">
                        @Model.Message
                    </div>
                </div>
            End If

            @If Model.Ranking <> "" Then
                @<div class="row">
                    <div class="col-md-4">
                        <h2>@Model.Name</h2>
                        <p>
                            <strong>Ranking:</strong>  @Model.Ranking
                        </p>
                    </div>
                </div>
            End If

        </div>
    </div>

End Using 