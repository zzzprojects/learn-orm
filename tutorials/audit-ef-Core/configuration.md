---
PermaID: 100004
Name: Configuration
---

# Configuration

The EF audit events are stored using a Data Provider. You can use one of the available data providers or implement your own. This can be set per DbContext instance or globally. If you plan to store the audit logs with EF, you can use the Entity Framework Data Provider.

## Global Settings

You can configure the following settings globally or you can also configure them for each context class.

### Mode

The **Mode** indicates the audit operation mode, which contains the following two options.

#### Opt-Out

All the entities are tracked by default, except those explicitly ignored. (Default)

#### Opt-In

No entity is tracked by default, except those explicitly included.

### IncludeEntityObjects

The `IncludeEntityObjects` indicates if the output should contain the complete entity object graphs. Its default value is `false`.

### AuditEventType 

The `AuditEventType` indicates the event type to use on the audit event. It contains the following placeholders:

 - `{context}`: You will need to replace it with the `DbContext` type name.
 - `{database}`: You will need to replace it with the database name.

### IncludeIndependantAssociations

The `IncludeIndependantAssociations` indicates if the independent associations should be included or not. The default value is `false` and it is only for **EF <= 6.2**.

### ExcludeTransactionId: 

The `ExcludeTransactionId` indicates if the Transaction IDs should be excluded from the output and not be retrieved. The default value is `false` to include the Transaction IDs.

### ExcludeValidationResults

The `ExcludeValidationResults` indicates if the entity validations should be avoided and excluded from the audit output. The default value is `false`.

### EarlySavingAudit

The `EarlySavingAudit` indicates if the audit event should be saved before the entity saving operation takes place. The default is `false` to save the audit event after the entity saving operation completes or fails.

## Entity Settings

You can configure the following settings per entity type.

### IgnoredProperties

The `IgnoredProperties` indicates the entity's properties (columns) to be ignored on the audit logs.

### OverrideProperties 

The `OverrideProperties` indicates constant values to override properties on the audit logs.

### FormatProperties

The `FormatProperties` indicates replacement functions for the property's values on the audit logs.

