import { Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable, of } from 'rxjs'
import { Employee, Dependent, CreateEmployeeRequest, CreateDependentRequest, EmployeeDependent } from '../shared/domain'

@Injectable({
    providedIn: 'root'
})
export class BenefitsService {

        baseUrl = 'http://localhost:55482'
        employeesUrl = '/api/employees'
        addEmployeeUrl = `${this.baseUrl}${this.employeesUrl}`
        httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
            })
        };

    addEmployee(firstName: string, lastName: string): Observable<Employee> {
        const request = new CreateEmployeeRequest()
        request.firstName = firstName
        request.lastName = lastName


        return this.http.post<Employee>(this.addEmployeeUrl, request, this.httpOptions)
    }

    addDependent(employeeId: string, firstName: string, lastName: string): Observable<EmployeeDependent> {
        const request = new CreateDependentRequest()
        request.employeeId = employeeId
        request.firstName = firstName
        request.lastName = lastName
        const addDependentUrl = `${this.addEmployeeUrl}/${employeeId}/dependents`

        return this.http.post<EmployeeDependent>(addDependentUrl, request, this.httpOptions)
    }

    constructor(private http: HttpClient) { }
}


