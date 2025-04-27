import { CommonModule, DatePipe } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import { ClientService } from '../../services/client.service';
import { APIResponseModel, IEmployee } from '../../model/interface/role';
import { client } from '../../model/class/client';
import { clientProject } from '../../model/class/client-project';

@Component({
  selector: 'app-client-project',
  imports: [ReactiveFormsModule, DatePipe],
  providers: [DatePipe],
  templateUrl: './client-project.component.html',
  styleUrl: './client-project.component.css'
})
export class ClientProjectComponent implements OnInit {

  projectForm: FormGroup = new FormGroup({
    clientProjectId: new FormControl(0),
    projectName: new FormControl("", [Validators.required, Validators.minLength(4), Validators.maxLength(10)]),
    startDate: new FormControl(""),
    expectedEndDate: new FormControl(""),
    leadByEmpId: new FormControl(0),
    completedDate: new FormControl(null),
    contactPerson: new FormControl(""),
    contactPersonContactNo: new FormControl(""),
    totalEmpWorking: new FormControl(""),
    projectCost: new FormControl(""),
    projectDetails: new FormControl(""),
    contactPersonEmailId: new FormControl(""),
    clientId: new FormControl(0)
  });

  datePipe = inject(DatePipe)
  clientService = inject(ClientService);
  employeeList: IEmployee[] = [];
  clientList: client[] = [];
  clientProjectList: clientProject[] = [];
  clientProjectObj = new clientProject;
  isFormEdited: boolean = false; // Flag to track form changes

  ngOnInit(): void {
    this.getAllEmployee();
    this.getAllClient();
    this.getAllClientProject();

    // Subscribe to form changes
    this.projectForm.valueChanges.subscribe(() => {
      this.isFormEdited = true; // Set flag to true when form is edited
    });
  }

  getAllEmployee(){
    this.clientService.getAllEmployees().subscribe((res:APIResponseModel)=>{
      this.employeeList = res.data; 
    })
  }

  getAllClient(){
    this.clientService.getAllClients().subscribe((res:APIResponseModel)=>{
      this.clientList = res.data;
    })
  }

  getAllClientProject(){
    this.clientService.getAllClientProject().subscribe((res:APIResponseModel)=>{
      this.clientProjectList = res.data;
    })
  }

  deleteClientProject(id:number){
   
    const sure = confirm("Are you sure you want to delete this record?");
    if(sure){
      this.clientService.deleteClientProjectbyId(id).subscribe((res:APIResponseModel)=>{
        if(res.result){
          alert(res.message);
          this.getAllClientProject();
        }else{
          alert(res.message);
        }
      })
    }
  }

  onEdit(id: number){
    this.clientService.getProjectByProjectId(id).subscribe((res:APIResponseModel)=>{
      this.clientProjectObj = res.data;
      res.data.startDate = this.datePipe.transform(res.data.startDate, 'yyyy-MM-dd');
      res.data.expectedEndDate = this.datePipe.transform(res.data.expectedEndDate, 'yyyy-MM-dd');
      this.projectForm.patchValue(res.data);
      this.isFormEdited = false; // Reset the flag when form is populated
    });
  }

  onSaveProject(){
    const formValue = this.projectForm.value;
    this.clientService.addUpdateClientProject(formValue).subscribe((res:APIResponseModel)=>{
      if(res.result){
        console.log(res);
        alert(res.message); 
        this.getAllClientProject();
        this.projectForm.reset();
        this.isFormEdited = false; // Reset the flag after saving
      }else{
        alert(res.message);
      }
    })
  }

  onReset(){
    this.projectForm.reset();
    this.clientProjectObj = new clientProject();
    this.isFormEdited = false; // Reset the flag on reset
  }

}
