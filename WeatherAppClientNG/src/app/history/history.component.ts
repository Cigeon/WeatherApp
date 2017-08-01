import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { DatePipe } from '@angular/common';

import { HistoryService } from '../services/history.service';
import { Forecast } from '../models/weather/forecast';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {
  forecasts: Forecast[];

  constructor(
    private historyService: HistoryService,
    private router: Router,
    private location: Location
  ) { }

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.historyService.getForecasts()
      .then(forecasts => this.forecasts = forecasts);
  }

  showDetails(forecast: Forecast) {
    this.router.navigate(['hist-forecast/', forecast.Id]);
  }

  deleteForecast(forecast: Forecast) {
    this.historyService.deleteForecast(forecast)
      .then(() => this.getForecasts());
  }

  convertDate(date: number) {
    return new Date(1000 * date);
  }

  goBack(): void {
    this.location.back();
  }
}
