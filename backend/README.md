# ZoneSync Backend

## Current Structure

- `ZoneSync.Domain/Models`: database tables represented as C# classes.
- `ZoneSync.Domain/Enums`: fixed values from SQL `CHECK` constraints.
- `ZoneSync.Domain/ViewModels`: simplified classes for display and screen data.
- `ZoneSync.Domain/Mapping`: manual mapping from models to view models.

## Phase 2 Notes

The project currently uses manual mapping, similar to the OOP demo:

```csharp
UserViewModel userViewModel = user.ToViewModel();
```

No `DbContext`, API controllers, or EF Core migrations have been added yet.
