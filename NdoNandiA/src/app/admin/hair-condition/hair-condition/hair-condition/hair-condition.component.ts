import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { Condition } from '../../../../model/condition';

@Component({ 
  selector: 'app-hair-condition',
  templateUrl: './hair-condition.component.html',
  styleUrls: ['./hair-condition.component.scss']
})
export class HairConditionComponent implements OnInit {

  allConditions: Observable<Condition[]>;   

  constructor(private apiService:ApiService) {
   }

  ngOnInit(): void {
    this.loadAllConditions();
  } 

   loadAllConditions() {  
    this.allConditions = this.apiService.getAllCondition();  
  }

  deleteCondition(ID: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.apiService.deleteConditionById(ID).subscribe(() => {  
      this.loadAllConditions();  
    });  
  }  
}


}
 