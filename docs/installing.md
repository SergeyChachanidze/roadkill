# Installing

## Pre-requisites
Roadkill requires IIS 7+ (although it will work with IIS Express and Cassini).

You will some basic technical knowledge of Windows to setup IIS, in particular enabling ISAPI handlers and permissions.

You do not need a database server - you can use SQLite if you choose. SQL Server Compact (SQL Server CE) is also supported.

Roadkill also has limited support for Mono on Ubuntu - see the Mono installation page for more details.

## Installing
Download the current version (which is a ZIP file) and unzip it to a new folder. If you are a developer planning to use Roadkill on your own machine or remote access to another machine, you will need to create an IIS site before installing - Roadkill does not do this for you in the wizard.

There is a howto for this on this Microsoft page: http://support.microsoft.com/kb/323972.

Once your site is created and the file is unzipped, copy/FTP the unzipped Roadkill files to your website root folder. Now open your site in your browser, for example: http://localhost/roadkill/

Roadkill has been designed to work from any virtual path, provided the path is configured as an application.

The installation wizard will then guide you through the installation step by step, and write your web.config settings at the end of the wizard. You can manually tweak your web.config settings if you prefer, guidance on the Roadkill settings can be found on the web.config page.

If your installation fails at any point, simply change the "installed=true" in the roadkill section of your web.config to "installed=false" to reset the installation.

## Common Issues

### Web.config can't be written to
This is probably the commonest problem with the installer. If you're hosting Roadkill on shared hosting, your control panel should be able to change the permissions for the web.config. However the application pool that Roadkill is running as should have enough permissions to write to the web.config.

If you are running Roadkill on your home/development machine then the simplest solution to the problem is to run the application pool as LOCALSYSTEM or LOCALSERVICE.

### Database exceptions at Finished stage
These are almost always caused by your connection string login details or a missing dependency. The stack trace you will see on the Finished page will give you full information of the problem, if you scroll down. You can also look at the event log if you have access to it.