import { Component, OnInit, Input } from '@angular/core';
import { Employee, EmployeeDependent, Dependent } from '../shared/domain'
import { BenefitsService } from '../shared/benefits.service'

@Component({
    selector: 'app-employee',
    templateUrl: './employee.component.html',
    styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
    @Input() employee: Employee

    firstName: string
    lastName: string
    dependents: Dependent[] = []
    // do I need these?
    // does one way binding update when I update employee?
    annualBenefitsCost: string
    benefitsCostPerPaycheck: string

    addDependent() {
        this.service.addDependent(this.employee.id, this.firstName, this.lastName)
            .subscribe(employeeDependent => {
                this.dependents.push(employeeDependent.dependent)
                this.employee = employeeDependent.employee
                this.firstName = ''
                this.lastName = ''
            })
    }
    constructor(private service: BenefitsService) { }

    ngOnInit() {
    }

}

