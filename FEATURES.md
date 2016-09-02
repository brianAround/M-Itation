# M-Itation Features Proposed
---

This list of features is neither complete nor fully vetted.  It is certain that
some of these features will fail the
[YAGNI](https://en.wikipedia.org/wiki/You_aren%27t_gonna_need_it) test, as they
represent redundant functionality with other features.  At some point, a choice
will be made and some features will remain, and others will disappear from the
backlog until there is demand for them.

*Some* of these items may actually be desirable constraints rather than
features. These may be moved into a separate file at a later date.

When a feature is meant to be implemented but the associated class or object
is not known, the feature will simply say that the **Library** does something,
as with **"_Library_ can query server for vault names"**.

**A consumer** should be understood in the list below to be the developer that
is using M-Itation.

---

## Server and Vault Connection features
1. Library can query server for vault names.
1. Each library instance can only connect to one Vault at a time.
1. Vault connections can be established with the complete range of credentials:
  * Current user
  * Specific Windows user
  * Specific M-Files user
1. Vault and Server connections can be configured using a [Fluent
Interface](https://en.wikipedia.org/wiki/Fluent_interface)
1. Vault and Server connections can be configured in an XML App.config file.
1. Library can close connections to a Server/Vault.
1. Until the library provides a solution for Vault Connection pooling, the
Library will allow a "Bring Your Own Connection" model in addition to providing
connection resources.

## Exceptions
1. COM exceptions thrown during normal operations will be assumed to be from
the M-Files server or the MFilesAPI and will be wrapped in a custom exception
defined by the library that cleans up the message text.

## Native functionality
1. A consumer can retrieve a document or object from the vault by
identifying the **Object Type**, and **ID** of the document.
1. A consumer can delete an M-Files object or document.
1. A consumer can destroy an M-Files object or document if it is already
deleted in the Vault.



### Native functionality - MFObject class
1. Objects retrieved from an Vault without a mapped object class will be
returned as an MFObject instance.
1. MFObject instances retrieved from the database will include essential stats
from the Vault item:
  * ObjectType
  * Class
  * ID
  * Version
  * Title
  * Additional TBD values
1. MFObjects can be retrieved with or without property data. (Has sub-features)
1. A consumer can save changes to property values on a MFObject. (Has
  sub-features)
1. A consumer can create a new M-Files object by creating an instance of
the MFObject class, setting the necessary properties, and saving the object.

### Native functionality - Property values
1. Property values can be set on the MFObject class using property name, alias,
or id.  Ambiguous property names will attempt to resolve using the property
name.
1. A consumer can configure the library to provide a certain amount of design-
time type checking for specific properties.  ** Unclear on binding mechanism
and timing. **

### Native functionality - Searching
1. A consumer can search the M-Files Vault using a string value and the Library
will return objects resulting from a Full-Text search.
1. By default, a consumer will be shown items that are not deleted, but can
retrieve deleted items by choice.
1. A consumer can search using a specific property value, naming the property
by name, alias, or id.
1. A searching by property value allows the standard M-Files search
methodologies such as:
  * Items matching the searched value (or set of values).
  * Items that have non-matching values for that property.
  * Items that have empty values for that property. (See footnote 1)
  * Items that have any non-blank value for that property at all.
  * Items that have a specific kind of equality relationship (as in greater
    than, less than or equal, etc.)
  * Items with property values that contain, start with, or end with a specific
  string.
1. A consumer can define multiple property values on a search with each
applying an AND restriction on the results.
1. A consumer can filter search results by Object Type, Or Class.




---
#### Footnotes
1. Empty values mean that an object HAS a property, but the value is not set
or is blank.  Unfortunately, MFilesAPI provides no way to search for objects
that do not even have a property defined on them.  This may be a possible
future extension or feature, but right now it is not within the scope of the
project.
