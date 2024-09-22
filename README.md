1) Implement rest of Company controller functions, all the way down to data access layer

2) Change all Company controller functions to be asynchronous

3) Create new repository to get and save employee information with the following data model properties:

* string SiteId,
* string CompanyCode,
* string EmployeeCode,
* string EmployeeName,
* string Occupation,
* string EmployeeStatus,
* string EmailAddress,
* string Phone,
* DateTime LastModified

4) Create employee controller to get the following properties for client side:

* string EmployeeCode,
* string EmployeeName,
* string CompanyName,
* string OccupationName,
* string EmployeeStatus,
* string EmailAddress,
* string PhoneNumber,
* string LastModifiedDateTime

5) Add logger to solution and add proper error handling

Developer comments:
1. All above requirements are finished. 
2. Used log4Net as logger. Logs can be found at folder JonasCodingTest\WebApi\Logs\
3. Error handling codes can be found at JonasCodingTest\WebApi\ActionFilters\GlobalExceptionFilter.cs