import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StateService {

  constructor(private httpClient: HttpClient) { }

  public jwtTokenValue = new BehaviorSubject(this.JwtToken);
  public usernameValue = new BehaviorSubject(this.Username);

  set JwtToken(newToken: string){
    localStorage.setItem("jwtToken", newToken);
    this.jwtTokenValue.next(newToken);
  }

  get JwtToken(){
    return localStorage.getItem("jwtToken") ?? "";
  }

  set Username(username: string){
    localStorage.setItem("username", username);
    this.usernameValue.next(username);
  }

  get Username(){
    return localStorage.getItem("username") ?? "";
  }
}
