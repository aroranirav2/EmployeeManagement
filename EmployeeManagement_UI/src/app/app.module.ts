import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StoreModule } from '@ngrx/store';
import { DepartmentsListComponent } from './departments/components/departments-list/departments-list.component';
import { EmployeesListComponent } from './employees/components/employees-list/employees-list.component';

@NgModule({
  declarations: [
    AppComponent,
    DepartmentsListComponent,
    EmployeesListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    StoreModule.forRoot({}, {})
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
