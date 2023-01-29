# Setup

* 1.Clone the repository to your local machine
* 2.Open the solution in Visual Studio
* 3.In the appsettings.json file, change the connection string to match your database settings
* 4.In the SeBook/SeBookWeb/Areas/Admin/Controllers/OrderController, change ```var domain = "https://localhost:44377/";``` to your localhost address
* 5.Open the Package Manager Console and run the command
```
update-database
``` 
to apply any pending migrations and update the database
* 6.Build and run the application
