# .Net Core API Testing

ASP.NET Core Application with RESTful HTTP services.

# Getting Started
To get started with this project, follow these steps:

1) Clone or download the repository in your local machine.<br>
```cmd
  git clone https://github.com/notwld/dotnet-core-testing
```
2) Run `database_init.sql` script in SQLServer.
3) Open the solution file in Visual Studio.<br>
4) Change the connection string in `Connection.cs`
```cmd
  "Data Source=*insert your server name*; Initial Cadtalog=*insert your database name*;Integrated Security = True;"
```
or
```cmd
  "Data Source=*insert your server name*; Initial Cadtalog=*insert your database name*;User=*insert your username*;Password=*insert your password*;"
```
`Note: If there's an error in initializing a connection to SQLSever, make sure to start sql services and TCP/IP protocol enabled via SQL Server Configration Manager.`<br><br>
5) Run the application by pressing F5 or by clicking the Start button.
