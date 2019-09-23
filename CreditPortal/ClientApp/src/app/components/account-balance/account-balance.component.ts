import { Component, OnInit } from '@angular/core';
import { CreditProfile } from 'src/app/models/credit-profile';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CreditProfileService } from 'src/app/services/credit-profile.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-account-balance',
  templateUrl: './account-balance.component.html',
  styleUrls: ['./account-balance.component.scss']
})
export class AccountBalanceComponent implements OnInit {
  public creditProfile: CreditProfile;

  constructor(
    private creditProfileService: CreditProfileService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.loadCreditProfile();
  }

  public withdrawMoney(): void {
    this.router.navigateByUrl("/withdraw");
  }

  private loadCreditProfile(): void {
    const customerId: number = 1;
    const creditProfileId: number = 1;
    this.creditProfileService.getCreditProfile(customerId, creditProfileId)
      .subscribe((res: CreditProfile) => {
        this.creditProfile = res;
      }, err => this.showError(err));
  }

  private showError(response: HttpErrorResponse): void {
    this.snackBar.open(response.error, "Close", { duration: 5000 });
  }

}
