import { Injectable } from '@angular/core';
import { User } from './user'

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AppServiceService {
  public current_User: User;
  public serviceUrl: string = "https://localhost:44356";
  constructor() {
    
  }
}
