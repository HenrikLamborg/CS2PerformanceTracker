# CS2PerformanceTracker

A CS2 player performance tracking application built with ASP.NET Core and C#.

The application allows users to search for Counter-Strike 2 players using a Steam ID, Steam profile URL, or Steam vanity URL, and retrieves player statistics from Leetify.

## Getting Started

### Requirements

Before running the project, make sure you have:

* [.NET 10 SDK](https://dotnet.microsoft.com/download)
* Git
* A Steam Web API key
* A Leetify API key

### Configuration

The application requires API keys for Steam and Leetify. These are stored using **.NET User Secrets** so that sensitive information is kept outside the repository.

After cloning the repository, navigate to the API project:

```bash
cd backend/CS2PerformanceTracker.API
```

Initialize User Secrets:

```bash
dotnet user-secrets init
```

Add your API keys:

```bash
dotnet user-secrets set "Steam:ApiKey" "YOUR_STEAM_API_KEY"
dotnet user-secrets set "Leetify:ApiKey" "YOUR_LEETIFY_API_KEY"
```

You can verify that the secrets have been added with:

```bash
dotnet user-secrets list
```

**Do not commit API keys or other sensitive information to the repository.**

### Build and Run

From the API project directory, restore the project dependencies:

```bash
dotnet restore
```

Build the project:

```bash
dotnet build
```

Run the application:

```bash
dotnet run
```

The terminal will display the URL where the application is running.

### Fresh Setup

For a fresh clone, the complete setup is:

```bash
git clone <repository-url>
cd CS2PerformanceTracker/backend/CS2PerformanceTracker.API

dotnet user-secrets init
dotnet user-secrets set "Steam:ApiKey" "YOUR_STEAM_API_KEY"
dotnet user-secrets set "Leetify:ApiKey" "YOUR_LEETIFY_API_KEY"

dotnet restore
dotnet build
dotnet run
```


## Dashboard

The dashboard provides an overview of player performance, including Steam profile information, Leetify statistics, performance summaries, and recent matches.

![CS2 Performance Tracker Dashboard](docs/images/dashboard.png)

## Performance Analytics

The application provides interactive performance trends where users can switch between different metrics such as Leetify Rating, K/D ratio, kills, and deaths.

![Performance Trend and Recent Matches](docs/images/recent-match-and-graph.png)

## Features

- Search players using:
  - Steam64 ID
  - Steam profile URL
  - Steam vanity URL
- Resolve Steam users through the Steam Web API
- Retrieve player statistics from Leetify API
- Dashboard displaying player performance metrics
- ASP.NET Core MVC frontend with Razor Views

## Tech Stack

### Backend
- ASP.NET Core Web API
- C#
- Steam Web API
- Leetify API

### Frontend
- ASP.NET Core MVC
- Razor Views
- Bootstrap

## Project Status

Currently building the foundation for a CS2 performance tracking platform.
Future improvements include advanced statistics, performance trends, and AI-based player insights.
