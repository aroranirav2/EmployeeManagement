import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
  readonly baseUrl = environment.employeeManagementBaseUrl;

  constructor() { }

  setJsonHeader(): HttpHeaders {
    return new HttpHeaders({
      'Accept': 'application/json',
      'Content-type': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
    });
  }
}
