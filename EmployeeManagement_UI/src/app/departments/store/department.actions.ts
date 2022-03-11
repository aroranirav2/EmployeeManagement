import { createAction, props } from '@ngrx/store';
import { IDepartment } from '../models/IDepartment';

export const getDepartments = createAction(
  '[Department List Component] Get Departments'
);

export const getDepartmentsSuccess = createAction(
  '[Department List Component] Get Departments Success',
  props<{ departments: IDepartment[] }>()
);

export const getDepartmentsFailure = createAction(
  '[Department List Component] Get Departments Failure',
  props<{ error: any }>()
);
