# UrlContentGrab
Demo Application to demonstrate content grabbing from any URL

### Technology
This application developed using C# .NET

### NuGet Packages
* HtmlAgilityPack - https://www.nuget.org/packages/HtmlAgilityPack/

### JQuery Plugins
* Bootstrap 5 - https://getbootstrap.com/docs/5.2/getting-started/introduction/
* c3.js - https://c3js.org/
* jQueryValidator - https://jqueryvalidation.org/

Bootstrap 5 plugin is used to create reponsive website.<br /> 
c3.js plugin used to create charts.<br />
jqueryvalidation plugin used to validate form inputs

### Pre-Requisited
* .NET Framework 4.8
* Visual Studio 

### Setup
Clone the repository or Download the code.

### Run
* Open WebGrabDemo.sln in visual studio. 
* Clean the solution Menu > Build > Clean Solution
* Rebuild the solution Menu > Build > Rebuild Solution
* Make sure you enabled below Nuget package manager settings
  - Allow NuGet to download missing packages
  - Automatically check for missing packages during build iin Visual Studio
* Run the solution

### Demo
* Enter any URL in the input eg: "https://www.sony.co.in/electronics/televisions/a95k-series"
* Click Fetch button
* Wait for few seconds to get the response
