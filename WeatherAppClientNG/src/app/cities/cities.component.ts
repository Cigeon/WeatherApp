import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';

import { CityService } from '../services/city.service';
import { City } from '../models/city';

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit {
  cities: City[];
  newCity: string;

  constructor(
    private cityService: CityService,
    private location: Location
  ) { }

  ngOnInit() {
    this.getCities();
  }

  getCities() {
    this.cityService.getCities()
      .then(cities => this.cities = cities);
  }

  addCity() {
    const city = new City();
    city.Text = this.newCity;
    city.Value = this.newCity;
    this.cityService.addCity(city)
      .then(() => this.getCities());
  }

  updateCity(city: City) {
    city.Text = city.Value;
    this.cityService.updateCity(city)
      .then(() => this.getCities());
  }

  deleteCity(city: City) {
    this.cityService.deleteCity(city)
      .then(() => this.getCities());
  }

  goBack(): void {
    this.location.back();
  }
}
