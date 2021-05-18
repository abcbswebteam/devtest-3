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
             @Using Html.BeginForm()
                 @Html.ValidationSummary(True)
                 @<fieldset>
                      <div class="editor-field">
                          @Html.LabelFor(Function(m) m.Name, "Player Name")
                          @Html.TextBoxFor(Function(m) m.Name, New With {.class = "form-control"})
                          @Html.ValidationMessageFor(Function(m) m.Name)
                      </div>
                     <Button Class="btn btn-primary" type="submit" value="Submit">Submit</Button>
                 </fieldset>
             End Using
             @If Model.Ranking >= 0 Then
                 @<div class="row">
                     <div class="col-md-4">
                         <h2>@Model.Name</h2>
                         <p>
                             <strong>Ranking :       </strong>  @Model.Ranking
                         </p>

                     </div>

                 </div>
             End If

         </div>
    </div>

End Using 