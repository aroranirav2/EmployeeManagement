import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of, tap } from 'rxjs';
import { Department } from '../models/department.model';
import { DepartmentService } from '../services/department.service';
import * as fromDepartmentAction from '../store/department.actions';

@Injectable()
export class DepartmentEffects {

  loadDepartments$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromDepartmentAction.loadDepartments),
      mergeMap(() => this.departmentService.getAllDepartmentsWithEmployees().pipe(
        map((departments: Department[]) => fromDepartmentAction.loadDepartmentsSuccess({ departments })),
        catchError((error: any) =>
          of(fromDepartmentAction.loadDepartmentsFailure({ error })))
      ))
    )
  );

  createDepartment$ = createEffect(() =>
    this.actions$.pipe(
      ofType(fromDepartmentAction.addDepartment),
      mergeMap(action => this.departmentService.postDepartment(action.department).pipe(
        map((department: Department) => fromDepartmentAction.addDepartmentSuccess({ department })),
        catchError((error: any) =>
          of(fromDepartmentAction.addDepartmentFailure({ error })))
      )),
      tap(() => console.log('we will route back to the list all department again'))
    )
  );
  constructor(private actions$: Actions, private departmentService: DepartmentService) { }

}
