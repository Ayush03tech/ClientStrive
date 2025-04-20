import { Component, inject, OnInit } from '@angular/core';
import { ClientService } from '../../services/client.service';
import { APIResponseModel, IEmployee } from '../../model/interface/role';
import { Employee } from '../../model/class/employee';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-employee',
  imports: [RouterLink, RouterOutlet],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent implements OnInit {
  clientService = inject(ClientService);
  employeeList: IEmployee[] = [];

  ngOnInit(): void {
    this.getAllEmployee();
  }

  getAllEmployee(){
    this.clientService.getAllEmployees().subscribe((res:APIResponseModel)=>{
      this.employeeList = res.data;
    })
  }

  deleteEmployee(id:number){
   const sure = confirm("Are you sure you want to delete this employee?");
    if(sure){
      this.clientService.deleteEmpolyeebyId(id).subscribe((res:APIResponseModel)=>{
        if(res.result){
          alert(res.message);
          this.getAllEmployee();
        } else {
          alert(res.message);
        }
      })
    }
  }
  
}
