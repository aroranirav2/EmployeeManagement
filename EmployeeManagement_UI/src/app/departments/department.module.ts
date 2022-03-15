import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DepartmentListComponent } from './components/department-list/department-list.component';
import { DepartmentService } from './services/department.service';
import { StoreModule } from '@ngrx/store';
import * as fromDepartment from './store/department.reducer';
import { EffectsModule } from '@ngrx/effects';
import { DepartmentEffects } from './store/department.effects';



@NgModule({
  declarations: [
    DepartmentListComponent,
  ],
  imports: [
    CommonModule,
    StoreModule.forFeature(
      fromDepartment.departmentsFeatureKey, 
      fromDepartment.reducer
    ),
    EffectsModule.forFeature([DepartmentEffects]),
  ],
  providers: [DepartmentService],
  exports: [
    DepartmentListComponent
  ]
})
export class DepartmentModule { }
