import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { Province } from 'src/app/model/province';

@Component({
  selector: 'app-province',
  templateUrl: './province.component.html',
  styleUrls: ['./province.component.scss']
})
export class ProvinceComponent implements OnInit {

  allProvinces: Observable<Province[]>; 

  constructor(private apiService:ApiService) {
  }

 ngOnInit(): void {
   this.loadAllProvinces();
 } 

  loadAllProvinces() {  
   this.allProvinces = this.apiService.getAllProvince();  
 }

 deleteProvince(ID: number) {  
   if (confirm("Are you sure you want to delete this ?")) {   
   this.apiService.deleteProvinceById(ID).subscribe(() => {  
     this.loadAllProvinces();  
   });  
 }  
} 

}
 