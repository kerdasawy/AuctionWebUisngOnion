import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BidderComponent } from './bidder/bidder.component';
import { AuctionListComponent } from './auction-list/auction-list.component';
import { AuctionBiddingComponent } from './auction-bidding/auction-bidding.component';
import { AuctionReportComponent } from './auction-report/auction-report.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    BidderComponent,
    AuctionListComponent,
    AuctionBiddingComponent,
    AuctionReportComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'users', component: BidderComponent },
      { path: 'items', component: AuctionListComponent },
      { path: 'itembid', component: AuctionBiddingComponent },
      { path: 'itembid/:id', component: AuctionBiddingComponent },
      { path: 'itemhis', component: AuctionReportComponent },
      { path: 'itemhis/:id', component: AuctionReportComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
