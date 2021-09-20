import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { Suburb } from 'src/app/model/suburb';

@Component({
  selector: 'app-suburb',
  templateUrl: './suburb.component.html',
  styleUrls: ['./suburb.component.scss']
})
export class SuburbComponent implements OnInit {

  allSuburbs: Observable<Suburb[]>; 

  constructor(private apiService:ApiService) {
  }

 ngOnInit(): void {
   this.loadAllSuburbs();
 } 

  loadAllSuburbs() {  
   this.allSuburbs = this.apiService.getAllSuburb();  
 }

 deleteSuburb(ID: number) {  
   if (confirm("Are you sure you want to delete this ?")) {   
   this.apiService.deleteSuburbById(ID).subscribe(() => {  
     this.loadAllSuburbs();  
   });  
 }  
} 

}
 