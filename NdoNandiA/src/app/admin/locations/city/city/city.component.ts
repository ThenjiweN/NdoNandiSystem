import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { City } from 'src/app/model/city';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.scss']
}) 
export class CityComponent implements OnInit {
 
  allCitys: Observable<City[]>; 

  constructor(private apiService:ApiService) {
  }

 ngOnInit(): void {
   this.loadAllCities();
 } 

  loadAllCities() {  
   this.allCitys = this.apiService.getAllCity();  
 }

 deleteCity(ID: number) {  
   if (confirm("Are you sure you want to delete this ?")) {   
   this.apiService.deleteCityById(ID).subscribe(() => {  
     this.loadAllCities();  
   });  
 }  
} 

}
 