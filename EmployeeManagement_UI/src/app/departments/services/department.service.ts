import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, catchError, throwError } from 'rxjs';
import { CommonService } from 'src/app/shared/services/common.service';
import { ApiPaths } from 'src/enums/api-paths-enum';
import { environment } from 'src/environments/environment';
import { Department } from '../models/department.model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  readonly baseUrl = environment.employeeManagementBaseUrl;

  constructor(private httpClient: HttpClient, private commonService: CommonService) { }

  getAllDepartmentsWithoutEmployees(): Observable<Department[]> {
    const headers = this.commonService.setDefaultHeader();
    const query = `${this.baseUrl}${ApiPaths.GetAllDepartmentsWithoutEmployees}`;
    return this.httpClient.get<Department[]>(query, { headers })
      .pipe(
        map((departments: Department[]) => departments),
        catchError(error => throwError(() => error))
      );
  }

  getAllDepartmentsWithEmployees(): Observable<Department[]> {
    const headers = this.commonService.setDefaultHeader();
    const query = `${this.baseUrl}${ApiPaths.GetAllDepartmentsWithEmployees}`;
    return this.httpClient.get<Department[]>(query, { headers })
      .pipe(
        map((departments: Department[]) => departments),
        catchError(error => throwError(() => error))
      );
  }

  postDepartment(department: Department): Observable<Department> {
    const headers = this.commonService.setDefaultHeader();
    const query = `${this.baseUrl}${ApiPaths.PostDepartment}`;
    return this.httpClient.post<Department>(query, department, { headers });
  }
}
