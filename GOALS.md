# Project Goals

Until someone other than myself puts this into a production environment, the
following goals should provide the high-level guidance for choices during this
project, and what constitutes an acceptable minimum viable product at each point.

* Using M-Itation should be simpler and more intuitive than directly using the
MFilesAPI.
  * M-Itation should not require intimate knowledge of the id values for
  object types, value lists, classes, properties, or other M-Files vault
  objects.
  * M-Itation will provide strong type checking, but be capable of type
  inference when mapping to the Vault.
  * M-Itation will provide mapping from POCO classes to M-Files, but will also
  provide enough native functionality to make CRUD operations possible without
  any consumer defined classes.
* The M-Itation Library will provide its full functionality at install, and
  the only prerequisites for its effective use will be:
  1. Installation of the correct .NET Framework version.
  1. The installation of its M-Files Server dependencies in the execution
    environment.
  1. Access to the target M-Files Server and Vault
