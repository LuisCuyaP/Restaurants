C:\Repositorios\Restaurants -> 
- dotnet new webapi -n Restaurant.API --no-openapi -controllers
- dotnet new sln -n Restaurants
   dotnet sln add .\Restaurant.API\

Relacion: 
- restaurant.api -> restaurant.application
- restaurant.application -> restaurant.domain
- restaurant.infrastructure -> restaurant.application

Migracion:
- dotnet ef migrations add Init --project Restaurants.Infrastructure --startup-project Restaurants.Infrastructure
- docker ps
- docker logs RestaurantsDb
- sqlcmd -S localhost,1433 -U sa -P SwN12345678 -Q "SELECT @@VERSION"
- dotnet build
- dotnet ef database update --project Restaurants.Infrastructure --startup-project Restaurants.Infrastructure}
