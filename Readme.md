# Benefits App

## Problem
We provide our clients with the ability to pay for their employees’ benefits packages. A portion of these costs are deducted from their paycheck, and we handle that deduction. Please demonstrate how you would code the following scenario:
* The cost of benefits is $1000/year for each employee
* Each dependent (children and possibly spouses) incurs a cost of $500/year
* Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent

We’d like to see this calculation used in a web application where employers input employees and their dependents, and get a preview of the costs.

Please implement a web application based on these assumptions:
* All employees are paid $2000 per paycheck before deductions
* There are 26 paychecks in a year.

## Assumptions
* "Name starts with 'A'" means first name starts with capital A only.

## Prereqquisites
* `npm install -g @angular/cli`
* `npm install -g newman`
* dotnet core 2.1 SDK: https://www.microsoft.com/net/download/

## Test
* `dotnet test src/API/PaylocityBenefitsService.sln`
* `dotnet src\api\bin\Debug\netcoreapp2.1\Paylocity.Benefits.Service.dll`
* `dotnet run --project src\api\PaylocityBenefitsService.csproj --launch-profile Service`
* `newman run "src\API\IntegrationTests\Employees\Employees API Integration Tests.postman_collection.json" -e "src\API\IntegrationTests\Test.postman_environment.json"`

## Missing
* security
* logging
* validation
* docs