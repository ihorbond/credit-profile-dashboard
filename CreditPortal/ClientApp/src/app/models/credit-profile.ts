export class CreditProfile {
  public id: number;
  public balance: number;
  public available: number;
  public lineOfCredit: number;
}

export class CreditProfileWithdrawal {
  public withdrawalAmount: number;

  constructor(amount: number) {
    this.withdrawalAmount = amount;
  }
}
