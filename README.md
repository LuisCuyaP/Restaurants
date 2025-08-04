C:\Repositorios\Restaurants -> 
dotnet new webapi -n Restaurant.API --no-openapi -controllers
dotnet new sln -n Restaurants
dotnet sln add .\Restaurant.API\

Relacion
restaurant.api -> restaurant.application
restaurant.application -> restaurant.domain
restaurant.infrastructure -> restaurant.application
