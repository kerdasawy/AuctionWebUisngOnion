export class AuctionItem {

  public id: number;
  public item_ID: number;
  public name: string;
  public price: number;
  public lastBid: number;
  public history: AuctionItemHistory[];
  public bidder_ID: number;
  public lastBidder: string;
  public lastBidderID: number;
  public ticksRemain: number;
}
export class AuctionItemHistory {

 
  public name: string;
  public bid: number;
 
}
