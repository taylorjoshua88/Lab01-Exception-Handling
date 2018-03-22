About Me Quiz
=============
About Me Quiz is a simple demo of handling exceptions in C#. Additionally,
it uses JSON data contracts to load the questions from JSON files.

Dependencies
------------
About Me Quiz depends only on the .NET Core 2.0 runtime / SDK. This can be found
at the following URL for Windows, Linux, and macOS systems:

https://www.microsoft.com/net/download/windows

Running
-------
After cloning from GitHub, typing the following in your terminal of choice will
launch the program as long as the dotnet CLI utility is in your path:

    cd AboutMeQuiz
    dotnet build
    dotnet run

Additionally, the solution file can be opened within Microsoft Visual Studio 2017
or greater with .NET Core 2.0 or higher installed to build, run, and debug the program.

Operation
---------
About Me Quiz runs within the terminal and simply asks a series of questions
about the author (Josh Taylor), followed by opportunities for user input. Once all of
the questions have been answered, the program will give you a tally of your correct
answers versus the total number of questions. An opportunity to view the answer key
will be presented at the end.

Determining Success
-------------------
The program has functioned correctly if it receives all user input correctly, counts
answers as being true or false fairly (determined via the answer key), and is intuitive
for the end user.

Screenshots
-----------
![Asking Questions](https://github.com/taylorjoshua88/Lab01-Exception-Handling/raw/master/assets/questionsScreenshot.jpg)
![Answer Key](https://github.com/taylorjoshua88/Lab01-Exception-Handling/raw/master/assets/answerKey.jpg)