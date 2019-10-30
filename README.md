# SniDllFailure

When this ASP.NET Core 3.0 app is deployed to our Windows Server 2012 R2 this project results in the following error

**DllNotFoundException: Unable to load DLL 'sni.dll' or one of its dependencies: Access is denied. (0x80070005 (E_ACCESSDENIED))**

A publish.bat file is included to show how I publish the app.

The app is from the standard asp.net core 3.0 template with only a single new action added to query a few records from a table.

**There are two branches**. master is using Entity Framework. sqlclient is using SqlConnection/SqlCommand to do the same. Both fail with the same error.
