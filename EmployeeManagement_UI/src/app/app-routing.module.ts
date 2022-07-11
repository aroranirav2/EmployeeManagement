import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddDepartmentComponent } from './departments/components/add-department/add-department.component';
import { DepartmentListComponent } from './departments/components/department-list/department-list.component';
import { EmployeeListComponent } from './employees/components/employee-list/employee-list.component';

const routes: Routes = [
  { path: 'departments', component: DepartmentListComponent },
  { path: 'add-department', component: AddDepartmentComponent },
  { path: 'employees', component: EmployeeListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
