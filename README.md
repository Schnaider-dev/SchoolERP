# School ERP

A multi-school SaaS platform that gives each school its own online space to manage daily operations: students, staff, classes, enrollment, finances, and communication.

> **Status:** 🚧 In active development. Currently building the authentication module (back end). The front end has not been started yet.

## Overview

Each school registers its own account and gets:
- A public showcase page presenting the school
- A management workspace with role-based dashboards

Users see only what their role allows: administrator, director, secretary, finance staff, discipline prefect, teacher, student, or parent.

## Progress

**Back end**
- [x] ASP.NET Core Web API project structure with a folder per module
- [x] Database models (initial set) on SQLite for development
- [x] Authentication: login and registration endpoints (JWT)
- [ ] Authentication: Google OAuth *(in progress)*
- [ ] Role-based access control
- [ ] School registration (multi-tenant)
- [ ] Student, teacher, and staff management
- [ ] Classes, courses, and schedules

**Planned**
- [ ] Next.js front end and role-based dashboards
- [ ] Finance module (student fees, teacher and staff payroll)
- [ ] Assignments, grading, and attendance
- [ ] Announcements by email and in-app notifications
- [ ] Online video classes with a shared whiteboard
- [ ] Parent portal and public directory of schools

## Tech Stack

| Layer | Technology |
|-------|------------|
| Back end | ASP.NET Core Web API (controllers), C# |
| Authentication | JWT, Google OAuth (in progress) |
| Database | SQLite (development), PostgreSQL (planned for production) |
| Front end | Next.js, React *(planned)* |

## Getting Started

### Prerequisites
- .NET SDK <net10.0>

### Run the API
```bash
cd <Backend/EduSaasBackend>
dotnet restore
dotnet ef database update
dotnet run
```

The database schema is managed with **Entity Framework Core migrations**. The `dotnet ef database update` command creates the local SQLite database and applies all migrations. If you don't have the EF Core CLI yet, install it once with:

```bash
dotnet tool install --global dotnet-ef
```

To add a new migration after changing a model:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

### Configuration
- `Jwt:Key`: a secret used to sign tokens
- `Jwt:Issuer` / `Jwt:Audience`: <my values>
- `Authentication:Google:ClientId` / `ClientSecret`: *(once Google OAuth is added)*

## API Endpoints (current)

| Method | Route | Description |
|--------|-------|-------------|
| POST | `/api/auth/register` | Create an account |
| POST | `/api/auth/login` | Log in and receive a JWT |

## Roadmap

1. Finish authentication (JWT + Google OAuth) and role-based access
2. School registration and multi-tenant data separation
3. Student, staff, and class management
4. Next.js front end and dashboards
5. Finance, grading, attendance
6. Online classes and parent portal

## Author

**Schnaider Jean Louis**
GitHub: [@Schnaider-dev](https://github.com/Schnaider-dev)
