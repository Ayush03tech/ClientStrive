import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { APIResponseModel } from '../model/interface/role';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MasterService {

  http = inject(HttpClient);
  constructor() { }

  getDesignation(): Observable<APIResponseModel>{
    return this.http.get<APIResponseModel>("http://localhost:5096/api/ClientStrive/GetAllDesignations");
  }
}
