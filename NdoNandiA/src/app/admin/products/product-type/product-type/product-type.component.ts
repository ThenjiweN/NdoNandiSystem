import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { ProductType } from 'src/app/model/product-type';

@Component({
  selector: 'app-product-type',
  templateUrl: './product-type.component.html',
  styleUrls: ['./product-type.component.scss']
})
export class ProductTypeComponent implements OnInit {

  allProductTypes: Observable<ProductType[]>;   

  constructor(private apiService:ApiService) {
   }

  ngOnInit(): void {
    this.loadAllProductTypes();
  } 
 
   loadAllProductTypes() {  
    this.allProductTypes = this.apiService.getAllProType();  
  }

  deleteProductType(ID: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.apiService.deleteProTypeById(ID).subscribe(() => {  
      this.loadAllProductTypes();  
    });  
  }  
}
}
