# Dima

Dima is a .NET 8.0 web API for managing financial categories and transactions. It uses Entity Framework Core with SQL Server and follows a clean architecture with separate API and Core projects.

## Project Structure

- **Dima.Api/** – ASP.NET Core Web API
  - `Program.cs` – API entry point
  - `Data/` – EF Core DbContext, mappings, migrations, and SQL scripts
  - `Endpoints/` – Minimal API endpoints for categories
  - `Handlers/` – Business logic for categories
  - `Common/` – Shared API interfaces
  - `appsettings.json` – Configuration

- **Dima.Core/** – Domain models and business logic
  - `Models/` – Category, Transaction entities
  - `Enums/` – Transaction type enum
  - `Requests/` – Request DTOs for endpoints
  - `Responses/` – Response DTOs for endpoints
  - `Handlers/` – Handler interfaces
  - `Configuration.cs` – Default values

## Getting Started

1. **Requirements**
   - [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
   - SQL Server

2. **Setup Database**
   - Update `Dima.Api/appsettings.json` with your SQL Server connection string or in user secrets.
   - Run EF Core migrations to create the database:
     ```sh
     dotnet ef database update --project Dima.Api
     ```

3. **Run the API**
   ```sh
   dotnet run --project Dima.Api
   ```
   The API will be available at `http://localhost:5078` (see launchSettings.json).

4. **API Documentation**
   - Swagger UI is enabled at `/swagger`.

## Features

- CRUD operations for categories
- Pagination support for listing categories
- Transaction model (not yet exposed via endpoints)
- Clean separation of concerns

## Development

- Endpoints are defined in [Dima.Api/Endpoints/](Dima.Api/Endpoints/)
- Business logic is in [Dima.Api/Handlers/](Dima.Api/Handlers/) and [Dima.Core/Handlers/](Dima.Core/Handlers/)
- Domain models and DTOs are in [Dima.Core/Models/](Dima.Core/Models/), [Dima.Core/Requests/](Dima.Core/Requests/), and [Dima.Core/Responses/](Dima.Core/Responses/)

## License

MIT (add your license file if needed)

---

**Note:** This project uses a hardcoded user ID (`teste@dev.com`) for demonstration. Update authentication and user management as