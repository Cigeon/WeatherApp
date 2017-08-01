import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { QueryComponent } from '../query/query.component';
import { ForecastComponent } from '../forecast/forecast.component';
import { CitiesComponent } from '../cities/cities.component';
import { HistoryComponent } from '../history/history.component';
import { HistForecastComponent } from '../hist-forecast/hist-forecast.component';

const routes: Routes = [
  { path: '', redirectTo: '/query', pathMatch: 'full' },
  { path: 'query', component: QueryComponent  },
  { path: 'forecast/:city/:period',   component: ForecastComponent },
  { path: 'hist-forecast/:id',   component: HistForecastComponent },
  { path: 'cities',   component: CitiesComponent },
  { path: 'history',  component: HistoryComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ],
  declarations: []
})
export class AppRoutingModule { }
