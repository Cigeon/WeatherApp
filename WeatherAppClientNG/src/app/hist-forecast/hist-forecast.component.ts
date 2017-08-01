import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Location } from '@angular/common';
import { DatePipe } from '@angular/common';

import { HistoryService } from '../services/history.service';
import { Forecast } from '../models/weather/forecast';
import { City } from '../models/city';
import { Period } from '../models/period';


import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'app-hist-forecast',
  templateUrl: './hist-forecast.component.html',
  styleUrls: ['./hist-forecast.component.css']
})
export class HistForecastComponent implements OnInit {
  forecast: Forecast;
  error: string;

  constructor(
    private history: HistoryService,
    private route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    this.getForecast();
  }

  getForecast() {
    this.route.params
      .subscribe(params => {
        const id = params['id'];
        this.history.getForecastsById(id)
          .then(forecast => {
            this.forecast = forecast;
            this.error = null;
          })
          .catch(() => {
            this.error = 'not found';
            this.forecast = null;
          });
      });
  }

  convertDate(date: number) {
    return new Date(1000 * date);
  }

  goBack(): void {
    this.location.back();
  }
}
