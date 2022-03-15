import { createAction, props } from '@ngrx/store';
import { Update } from '@ngrx/entity';

import { Department } from '../models/department.model';

export const loadDepartments = createAction(
  '[Departments List Component] Load Departments'
);

export const loadDepartmentsSuccess = createAction(
  '[Departments Effect] Load Departments Success',
  props<{ departments: Department[] }>()
);

export const loadDepartmentsFailure = createAction(
  '[Departments Effect] Load Departments Failure',
  props<{ error: any }>()
);

export const addDepartment = createAction(
  '[Department Add Component] Add Department',
  props<{ department: Department }>()
);

export const addDepartmentSuccess = createAction(
  '[Department Effect] Add Department Success',
  props<{ department: Department }>()
);

export const addDepartmentFailure = createAction(
  '[Department Effect] Add Department Failure',
  props<{ error: any }>()
);

export const upsertDepartment = createAction(
  '[Department/API] Upsert Department',
  props<{ department: Department }>()
);

export const addDepartments = createAction(
  '[Department/API] Add Departments',
  props<{ departments: Department[] }>()
);

export const upsertDepartments = createAction(
  '[Department/API] Upsert Departments',
  props<{ departments: Department[] }>()
);

export const updateDepartment = createAction(
  '[Department/API] Update Department',
  props<{ department: Update<Department> }>()
);

export const updateDepartments = createAction(
  '[Department/API] Update Departments',
  props<{ departments: Update<Department>[] }>()
);

export const deleteDepartment = createAction(
  '[Department/API] Delete Department',
  props<{ id: string }>()
);

export const deleteDepartments = createAction(
  '[Department/API] Delete Departments',
  props<{ ids: string[] }>()
);

export const clearDepartments = createAction(
  '[Department/API] Clear Departments'
);
