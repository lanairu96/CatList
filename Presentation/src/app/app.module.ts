import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';

import { AppComponent } from './app.component';
import { CatListComponent } from './Components/cat-list/cat-list.component';
import { ApiService } from './Services/Api/api.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CatDetailComponent } from './Components/cat-detail/cat-detail.component';
import { StateService } from './Services/State/state.service';
import { LoginComponent } from './Components/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import {MatTableModule} from '@angular/material/table'
import { MatFormFieldModule } from '@angular/material/form-field';
import { AuthInterceptor } from './Services/Auth/auth.interceptor';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import{ MatToolbarModule} from '@angular/material/toolbar'
import {MatIconModule} from '@angular/material/icon'

@NgModule({
  declarations: [
    AppComponent,
    CatListComponent,
    CatDetailComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      {path: '', component: CatListComponent},
      {path: 'cat/:catId', component: CatDetailComponent},
    ]),
    BrowserAnimationsModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    FormsModule,
    MatSnackBarModule,
    MatToolbarModule,
    MatIconModule
  ],
  providers: [ApiService, StateService, {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
