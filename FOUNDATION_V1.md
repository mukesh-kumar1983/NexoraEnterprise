# NexoraEnterprise Foundation v1.0

**Status:** Approved
**Version:** 1.0
**Date:** July 2026

---

# Purpose

This document defines the architectural foundation of NexoraEnterprise.

The purpose of this document is to:

- Keep the architecture consistent.
- Prevent unnecessary redesigns.
- Record architectural decisions.
- Provide guidance for future development.
- Ensure all modules follow the same standards.

This document is considered frozen unless a genuine architectural defect, security issue,
correctness issue, or proven performance issue is discovered.

---

# Technology Stack

## Backend

- .NET 10
- ASP.NET Core
- Entity Framework Core
- SQL Server
- ASP.NET Identity
- JWT Authentication
- FluentValidation
- MediatR (hidden behind an application abstraction)

## Frontend

- Angular 17+ Standalone

## Architecture

- Clean Architecture
- Domain-Driven Design (DDD)
- CQRS
- Modular Monolith
- Multi-Tenant SaaS

---

# Core Architectural Principles

- Domain first.
- Business rules belong in the Domain.
- Infrastructure never leaks into Domain.
- Application depends only on abstractions.
- Controllers remain thin.
- Manual mapping only.
- Build only what is needed (YAGNI).
- Favor simplicity over unnecessary abstractions.

---

# Project Structure

```
src/
    NexoraEnterprise.API
    NexoraEnterprise.Application
    NexoraEnterprise.Domain
    NexoraEnterprise.Infrastructure

tests/
    NexoraEnterprise.Domain.Tests
    NexoraEnterprise.Application.Tests
    NexoraEnterprise.Infrastructure.Tests
    NexoraEnterprise.API.Tests

docs/
```

---

# Domain

The Domain project must remain independent.

It must not reference:

- Entity Framework Core
- ASP.NET Core
- ASP.NET Identity
- MediatR
- FluentValidation
- AutoMapper
- Azure SDK
- Logging frameworks

Domain building blocks:

- Entity
- BaseEntity
- AggregateRoot
- ValueObject
- Domain Events
- Business Rules

Specifications and Domain Services will only be introduced when genuinely required.

---

# Tenant Model

One Tenant represents exactly one Organization.

All business data belongs to a single Tenant.

The current platform is designed to support:

- Customs Management
- Human Resources
- Law Firm Management
- Private Clinics

without changing the architecture.

---

# Application Layer

The Application layer owns:

- CQRS contracts
- Repository contracts
- Unit of Work abstraction
- Current User abstraction
- Date/Time abstraction
- Validation
- Result pattern

The Application layer must not reference MediatR directly.

A request dispatcher abstraction is used instead.

---

# Result Pattern

The application uses a Result / Result<T> pattern.

The Result pattern provides:

- Success
- Failure
- Strongly typed Errors
- ErrorType classification

Business logic should return Results rather than throwing exceptions for expected
business outcomes.

---

# Validation

Validation responsibilities are divided as follows:

- FluentValidation validates requests.
- Domain Business Rules enforce business invariants.
- Unexpected failures are handled by global exception handling.

---

# Infrastructure

Infrastructure owns:

- Entity Framework Core
- ASP.NET Identity
- SQL Server
- Azure Blob Storage
- SMTP Email
- RabbitMQ
- JWT implementation

Infrastructure implements all interfaces defined by the Application layer.

---

# API

The API uses:

- Controllers
- JWT Authentication
- Policy-based Authorization
- API Versioning
- Global Exception Handling
- Problem Details
- DTOs

Domain entities are never exposed directly.

---

# Coding Standards

- Complete files only.
- Copy-paste ready code.
- Enterprise-grade implementation.
- One class per file (except tightly coupled generic companion types such as Result
  and Result<T>).
- XML documentation on public members.
- Async APIs throughout.
- Manual mapping.
- Minimal controller logic.

---

# Deferred Until Needed

The following are intentionally postponed:

- Microservices
- Shared Kernel
- Specifications
- Redis
- Hangfire
- Quartz
- Event Bus
- Plugin Architecture
- Distributed Cache
- Feature Flags
- Localization
- AutoMapper

These technologies will only be introduced when justified by business requirements.

---

# Foundation Freeze

The following architectural decisions are considered frozen:

- Clean Architecture
- DDD
- CQRS
- Modular Monolith
- One Tenant = One Organization
- Manual Mapping
- ASP.NET Identity
- JWT Authentication
- Entity Framework Core
- SQL Server
- Angular Standalone
- MediatR behind an abstraction
- Result Pattern
- Repository Pattern
- Unit of Work

Architectural changes are permitted only when one of the following applies:

1. A correctness defect.
2. A security vulnerability.
3. A proven performance issue.
4. A genuine architectural defect.

All other improvements will be considered for future versions rather than changing
Foundation v1.0.
