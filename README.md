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
- dotnet ef database update --project Restaurants.Infrastructure --startup-project Restaurants.Infrastructure

Migracion.V2:
- dotnet ef migrations add Init --project Restaurants.Infrastructure --startup-project Restaurants.API
- dotnet ef database update --project Restaurants.Infrastructure --startup-project Restaurants.API

Migracion.v3 (Configuracion con identity)
- me situo para cualquier migracion que dese hacer en : C:\Repositorios\Restaurants --> dotnet ef migrations add IdentityAdded --project Restaurants.Infrastructure --startup-project Restaurants.API
- dotnet ef database update --project Restaurants.Infrastructure --startup-project Restaurants.API

Asociar roles a los usuarios ( ejecutar inserts en sql server )
- select * from aspnetusers
- select * from aspnetroles
- select * from aspnetuserroles

- insert into aspnetuserroles values ('26631c72-e7f2-49e4-8acf-668e516a3be7','67785d8c-0ba1-4db0-841f-54b978552823')
- insert into aspnetuserroles values ('42f07eca-0c85-40ad-bde6-0982a8975cad','e79b646b-6cd5-4267-84e2-9632b1bf61ea')
- insert into aspnetuserroles values ('74a2498e-e980-450e-bb0b-028b1c5185bb','81c646a9-e5fe-49a6-a322-cf1ada4b9232')
