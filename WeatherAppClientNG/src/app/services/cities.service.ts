import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { City } from '../models/city';
import { server } from '../config/constants';

@Injectable()
export class CitiesService {
private headers: Headers = new Headers({'Content-Type': 'application/json'});

  constructor(
    private http: Http
  ) { }

  getDefaultCities(): Promise<City[]> {
    return this.http
      .get(`${server}/api/Cities`)
      .toPromise()
      .then(response => response.json() as City[]);
  }


}
