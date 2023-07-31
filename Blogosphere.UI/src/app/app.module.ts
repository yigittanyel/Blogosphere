import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './blogs/home/home.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { BlogCardComponent } from './blogs/blog-card/blog-card.component';
import {MatCardModule} from '@angular/material/card';
import { HttpClientModule } from '@angular/common/http'; 
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule} from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { AddBlogComponent } from './blogs/add-blog/add-blog.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DeleteBlogComponent } from './delete-blog/delete-blog.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BlogCardComponent,
    AddBlogComponent,
    DeleteBlogComponent
      ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatCardModule,
    HttpClientModule,
    MatIconModule,
    MatSnackBarModule,
    MatDialogModule,
    MatFormFieldModule,
    FormsModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
  providers: [
    {
      provide: 'apiUrl',
      useValue: 'https://localhost:44363/api/blog/'
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
