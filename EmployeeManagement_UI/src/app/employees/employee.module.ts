import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';
import { StoreModule } from '@ngrx/store';
import * as fromEmployee from './store/employee.reducer';
import { EffectsModule } from '@ngrx/effects';
import { EmployeeEffects } from './store/employee.effects';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [    
    EmployeeListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    StoreModule.forFeature(fromEmployee.employeesFeatureKey, fromEmployee.reducer),
    EffectsModule.forFeature([EmployeeEffects])
  ],
  exports: [
    EmployeeListComponent
  ]
})
export class EmployeeModule { }
