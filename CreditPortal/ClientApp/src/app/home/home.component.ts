import { Component, OnInit } from '@angular/core';
import { CreditProfileService } from '../services/credit-profile.service';
import { CreditProfile } from '../models/credit-profile';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public creditProfile: CreditProfile;

  constructor(
    private creditProfileService: CreditProfileService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.loadCreditProfile();
  }

  public draw(): void {
    this.router.navigateByUrl("/withdraw");
  }

  private loadCreditProfile(): void {
    const customerId: number = 1;
    const creditProfileId: number = 1;
    this.creditProfileService.getCreditProfile(customerId, creditProfileId)
      .subscribe((res: CreditProfile) => {
        this.creditProfile = res;
      }, _ => this.showError());
  }

  private showError(): void {
    this.snackBar.open("There was an error processing your request", "Close", { duration: 3000 });
  }

}
