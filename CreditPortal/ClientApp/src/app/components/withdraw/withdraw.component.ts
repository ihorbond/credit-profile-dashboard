import { Component, OnInit } from '@angular/core';
import { CreditProfileService } from 'src/app/services/credit-profile.service';
import { CreditProfileWithdrawal } from 'src/app/models/credit-profile';
import { Router } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-withdraw',
  templateUrl: './withdraw.component.html',
  styleUrls: ['./withdraw.component.scss']
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
        this.router.navigateByUrl("");
    }, _ => this.showError());
  }

  private showError(): void {
    this.snackBar.open("There was an error processing your request", "Close", { duration: 3000 });
  }

}
