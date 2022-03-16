import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of } from 'rxjs';
import { Employee } from '../models/employee.model';
import { EmployeeService } from '../services/employee.service';
import * as fromEmployeeAction from '../store/employee.actions';


@Injectable()
export class EmployeeEffects {

  loadEmployees$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromEmployeeAction.loadEmployees),
      mergeMap(() => this.employeeService.getAllEmployees().pipe(
        map((employees: Employee[]) => fromEmployeeAction.loadEmployeesSuccess({ employees })),
        catchError((error: any) =>
          of(fromEmployeeAction.loadEmployeesFailure({ error })))
      ))
    )
  );

  constructor(private actions$: Actions, private employeeService: EmployeeService) {}

}
