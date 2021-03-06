import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { CreditProfileService } from 'src/app/services/credit-profile.service';
import { CreditProfileWithdrawal } from 'src/app/models/credit-profile';
import { Router } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-withdraw',
  templateUrl: './withdraw.component.html',
  styleUrls: ['./withdraw.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class WithdrawComponent implements OnInit {

  public withdrawalAmount: FormControl = new FormControl(null,
    [Validators.required, Validators.min(1), Validators.pattern(/[\d]/)]);

  constructor(
    private creditProfileService: CreditProfileService,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  ngOnInit() {

  }

  public submit(): void {
    const customerId: number = 1;
    const creditProfileId: number = 1;
    const body: CreditProfileWithdrawal = new CreditProfileWithdrawal(this.withdrawalAmount.value);
    this.creditProfileService.withdrawMoney(customerId, creditProfileId, body)
      .subscribe(_ => {
        this.router.navigateByUrl("/home");
    }, err => this.showError(err));
  }

  private showError(response: HttpErrorResponse): void {
    this.snackBar.open(response.error, "Close", { duration: 5000 });
  }

}
