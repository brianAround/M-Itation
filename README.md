# M-Itation : ORM Library for M-Files Vaults

## A .NET Library for simplifying the process of creating, retrieving, and modifying documents in an M-Files Vault.  

### Current State

Currently the M-Itation Project has only completed as far as generating a 
connection to the server.  More work is to follow. 

### About M-Files and MFilesAPI

M-Files is a Document Management System with an Attribute-Based Schema that at
its heart, is an Entity-Attribute-Value database with various schema elements
applied.  The M-Files Corporation provides a powerful but complicated COM API
that more-or-less exactly mirrors the physical model for the data. This makes it
possible to perform nearly all of the operations that are possible from the
M-Files Client or Server Administrator.

### The Problem

To your typical Business Application Developer, this API is positively
arcane.  The COM interfaces exposed seem needlessly complex and the operations
exposed have numerous dead-ends and points of failure.  Adding to this
complexity is the fact that the API relies heavily on the "ID" values of every
level of the true schema, so that every property set requires the developer to
perform either a design-time or runtime lookup of ID for every Object Type,
Class, Property, Value List, and Instance in order to successfully perform
many of the possible operations.

### Caveats

There are numerous work arounds for working with Vault data in .NET other than
the COM API.  There is a RESTful web service that really mirrors the same
complexity as the COM API.  M-Files provides a fairly real-time "External
Object" import connection that does a good job of binding very simple objects
to a table in an external data source.  And there is a Reporting Export, that
can be configured to periodically update a raw export of an OLE DB interface.  
All of these taken together might provide a way of simply managing objects in
their own way.  Each of these have their own issues taken individually.  The
more direct route seems to try to provide some way of adapting the COM API,
since it has fewer brittle connections, doesn't require as much configuration
of external systems, can handle much more complexity, and has no lag time.

### The Goal of M-Itation

The End-Goal of the M-Itation project is to build a library that works as an
Adapter over the MFilesAPI components, allowing a developer to develop against
strongly typed classes and data types.  The approach I would like to be able to
take is to allow a "Plain Old Class Object" to be defined by the .NET developer
and then allow the same class instance to act as the "Data Transfer Object"
within the Library, allowing developers to perform CRUD operations in the
M-Files Vault using classes that resemble the Vault's schema enough map using
a set of configurable "conventions" to map to the correct M-Files objects,
properties, and values.

Essentially, an ORM for the M-Files Vault.
