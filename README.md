# Video Game Catalogue

A full-stack video game catalogue application built with ASP.NET Core Web API and Angular. Features browse, create, and edit functionality with a layered architecture.

## Tech Stack

**Backend:** ASP.NET Core Web API, Entity Framework Core (Code First), SQL Server Express

**Frontend:** Angular, Bootstrap, ng-bootstrap

## Project Structure

- **VideoGameCatalogue.API**
  - Web API controllers, startup config
- **VideoGameCatalogue.Core**
  - Models, interfaces
- **VideoGameCatalogue.Services**
  - Business logic, validation
- **VideoGameCatalogue.Data**
  - DbContext, migrations, repository
- **VideoGameCatalogue.Tests**
  - Unit tests 
- **VideoGameCatalogue.Client**
  - Angular frontend


## Architecture

- **Repository Pattern** — separates database logic from business logic
- **Service Layer** — handles validation and business rules
- **Dependency Injection** — all layers communicate through interfaces for loose coupling and testability
- **Code First Approach** — database generated from C# models via EF Core migrations

## How to Run

### Backend
1. Install SQL Server Express
2. Update the connection string in `VideoGameCatalogue.API/appsettings.json` to point to your local database
3. Run migrations in Package Manager Console to update database with seed data:
   ```
   Update-Database
   ```
4. Run the API (default: `http://localhost:5151`)

### Frontend
1. Navigate to `VideoGameCatalogue.Client`
2. Install dependencies:
   ```
   npm install
   ```
3. Start the dev server:
   ```
   ng serve
   ```
4. Open `http://localhost:4200`

## API Endpoints

| Method | Endpoint              | Description         |
|--------|-----------------------|---------------------|
| GET    | /api/videogames       | Get all games       |
| GET    | /api/videogames/{id}  | Get a game by id    |
| POST   | /api/videogames       | Create a new game   |
| PUT    | /api/videogames/{id}  | Update a game       |
