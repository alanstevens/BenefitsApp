export class Employee {
    id: string
    firstName: string
    lastName: string
    annualBenefitsCost: string
    benefitsCostPerPaycheck: string
}

export class Dependent {
    id: string
    employeeId: string
    firstName: string
    lastName: string
    personalBenefitsCost: string
}

export class EmployeeDependent {
    employee: Employee
    dependent: Dependent
}

export class CreateEmployeeRequest {
    firstName: string
    lastName: string
}

export class CreateDependentRequest {
    employeeId: string
    firstName: string
    lastName: string
}

