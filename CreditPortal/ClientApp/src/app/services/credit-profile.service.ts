import { Injectable, isDevMode } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CreditProfile, CreditProfileWithdrawal } from '../models/credit-profile';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CreditProfileService {

  private readonly base: string = environment.apiEndpoint;

  constructor(
    private http: HttpClient
  ) { }

  public getCreditProfile(customerId: number, profileId: number): Observable<CreditProfile> {
    const url: string = `${this.base}/api/v1/customers/${customerId}/creditprofiles/${profileId}`;
    return this.http.get<CreditProfile>(url);
  }

  public withdrawMoney(customerId: number, profileId: number, body: CreditProfileWithdrawal): Observable<any> {
    const url: string = `${this.base}/api/v1/customers/${customerId}/creditprofiles/${profileId}`;
    return this.http.put(url, body);
  }

}
