# boilerplate-aspnet-sqlite

This is a boilerplate project for an ASP.NET Core application using SQLite as the database. It includes basic setup for a RESTful API with user management.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started)

### Running the Application

1. **Clone the repository:**

    ```sh
    git clone <repository-url>
    cd boilerplate-aspnet-sqlite
    ```

2. **Build and run the application using Docker:**

    ```sh
    docker-compose up --build
    ```

3. **Access the API:**

    The API will available at `http://localhost:5279` and `https://localhost:7056`.

### Configuration

- **Connection Strings:**

    The connection string for the SQLite database is configured in `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Data Source=../database.sqlite"
      }
    }
    ```

### API Endpoints

- **Create Users Table:**

    ```http
    GET /create-users-table
    ```

- **Add User:**

    ```http
    POST /add-user?name={name}
    ```

- **Get Users:**

    ```http
    GET /users
    ```

## Project Details

- **User Service:**

    The `UserService` class in `UserService.cs` handles the database operations for user management.

- **User Controller:**

    The `UsersController` class in `UsersController.cs` exposes the API endpoints for user management.

## License

This project is licensed under the MIT License.