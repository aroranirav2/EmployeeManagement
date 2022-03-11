import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentsListComponent } from './components/departments-list/departments-list.component';



@NgModule({
  declarations: [
    DepartmentsListComponent,
  ],
  imports: [
    CommonModule
  ],
  exports: [
    DepartmentsListComponent
  ]
})
export class DepartmentModule { }
