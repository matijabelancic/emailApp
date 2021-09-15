# EmailApp
Simple EmailApp build in Blazor WebAssembly with ASP.NET Core Web API.

## How to run

**Database migration**

For this project I use MSSQL so to enable migrations to database you need to do this:

Open application with Visual Studio (2017 or 2019), and open the Package Manager Console window.
To create a tables and transfer all the data from configuration files you need to apply:
```
PM> Update-Database
```

## Things demonstrated
- Blazor WebAssembly (client)
- ASP.NET Core Web API (server)
- Entity Framework Core
- MudBlazor components
- Pagination, Searching, Validation 
