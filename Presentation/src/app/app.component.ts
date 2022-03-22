import { Component, Input } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { LoginComponent } from './Components/login/login.component';
import { StateService } from './Services/State/state.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public title = 'RankCats';

  constructor(private matDialog: MatDialog, public stateService: StateService) { }

  openLoginModal(): void{
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = "modal-component";
    const modalDialog = this.matDialog.open(LoginComponent, dialogConfig);
  }

  logout():void{
    this.stateService.JwtToken = '';
    this.stateService.Username = '';
  }
}
