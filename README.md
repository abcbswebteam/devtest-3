# Dev Test 3

## Scenario
You have taken up maintenance on an application created by another developer.  
The application allows searching for a player by name to view their ranking.  
Testers have found several bugs.

### Bugs
* Searching by name does not work correctly.
  * Seaching for "john doe" or "jake rob" does not seem to work.
* When no player is found, a 500 error occurs.
* When no player is entered and submit is pressed, a 500 error occurs.

## Your Task
In your pull request
* Describe in detail the reason that the search was not always working.
* Fix all of the bugs.  For the 500 errors listed above, have it show an appropriate message.

## Explanation
* Bug: Searching for name does not work correctly -- Searching for "john doe" or "jake rob" does not seem to work.
    * In the given code, the search function is using the System.String.Contains(string str) method. 
        This is a case-sensitive string comparator. So searching for "john doe" when the stored value is "John Doe" would 
        produce no results. The same explaination is true for "jake rob"
    * This bug is remedied by, in the .Where() (or .FirstOrDefault()) Linq queries, adding ".ToLower()" to both
        the parameter.Name and model.Name 
        --> data.FirstOrDefault(Function(p) p.Name.ToLower().Contains(model.Name.ToLower()))
        This effectively ignores the case-sensitve nature of the System.String.Contains() method.
* Bug: When no player is found, a 500 error occurs.
    * In the given code, if a player is not found, the "result" variable is set to Nothing by the FirstOrDefault() Linq method.
        This causes a NullReferenceException when the code tries to access result.Name in the line "model.Name = result.Name".
        This unhandled NullReferenceException causes the 500 error for this instance.
    * This is remedied for adding a case for when result Is Nothing. A property was added to the GetPlayerRanking.cs model for 
        ErrorMessage. Upon reachign the case when result Is Nothing, an appropriate error message is displayed in the View
        telling the user that "No player found with Name conatining {model.Name}"
* Bug: When no player is entered and submit is pressed, a 500 error occurs.
    * Similar to the previous bug, if nothing is entered into the search field, then no results will be found.
        This results in the same unhandled NullReferenceException causing a 500 error.
    * This is remedied by adding a condition for when the model Is Nothing or model.Name is null or empty.
        An appropriate error message of "Name cannot be empty" is displayed to the user in this condition.