import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ApiService } from 'src/app/Services/Api/api.service';
import { StateService } from 'src/app/Services/State/state.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private apiService: ApiService,
    private stateService: StateService,
    private dialogRef: MatDialogRef<LoginComponent>) { }

  public email: string = '';
  public password: string = '';
  public incorrectCredentials : boolean = false;

  ngOnInit(): void {
  }


  login(): void{
    this.apiService.login(this.email, this.password).subscribe({
      next: data => {
        let rep:any = data;
        console.log(data);
        this.stateService.JwtToken = rep["accessToken"];
        this.stateService.Username = rep["loggedInAs"];
        this.dialogRef.close();
      },
      error: error => {
        console.log(error);   
        this.incorrectCredentials = true;     
      }
    });
  }
}
