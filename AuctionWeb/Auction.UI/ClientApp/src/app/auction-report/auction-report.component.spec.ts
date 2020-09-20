import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionReportComponent } from './auction-report.component';

describe('AuctionReportComponent', () => {
  let component: AuctionReportComponent;
  let fixture: ComponentFixture<AuctionReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuctionReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuctionReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
