import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Location } from '@angular/common';

import { WeatherService } from '../services/weather.service';
import { Forecast } from '../models/weather/forecast';


import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-forecast',
  templateUrl: './forecast.component.html',
  styleUrls: ['./forecast.component.css']
})
export class ForecastComponent implements OnInit {
  forecast: Forecast;
  error: string;

  constructor(
    private weather: WeatherService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    this.getParameters();
  }

  getParameters() {
    this.route.params
      .subscribe(params => {
        const city = params['city'];
        const period = params['period'];
        console.log(city);
        this.weather.getForecast(city, period)
          .then(forecast => {
            this.forecast = forecast;
            this.error = null;
            console.log(forecast);
          })
          .catch(() => {
            this.error = 'not found';
            this.forecast = null;
          });
      });
  }

  goBack(): void {
    this.location.back();
  }
}
