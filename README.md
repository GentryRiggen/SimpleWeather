SimpleWeather
=============

A simple weather app for Windows Phone that uses data from
http://openweathermap.org/

Considerations & Tradeoffs
==========================
I decided to display the table in what I will call a table-like format. For
mobile devices I believe that simple rows of data can appear bland and not very
touch friendly. Instead I chose a simple and slightly transparent box with rich
data inside that is inviting to touch. With this design choice I changed how
the sorting works from the traditional clicking of the column header. I instead
opted for a button in the appbar at the bottom of the page with a sort icon.
When pressed a menu of sorting options appear. When a sort is selected, I sort
the "cards" of data by the selected sort.

Code Description
================
I used the Model View Controller (MVC) design pattern.
    - In the View folder you will find "pages" for the UI and some partial pages
      for code reuse. I have only two full pages: the main view "HomeView" and
      the details view "DayView."
    - In the Model folder you will find my Plain Old C# Objects (POCOs ~ POJOs)
      that represent the data from the web service with a few additional
      properties and/or methods.
    - In the Controller folder I have only one controller that all my views
      bind to: "MainController." It is in the class that I coordinate all the
      work to be done. It initializes navigation services, dialog services,
      web services etc. It has class properties that the view binds to. It
      responds to user input by querying new data, sorting data etc.

I used a repository pattern for data access.
    - In the data folder at the root of the project there is another folder
      called "Repositories." I use an interface called "IRepository" where I
      have methods and fields that I want every repository to contain. For this
      project I have only one method "GetCityForecast" which accepts a city name
      as a parameter. I also have a "BaseRepository" that implements the
      "IRepository" interface. It is in this class that I have all the default
      implementations for interacting with the web service. It has things like
      the base URL, query string parameters and JSON converter class. For each
      data type I I want to query from the web service I create a new class
      that extends this base repository. Since we are only querying for one
      object I only have one extension of BaseRepository: CityWeatherRepository.

I did use a JSON serialization library even though in the challenge rules say
no third party/open source libraries allowed. I believed parsing JSON by hand
and mapping the data to a specific language's object is not the
point of this challenge. I do however understand the need to know and understand
the JSON data format so I have some examples of using the third party software
that displays this understanding (Other solutions will have similar use cases).
My model class called "CityWeatherForecast" contains a member field called
"DailyWeatherForecasts." I chose this name because it is more friendly than the
API's name of "list." To make this work I annotated my field with the third
party attribute that specified the JSON field name. When working with lots of
JSON data that is optimized to be as small as possible, you will have this
tradeoff of creating readable code and have effective code. That's my rant...
