import { BrowserModule } from '@angular/platform-browser'
import { NgModule } from '@angular/core'

import { AppComponent } from './app.component'
import { AddEmployeeComponent } from './add-employee/add-employee.component'
import { EmployeeComponent } from './employee/employee.component'
import { DependentComponent } from './dependent/dependent.component'
import { HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms';

@NgModule({
    declarations: [
        AppComponent,
        AddEmployeeComponent,
        EmployeeComponent,
        DependentComponent
    ],
    imports: [
        HttpClientModule,
        FormsModule,
        BrowserModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }

