# ZoneSync Backend

## Current Structure

- `ZoneSync.Domain/Models`: database tables represented as C# classes.
- `ZoneSync.Domain/Enums`: fixed values from SQL `CHECK` constraints.
- `ZoneSync.Domain/ViewModels`: simplified classes for display and screen data.
- `ZoneSync.Domain/Mapping`: manual mapping from models to view models.
- `ZoneSync.Domain/Validation`: manual validation using interfaces and validator classes.
- `ZoneSync.Domain/Services`: simple business services that connect related objects.
- `ZoneSync.Domain/Repositories`: generic in-memory repositories for practicing collections.
- `ZoneSync.ConsoleDemo`: console project that creates sample objects and prints view models.

## Phase 2 Notes

The project currently uses manual mapping, similar to the OOP demo:

```csharp
UserViewModel userViewModel = user.ToViewModel();
```

No `DbContext`, API controllers, or EF Core migrations have been added yet.

## Phase 3 Notes

Run the console demo from the repository root:

```powershell
dotnet restore backend\ZoneSync.Backend.sln --configfile NuGet.Config
dotnet build backend\ZoneSync.Backend.sln --no-restore
dotnet run --project backend\ZoneSync.ConsoleDemo\ZoneSync.ConsoleDemo.csproj
```

The demo creates related objects in memory, such as `Farm`, `Zone`, `CropPlan`,
`Alert`, and `TaskItem`, then maps them to view models using `ToViewModel()`.

## Phase 4 Notes

Validation is manual and uses an interface contract:

```csharp
IModelValidator<User> validator = new UserValidator();
ValidationResult result = validator.Validate(user);
```

This keeps the current phase focused on OOP concepts: interfaces, classes,
method implementation, and object validation without adding EF Core or APIs yet.

## Phase 5 Notes

Business operations are now moved to services:

```csharp
IFarmService farmService = new FarmService();
Zone zone = farmService.CreateZone(farm, owner, 1, 20.75m, ZoneStatus.Planted);
```

The services are still in-memory and OOP-focused. They create objects and update
navigation lists, but they do not save data to a database yet.

## Phase 6 Notes

The project now has a generic repository contract:

```csharp
IRepository<User> users = new InMemoryRepository<User>();
users.Add(owner);
```

`ZoneSyncMemoryStore` groups repositories for the demo. This is only an
in-memory collection layer for practicing generics, interfaces, and `List<T>`.
It is not a replacement for SQL Server or EF Core.
