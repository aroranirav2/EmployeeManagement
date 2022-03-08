import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { catchError, map, Observable, throwError } from 'rxjs';
import { DepartmentDto } from 'src/app/Dtos/department-dto';
import { CommonService } from './common.service';
import { environment } from 'src/environments/environment';
import { ApiPaths } from 'src/enums/api-paths-enum';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  readonly baseUrl = environment.employeeManagementBaseUrl;

  constructor(private httpClient: HttpClient, private commonService: CommonService) { }

  getAllDepartmentsWithoutEmployees(): Observable<DepartmentDto[]> {
    const headers = this.commonService.setDefaultHeader();
    const query = `${this.baseUrl}${ApiPaths.GetAllDepartmentsWithoutEmployees}`;
    return this.httpClient.get(query, { headers })
      .pipe(
        map((departments: any) => departments),
        catchError(error => throwError(() => error))
      );
  }

  getAllDepartmentsWithEmployees(): Observable<DepartmentDto[]> {
    const headers = this.commonService.setDefaultHeader();
    const query = `${this.baseUrl}${ApiPaths.GetAllDepartmentsWithEmployees}`;
    return this.httpClient.get(query, {headers})
      .pipe(
        map((departments: any) => departments),
        catchError(error => throwError(() => error))
      );
  }
}
