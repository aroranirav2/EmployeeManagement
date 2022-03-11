import { Component, OnInit } from '@angular/core';
import { IDepartment } from '../../models/IDepartment';
import { DepartmentsService } from '../../services/departments.service';

@Component({
  selector: 'app-departments-list',
  templateUrl: './departments-list.component.html',
  styleUrls: ['./departments-list.component.scss']
})
export class DepartmentsListComponent implements OnInit {

  constructor(private departmentService: DepartmentsService) { }
  ngOnInit(): void {
    this.departmentService.getAllDepartmentsWithoutEmployees().subscribe((departments: IDepartment[]) => {
      console.log(departments);
    });
    this.departmentService.getAllDepartmentsWithEmployees().subscribe((departments: IDepartment[]) => {
      console.log(departments);
    });
  }
}