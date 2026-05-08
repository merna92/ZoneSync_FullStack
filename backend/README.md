# ZoneSync Backend

## Current Structure

- `ZoneSync.Domain/Models`: database tables represented as C# classes.
- `ZoneSync.Domain/Enums`: fixed values from SQL `CHECK` constraints.
- `ZoneSync.Domain/ViewModels`: simplified classes for display and screen data.
- `ZoneSync.Domain/Mapping`: manual mapping from models to view models.
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
