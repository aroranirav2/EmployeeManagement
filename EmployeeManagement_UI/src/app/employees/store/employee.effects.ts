import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of } from 'rxjs';
import { EmployeeService } from '../services/employee.service';
import * as fromEmployeeAction from '../store/employee.actions';


@Injectable()
export class EmployeeEffects {

  loadEmployees$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromEmployeeAction.loadEmployees),
      mergeMap(() => this.employeeService.getAllEmployees().pipe(
        map(employees => fromEmployeeAction.loadEmployeesSuccess({ employees })),
        catchError(error =>
          of(fromEmployeeAction.loadEmployeesFailure({ error })))
      ))
    )
  );

  constructor(private actions$: Actions, private employeeService: EmployeeService) {}

}
