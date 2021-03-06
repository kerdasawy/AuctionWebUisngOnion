import { Component, OnInit } from '@angular/core';
import { AuctionItem } from '../auction-item';
import { Router } from '@angular/router';
import { AppServiceService } from '../app-service.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-auction-list',
  templateUrl: './auction-list.component.html',
  styleUrls: ['./auction-list.component.css']
})
export class AuctionListComponent implements OnInit {
  public items: AuctionItem[] = null;
  public itemsReady: AuctionItem[] = [{ id: 1,   item_ID:1, lastBid: 500, name: "h watch", price: 200, history: null, bidder_ID: null , lastBidder: "", lastBidderID:0,ticksRemain:60},
    { id: 2,   item_ID:1, lastBid: 600, name: "h watch2", price: 200, history: null, bidder_ID: null , lastBidder: "", lastBidderID:0,ticksRemain:60},
    { id: 3,   item_ID:1, lastBid: 700, name: "h watch3", price: 200, history: null, bidder_ID: null , lastBidder: "", lastBidderID:0,ticksRemain:60},
    { id: 4,   item_ID:1, lastBid: 800, name: "h watch4", price: 200, history: null, bidder_ID: null , lastBidder: "", lastBidderID:0,ticksRemain:60},
    { id: 5,   item_ID:1, lastBid: 900, name: "h watch5", price: 200, history: null, bidder_ID: null , lastBidder: "", lastBidderID:0,ticksRemain:60},
  ];
  public itemsSold: AuctionItem[] = [{ id: 1,  item_ID:1, lastBid: 500, name: "h hat", price: 200, history: null, bidder_ID: null , lastBidder: "", lastBidderID:0,ticksRemain:60},
    { id: 2,   item_ID:1, lastBid: 600, name: "h hat2", price: 200, history: null, bidder_ID: null , lastBidder: "", lastBidderID:0,ticksRemain:60},
    { id: 3,   item_ID:1, lastBid: 700, name: "h hat3", price: 200, history: null, bidder_ID: null , lastBidder: "", lastBidderID:0,ticksRemain:60},
    { id: 4,   item_ID:1, lastBid: 800, name: "h hat4", price: 200, history: null, bidder_ID: null , lastBidder: "", lastBidderID:0,ticksRemain:60},
    { id: 5,   item_ID:1, lastBid: 900, name: "h hat5", price: 200, history: null, bidder_ID: null , lastBidder: "", lastBidderID:0,ticksRemain:60},
  ];
  public getAllItemsUrl: string = "/api/v1/item";
  constructor(public service: AppServiceService, private router: Router, private http: HttpClient) {
    this.http.get<AuctionItem[]>(this.service.serviceUrl + this.getAllItemsUrl).subscribe(s => {
      this.items = s

      this.itemsReady = this.items.filter(i => !i.bidder_ID);
      this.itemsSold = this.items.filter(i => i.bidder_ID);
    });
    
  }

  ngOnInit() {
  }
  public showReport(ItemID: number) {

    this.router.navigateByUrl("/itemhis/" + ItemID.toString()); 
  }
  public bidItem(ItemID: number) {
    this.router.navigateByUrl("/itembid/"+ ItemID.toString()); 
  }
}
