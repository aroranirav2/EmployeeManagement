import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { IDepartment } from '../../models/IDepartment';
import { DepartmentsService } from '../../services/departments.service';
import { DepartmentState } from '../../store';
import * as fromActions from "../../store/department.actions";

@Component({
  selector: 'app-departments-list',
  templateUrl: './departments-list.component.html',
  styleUrls: ['./departments-list.component.scss']
})
export class DepartmentsListComponent implements OnInit {
  departments: IDepartment[];

  constructor(private departmentService: DepartmentsService, private store: Store<DepartmentState>) { }
  ngOnInit(): void {
    this.store.dispatch(fromActions.getDepartments());
    this.loadDepartments();

    this.departmentService.getAllDepartmentsWithoutEmployees().subscribe((departments: IDepartment[]) => {
      console.log(departments);
    });
    this.departmentService.getAllDepartmentsWithEmployees().subscribe((departments: IDepartment[]) => {
      console.log(departments);
    });
  }
  loadDepartments(): void {
    const departmentsObserver = {
      next: (departments: IDepartment[]) => {
        this.store.dispatch(fromActions.getDepartmentsSuccess(({ departments: departments })));
        this.departments = departments;
      },
      error: (err: any) => {
        this.store.dispatch(fromActions.getDepartmentsFailure(({error: err})));
        console.log(err)
      }
    };
  }
}