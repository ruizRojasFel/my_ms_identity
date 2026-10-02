<div align="center">

<h1> 🫆 Microservicio de identidad </h1>

*Microservicio de identidad en .NET 10 que delega la autenticación a Microsoft Entra External ID y gestiona perfiles de usuario en PostgreSQL.*

[![Website](https://img.shields.io/badge/ver_sitio-mymicroservicesfel.vercel.app-lightblue)](https://mymicroservicesfel.vercel.app/) [![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/ruizRojasFel/my_ms_identity?tab=MIT-1-ov-file)

</div>

<br>

## Descripción

**ms-identity** es un microservicio de identidad construido en .NET 10 con Clean Architecture y CQRS ligero.
Delega el registro, el inicio de sesión y la gestión de roles a Microsoft Entra External ID.
Gestiona los perfiles de usuario en PostgreSQL y será la base de una plataforma de microservicios.

## Stack

| Categoría | Tecnología |
| --- | --- |
| Runtime | .NET 10 / ASP.NET Core |
| Identidad | Microsoft Entra External ID · Microsoft.Identity.Web · Microsoft Graph · Azure.Identity |
| Persistencia | PostgreSQL · Entity Framework Core 10 (Npgsql) |
| Resiliencia | Microsoft.Extensions.Http.Resilience |
| Documentación API | Microsoft.AspNetCore.OpenApi |
| Testing | xUnit · Microsoft.AspNetCore.Mvc.Testing · Coverlet |

## Arquitectura

El proyecto sigue **Clean Architecture**, con dependencias que apuntan siempre hacia el dominio, y aplica **CQRS ligero** separando comandos (escritura) de consultas (lectura) en la capa de aplicación.

```
        ┌──────────────────┐
        │       Api        │  Endpoints HTTP, autenticación (Entra External ID)
        └────────┬─────────┘
                 │
     ┌───────────┴───────────┐
     ▼                       ▼
┌──────────────┐   ┌────────────────────┐
│ Application  │◄──│   Infrastructure   │  EF Core + PostgreSQL, Microsoft Graph
└──────┬───────┘   └────────────────────┘
       │           Casos de uso (commands / queries)
       ▼
┌──────────────┐
│    Domain    │  Entidades y reglas de negocio
└──────────────┘
```

| Capa | Responsabilidad | Depende de |
| --- | --- | --- |
| `Domain` | Entidades y reglas de negocio | — |
| `Application` | Casos de uso, commands y queries | `Domain` |
| `Infrastructure` | Persistencia (PostgreSQL) e integración con Microsoft Graph | `Application` |
| `Api` | Exposición HTTP y autenticación | `Application`, `Infrastructure` |

## Estructura del proyecto

```
MsIdentity/
├── MsIdentity.slnx
├── src/
│   ├── MsIdentity.Api/               # Capa de presentación (ASP.NET Core)
│   ├── MsIdentity.Application/       # Casos de uso (CQRS)
│   ├── MsIdentity.Domain/            # Núcleo de dominio
│   └── MsIdentity.Infrastructure/    # Persistencia e integraciones externas
└── tests/
    ├── MsIdentity.UnitTests/         # Pruebas de Domain y Application
    └── MsIdentity.IntegrationTests/  # Pruebas de la API
```

## License

[![License](https://img.shields.io/badge/License-MIT-yellow)](https://github.com/ruizRojasFel/ms-identity/blob/main/LICENSE)

<br>

---

<div align="center">

<h2> Developer </h2>

<h3> Felipe Andrés Ruiz Rojas </h3>

[![LinkedIn](https://img.shields.io/badge/LinkedIn-linkedin.com%2Fin%2Fruizrojasfel-blue)](https://www.linkedin.com/in/ruizrojasfel) [![Website](https://img.shields.io/badge/Website-felruiz--dev.netlify.app-lightblue)](https://felruiz-dev.netlify.app/)

Copyright © 2026 Fel Ruiz
</div>
