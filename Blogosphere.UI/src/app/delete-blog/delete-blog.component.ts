import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BlogModel } from '../Models/blog-model';
import { SnackBarServiceService } from '../Services/snack-bar-service.service';
import { BlogServiceService } from '../Services/blog-service.service';

@Component({
  selector: 'app-delete-blog',
  templateUrl: './delete-blog.component.html',
  styleUrls: ['./delete-blog.component.scss'],
})
export class DeleteBlogComponent {
  constructor(
    private blogService: BlogServiceService,
    private snackBarService: SnackBarServiceService,
    private dialogRef: MatDialogRef<DeleteBlogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: BlogModel
  ) {}

  async deleteBlog() {
    try {
      await this.blogService.deleteBlog(this.data.id);
      this.snackBarService.showSnackBar('Blog Deleted Successfully');
      this.dialogRef.close(true);
    } catch (error) {
      this.snackBarService.showSnackBar('Error deleting blog');
    }
  }
}
