import { Component, inject, OnInit } from '@angular/core';
import { MasterService } from '../../services/master.service';
import { APIResponseModel } from '../../model/interface/role';

@Component({
  selector: 'app-degisnation',
  imports: [],
  templateUrl: './degisnation.component.html',
  styleUrl: './degisnation.component.css'
})
export class DegisnationComponent implements OnInit{
  
  designationList : any[] = [];
  masterService = inject(MasterService);
  isLoader: boolean = true;

  ngOnInit(): void {
    this.masterService.getDesignation().subscribe((res:APIResponseModel )=>{
      this.designationList = res.data;
      this.isLoader = false;
    },
    (error)=>{
      console.log(error);
      alert("Error in fetching designation data");
      this.isLoader = false;
    })
  }
  
}
