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
  public bidID: number =-1;//Start no change 0 bidding not sucess other SucessBid
  public item: AuctionItem = {
    id: 1,  item_ID:1, lastBid: 500, name: "h watch", price: 200, history: [
      { name: "Abdo", bid: 210 }, {
        name: "Abdo2"
        , bid: 220
      }]
    , bidder_ID: null, lastBidder: "", lastBidderID:0,ticksRemain:60 
  };
  interval: any;
  updtaeTicksInterval: any;
  public getAllItemsUrl: string = "/api/v1/item/";
  public bidItemUrl: string ="/api/v1/Auction/"
  constructor(private _Activatedroute: ActivatedRoute, public service: AppServiceService, private router: Router, private http: HttpClient) {

    this.id = parseInt(this._Activatedroute.snapshot.paramMap.get("id"));

    //Parse sucessed
    if (this.id) {
      //Get Item From Server
      var compont = this;
      this.http.get<AuctionItem>(this.service.serviceUrl + this.getAllItemsUrl + this.id).subscribe(s => this.item = s);
      this.interval = setInterval(function () {
        compont.checkForUpdate();
        //alert("test");
      }, 3000);
      this.updtaeTicksInterval = setInterval(function () {
        if (compont.item.ticksRemain>0) {
          compont.item.ticksRemain--;
        }
        else if (compont.item.ticksRemain<= 0 && compont.item.lastBidderID) {
          this.router.navigateByUrl("/itemhis/" + compont.item.id.toString()); 
        }
        //alert("test");
      }, 1000);
    }
    else {
      this.router.navigateByUrl("/"); 
    }
    
  }

  ngOnInit() {

  }
 
  public bidding() {
    //
    if (this.service.current_User) {


      this.http.get<number>(this.service.serviceUrl + this.bidItemUrl + this.item.id + " , " + this.service.current_User.id + " , " + this.bidValue)
        .subscribe(s => {
          this.bidID = s

          this.checkForUpdate();
        });
    }
    else {
      this.router.navigateByUrl("/");
    }

    
    //Send and revice result of bidding

  }
  public checkForUpdate():void{

    if (this.id ) {
      //Get Item From Server

      this.http.get<AuctionItem>(this.service.serviceUrl + this.getAllItemsUrl + this.id).subscribe(s => this.item = s);
    }
    else {
      this.router.navigateByUrl("/");
    }
    //request auction item update using this.id...
    
  }
}
