import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { StateService } from '../State/state.service';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient:HttpClient) { }

  private apiUrl: string = "https://localhost:7111/";
  getCat(){
    return this.httpClient.get(this.apiUrl + "Cat");
  }

  getCatById(catId: number){
    return this.httpClient.get(this.apiUrl + "Cat/" + catId);
  }

  login(email: string, password: string){
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify({email, password});
    return this.httpClient.post(this.apiUrl + "Account/Login", body, {'headers': headers});
  }

  comment(catId: number, comment: string){
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify({catId, comment});
    return this.httpClient.post(this.apiUrl + "Cat/AddComment", body, {'headers': headers});
  }
}
