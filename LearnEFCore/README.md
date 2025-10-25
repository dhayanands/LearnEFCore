# LearnEFCore Project

This project demonstrates the use of **Entity Framework Core (EF Core)** with a PostgreSQL database, following the **Clean Architecture** pattern.

---

## Project Structure

The project is organized into the following layers:

- **Core**: Contains the domain entities and business logic.
- **Application**: Contains interfaces and application-specific logic.
- **Infrastructure**: Contains the database context and repository implementations.
- **Presentation**: Contains the API controllers and user-facing components.

---

## Prerequisites

Ensure the following tools are installed and available on the `PATH`:

- **.NET SDK**: Install the latest version from [dotnet.microsoft.com](https://dotnet.microsoft.com/).
- **PostgreSQL**: Install PostgreSQL and ensure the database server is running.
- **EF Core CLI**: Install the EF Core tools globally:

  ```bash
  dotnet tool install --global dotnet-ef
  ```

---

## Setting Up the Project

1. **Install Dependencies**:
   Run the following command to restore NuGet packages:

   ```bash
   dotnet restore
   ```

2. **Configure the Database**:
   Update the `appsettings.json` file with your PostgreSQL connection string:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=LearnEFCore;Username=postgres;Password=yourpassword"
     }
   }
   ```

3. **Run Migrations**:
   Generate and apply migrations to set up the database schema.

---

## Working with Migrations

Migrations in EF Core are used to manage changes to the database schema. Below are the steps to work with migrations:

### 1. Add a Migration

When you make changes to your entity classes or `DbContext`, create a new migration to capture those changes:

```bash
dotnet ef migrations add <MigrationName>
```

Replace `<MigrationName>` with a descriptive name for the migration (e.g., `AddStudentAddress`).

### 2. Apply the Migration

Apply the migration to update the database schema:

```bash
dotnet ef database update
```

### 3. Roll Back a Migration

If you need to revert to a previous migration, use:

```bash
dotnet ef database update <PreviousMigrationName>
```

Replace `<PreviousMigrationName>` with the name of the migration you want to roll back to.

---

## Running the Application

1. Start the application:

   ```bash
   dotnet run --project LearnEFCore
   ```

2. Open the API in your browser:

   ```bash
   "$BROWSER" http://localhost:5000
   ```

3. Test the available endpoints:

   - Root endpoint: `http://localhost:5000/` (returns a welcome message)
   - Quotes endpoint: `http://localhost:5000/quotes` (retrieves a random quote)
   - Students endpoint: `http://localhost:5000/students` (retrieves all students)

---

## Notes

- The `AppDbContext` class is configured to use PostgreSQL via the `UseNpgsql` method.
- Ensure the `Npgsql.EntityFrameworkCore.PostgreSQL` package is installed in the project.
