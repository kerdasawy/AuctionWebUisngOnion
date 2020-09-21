import { Component } from '@angular/core';
import { AppServiceService } from '../app-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public constructor(public service: AppServiceService) {
  }
}
