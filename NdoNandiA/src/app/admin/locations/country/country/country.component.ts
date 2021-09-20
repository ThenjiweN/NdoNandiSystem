import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { Country } from 'src/app/model/country';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.scss']
})
export class CountryComponent implements OnInit {

  allCountries: Observable<Country[]>; 

  constructor(private apiService:ApiService) {
  }

 ngOnInit(): void {
   this.loadAllCountries();
 } 

  loadAllCountries() {  
   this.allCountries = this.apiService.getAllCountry();  
 }

 deleteCountry(ID: number) {  
   if (confirm("Are you sure you want to delete this ?")) {   
   this.apiService.deleteCountryById(ID).subscribe(() => {  
     this.loadAllCountries();  
   });  
 }  
} 

}
 