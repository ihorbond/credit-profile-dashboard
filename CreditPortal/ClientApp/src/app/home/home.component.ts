import { Component, OnInit } from '@angular/core';
import { CreditProfileService } from '../services/credit-profile.service';
import { CreditProfile } from '../models/credit-profile';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public creditProfile: CreditProfile;

  constructor(private creditProfileService: CreditProfileService) { }

  ngOnInit() {
    this.loadCreditProfile();
  }

  public draw(): void {

  }

  private loadCreditProfile(): void {
    const customerId: number = 1;
    const creditProfileId: number = 1;
    this.creditProfileService.getCreditProfile(customerId, creditProfileId)
      .subscribe((res: CreditProfile) => {
        this.creditProfile = res;
      });
  }


}
