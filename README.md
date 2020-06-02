# Generic.Api

Generic.Api is a RESTful api that allows you to GET/PUT/POST Programming Language data. The main purpose of this API is to demonstrate how you can create a solid API that is quick and easy to develope via the use:

  - FluentValidation (https://fluentvalidation.net/)
  - AutoMapper (https://automapper.org/)
  - Generic Repositories 
  - Swagger (https://swagger.io/)

## Installation

This project is built with dotnet core 3.1 and dotnet standard (https://dotnet.microsoft.com/download/dotnet-core/3.1)

Simply clone this repository and:

   - Right Click and publish the GenericDemo.Database (make sure you create your database with the name "GenericDemo" otherwise you'll have to rename the database in appsettings.json and in the static user scripts)
   - Run GenericDemo.Api project.

## Demo

The Demo will show how we can extend this API to allow us to GET/PUT/POST Like data about languages.

### Discussion Points

   - Whats the best when to add custom implementations for Create and Update?


