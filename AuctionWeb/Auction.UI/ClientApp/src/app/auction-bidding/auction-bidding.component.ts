import { Component, OnInit } from '@angular/core';
import { AuctionItem } from '../auction-item';
import { AuctionItemHistory } from '../auction-item';
import { ActivatedRoute, Router } from '@angular/router';
import { AppServiceService } from '../app-service.service';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-auction-bidding',
  templateUrl: './auction-bidding.component.html',
  styleUrls: ['./auction-bidding.component.css']
})
export class AuctionBiddingComponent implements OnInit {
  public id: number;
  public bidValue: number;
  public item: AuctionItem = {
    id: 1, lastBid: 500, name: "h watch", price: 200, history: [
      { name: "Abdo", bid: 210 }, {
        name: "Abdo2"
        , bid: 220
      }]
    , bidder_ID: null
  };
    interval: any;
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
    this.interval = setInterval(() => {
      this.checkUpdate();
    }, 1000);
  }
  checkUpdate(): AuctionItem {

    //request auction item update using this.id...
    return null;
  }
  public bidding() {
    //
    this.bidValue;
    this.service.current_User.id;
    this.id;//Auction Item id

    //Send and revice result of bidding

  }
  public checkForUpdate(): AuctionItem{

    //request auction item update using this.id...
    return null;
  }
}
