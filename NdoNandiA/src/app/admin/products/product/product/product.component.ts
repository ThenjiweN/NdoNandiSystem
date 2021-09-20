import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { Product } from 'src/app/model/product';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
 
  allProducts: Observable<Product[]>;   

  constructor(private apiService:ApiService) { }

  ngOnInit(): void {
    this.loadAllProducts();
  } 
 
   loadAllProducts() {  
    this.allProducts = this.apiService.getAllProduct();  
  }

  deleteProduct(ID: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.apiService.deleteProductById(ID).subscribe(() => {  
      this.loadAllProducts();  
    });  
  }  
}

}
