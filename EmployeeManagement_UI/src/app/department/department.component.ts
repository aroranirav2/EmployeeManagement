import { Component, OnInit } from '@angular/core';
import { DepartmentDto } from '../Dtos/department-dto';
import { DepartmentService } from '../shared/services/department.service';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.scss']
})
export class DepartmentComponent implements OnInit {

  constructor(private departmentService: DepartmentService) { }

  ngOnInit(): void {
    this.departmentService.getAllDepartmentsWithoutEmployees().subscribe((departments: DepartmentDto[]) => {
      console.log(departments);
    }); 
    this.departmentService.getAllDepartmentsWithEmployees().subscribe((departments: DepartmentDto[]) => {
      console.log(departments);
    });
  }
}
