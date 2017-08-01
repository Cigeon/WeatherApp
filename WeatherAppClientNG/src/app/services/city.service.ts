import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { City } from '../models/city';
import { Period } from '../models/period';
import { server } from '../config/constants';

@Injectable()
export class CityService {
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

  addCity(city: City): Promise<void> {
    return this.http
      .post(`${server}/api/Cities`, JSON.stringify(city), {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }

  updateCity(city: City): Promise<void> {
    return this.http
      .put(`${server}/api/Cities/${city.Id}`, JSON.stringify(city), {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }

  deleteCity(city: City): Promise<void> {
    return this.http
      .delete(`${server}/api/Cities/${city.Id}`, {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }

}
