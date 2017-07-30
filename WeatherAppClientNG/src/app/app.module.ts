import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MdToolbarModule } from '@angular/material';

import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { QueryComponent } from './query/query.component';
import { CitiesComponent } from './cities/cities.component';
import { HistoryComponent } from './history/history.component';

@NgModule({
  declarations: [
    AppComponent,
    QueryComponent,
    CitiesComponent,
    HistoryComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: '',
        redirectTo: '/query',
        pathMatch: 'full'
      },
      {
        path: 'query',
        component: QueryComponent
      },
      {
        path: 'cities',
        component: CitiesComponent
      },
      {
        path: 'history',
        component: HistoryComponent
      }
    ]),
    MdToolbarModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
