import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { InventoryItem } from 'src/app/model/inventory-item';


@Component({
  selector: 'app-inventory-item',
  templateUrl: './inventory-item.component.html',
  styleUrls: ['./inventory-item.component.scss']
})
export class InventoryItemComponent implements OnInit {

  allInventoryItems: Observable<InventoryItem[]>;   

  constructor(private apiService:ApiService) {
   }

  ngOnInit(): void {
    this.loadallInventoryItems();
  } 
 
   loadallInventoryItems() {  
    this.allInventoryItems = this.apiService.getAllInventoryItem();  
  }

  deleteInventoryItem(ID: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.apiService.deleteInventoryItemById(ID).subscribe(() => {  
      this.loadallInventoryItems();  
    });  
  }  
}

} 
