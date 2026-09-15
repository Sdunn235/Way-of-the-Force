# Way of the Force

Way of the Force is an ASP.NET Core MVC application for browsing Star Wars
alliances and their Force-related information.

## Features

- Lists eight seeded Star Wars groups.
- Shows each group's creed, Force affinity, friendliness, and Holocron count.
- Provides a details page for each group.
- Keeps Holocron counts at zero until the application can load a real Holocron list.

The current seeded groups are the Jedi Order, Sith Order, Rebel Alliance,
Galactic Empire, Mandalorian Clans, Wookiee Clans, Imperial Knights, and
Jeaii Order.

## Project Structure

- `WayOfTheForce.Web/Models/Creeds.cs` defines the alliance model.
- `WayOfTheForce.Web/Models/CreedsData.cs` contains the temporary in-memory seed data.
- `WayOfTheForce.Web/Controllers/CreedsController.cs` serves the list and details pages.
- `WayOfTheForce.Web/Views/Creeds/` contains the Razor views.

## Run Locally

From this directory, start the application with:

```powershell
dotnet watch --project .\WayOfTheForce.Web
```

The project targets .NET 10. To build it without starting the watcher:

```powershell
dotnet build .\WayOfTheForce.Web\WayOfTheForce.Web.csproj
```

## Azure Deployment

The app is deployed as a Windows Azure App Service using the .NET 10 runtime.
The current deployed site is:

https://sd-web-sd002.azurewebsites.net
