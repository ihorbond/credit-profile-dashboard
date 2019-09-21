import { Injectable, Inject } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';

@Injectable({
  providedIn: 'root'
})
export class CreditProfileService {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

  }
}
