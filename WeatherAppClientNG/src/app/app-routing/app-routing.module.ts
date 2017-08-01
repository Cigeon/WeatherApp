import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { QueryComponent } from '../query/query.component';
import { ForecastComponent } from '../forecast/forecast.component';
import { CitiesComponent } from '../cities/cities.component';
import { HistoryComponent } from '../history/history.component';

const routes: Routes = [
  { path: '', redirectTo: '/query', pathMatch: 'full' },
  { path: 'query',
    component: QueryComponent,
    // children: [
    //     {
    //       path: ':city/:period',
    //       component: ForecastComponent
    //     }
    //   ]
  },
  { path: 'forecast/:city/:period',   component: CitiesComponent },
  { path: 'cities',   component: CitiesComponent },
  { path: 'history',  component: HistoryComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ],
  declarations: []
})
export class AppRoutingModule { }
