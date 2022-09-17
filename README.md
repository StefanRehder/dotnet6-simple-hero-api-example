# Simple RESTful Web Service implemented with .NET6
This is a simple lightweight RESTful web service implemented with .NET6. 
The example web service exposes a number of operations that can be used to handle hero objects stored in memory. 
The web service is self hosted and can run on any Windows, Linux or macOS computer (even a raspberry pi).

## Requirements

[.NET6](https://www.microsoft.com/net/learn/get-started/)

## Getting Started

 ```
 dotnet build --configuration Release

 # Windows
 dotnet bin\Release\net6.0\dotnet6-simple-hero-api-example.dll

 # Linux or macOS
 dotnet bin/Release/net6.0/dotnet6-simple-hero-api-example.dll
 ```

Play around with the running web service with curl or Postman.
e.g. on Windows you can use this command to add a hero `curl.exe -X PUT http://localhost:5000/api/Heroes -H 'accept: */*' -H 'Content-Type: application/json' -d '{\"name\": \"Superman\", \"strength\": 10}'`
or this command to delete a hero `curl.exe -X DELETE http://localhost:5000/api/Heroes/Batman -H 'accept: */*'` 
or this command to get all heroes `curl.exe -X GET http://localhost:5000/api/Heroes -H 'accept: text/plain'`
or this command to get a specific hero `curl.exe -X GET http://localhost:5000/api/Heroes/Super%20Woman -H 'accept: text/plain'`