import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { CommonService } from 'src/app/shared/services/common.service';
import { ApiPaths } from 'src/enums/api-paths-enum';
import { Department } from '../models/department.model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private httpClient: HttpClient, private commonService: CommonService) { }

  getAllDepartmentsWithoutEmployees(): Observable<Department[]> {
    const headers = this.commonService.setJsonHeader();
    const query = `${this.commonService.baseUrl}${ApiPaths.GetAllDepartmentsWithoutEmployees}`;
    return this.httpClient.get<Department[]>(query, { headers: headers })
      .pipe(
        map((departments: Department[]) => departments)
      );
  }

  getAllDepartmentsWithEmployees(): Observable<Department[]> {
    const headers = this.commonService.setJsonHeader();
    const query = `${this.commonService.baseUrl}${ApiPaths.GetAllDepartmentsWithEmployees}`;
    return this.httpClient.get<Department[]>(query, { headers: headers })
      .pipe(
        map((departments: Department[]) => departments)
      );
  }

  postDepartment(department: Department): Observable<Department> {
    const headers = this.commonService.setJsonHeader();
    const query = `${this.commonService.baseUrl}${ApiPaths.PostDepartment}`;
    return this.httpClient.post<Department>(query, department, { headers: headers });
  }
}
