import { Component, OnInit } from '@angular/core';
import { AuctionItem } from '../auction-item';

@Component({
  selector: 'app-auction-list',
  templateUrl: './auction-list.component.html',
  styleUrls: ['./auction-list.component.css']
})
export class AuctionListComponent implements OnInit {

  public itemsReady: AuctionItem[] = [{ id: 1, lastBid: 500, name: "h watch", price: 200, history: null},
    { id: 2, lastBid: 600, name: "h watch2", price: 200, history: null },
    { id: 3, lastBid: 700, name: "h watch3", price: 200, history: null},
    { id: 4, lastBid: 800, name: "h watch4", price: 200, history: null},
    { id: 5, lastBid: 900, name: "h watch5", price: 200, history: null},
  ];
  public itemsSold: AuctionItem[] = [{ id: 1, lastBid: 500, name: "h hat", price: 200, history: null },
    { id: 2, lastBid: 600, name: "h hat2", price: 200, history: null },
    { id: 3, lastBid: 700, name: "h hat3", price: 200, history: null},
    { id: 4, lastBid: 800, name: "h hat4", price: 200, history: null},
    { id: 5, lastBid: 900, name: "h hat5", price: 200, history: null },
  ];
  constructor() { }

  ngOnInit() {
  }
  public bidItem(auctionItemID: number) {

  }
}
