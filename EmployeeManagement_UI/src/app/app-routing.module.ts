import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentListComponent } from './departments/components/department-list/department-list.component';
import { EmployeeListComponent } from './employees/components/employee-list/employee-list.component';

const routes: Routes = [
  { path: 'departments', component: DepartmentListComponent },
  { path: 'employees', component: EmployeeListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
