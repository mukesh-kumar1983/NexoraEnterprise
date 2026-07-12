# NexoraEnterprise Foundation v1.0

**Status:** Approved (Frozen)
**Version:** 1.2
**Date:** July 12, 2026

---

# Purpose

This document defines the architectural foundation of NexoraEnterprise.

Its purpose is to:

- Establish a consistent architecture across the solution.
- Prevent unnecessary redesigns.
- Record architectural decisions.
- Guide future development.
- Ensure every module follows the same engineering standards.

This document is considered **frozen**. Architectural changes are permitted only when a genuine architectural defect, security vulnerability, correctness issue, or proven performance issue has been identified.

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
- MediatR (behind an application abstraction)

## Frontend

- Angular 20+ (Standalone)

## Architecture

- Clean Architecture
- Domain-Driven Design (DDD)
- CQRS
- Modular Monolith
- Multi-Tenant SaaS

---

# Core Architectural Principles

- Domain-first development.
- Business rules belong exclusively in the Domain layer.
- Infrastructure must never leak into the Domain.
- Application depends only on abstractions.
- Controllers remain thin.
- Manual mapping throughout the solution.
- Build only what is required (YAGNI).
- Prefer simplicity over unnecessary abstractions.

---

# Project Structure

```text
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

# Domain Layer

The Domain project is the heart of the application and must remain completely independent.

The Domain project must never reference:

- Entity Framework Core
- ASP.NET Core
- ASP.NET Identity
- MediatR
- FluentValidation
- AutoMapper
- Azure SDK
- Logging frameworks

## Domain Foundation

The Domain layer is built upon the following foundational building blocks:

### Common

- Entity<TId>
- AggregateRoot<TId>
- AuditableAggregateRoot<TId>
- ValueObject

### Events

- IDomainEvent
- DomainEvent

### Rules

- IBusinessRule
- BusinessRule
- BusinessRuleValidationException

### Exceptions

- DomainException

These classes form the permanent foundation of the Domain Model.

Specifications, Domain Services, Policies, and additional patterns will only be introduced when justified by business requirements.

---

# Tenant Model

One Tenant represents exactly one Organization.

Every business resource belongs to exactly one Tenant.

Examples include:

- Employees
- Departments
- Customers
- Vendors
- Products
- Sales
- Financial Records

Every tenant-owned aggregate stores a TenantId to ensure complete logical isolation.

The architecture is designed to support multiple business verticals including:

- Customs Management
- Human Resources
- Law Firm Management
- Private Clinics
- ERP
- CRM
- Retail & POS

without requiring architectural changes.

---

# Application Layer

The Application layer owns:

- CQRS Contracts
- Repository Contracts
- Unit of Work
- Current User abstraction
- Current Tenant abstraction
- Date/Time abstraction
- Validation
- Result Pattern

The Application layer must not reference MediatR directly.

Instead, requests are dispatched through an application abstraction.

---

# Result Pattern

The application uses a strongly typed Result pattern.

The Result pattern provides:

- Success
- Failure
- Strongly typed Errors
- ErrorType classification

Expected business outcomes should return Results.

Exceptions are reserved for unexpected or exceptional situations.

---

# Validation Strategy

Validation responsibilities are divided as follows.

## FluentValidation

Validates incoming requests.

## Domain Business Rules

Protect aggregate invariants.

## Global Exception Handling

Handles unexpected failures and converts them into consistent API responses.

---

# Infrastructure

Infrastructure owns all external integrations including:

- Entity Framework Core
- ASP.NET Identity
- SQL Server
- Azure Blob Storage
- SMTP
- RabbitMQ
- JWT implementation

Infrastructure implements every interface defined by the Application layer.

---

# API

The API layer provides:

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

The following standards apply throughout the solution.

- Complete files only.
- Copy-and-paste ready code.
- Enterprise-grade implementation.
- One class per file.
- XML documentation on all public members.
- Async APIs.
- Manual mapping.
- Minimal controller logic.

---

# Deferred Until Required

The following technologies are intentionally postponed.

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

These technologies will only be introduced when justified by real business requirements.

---

# Current Implementation Status

Completed:

- Domain Foundation
- Entity<TId>
- AggregateRoot<TId>
- AuditableAggregateRoot<TId>
- ValueObject
- Domain Events Infrastructure
- Business Rules Infrastructure
- Tenant Aggregate
- Tenant Business Rules
- Tenant Domain Events

Next:

- Module Aggregate
- Subscription Aggregate
- Identity & Access Management

---

# Foundation Freeze

The following architectural decisions are permanently locked for Foundation v1.

## Architecture

- Clean Architecture
- Domain-Driven Design
- CQRS
- Modular Monolith
- Multi-Tenant SaaS

## Domain

- Entity<TId>
- AggregateRoot<TId>
- AuditableAggregateRoot<TId>
- ValueObject
- Domain Events
- Business Rules

## Data

- Entity Framework Core
- SQL Server
- Repository Pattern
- Unit of Work

## Identity

- ASP.NET Identity
- JWT Authentication

## Frontend

- Angular Standalone
- Manual Mapping

Architectural changes are permitted only when one of the following applies:

1. A correctness defect.
2. A security vulnerability.
3. A proven performance issue.
4. A genuine architectural defect.

All other improvements will be considered in future foundation versions rather than modifying Foundation v1.
