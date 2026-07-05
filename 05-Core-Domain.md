# 05 - Core Domain

**Version:** 1.0
**Status:** Active
**Last Updated:** July 5, 2026

---

# Purpose

This document identifies the Core Domain of NexoraEnterprise and distinguishes it from Supporting Domains and
Generic Domains.

Understanding these distinctions allows development effort to be focused where it delivers the greatest business
value.

The Core Domain represents the strategic heart of the platform. It receives the highest architectural attention,
the richest domain models, and the greatest investment in business behavior.

---

# Domain Classification

NexoraEnterprise is divided into three categories of business domains:

- Core Domain
- Supporting Domains
- Generic Domains

Each category has different architectural importance and implementation priorities.

---

# Core Domain

## Definition

The Core Domain contains the business capabilities that define the identity of NexoraEnterprise.

These domains:

- Differentiate the platform.
- Contain the most important business rules.
- Require rich domain models.
- Drive architectural decisions.
- Are developed before all other business capabilities.

The quality of the Core Domain determines the long-term success of the platform.

---

# Core Domain Components

The Core Domain of NexoraEnterprise consists of:

## Identity & Access Management

Responsible for:

- Tenant management
- User management
- Authentication
- Authorization
- Roles
- Permissions
- Security
- Tenant isolation

Without Identity, no other module can operate.

---

## Human Resources

Responsible for:

- Branches
- Departments
- Job Titles
- Employees
- Organizational hierarchy
- Attendance
- Leave
- Payroll

Employees represent the primary actors within the business platform.

---

## Platform Services

Responsible for:

- Notifications
- Document Management
- Audit Logs
- Background Jobs
- File Storage
- System Configuration
- Localization

Although shared across modules, these services provide essential platform capabilities.

---

# Why These Are Core

Every other business module depends directly or indirectly upon these domains.

For example:

```text
Tenant
    ↓
Users
    ↓
Employees
    ↓
Departments
    ↓
Business Operations
```

Without these foundational capabilities:

- Sales cannot assign sales representatives.
- Finance cannot approve expenses.
- Inventory cannot track warehouse managers.
- Projects cannot assign resources.
- CRM cannot assign account managers.

These domains establish the business identity of the platform.

---

# Supporting Domains

Supporting Domains provide significant business value but are built upon the Core Domain.

They contain important business logic but are not responsible for defining the overall platform architecture.

Supporting Domains include:

- Customer Relationship Management (CRM)
- Procurement
- Inventory
- Sales
- Finance
- Projects

Each supporting domain depends upon the Core Domain for identity, security and organizational structure.

---

# Generic Domains

Generic Domains provide reusable technical capabilities that are commonly required by enterprise applications.

Examples include:

- Email
- File Storage
- Caching
- Logging
- Reporting Infrastructure
- Scheduling
- Search
- Localization
- Health Monitoring

These capabilities are important but do not differentiate NexoraEnterprise from other enterprise platforms.

Where appropriate, existing frameworks or well-established libraries should be leveraged rather than reinventing
generic functionality.

---

# Dependency Flow

The relationship between domain categories is illustrated below.

```text
                  +----------------------+
                  |     Core Domain      |
                  +----------+-----------+
                             |
                             v
                  +----------------------+
                  | Supporting Domains   |
                  +----------+-----------+
                             |
                             v
                  +----------------------+
                  |  Generic Domains     |
                  +----------------------+
```

Supporting Domains rely on the Core Domain.

Generic Domains support both Core and Supporting Domains but should remain independent of business rules.

---

# Architectural Investment

Development effort should not be distributed equally.

| Domain Category    | Architectural Investment |
| ------------------ | ------------------------ |
| Core Domain        | Highest                  |
| Supporting Domains | High                     |
| Generic Domains    | Moderate                 |

The Core Domain receives:

- Rich domain modeling.
- Explicit business rules.
- Comprehensive domain events.
- Strong aggregate design.
- Extensive automated testing.
- Highest documentation quality.

---

# Rich Domain Model Strategy

The Core Domain follows a Rich Domain Model.

Characteristics include:

- Behavior-driven entities.
- Aggregate roots protecting invariants.
- Explicit business rules.
- Domain events.
- Value Objects.
- Encapsulation.
- Minimal public setters.

Business logic should always reside inside the domain model rather than application services.

---

# Business Priorities

The platform should be implemented according to business importance rather than module size.

The recommended implementation order is:

1. Tenant
2. Identity
3. Branch
4. Department
5. Job Title
6. Employee
7. Platform Services
8. CRM
9. Procurement
10. Inventory
11. Sales
12. Finance
13. Projects

This sequence ensures each module is built upon a stable business foundation.

---

# Domain Evolution

The Core Domain should evolve cautiously.

Changes to aggregates such as:

- Tenant
- AppUser
- Employee
- Department

may affect every other bounded context.

Supporting Domains have greater flexibility to evolve independently provided they continue to respect published
contracts.

---

# Strategic Importance

The Core Domain represents the long-term competitive value of NexoraEnterprise.

Architectural shortcuts should never compromise:

- Business correctness.
- Domain integrity.
- Tenant isolation.
- Security.
- Aggregate consistency.

Long-term maintainability always takes precedence over short-term implementation speed.

---

# Relationship to Other Documents

This document identifies the strategic business priorities of the platform.

The following documents expand upon each Core Domain in detail, beginning with the Tenant Domain, which serves
as the foundation for every tenant-specific business capability.

---

# Summary

The Core Domain defines the business identity of NexoraEnterprise.

By prioritizing Tenant Management, Identity, Human Resources and Platform Services, the platform establishes a
stable and scalable foundation upon which every future business module can confidently be built.

All subsequent domain modeling and implementation work should respect the priorities and architectural boundaries established in this document.
