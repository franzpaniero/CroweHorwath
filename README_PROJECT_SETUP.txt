After opening the CroweHorwath.HelloWorld.sln file, right click on the solution in Visual Studio and go to Properties.
Click on Startup Project tab, select Radio button for Multiple Startup Projects.
Change the project 'CroweHorwath.HelloWorld.Api' to Action = Start.
Change the project 'CroweHorwath.HelloWorld.Console' to Action = Start.

This will ensure that both the API and console application launch automatically when the solution is run in the debugger.
