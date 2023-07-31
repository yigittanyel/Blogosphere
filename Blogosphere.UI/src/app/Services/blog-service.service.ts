import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BlogModel } from '../Models/blog-model';
import { BlogModelWithoutPic } from '../Models/blog-model-withoutpic';

@Injectable({
  providedIn: 'root',
})
export class BlogServiceService {
  constructor(
    @Inject('apiUrl') private apiUrl: string,
    private http: HttpClient
  ) {}

  blogs: BlogModel[] = [];

  async getAllBlogs() {
    try {
      const response = await this.http.get<BlogModel[]>(this.apiUrl + "GetBlogs").toPromise();
      this.blogs = response;
    } catch (error) {
      console.error('Error getting all blogs:', error);
    }
  }
  
  async getBlogById(id: number) {
    try {
      const res = await this.http.get<BlogModel>(this.apiUrl + 'GetBlog/' + id).toPromise();
      const index = this.blogs.findIndex(t => t.id === res.id);
      this.blogs[index] = res;
    } catch (error) {
      console.error('Error getting blog by ID:', error);
    }
  }
  
  async addBlog(blog: BlogModelWithoutPic) {
    try {
      const res = await this.http.post<BlogModel>(this.apiUrl + 'PostBlogWithoutLargePic', blog).toPromise();
      this.blogs.push(res);
    } catch (error) {
      console.error('Error adding blog:', error);
    }
  }
  
  async updateBlog(id: number, blog: BlogModel) {
    try {
      await this.http.put<BlogModel>(this.apiUrl + 'PutBlog/' + id, blog).toPromise();
    } catch (error) {
      console.error('Error updating blog:', error);
    }
  }

  async deleteBlog(id: number) {
    try {
      await this.http.delete(this.apiUrl + 'DeleteBlog/' + id).toPromise();
    } catch (error) {
      console.error('Error deleting blog:', error);
    }
  }
  
}
