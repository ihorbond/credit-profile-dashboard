export class CreditProfile {
  public id: number;
  public lineOfCredit: number;
  public balance: number;
}

export class CreditProfileWithdrawal {
  public withdrawalAmount: number;

  constructor(amount: number) {
    this.withdrawalAmount = amount;
  }
}
