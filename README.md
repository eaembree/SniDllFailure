# SniDllFailure

When this ASP.NET Core 3.0 app is deployed to our Windows Server 2012 R2 this project results in the following error

**DllNotFoundException: Unable to load DLL 'sni.dll' or one of its dependencies: Access is denied. (0x80070005 (E_ACCESSDENIED))**

A publish.bat file is included to show how I publish the app.

**There are two branches**. Both to the same task of querying a few records from a simple table. **Master** branch is using Entity Framework. **sqlclient** branch is using SqlConnection/SqlCommand to do the same. Both fail with the same error.
