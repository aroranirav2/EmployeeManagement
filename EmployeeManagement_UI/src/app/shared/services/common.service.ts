import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  constructor() { }

  setDefaultHeader(): HttpHeaders {
    return new HttpHeaders({
      'Accept': 'application/json',
      'Content-type': 'application/json'
    });
  }
}
