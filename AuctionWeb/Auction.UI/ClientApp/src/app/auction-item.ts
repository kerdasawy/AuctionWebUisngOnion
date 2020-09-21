export class AuctionItem {

  public id: number;
  public name: string;
  public price: number;
  public lastBid: number;
  public history: AuctionItemHistory[];
  public bidder_ID: number;
}
export class AuctionItemHistory {

 
  public name: string;
  public bid: number;
 
}
