import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { APIResponseModel, IRole } from '../../model/interface/role';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-roles',
  imports: [CommonModule],
  templateUrl: './roles.component.html',
  styleUrl: './roles.component.css'
})
export class RolesComponent implements OnInit {
  http = inject(HttpClient);
  roleList: IRole[] = [];
  isLoader :boolean = true;

  ngOnInit(): void {
    this.getAllRoles();
  }

  getAllRoles(){
      this.http.get<APIResponseModel >("http://localhost:5096/api/ClientStrive/GetAllRoles").subscribe((res:APIResponseModel)=>{
        console.log(res.data);
        this.roleList = res.data;
        console.log(this.roleList);
        this.isLoader = false;
      },
      (error)=>{
        console.log(error);
        alert("Error in fetching role data");
        this.isLoader = false;
      })
  }
  
}
