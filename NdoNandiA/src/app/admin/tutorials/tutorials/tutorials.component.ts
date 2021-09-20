import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { ApiService } from 'src/app/service/api.service'; 
import { Tutorials } from 'src/app/model/tutorials';

@Component({
  selector: 'app-tutorials',
  templateUrl: './tutorials.component.html',
  styleUrls: ['./tutorials.component.scss']
})
export class TutorialsComponent implements OnInit {

  allTutorials: Observable<Tutorials[]>;   

  constructor(private apiService:ApiService) {
   }

  ngOnInit(): void {
    this.loadAllTutorials();
  } 

   loadAllTutorials() {  
    this.allTutorials = this.apiService.getAllTutorial();  
  }

  deleteTutorial(ID: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.apiService.deleteTutorialById(ID).subscribe(() => {  
      this.loadAllTutorials();  
    });  
  }  
}

}
 