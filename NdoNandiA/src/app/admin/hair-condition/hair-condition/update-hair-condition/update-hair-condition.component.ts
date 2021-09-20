import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';   
import { Condition } from '../../../../model/condition';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-hair-condition',
  templateUrl: './update-hair-condition.component.html',
  styleUrls: ['./update-hair-condition.component.scss']
})
export class UpdateHairConditionComponent implements OnInit {

  dataSaved = false;
  conditionForm: any;  
  Name!: string; 
  ID!: number;
  allConditions!: Observable<Condition[]>;   
  conditionload = null;

  constructor(private formbulider: FormBuilder, private apiService:ApiService,private route:ActivatedRoute) { }

  ngOnInit(): void {
    
    this.route.params.subscribe(
      (params) => {
        this.ID = params['id'];
        console.log(this.ID);
      });

    this.conditionForm = this.formbulider.group({  
      Name: ['', [Validators.required]],   
    });  
  }
  

  updateCondition(condition: Condition) {    
    this.apiService.updateCondition(this.ID, condition).subscribe(() => {  
    });  
  }  


 /*  updateCondition(obj: Condition) {
    this.apiService.hairData = obj;
  } */
 
/*    loadConditionToEdit(ID: number) {  
    this.conditionService.getConditionById(ID).subscribe(data=> {    
      this.dataSaved = false;  
      this.conditionload = data.ID;  
      this.conditionForm.controls['Name'].setValue(data.Name);   
    });  

  } 
 
  */
}
 
