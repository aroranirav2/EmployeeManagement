import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, catchError, throwError } from 'rxjs';
import { CommonService } from 'src/app/shared/services/common.service';
import { ApiPaths } from 'src/enums/api-paths-enum';
import { environment } from 'src/environments/environment';
import { IDepartment } from '../models/IDepartment';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {
  readonly baseUrl = environment.employeeManagementBaseUrl;

  constructor(private httpClient: HttpClient, private commonService: CommonService) { }

  getAllDepartmentsWithoutEmployees(): Observable<IDepartment[]> {
    const headers = this.commonService.setDefaultHeader();
    const query = `${this.baseUrl}${ApiPaths.GetAllDepartmentsWithoutEmployees}`;
    return this.httpClient.get<IDepartment[]>(query, { headers })
      .pipe(
        map((departments: IDepartment[]) => departments),
        catchError(error => throwError(() => error))
      );
  }

  getAllDepartmentsWithEmployees(): Observable<IDepartment[]> {
    const headers = this.commonService.setDefaultHeader();
    const query = `${this.baseUrl}${ApiPaths.GetAllDepartmentsWithEmployees}`;
    return this.httpClient.get<IDepartment[]>(query, {headers})
      .pipe(
        map((departments: IDepartment[]) => departments),
        catchError(error => throwError(() => error))
      );
  }
}
