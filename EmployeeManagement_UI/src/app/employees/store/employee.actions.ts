import { createAction, props } from '@ngrx/store';
import { Update } from '@ngrx/entity';

import { Employee } from '../models/employee.model';

export const loadEmployees = createAction(
  '[Employee List Component] Load Employees'
);

export const loadEmployeesSuccess = createAction(
  '[Employee Effect] Load Employees Success', 
  props<{ employees: Employee[] }>()
);

export const loadEmployeesFailure = createAction(
  '[Employee Effect] Load Employees Failure', 
  props<{ error: any }>()
);

export const addEmployee = createAction(
  '[Employee/API] Add Employee',
  props<{ employee: Employee }>()
);

export const upsertEmployee = createAction(
  '[Employee/API] Upsert Employee',
  props<{ employee: Employee }>()
);

export const addEmployees = createAction(
  '[Employee/API] Add Employees',
  props<{ employees: Employee[] }>()
);

export const upsertEmployees = createAction(
  '[Employee/API] Upsert Employees',
  props<{ employees: Employee[] }>()
);

export const updateEmployee = createAction(
  '[Employee/API] Update Employee',
  props<{ employee: Update<Employee> }>()
);

export const updateEmployees = createAction(
  '[Employee/API] Update Employees',
  props<{ employees: Update<Employee>[] }>()
);

export const deleteEmployee = createAction(
  '[Employee/API] Delete Employee',
  props<{ id: string }>()
);

export const deleteEmployees = createAction(
  '[Employee/API] Delete Employees',
  props<{ ids: string[] }>()
);

export const clearEmployees = createAction(
  '[Employee/API] Clear Employees'
);
