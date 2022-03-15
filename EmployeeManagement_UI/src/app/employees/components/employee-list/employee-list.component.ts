import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Employee } from '../../models/employee.model';
import { EmployeeState } from '../../store/employee.reducer';
import * as fromEmployeeAction from '../../store/employee.actions';
import * as employeeSelector from '../../store/employee.selectors';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  employees$: Observable<Employee[]>;
  employees: Employee[];

  constructor(private store: Store<EmployeeState>) { }

  ngOnInit(): void {
    this.store.dispatch(fromEmployeeAction.loadEmployees());
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.employees$ = this.store.pipe(select(employeeSelector.selectEmployees));
  }
}
