# Project Goals

Until someone other than myself puts this into a production environment, the
following goals should provide the high-level guidance for choices during this
project, and what constitutes an acceptable minimum viable product at each point.

* **Using M-Itation should be simpler and more intuitive than directly using the
MFilesAPI.**
  * M-Itation should not require intimate knowledge of the id values for
  object types, value lists, classes, properties, or other M-Files vault
  objects.
  * M-Itation will provide strong type checking, but be capable of type
  inference when mapping to the Vault.
  * M-Itation will provide mapping from POCO classes to M-Files, but will also
  provide enough native functionality to make CRUD operations possible without
  any consumer defined classes.
* **The M-Itation Library will provide its full functionality at install**, and
  the only prerequisites for its effective use will be:
  1. Installation of the correct .NET Framework version.
  1. The installation of its M-Files Server dependencies in the execution
    environment.
  1. Access to the target M-Files Server and Vault
* **M-Itation can use user-defined classes to retrieve and update data in the
vault.**  
  1. M-Itation will attempt to map Class names and Property names to object and
  document classes found in the connected vault, and if unambiguous connections
  can be made to a Vault Object Type, Object Class, and any required
  Properties, and if an appropriate ID property exists, the mapping will
  be remembered for the lifetime of the library class.
  1. Mapped classes will be used for object retrieval, updates, and creation
  whereever appropriate, with M-Itation using best-guess type inference where
  necessary.
  1. Additionally, M-Itation will provide a runtime Mapping configuration
  mechanism such as JSON or XML Configuration, or a MapBuilder object that
  allows code-driven configuration of the document mapping.
  1. M-Itation will attempt to map classes that are referenced by Mapped
  classes, if there is a corresponding Vault class or object type.
