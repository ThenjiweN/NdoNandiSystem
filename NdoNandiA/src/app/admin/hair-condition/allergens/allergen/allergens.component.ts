import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { Allergen } from 'src/app/model/allergen';

@Component({
  selector: 'app-allergens',
  templateUrl: './allergens.component.html',
  styleUrls: ['./allergens.component.scss']
})
export class AllergensComponent implements OnInit {

  allAllergens: Observable<Allergen[]>;   

  constructor(private apiService:ApiService) {
   }

  ngOnInit(): void {
    this.loadAllAllergens();
  } 
 
   loadAllAllergens() {  
    this.allAllergens = this.apiService.getAllAllergen();  
  }

  deleteAllergen(ID: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.apiService.deleteAllergenById(ID).subscribe(() => {  
      this.loadAllAllergens();  
    });  
  }  
}
 
}
 