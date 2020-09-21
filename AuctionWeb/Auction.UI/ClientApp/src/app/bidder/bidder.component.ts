import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AppServiceService } from '../app-service.service';
import { User } from '../user';
import { strict } from 'assert';
import { Router } from '@angular/router';
@Component({
  selector: 'app-bidder',
  templateUrl: './bidder.component.html',
  styleUrls: ['./bidder.component.css']
})
export class BidderComponent implements OnInit {

  public users: User[];
  public getAllBidderUrl: string = "/api/v1/Bidder";

  constructor(public service: AppServiceService, private router: Router,private http: HttpClient ) { }

  ngOnInit() {
    this.http.get<User[]>(this.service.serviceUrl + this.getAllBidderUrl).subscribe(s => this.users=s);

  }
  getStringOfObject(obj: any): string
  {
    var res: string = "";
    for (var key in obj) {
      if (Object.prototype.hasOwnProperty.call(obj, key)) {
        var val = obj[key];
        res += key+":"+ val
      }
      
    }
    return res;
  }
  public selectBidder(bidder: User) {
    this.service.current_User = bidder;
    this.router.navigateByUrl("/items");  
  }
}
