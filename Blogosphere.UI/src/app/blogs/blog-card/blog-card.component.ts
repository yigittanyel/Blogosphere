import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { BlogServiceService } from 'src/app/Services/blog-service.service';
import { AddBlogComponent } from '../add-blog/add-blog.component';
import { BlogModelWithoutPic } from 'src/app/Models/blog-model-withoutpic';
import { BlogModel } from 'src/app/Models/blog-model';
import { SnackBarServiceService } from 'src/app/Services/snack-bar-service.service';
import { DeleteBlogComponent } from 'src/app/delete-blog/delete-blog.component';

@Component({
  selector: 'app-blog-card',
  templateUrl: './blog-card.component.html',
  styleUrls: ['./blog-card.component.scss']
})
export class BlogCardComponent implements OnInit {

  @Input() blog!: BlogModel;

  constructor(
    public blogService: BlogServiceService,
    public dialog: MatDialog,
    private snackBarService: SnackBarServiceService,
  ) { }
  
  ngOnInit(): void {
    this.loadBlogs();
  }

  loadBlogs(): void {
    this.blogService.getAllBlogs();
  }

  OpenAddBlogModal(){
      this.dialog.open(AddBlogComponent),{
        width: '500px',
        height: '500px'
      };
    }

    OpenUpdateBlogModal(blog: BlogModel) {
      const data = { update: blog };
      this.dialog.open(AddBlogComponent, {
        width: '500px',
        height: '500px',
        data: data, 
      });
    }

    OpenDeleteBlogModal(blog: BlogModel) {
      const dialogRef = this.dialog.open(DeleteBlogComponent, {
        width: '400px',
        height: '300px',
        data: blog 
      });
  
      dialogRef.afterClosed().subscribe((result) => {
        if (result) {
          this.loadBlogs();
        }
      });
    }
}
