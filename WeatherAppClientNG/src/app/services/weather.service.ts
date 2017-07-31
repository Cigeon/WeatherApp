import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { Forecast } from '../models/weather/forecast';
import { server } from '../config/constants';

import 'rxjs/add/operator/toPromise';

@Injectable()
export class WeatherService {

  constructor(
    private http: Http
  ) { }

  getForecast(city: string, period: number): Promise<Forecast> {
    return this.http.get(`${server}/api/Weather/${city}/${period}`)
      .toPromise()
      .then(response => response.json() as Forecast);
  }

}
