# CustomerCrud Application
This is an ASP.NET application that provides a simple customer management system. It includes both an API and a front-end, all within the same solution. The application uses Entity Framework Core for database interactions and Microsoft SQL Server as the database.

## Features

- Create, read, update, and delete (CRUD) operations for customers.
- Entity Framework Core for database access.
- ASP.NET Core API to handle customer data.
- Front-end built with Razor Pages and Javascript for cleint side rendering
- Microsoft SQL Server for data storage.

 ### Prerequisites

- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) 
- [Visual Studio](https://visualstudio.microsoft.com/) 

### Setup

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/itsAanis/ASPNET-Customer.git
   cd ASPNET-Customer

 2.  Update the Database Connection String:

Open appsettings.json in the root of the project.
Add your database connection string to the ConnectionStrings section

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "YourDatabaseConnectionStringHere"
  }
}

```
3.
Configure the API Base URL:

Open Index.cshtml in the front-end part of the project.
Change the apiBaseUrl to match your local setup (port number may vary):

```
const apiBaseUrl = 'https://localhost:7208/customers';
```
Usage
The front-end provides a simple interface to manage customers.
Use the provided forms to add, update, and delete customers.
The customer list will be dynamically updated as you interact with the API.
Technologies Used
ASP.NET Core
Entity Framework Core
Razor Pages
Microsoft SQL Server
Bootstrap (for front-end styling)
