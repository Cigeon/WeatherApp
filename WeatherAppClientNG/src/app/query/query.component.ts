import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MdSelectModule } from '@angular/material';

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

  constructor() { }

  showForecast() {
    console.log(this.selectedCity);
  }

  ngOnInit() {
    this.cities = [{
      Id: 1,
      Text: 'Kyiv',
      Value: 'Kyiv2'
    }, {
      Id: 2,
      Text: 'Lviv',
      Value: 'Lviv2'
    }];

    this.periods = [{
      Id: 1,
      Text: 'Current',
      Value: '1'
    }, {
      Id: 2,
      Text: 'For 3 days',
      Value: '3'
    }];
  }

}
