import { Component, OnInit, OnDestroy } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable, Subject, Subscriber, Subscription, takeUntil } from 'rxjs';
import { Department } from '../../models/department.model';
import { DepartmentState } from '../../store/department.reducer';
import * as fromDepartmentAction from '../../store/department.actions';
import * as departmentSelector from '../../store/department.selectors';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.scss']
})
export class DepartmentListComponent implements OnInit, OnDestroy {
  departments$: Observable<Department[]>;
  displayedColumns: string[] = ['Department Name'];
  private departmentsSubject = new Subject();

  constructor(private store: Store<DepartmentState>) { }

  ngOnInit(): void {
    this.store.dispatch(fromDepartmentAction.loadDepartments());
    this.loadDepartments();
  }

  ngOnDestroy(): void {
    this.departmentsSubject.next(true);
    this.departmentsSubject.complete();
  }

  loadDepartments(): void {
    this.departments$ = this.store.pipe(takeUntil(this.departmentsSubject), select(departmentSelector.selectDepartments));
  }
}