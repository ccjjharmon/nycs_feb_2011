#Project Conventions

##Test Naming

[SUT]Specs.cs - All tests for the component named [SUT]

##Configuration

Micro configuration files can be placed under the config folder with a .erb extension after their real extension. This will ensure that the new configuration file is copied to all the locations that is necessary for it to be read at both test and runtime. To take advantage of machine specific settings, leverage the @local_settings and @database_settings classes.
