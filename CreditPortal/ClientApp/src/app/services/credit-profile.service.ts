import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CreditProfile, CreditProfileWithdrawal } from '../models/credit-profile';

@Injectable({
  providedIn: 'root'
})
export class CreditProfileService {

  constructor(
    private http: HttpClient
  ) { }

  public getCreditProfile(customerId: number, profileId: number): Observable<CreditProfile> {
    const url: string = `/api/v1/${customerId}/customers/creditprofiles/${profileId}`;
    return this.http.get<CreditProfile>(url);
  }

  public withdrawMoney(customerId: number, profileId: number, body: CreditProfileWithdrawal): Observable<any> {
    const url: string = `/api/v1/${customerId}/customers/creditprofiles/${profileId}`;
    return this.http.put(url, body);
  }

}
