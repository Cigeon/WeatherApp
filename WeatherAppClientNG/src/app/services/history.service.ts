import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Forecast } from '../models/weather/forecast';
import { server } from '../config/constants';

@Injectable()
export class HistoryService {
private headers: Headers = new Headers({'Content-Type': 'application/json'});

  constructor(
    private http: Http
  ) { }

  getForecasts(): Promise<Forecast[]> {
    return this.http
      .get(`${server}/api/History`)
      .toPromise()
      .then(response => response.json() as Forecast[])
      .catch(this.handleError);
  }

  getForecastsById(id: number): Promise<Forecast> {
    return this.http
      .get(`${server}/api/History/${id}`)
      .toPromise()
      .then(response => response.json() as Forecast)
      .catch(this.handleError);
  }

  deleteForecast(forecast: Forecast): Promise<void> {
    return this.http
      .delete(`${server}/api/History/${forecast.Id}`, {headers: this.headers})
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }

}