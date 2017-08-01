import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { City } from '../models/city';
import { Period } from '../models/period';
import { server } from '../config/constants';

@Injectable()
export class ParamsService {
private headers: Headers = new Headers({'Content-Type': 'application/json'});

  constructor(
    private http: Http
  ) { }

  getCities(): Promise<City[]> {
    return this.http
      .get(`${server}/api/Cities`)
      .toPromise()
      .then(response => response.json() as City[])
      .catch(this.handleError);
  }

  getPeriods(): Promise<Period[]> {
    return this.http
      .get(`${server}/api/Periods`)
      .toPromise()
      .then(response => response.json() as Period[])
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }

}
