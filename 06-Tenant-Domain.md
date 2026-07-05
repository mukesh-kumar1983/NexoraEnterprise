# 06 - Tenant Domain

**Version:** 1.0
**Status:** Active
**Last Updated:** July 5, 2026

---

# Purpose

This document defines the Tenant Domain, which serves as the foundation of the NexoraEnterprise platform.

Every business operation within NexoraEnterprise belongs to exactly one Tenant. The Tenant establishes the primary
business boundary, provides complete data isolation, and owns all business resources created within the platform.

The Tenant Domain is the first aggregate to be implemented because every other domain depends upon it.

---

# Business Definition

A Tenant represents an independent legal business entity using the NexoraEnterprise platform.

Examples include:

- ABC Pharmaceuticals
- ABC Textile Mills
- ABC Cement
- XYZ Trading Company

Each Tenant operates independently with its own:

- Users
- Employees
- Branches
- Departments
- Customers
- Vendors
- Products
- Sales
- Financial Records
- Business Configuration

No business data is shared between tenants unless explicitly supported by future platform features.

---

# Business Responsibilities

The Tenant Domain is responsible for:

- Tenant registration
- Tenant profile management
- Tenant lifecycle management
- Subscription ownership
- Tenant activation
- Tenant suspension
- Tenant archival
- Tenant settings ownership
- Business identity

The Tenant Domain is **not** responsible for managing employees, departments, customers, inventory, or financial
transactions. Those responsibilities belong to their respective bounded contexts.

---

# Aggregate Root

The aggregate root of this domain is:

```text
Tenant
```

All modifications to tenant information must occur through the `Tenant` aggregate.

No external component may modify tenant state directly.

---

# Aggregate Structure

```text
Tenant
│
├── Identity
├── Business Information
├── Contact Information
├── Subscription Information
├── Status
└── Settings
```

The aggregate protects the consistency of all tenant-related business data.

---

# Tenant Identity

Every Tenant is uniquely identified by:

- TenantId (GUID Version 7)

Additional business identifiers may include:

- Tenant Code
- Legal Registration Number
- Tax Registration Number

Business identifiers may change over time, but the TenantId remains immutable.

---

# Business Information

A Tenant maintains core business information including:

- Legal Business Name
- Display Name
- Business Type
- Industry
- Company Registration Number
- Tax Identification Number
- Website
- Company Logo

These attributes define the public identity of the business.

---

# Contact Information

A Tenant maintains official contact information including:

- Primary Email Address
- Primary Phone Number
- Address
- City
- State / Province
- Postal Code
- Country

These details are used for communication, billing, and legal documentation.

---

# Subscription

Every Tenant owns exactly one active subscription.

The subscription determines:

- Available modules
- User limits
- Storage limits
- Feature availability
- Billing plan
- Subscription status

Subscription implementation belongs to the Identity & Access Management bounded context and may evolve
independently.

---

# Tenant Lifecycle

A Tenant progresses through the following lifecycle.

```text
Created
    │
    ▼
Active
    │
    ├────────────► Suspended
    │                  │
    │                  ▼
    │               Reactivated
    │
    ▼
Archived
```

Only valid business transitions are permitted.

The aggregate enforces lifecycle consistency.

---

# Tenant Status

A Tenant may exist in one of the following states.

| Status    | Description                                      |
| --------- | ------------------------------------------------ |
| Pending   | Tenant has been created but is not yet activated |
| Active    | Tenant is fully operational                      |
| Suspended | Tenant access is temporarily disabled            |
| Archived  | Tenant is permanently retired from active use    |

Business operations are permitted only for Active tenants unless explicitly stated otherwise.

---

# Business Rules

The Tenant aggregate enforces the following business rules.

## Identity

- Every Tenant must have a unique identifier.
- Every Tenant must have a unique tenant code.
- Every Tenant must have a legal business name.

---

## Contact

- Every Tenant must have a valid primary email address.
- Every Tenant must have a valid country.
- Contact information should remain accurate.

---

## Status

- Only active tenants may perform business operations.
- Archived tenants cannot be reactivated.
- Suspended tenants cannot authenticate until reactivated.

---

## Integrity

- Tenant identifiers are immutable.
- Business ownership cannot be transferred.
- Every business resource belongs to exactly one Tenant.

---

# Domain Events

The following domain events may be raised by the Tenant aggregate.

- TenantRegistered
- TenantActivated
- TenantSuspended
- TenantReactivated
- TenantArchived
- TenantProfileUpdated
- TenantSubscriptionChanged
- TenantLogoUpdated

These events communicate significant business occurrences to other parts of the platform.

---

# Relationships

The Tenant aggregate owns the following business relationships.

```text
Tenant
│
├── Users
├── Branches
├── Departments
├── Employees
├── Customers
├── Vendors
├── Products
├── Warehouses
├── Projects
├── Sales
├── Finance
└── Platform Settings
```

Although the Tenant owns these business capabilities conceptually, each aggregate is implemented and managed
within its own bounded context.

---

# Ownership Principle

Every tenant-owned aggregate stores a TenantId.

Examples include:

- Employee
- Department
- Branch
- Customer
- Vendor
- Product
- Warehouse
- Sales Order
- Invoice
- Expense
- Project

TenantId provides complete logical isolation across the platform.

---

# Security Considerations

Tenant isolation is mandatory.

Every query and command operating on tenant-owned data must execute within the current Tenant context.

Cross-tenant access is prohibited unless explicitly supported by future platform capabilities.

Tenant boundaries are enforced throughout:

- Domain
- Application
- Infrastructure
- API
- User Interface

---

# Future Expansion

The Tenant Domain may later include:

- Subscription Plans
- Licensing
- Billing
- Usage Metrics
- Feature Flags
- Marketplace Extensions
- White Label Branding
- Multi-Region Deployment
- Compliance Settings

These capabilities should extend the aggregate without violating the architectural principles established in
previous documents.

---

# Relationship to Other Documents

This document establishes the primary business boundary of NexoraEnterprise.

The next document introduces the Identity & Access Management domain, which builds upon the Tenant aggregate by
defining users, roles, permissions, and authentication.

---

# Summary

The Tenant Domain is the foundation of the NexoraEnterprise platform.

It establishes business ownership, tenant isolation, and the lifecycle of every organization using the system.

Every tenant-specific business capability ultimately derives its ownership and security boundary from the
Tenant aggregate, making it the cornerstone of the platform's architecture.
