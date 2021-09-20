import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';   
import { ApiService } from '../../../../service/api.service';  
import { Product } from 'src/app/model/product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.scss']
})
export class CreateProductComponent implements OnInit {

  productForm: any;   

  constructor(private formbulider: FormBuilder, private router: Router, private apiService:ApiService) { }


  createProduct(product: Product) {  
    if (confirm("Confirm product details?")){
          this.apiService.createProduct(product).subscribe( () => {              
        })}
      this.onBack();  
  }
  
  onBack(){
    this.router.navigate(['./product']);
  }

  ngOnInit(): void {
    this.productForm = this.formbulider.group({  
      Name: ['', [Validators.required, Validators.pattern('[a-zA-Z ]*')]],  
      }); 
    }

}
 