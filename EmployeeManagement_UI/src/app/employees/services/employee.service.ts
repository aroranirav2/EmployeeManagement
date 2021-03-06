import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { CommonService } from 'src/app/shared/services/common.service';
import { ApiPaths } from 'src/enums/api-paths-enum';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private httpClient: HttpClient, private commonService: CommonService) { }

  getAllEmployees(): Observable<Employee[]> {
    const headers = this.commonService.setJsonHeader();
    const query = `${this.commonService.baseUrl}${ApiPaths.GetAllEmployees}`
    return this.httpClient.get<Employee[]>(query, { headers: headers }).pipe(
      map((employees: Employee[]) => employees)
    );
  }
}
