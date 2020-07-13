# Unoffical_IMDB_API_C-Sharp

## Disclaimer:
I wrote this more than a year ago, I no longer use C# and have no intention of maintaining this.

If you need something like this, do yourself a favor and write it yourself, it's really just a simple webscraper.

## Documentation:

### Search IMDB:
>Searching imdb can be done by using the Get_SearchResults() function. This returns a list of IMDB_SearchResult objects. If we have a combobox in which we want to store our seach results as well as use for the actuall searching, we would first add a KeyDown event function to our code. In that function we would test if the enter key was pressed. If so, we want to search imdb for the text that was written in the textbox and then display the results in our combobox. The code for that would look like this:
```csharp
private void combobox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string search = combobox.Text;
                IMDB_SearchApi searchApi = new IMDB_SearchApi();
                List<IMDB_SearchResult> x = searchApi.Get_SearchResults(search);
                combobox.DataSource = x;
                combobox.SelectionStart = combobox.Text.Length;
                combobox.SelectionLength = 0;
            }
        }
```

### Get data about a specific movie/series:
>We now want to get all infos about a move/series that we selected in the combobox. First, inside the Selected_index_changed event for our combobox, we get a IMDB_SearchResult object from the selected object in the combobox like this:
```csharp
IMDB_SearchResult search = combobox.SelectedItem as IMDB_SearchResult;
```
>To get information about a movie/series we need the url to that movie. A IMDB_SearchResult object only gives us the ending of the link, so we need the full link. This is easily done like this:
```csharp
string full_url = "https://www.imdb.com/" + search.IMDB_TITLE_URL;
```
>Now we want to get a IMDB_Entry object. We archive that like this:
```csharp
IMDB_Entry entry = webToolsIMDB.Get_IMDB_Entry(full_url);
```
>Now we can acces everything in that object. If we wanted to get the title of the movie/series and display it in a label for example, we would do it like this:
```csharp
label.Text = entry.Name;
```

### Information fetched by the api:

| string            | type           | Information about what the entry is                                                                  | @movie                                                                                                                                                                                                                              |
|-------------------|----------------|------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| string            | url            | Full url to the imdb page                                                                            | https://www.imdb.com//title/tt1285016/?ref_=fn_tt_tt_1                                                                                                                                                                              |
| string            | name           | Title of the movie/series                                                                            | The Social Network                                                                                                                                                                                                                  |
| string            | image          | Url to cover image                                                                                   | https://m.media-amazon.com/images/M/MV5BOGUyZDUxZjEtMmIzMC00MzlmLTg4MGItZWJmMzBhZjE0Mjc1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg                                                                                                       |
| List<String>      | genre          | List of the genres                                                                                   | Biography, Drama                                                                                                                                                                                                                    |
| string            | content_rating | string containing the content rating                                                                 | PG-13                                                                                                                                                                                                                               |
| List<IMDB_Person> | actors         | List of IMDB_Person objects                                                                          | Jesse Eisenberg, Andrew Garfield, Justin Timberlake, Rooney Mara                                                                                                                                                                    |
| List<IMDB_Person> | directors      | List of IMDB_Person objects                                                                          | David Fincher                                                                                                                                                                                                                       |
| List<IMDB_Person> | creators       | List of IMDB_Person objects                                                                          | Aaron Sorkin, Ben Mezrich                                                                                                                                                                                                           |
| string            | description    |  string containing the description of the movie/series                                               | The Social Network is a movie starring Jesse Eisenberg, Andrew Garfield, and Justin Timberlake. Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, but is later sued by two... |
| string            | date           |  string containing the date on which the movie/series was first published                            | 2010-10-01                                                                                                                                                                                                                          |
| List<String>      | keywords       |  List of strings containing the keywords/tags of the movie                                           | facebook, entrepreneur, competitiveness, creator, intellectual property                                                                                                                                                             |
| IMDB_Rating       | rating         |  IMDB_Rating object containing Best-, Worst- and average rating as well as the total number of votes | (Total number of votes) 7.7                                                                                                                                                                                                         |
| string            | duration       | string containing the duration of the movie (Currently not functional for series)                    | 02:00:00                                                                                                                                                                                                                            |
