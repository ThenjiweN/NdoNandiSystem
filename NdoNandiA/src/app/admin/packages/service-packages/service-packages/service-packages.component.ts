import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';  
import { ApiService } from '../../../../service/api.service';  
import { Package } from 'src/app/model/package'; 

@Component({
  selector: 'app-service-packages',
  templateUrl: './service-packages.component.html',
  styleUrls: ['./service-packages.component.scss']
})
export class ServicePackagesComponent implements OnInit {

  allPackages: Observable<Package[]>; 

  constructor(private apiService:ApiService) { }

  ngOnInit(): void {
    this.loadAllPackages();
  } 
 
   loadAllPackages() {  
    this.allPackages = this.apiService.getAllPackage();  
  }

  deletePackage(ID: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.apiService.deletePackageById(ID).subscribe(() => {  
      this.loadAllPackages();  
    });  
  }  
}

}
 