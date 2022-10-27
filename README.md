# Pablika Backend (.NET) Assessment

A telephone directory application with two microservices communicating with each other. In this application, you can add or remove people to the directory, add more than one contact information to the user, and also create a report that brings the number of people and phones by location.

The project can be downloaded using the command:
```
$ git clone https://github.com/dogukanergezer/PablikaAssessment.git
```
### Then make sure the following are chosen as startup projects:

- **EventBus.ConsumerConsole**
- **WebApiGateway**
- **ContactService.Api**
- **ReportService.Api**

### Used technologies and tools
- C#, .NET Core, Automapper
- Git
- Ocelot, Api Gateway
- PostgreSQL
- RabbitMQ 


**When making an external request, send a request to the addresses below**:
- http://localhost:5000/contact 
- http://localhost:5000/report

**You will be redirected to the following addresses via ocelot**:
- http://localhost:5001/api/contact 
- http://localhost:5002/api/report

### To make it services run:
1 - Go to **appsetting.json** file, then enter your own server information in the **ConnectionStrings** field.

2 - Delete the migrations folder 

3 - Set **ContactService.Api** as the startup project.

3 - Go to **ContactService.Api** directory on command line
```
$ dotnet migrations add init_contactDB --startup-project ./ --project ../ContactService.Data/
```
 **Next**
```
$ dotnet ef database update --startup-project ./ --project ../ContactService.Data/
```
You can also run the commands for report service and try again..
