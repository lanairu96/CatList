import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/Services/Api/api.service';
import { StateService } from 'src/app/Services/State/state.service';
import { LoginComponent } from '../login/login.component';
import {MatSnackBar} from '@angular/material/snack-bar'

@Component({
  selector: 'app-cat-detail',
  templateUrl: './cat-detail.component.html',
  styleUrls: ['./cat-detail.component.css']
})
export class CatDetailComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute,
    private apiService: ApiService,
    public stateService: StateService,
    private matDialog: MatDialog,
    private snackBarRef: MatSnackBar) { }

  public cat: any;
  public catId: any;
  public comments: any;

  public commentInput: string = '';
  
  ngOnInit(): void {
    this.catId = this.activatedRoute.snapshot.paramMap.get("catId");
    this.loadCatInfo();
    this.stateService.jwtTokenValue.subscribe((nextValue) => {
      console.log("New Token: " + nextValue);
    })
  }

  loadCatInfo(){
    this.apiService.getCatById(this.catId).subscribe(response => {
      let rep: any = response;
      this.cat = rep.cat;
      this.comments = rep.comments;
    })
  }

  openLoginModal(): void{
    const dialogConfig = new MatDialogConfig();
    dialogConfig.id = "modal-component";
    const modalDialog = this.matDialog.open(LoginComponent, dialogConfig);
  }

  comment():void{
    this.apiService.comment(this.catId, this.commentInput).subscribe((result) => {
      console.log(result);
      if(result === true){
        this.loadCatInfo();
        this.commentInput = '';
        this.snackBarRef.open("Comment published!", '', {duration: 3000});
      }
    })
  }
}
