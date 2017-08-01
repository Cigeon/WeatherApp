import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MdSelectModule } from '@angular/material';
import { Router } from '@angular/router';

import { ParamsService } from '../services/params.service';
import { City } from '../models/city';
import { Period } from '../models/period';

@Component({
  selector: 'app-query',
  templateUrl: './query.component.html',
  styleUrls: ['./query.component.css']
})
export class QueryComponent implements OnInit {
  selectedCity: string;
  selectedPeriod: string;
  cities: City[];
  periods: Period[];

  constructor(
    private parameters: ParamsService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getCities();
    this.getPeriods();
  }

  getCities() {
    this.parameters.getCities()
      .then(cities => {
        this.cities = cities;
        this.selectedCity = this.cities[0].Value;
      });
  }

  getPeriods() {
    this.parameters.getPeriods()
      .then(periods => {
        this.periods = periods;
        this.selectedPeriod = this.periods[0].Value;
      });
  }

  showForecast() {
    this.router.navigate(['forecast/', this.selectedCity, this.selectedPeriod]);
  }

}
