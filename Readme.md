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
* "Name starts with 'A'" means *first name* starts with capital 'A' only.
* The benefits calculator is part of a larger app that does more than manage employees/benefits.

## Instructions
* To run the app:
    * CD ./source
    * Start the api: `npm run api`
    * In a new console window, start the ui:  `npm start`

## Prerequisites
* dotnet core 2.1 SDK: https://www.microsoft.com/net/download/

## Testing
* CD ./source
* API Unit Tests: `npm run apitests`
* API Integration Tests:
    * Start the api server: `npm run api`
    * In a new console window, run the tests:  `npm run apiintegrationtests`

## Missing
* security
* logging
* validation
* docs
* UI unit tests
* e2e tests

## Developer Notes
* Do not name postman collections with spaces. Use underscores instead.
* This is only my second sample in Angular. I'm still finding my way around.
