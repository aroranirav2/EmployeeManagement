import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentsListComponent } from './components/departments-list/departments-list.component';
import { StoreModule } from '@ngrx/store';
import * as fromDepartmentState from './store';



@NgModule({
  declarations: [
    DepartmentsListComponent,
  ],
  imports: [
    CommonModule,
    StoreModule.forFeature(fromDepartmentState.departmentStateFeatureKey, fromDepartmentState.reducers, { metaReducers: fromDepartmentState.metaReducers })
  ],
  exports: [
    DepartmentsListComponent
  ]
})
export class DepartmentsModule { }
