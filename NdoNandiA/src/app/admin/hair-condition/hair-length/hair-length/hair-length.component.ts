import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { Length } from 'src/app/model/length';

@Component({
  selector: 'app-hair-length',
  templateUrl: './hair-length.component.html',
  styleUrls: ['./hair-length.component.scss']
})
export class HairLengthComponent implements OnInit {
 
  allLengths: Observable<Length[]>; 

  constructor(private apiService:ApiService) {
  }

 ngOnInit(): void {
   this.loadAllLengths();
 } 

  loadAllLengths() {  
   this.allLengths = this.apiService.getAllLength();  
 }

 deleteLength(ID: number) {  
   if (confirm("Are you sure you want to delete this ?")) {   
   this.apiService.deleteLengthById(ID).subscribe(() => {  
     this.loadAllLengths();  
   });  
 }  
} 

}
 