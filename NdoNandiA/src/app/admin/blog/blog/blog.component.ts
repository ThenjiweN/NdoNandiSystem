import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';  
import { Observable } from 'rxjs';  
import { ApiService } from 'src/app/service/api.service'; 
import { Blog } from 'src/app/model/blog'; 

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.scss']
})
export class BlogComponent implements OnInit {

  allBlogs: Observable<Blog[]>;   

  constructor(private apiService:ApiService) {
   }

  ngOnInit(): void {
    this.loadAllBlogs();
  } 

   loadAllBlogs() {  
    this.allBlogs = this.apiService.getAllBlog();  
  }

  deleteBlog(ID: number) {  
    if (confirm("Are you sure you want to delete this ?")) {   
    this.apiService.deleteBlogById(ID).subscribe(() => {  
      this.loadAllBlogs();  
    });  
  }  
}

}
 