import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { client } from '../../model/class/client';
import { ClientService } from '../../services/client.service';
import { APIResponseModel } from '../../model/interface/role';
import { NgForm } from '@angular/forms';
import { UpperCasePipe } from '@angular/common';

@Component({
  selector: 'app-client',
  imports: [FormsModule, UpperCasePipe],
  templateUrl: './client.component.html',
  styleUrl: './client.component.css'
})
export class ClientComponent implements OnInit {
  clientObj : client = new client();
  clientList : client[] = [];

  clientService = inject(ClientService);

  ngOnInit(): void {
    this.loadClient();
  }

  loadClient(){
    this.clientService.getAllClients().subscribe((res: APIResponseModel) => {
      this.clientList = res.data;
    })
  }

  onSaveClient(form: NgForm){
    debugger;
    this.clientService.addUpdate(this.clientObj).subscribe((res: APIResponseModel) => {
      if(res.result){
        alert(res.message);
        this.loadClient();
        form.resetForm()
        this.clientObj = new client();
      }
      else{
        alert(res.message);
      }
    })
  }

  onDeleteClient(id:number){
      const sure = confirm("Are you sure you want to delete this record?");
      if(sure){
        this.clientService.deleteClientbyId(id).subscribe((res: APIResponseModel) => {
          if(res.result){
            alert(res.message);
            this.loadClient();
            this.clientObj = new client();
          }
          else{
            alert(res.message);
          }
        })
      }
  }

  onEditClient(data:client){
    this.clientObj = data;
  }

  onReset(form: NgForm){
    form.resetForm();
    this.clientObj = new client();
  }
}
