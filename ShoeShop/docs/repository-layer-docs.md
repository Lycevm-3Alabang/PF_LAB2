# Repository Layer Documentation

## Entity Models & Relationships

### Shoes
- **Id** (PK)
- Name, Brand, Cost, Price, Description, ImageUrl, IsActive, CreatedDate
- **Relationships:**
  - One-to-many with ShoeColorVariation

### ShoeColorVariation
- **Id** (PK)
- ShoeId (FK), ColorName, HexCode, StockQuantity, ReorderLevel, IsActive
- **Relationships:**
  - Many-to-one with Shoe
  - One-to-many with PurchaseOrderItem
  - One-to-many with StockPullOut

### Suppliers
- **Id** (PK)
- Name, ContactEmail, ContactPhone, Address, IsActive
- **Relationships:**
  - One-to-many with PurchaseOrder

### PurchaseOrders
- **Id** (PK)
- OrderNumber, SupplierId (FK), OrderDate, ExpectedDate, Status, TotalAmount
- **Relationships:**
  - Many-to-one with Supplier
  - One-to-many with PurchaseOrderItem

### PurchaseOrderItems
- **Id** (PK)
- PurchaseOrderId (FK), ShoeColorVariationId (FK), QuantityOrdered, QuantityReceived, UnitCost
- **Relationships:**
  - Many-to-one with PurchaseOrder
  - Many-to-one with ShoeColorVariation

### StockPullOuts
- **Id** (PK)
- ShoeColorVariationId (FK), Quantity, Reason, ReasonDetails, RequestedBy, ApprovedBy, PullOutDate, Status
- **Relationships:**
  - Many-to-one with ShoeColorVariation

## DbContext
- All DbSets are present
- Relationships configured via Fluent API
- Connection string for SQLite in `appsettings.json`

## Migrations & Seed Data
- Initial migration created
- Database updated
- Seed logic for 15 shoes, 3 suppliers, color variations, purchase orders, items, and pull-outs

## Console App
- Demonstrates CRUD, queries (low stock, pending orders), and relationship integrity

---

**This layer is ready for integration with the Service Layer.**
