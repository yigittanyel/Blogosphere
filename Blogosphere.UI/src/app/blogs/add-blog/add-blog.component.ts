import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BlogModel } from 'src/app/Models/blog-model';
import { BlogModelWithoutPic } from 'src/app/Models/blog-model-withoutpic';
import { BlogServiceService } from 'src/app/Services/blog-service.service';
import { SnackBarServiceService } from 'src/app/Services/snack-bar-service.service';

@Component({
  selector: 'app-add-blog',
  templateUrl: './add-blog.component.html',
  styleUrls: ['./add-blog.component.scss'],
})
export class AddBlogComponent implements OnInit {
  cardForm: FormGroup;

  constructor(
    private blogService: BlogServiceService,
    private snackBarService: SnackBarServiceService,
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<AddBlogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { withPic: BlogModelWithoutPic, update: BlogModel }

  ) {}

  ngOnInit(): void {
    
    if (this.data && this.data.update) {
      this.cardForm = this.fb.group({
        id: [this.data.update.id],
        title: [this.data.update.title, Validators.required],
        content: [this.data.update.content, Validators.required],
        summary: [this.data.update.summary, Validators.required],
        smallImageUrl: [this.data.update.smallImageUrl],
        largeImageUrl: [this.data.update.largeImageUrl],
        userId: [this.data.update.userId]
      });
    } else if (this.data && this.data.withPic) {
      this.cardForm = this.fb.group({
        title: [this.data.withPic.title, Validators.required],
        content: [this.data.withPic.content, Validators.required],
        summary: [this.data.withPic.summary, Validators.required],
        smallImageUrl: [this.data.withPic.smallImageUrl],
      });
    } else {
      this.cardForm = this.fb.group({
        title: ['', Validators.required],
        content: ['', Validators.required],
        summary: ['', Validators.required],
        smallImageUrl: [''],
      });
    }
  }
  
  
  async addBlog() {
    try {
      await this.blogService.addBlog(this.cardForm.value);
      this.snackBarService.showSnackBar('Blog Added Successfully');
      this.dialogRef.close();
      await this.blogService.getAllBlogs();
    } catch (error) {
      this.snackBarService.showSnackBar("Error adding blog");
    }
  }
  
  async updateBlog() {
    try {
      await this.blogService.updateBlog(this.data.update.id, this.cardForm.value);
      this.snackBarService.showSnackBar('Blog Updated Successfully');
      this.dialogRef.close();

      await this.blogService.getAllBlogs();
    } catch (error) {
      this.snackBarService.showSnackBar("Error updating blog");
    }
  }
}
