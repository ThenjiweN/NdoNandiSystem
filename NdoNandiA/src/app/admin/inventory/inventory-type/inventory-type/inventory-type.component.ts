import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { InventoryType } from 'src/app/model/inventory-type';

@Component({
  selector: 'app-inventory-type',
  templateUrl: './inventory-type.component.html',
  styleUrls: ['./inventory-type.component.scss']
})
export class InventoryTypeComponent implements OnInit {

  allInventoryTypes: Observable<InventoryType[]>;   

  constructor(private apiService:ApiService) {
   }

  ngOnInit(): void {
    this.loadallInventoryTypes();
  } 
 
   loadallInventoryTypes() {  
    this.allInventoryTypes = this.apiService.getAllInvType();  
  }

  deleteInventoryType(ID: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.apiService.deleteInvTypeById(ID).subscribe(() => {  
      this.loadallInventoryTypes();  
    });  
  }  
}
}
 