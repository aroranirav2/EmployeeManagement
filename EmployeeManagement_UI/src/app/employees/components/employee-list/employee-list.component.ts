import { Component, OnInit, OnDestroy } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable, Subject, takeUntil } from 'rxjs';
import { Employee } from '../../models/employee.model';
import { EmployeeState } from '../../store/employee.reducer';
import * as fromEmployeeAction from '../../store/employee.actions';
import * as employeeSelector from '../../store/employee.selectors';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit, OnDestroy {
  employees$: Observable<Employee[]>;
  displayedColumns: string[] = ['Full Name', 'Gender'];
  private employeesSubject = new Subject();

  constructor(private store: Store<EmployeeState>) { }

  ngOnInit(): void {
    this.store.dispatch(fromEmployeeAction.loadEmployees());
    this.loadEmployees();
  }

  ngOnDestroy(): void {
    this.employeesSubject.next(true);
    this.employeesSubject.complete();
  }
  loadEmployees(): void {
    this.employees$ = this.store.pipe(takeUntil(this.employeesSubject), select(employeeSelector.selectEmployees));
  }
  displayGender(gender: string): string {
    if (gender.toUpperCase() === 'M') {
      return 'Male';
    }
    if (gender.toUpperCase() === 'F') {
      return 'Female';
    }
    return 'Other';
  }
}
