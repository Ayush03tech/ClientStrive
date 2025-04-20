import { Component } from '@angular/core';
import { RolesComponent } from "../roles/roles.component";
import { DegisnationComponent } from "../degisnation/degisnation.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-master',
  imports: [RolesComponent, DegisnationComponent,CommonModule],
  templateUrl: './master.component.html',
  styleUrl: './master.component.css'
})

export class MasterComponent {
  
  currentComponent!: string;

  onshow (show:string){
    this.currentComponent = show;
  }
}
