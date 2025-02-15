# **Game Management API**  

## **Overview**  
The Game Management API is a RESTful service that enables users to manage games, publishers, and reviews efficiently. It supports full CRUD operations, advanced filtering, pagination, and follows the repository pattern for a clean and scalable architecture.  

## **Technologies Used**  
- **Backend:** C#, .NET, Entity Framework Core  
- **Database:** SQL Server  
- **Tools:** Swagger (API documentation)

## **Installation**  

1. Clone the repository:  
   ```sh
   git clone https://github.com/AhmedSaif2/GamefiyAPI.git
   cd GamefiyAPI
   ```  

2. Install dependencies:  
   ```sh
   dotnet restore
   ```  

3. Update database (Entity Framework migrations):  
   ```sh
   dotnet ef database update
   ```  

4. Run the application:  
   ```sh
   dotnet run
   ```  

## **Usage**  
- Access API documentation at `http://localhost:5000/swagger`  
- Test endpoints using Postman or any API client  

## **Sample Endpoints**  
| Method | Endpoint | Description |  
|--------|---------|-------------|  
| GET | `/api/games` | Get all games (with filtering & pagination) |  
| POST | `/api/games` | Add a new game |  
| PUT | `/api/games/{id}` | Update game details |  
| DELETE | `/api/games/{id}` | Remove a game |  

