export class AuctionItem {

  public id: number;
  public name: string;
  public price: number;
  public lastBid: number;
  public history: AuctionItemHistory[];
}
export class AuctionItemHistory {

 
  public name: string;
  public bid: number;
 
}
