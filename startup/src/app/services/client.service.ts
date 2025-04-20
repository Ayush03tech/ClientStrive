import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { client } from '../model/class/client';
import { APIResponseModel } from '../model/interface/role';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  http = inject(HttpClient);
  
  constructor() { }

  getAllClients():Observable<APIResponseModel>{
    return this.http.get<APIResponseModel>(environment.CLIENT_URL + 'GetAllClients');
  }

  getAllEmployees():Observable<APIResponseModel>{
    return this.http.get<APIResponseModel>(environment.API_URL + 'GetAllEmployees');
  }

  addUpdate(obj:client):Observable<APIResponseModel>{
    return this.http.post<APIResponseModel>(environment.CLIENT_URL + 'AddUpdateClient', obj);
  }

  deleteClientbyId(id:number):Observable<APIResponseModel>{
    return this.http.delete<APIResponseModel>(environment.CLIENT_URL + 'DeleteClientbyClientId?clientId=' + id);
  }

  addUpdateClientProject(obj:client):Observable<APIResponseModel>{
    return this.http.post<APIResponseModel>(environment.CLIENT_PROJECT_URL + 'AddUpdateClientProject', obj);
  }

  getAllClientProject():Observable<APIResponseModel>{
    return this.http.get<APIResponseModel>(environment.CLIENT_PROJECT_URL + 'GetAllClientProjects');
  }

  getProjectByProjectId(id:number):Observable<APIResponseModel>{
    return this.http.get<APIResponseModel>(environment.CLIENT_PROJECT_URL + 'GetProjectByProjectId?clientProjectId=' + id);
  }

  deleteClientProjectbyId(id:number):Observable<APIResponseModel>{
    return this.http.delete<APIResponseModel>(environment.CLIENT_PROJECT_URL + 'DeleteClientProjectById?projectId=' + id);
  }

  deleteEmpolyeebyId(id:number):Observable<APIResponseModel>{
    return this.http.delete<APIResponseModel>(environment.API_URL + 'DeleteEmployeeByEmpId?empId=' + id);
  }

}
