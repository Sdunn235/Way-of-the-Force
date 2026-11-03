# Way of the Force

A guide to the orders and factions of the Star Wars galaxy: what each one
believes, where it calls home, and which holocrons it guards. Built for .NET Web
Development at WCTC.

**Live:** https://sd-web-sd002.azurewebsites.net

## What it does

- Browse every creed, with its beliefs, homeworld, and lean toward the light or dark side
- Open a creed to see its holocrons and any other creeds that share its homeworld
- Browse the whole holocron archive in one list
- Add, edit, and remove creeds and holocrons
- Switch the whole site between Light, Grey, and Dark Side themes from the front page

## The three things I fixed for the midterm

1. Holocrons could be added but never corrected or removed, so a mistake stayed on the site for good. Every holocron can now be edited and removed.
2. Each card showed a hand-typed holocron total beside the real count, and the two disagreed. Cards now show only the real count.
3. Cards showed a bare Force Affinity number, had two links to the same page, and ran in one long column. They now say what the number means, have one link, and sit in a grid that stacks on a phone.

## Built with

ASP.NET Core MVC (.NET 10), Entity Framework Core, SQL Server, Bootstrap, and Bootswatch themes.

The seeded holocrons come from [Wookieepedia](https://starwars.fandom.com/wiki/Category:Holocrons),
each matched to the creed that made or held it. Where Wookieepedia gives no year
it was made, the earliest year it does give is used.

## Running it locally

You need the .NET 10 SDK, the `dotnet-ef` tool, and a SQL Server database. The
connection string lives in user secrets, not in this repo. From the
`WayOfTheForce.Web` folder:

    dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<your connection string>"
    dotnet ef database update
    dotnet watch
