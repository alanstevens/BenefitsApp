import { Component, OnInit } from '@angular/core';
import { BenefitsService } from '../shared/benefits.service'
import { Employee, Dependent, CreateEmployeeRequest, CreateDependentRequest, EmployeeDependent } from '../shared/domain'

@Component({
    selector: 'app-add-employee',
    templateUrl: './add-employee.component.html',
    styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {

    firstName: string
    lastName: string
    annualBenefitsCost: string
    benefitsCostPerPaycheck: string
    employees: Employee[] = []

  addEmployee() {
    this.service.addEmployee(this.firstName, this.lastName)
      .subscribe(employee => {
        this.employees.push(employee)
          this.firstName = ''
          this.lastName = ''
      })
  }

    constructor(private service: BenefitsService) { }

    ngOnInit() {
    }
}

