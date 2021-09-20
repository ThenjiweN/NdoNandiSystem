import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { Density } from 'src/app/model/density';

@Component({
  selector: 'app-hair-density',
  templateUrl: './hair-density.component.html',
  styleUrls: ['./hair-density.component.scss']
})
export class HairDensityComponent implements OnInit {

  allDensities: Observable<Density[]>;   

  constructor(private apiService:ApiService) {
   }

  ngOnInit(): void {
    this.loadAllDensities();
  } 

   loadAllDensities() {  
    this.allDensities = this.apiService.getAllDensity();  
  }

  deleteDensity(ID: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.apiService.deleteDensityById(ID).subscribe(() => {  
      this.loadAllDensities();  
    });  
  }  
} 

}
 