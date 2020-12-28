Montreal Dating App V1.1

Authors: Kurosh Farsi Madan, Zahra Rezaeisavadkohi

About?
This project is a simple skeleton for Angular + .NET Core. All of the necessary
error handling or logic has not been added so use it with caution. This project
is not supposed to be user friendly or follow the best practices in Angular routing or
security. It is only to be used for learning basic concepts for students or new people 
in web development. A lot of the stuff shown in this project is very standard basic stuff
and should be easily understandable. Everything you see in this project should be something that
you have seen in your previous projects in terms of naming, folder hierarchy or logic or you will 
see in your future projects whether they are university projects or real world applications. 
For all questions or help, send an email to kurosh_farsimadan@yahoo.com. I also provide tutorial
sessions to those who need help in programming for free. 

Possible future rework for V1.2?
- Add proper user session and security handling
- Add a proper module to handle all error messages
- Refactor the UI with Angular Material or Angular Bootstrap + customize with a good theme
- Error handling logic in both backend and frontend
	-> Required annotation for models
	-> Error message handling for SQL queries
	-> Error message handling for other known and unknown errors
	-> Error message handling in the UI/Angular
	-> Fix the login section error message. Now when you login, the application does not throw an error if your username does not exist
- Break down some Angular components using the standardized naming strategies
for services, guards, components and so on. Make reusable functions for some of 
logic. 
- Add a stepper for the user profile creation. I thought that this needs its own
bullet point as it is a feature in itself. 
- ...more

Project technology stack 
	- .NET Core 
	- Angular 8 
	- Sqlite
	- HTML5
	- CSS
	- Bootstrap framework
	- JWT

Core concepts
	- Single Page Application
	- API (possibility to refactor into microservice)
	- API and SPA security using database authentication and password encryption

Basic instructions 
1. Install "Microsoft Sqlite" from the package manager
2. Install https://www.nuget.org/packages/dotnet-ef/
and run "dotnet ef migrations add InitialCreate -o Data/Migrations"
in the root of the project folder. To undo use "ef migrations remove"
3. Run "dotnet ef database update"
4. Run the dummy data test script insertion for the database
5. Install Postman for testing the API
6. Run the project

BONUS
7. Run the project using HTTPS/SSL. Generate certificate for this
and add the necessary configuration


