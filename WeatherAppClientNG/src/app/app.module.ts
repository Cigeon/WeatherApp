import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MdToolbarModule } from '@angular/material';
import { MdSelectModule } from '@angular/material';
import { MdInputModule } from '@angular/material';
import { MdButtonModule } from '@angular/material';


import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormControl, FormGroup } from '@angular/forms';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { QueryComponent } from './query/query.component';
import { CitiesComponent } from './cities/cities.component';
import { HistoryComponent } from './history/history.component';
import { ForecastComponent } from './forecast/forecast.component';

import { ParamsService } from './services/params.service';
import { CityService } from './services/city.service';
import { WeatherService } from './services/weather.service';

@NgModule({
  declarations: [
    AppComponent,
    QueryComponent,
    CitiesComponent,
    HistoryComponent,
    ForecastComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MdToolbarModule,
    MdSelectModule,
    MdInputModule,
    MdButtonModule,
    AppRoutingModule,
    HttpModule
  ],
  providers: [ParamsService, CityService, WeatherService],
  bootstrap: [AppComponent]
})
export class AppModule { }
