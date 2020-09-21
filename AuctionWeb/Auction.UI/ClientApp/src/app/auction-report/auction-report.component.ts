import { Component, OnInit } from '@angular/core';
import { AuctionItem } from '../auction-item';
import { ActivatedRoute, Router } from '@angular/router';
import { AppServiceService } from '../app-service.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-auction-report',
  templateUrl: './auction-report.component.html',
  styleUrls: ['./auction-report.component.css']
})
export class AuctionReportComponent implements OnInit {
  public item: AuctionItem = {
    id: 1, lastBid: 500, name: "h watch", price: 200, history: [
      { name: "Abdo", bid: 210 }
      , { name: "Abdo2", bid: 220 }
      , { name: "Abdo", bid: 230 }
      , { name: "Abdo2", bid: 240 }
      , { name: "Abdo3", bid: 400 }
      , { name: "Abdo", bid: 500 }
    ], bidder_ID: null
  };
  public id: number;
  constructor(private _Activatedroute: ActivatedRoute, public service: AppServiceService, private router: Router, private http: HttpClient) {

    this.id = parseInt(this._Activatedroute.snapshot.paramMap.get("id"));
    //Parse sucessed
    if (this.id) {
      //Get Item From Server
    }
    else {
      this.router.navigateByUrl("/");
    }

  }

  ngOnInit() {
  }

}
