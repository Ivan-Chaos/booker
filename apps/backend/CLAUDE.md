# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

ASP.NET Core minimal API on .NET 10 — the backend of the Booker monorepo (the Next.js frontend lives in `apps/frontend` and is developed independently). Solution file is `Booker.slnx` with a single project, `Booker.Api`.

## Commands

Run from `apps/backend`:

```powershell
dotnet build Booker.slnx
dotnet run --project Booker.Api   # http://localhost:5241 (https profile: https://localhost:7198)
```

There are no test projects yet.

## Architecture

- `Booker.Api/Program.cs` — minimal API entry point (no controllers); services and endpoint mappings are wired here
- `Booker.Api/Endpoints/` — intended home for endpoint definitions, mapped from `Program.cs`
- `Booker.Api/Data/BookerContext.cs` — EF Core `DbContext` backed by PostgreSQL via `Npgsql.EntityFrameworkCore.PostgreSQL`, registered in `Program.cs`
- `Booker.Api/Models/` — entity classes exposed as `DbSet`s on `BookerContext`

The `BookerDb` connection string comes from .NET user secrets in local dev (`dotnet user-secrets set "ConnectionStrings:BookerDb" "..."` — note `:`, not `__`; the `__` form only works for real environment variables). The app throws at startup if it is missing. `Data/BookerContextFactory.cs` gives `dotnet ef` the same configuration at design time.

EF migrations live in `Data/Migrations/`; create new ones with `dotnet ef migrations add <Name> --output-dir Data/Migrations`. Seed data is defined via `HasData` in `BookerContext.OnModelCreating`.

Nullable reference types and implicit usings are enabled project-wide.
